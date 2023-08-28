using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using ZXing.Aztec;
using System.Threading;
using System.IO;
using System.Media;

namespace Lap_Tracker {
    public partial class frmMain : MetroFramework.Forms.MetroForm {
        private FilterInfoCollection captureDevice;
        private VideoCaptureDevice finalFrame;

        DateTime lastScanTime;
        String lastScanCode;
        DataTable currentRaceDataTable = new DataTable();
        DataSet currentRaceDataSet;
        int lapDistance = 0;
        bool exported = false;
        bool imported = false;
        bool lapSound = false;

        public frmMain() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            //this function sets up the form and program.
            try {
                refreshCameras();
                metroComboBox_Cameras.SelectedIndex = 0;
                finalFrame = new VideoCaptureDevice();

                //configure distance textbox to only allow numbers
                metroTextBox_LapDistance.KeyPress += new KeyPressEventHandler(metroTextBox_LapDistance_Change);

                this.FormClosing += new FormClosingEventHandler(Form1_Closing);

                metroTile_ImportExport.Text = "Import";

                //configure DataTable
                setupRaceDataTable();
            } catch (Exception ex) {
                MessageBox.Show("Error in Form1_Load. Error Message: " + ex.Message);
            }
        }

        private void Form1_Closing(object sender, FormClosingEventArgs e) {
            //this function runs when the program is exiting and asks whether to save.
            try {
                finalFrame.Stop();
                if (exported == false) {
                    //we haven't saved. Check they want to exit. 
                    DialogResult closingWithOutSave = MessageBox.Show("Are you sure you want to close without exporting the results?", "WARNING", MessageBoxButtons.YesNo);
                    if (closingWithOutSave == DialogResult.Yes) {
                        //close without saving
                        exported = true;
                        this.Close();
                    } else if (closingWithOutSave == DialogResult.No) {
                        exportData();
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show("Error in Form1_Closing. Error Message: " + ex.Message);
            }
        }

        private void refreshCameras() {
            //this function adds the names of camera devices to the dropdown list
            try {
                captureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                foreach (FilterInfo cam in captureDevice) {
                    metroComboBox_Cameras.Items.Add(cam.Name);
                }
            } catch (Exception ex) {
                MessageBox.Show("Error in refreshCameras. Error Message: " + ex.Message);
            }
        }

        private void metroTile_StartRace_Click(object sender, EventArgs e) {
            //this function starts the race.
            startRace();
        }

        private void finalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs) {
            //Set pictureBox immage to current image from webcam.
            try {
                pictureBox_Barcode.Image = (Bitmap)eventArgs.Frame.Clone();
            } catch (Exception ex) {
                MessageBox.Show("Error in finalFrame_NewFrame. Error Message: " + ex.Message);
            }
        }

        private void timer_CamRefresh_Tick(object sender, EventArgs e) {
            //This function configures the timer to update the picture box and sets the last scanned code.
            try { 
                BarcodeReader qrReader = new BarcodeReader();

                if (pictureBox_Barcode.Image == null) {
                    timer_CamRefresh.Enabled = false;
                    stopRace();
                    MessageBox.Show("There may be an issue with the camera. Please try to stop the race. If this doesn't work, close the app, disconnect then reconnect the camera and try again.");         
                    return; 
                }

                Result result = qrReader.Decode((Bitmap)pictureBox_Barcode.Image);
            
                if (result == null) { return; }

                string decoded = result.ToString().Trim();
                if (decoded != "") {
                    //check if last scan time was within 10 seconds and the same racer
                    DateTime now = DateTime.Now;
                    TimeSpan timeDifference = now.Subtract(lastScanTime);

                    if ((decoded == lastScanCode && timeDifference.TotalSeconds > 10) || (decoded != lastScanCode)) {
                        //set last scan time
                        lastScanTime = DateTime.Now;

                        //set last scan code
                        lastScanCode = decoded;

                        //record lap
                        recordLap(decoded);
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show("Error in timer_CamRefresh_Ticker. Error Message: " + ex.Message);
            }
        }

        private void metroTile_StopRace_Click(object sender, EventArgs e) {
            //this function stops the race.
            stopRace();
        }

        private void setupRaceDataTable() {
            //this function configures the datatable.
            try {
                currentRaceDataTable = new DataTable("currentRaceData");
                DataColumn dtColumn;
                DataRow dtRow;

                //configure Name
                dtColumn = new DataColumn();
                dtColumn.DataType = typeof(String);
                dtColumn.ColumnName = "Name";
                dtColumn.Caption = "Racer Name";
                dtColumn.ReadOnly = false;
                dtColumn.Unique = false;
                currentRaceDataTable.Columns.Add(dtColumn);

                //configure Laps
                dtColumn = new DataColumn();
                dtColumn.DataType = typeof(int);
                dtColumn.ColumnName = "Laps";
                dtColumn.Caption = "Total Laps";
                dtColumn.ReadOnly = false;
                dtColumn.Unique = false;
                currentRaceDataTable.Columns.Add(dtColumn);

                //configure Distance
                dtColumn = new DataColumn();
                dtColumn.DataType = typeof(int);
                dtColumn.ColumnName = "Distance";
                dtColumn.Caption = "Total Distance";
                dtColumn.ReadOnly = false;
                dtColumn.Unique = false;
                currentRaceDataTable.Columns.Add(dtColumn);

                currentRaceDataSet = new DataSet();
                currentRaceDataSet.Tables.Add(currentRaceDataTable);
            } catch (Exception ex) {
                MessageBox.Show("Error in setupRaceDataTable. Error Message: " + ex.Message);
            }
        }

        private void bindData() {
            //this function binds the datatable to the datagrid.
            try {
                BindingSource bs = new BindingSource();
                bs.DataSource = currentRaceDataSet.Tables["currentRaceData"];

                dataGridView1.DataSource = bs;
            } catch (Exception ex) {
                MessageBox.Show("Error in bindData. Error Message: " + ex.Message);
            }
        }

        private void recordLap(string racerName) {
            //this function records a lap against the racerName decoded from the QR Code.
            try {
                //log lap to dataset

                //get total laps for rider
                int riderLaps = getCurrentLaps(racerName) + 1;

                //get total distance for rider
                int riderDistance = getCurrentDistance(racerName) + lapDistance;

                //check if rider already in table and only update else create record
                if (getRiderExists(racerName)) {
                    //Update row for existing rider
                    foreach (DataRow row in currentRaceDataTable.Rows) {
                        if (row[0].ToString() == racerName) {
                            row[1] = riderLaps;
                            row[2] = riderDistance;
                        }
                    }
                } else {
                    //Add row to datatable for new rider
                    DataRow dr = currentRaceDataTable.NewRow();
                    dr[0] = racerName;
                    dr[1] = riderLaps;
                    dr[2] = riderDistance;

                    currentRaceDataTable.Rows.Add(dr);
                }

                if (lapSound == true) {
                    //play sound
                    SystemSounds.Exclamation.Play();
                }

                //refresh datagridview
                dataGridView1.Refresh();
            } catch (Exception ex) {
                MessageBox.Show("Error in recordLap. Error Message: " + ex.Message);
            }

        }

        private int getCurrentLaps(string racerName) {
            //this function will get the current laps for the racer
            int ret = 0;
            try {
                DataRow[] result = currentRaceDataTable.Select("Name = '" + racerName.ToString() + "'");
                foreach (DataRow row in result) {
                    ret = int.TryParse(row[1].ToString(), out ret) ? ret : 0;
                }
            } catch (Exception ex) {
                MessageBox.Show("Error in getCurrentLaps. Error Message: " + ex.Message);
            }
            return ret;
        }

        private int getCurrentDistance(string racerName) {
            //this function will get the current total distance for the racer
            int ret = 0;
            try {
                DataRow[] result = currentRaceDataTable.Select("Name = '" + racerName.ToString() + "'");
                foreach (DataRow row in result) {
                    ret = int.TryParse(row[2].ToString(), out ret) ? ret : 0;
                }
            } catch (Exception ex) {
                MessageBox.Show("Error in getCurrentDistance. Error Message: " + ex.Message);
            }
            return ret;
        }

        private bool getRiderExists(string racerName) {
            //this function will return the index in the datatable for a rider if exists.
            try {
                DataRow[] result = currentRaceDataTable.Select("Name = '" + racerName + "'");
                if (result.Length > 0) {
                    foreach (DataRow row in result) {
                        if (row[0].ToString() == racerName) {
                            //We have a match
                            return true;
                        } else {
                            return false;
                        }
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show("Error in getRiderExists. Error Message: " + ex.Message);
            }
            return false;
        }

        private void metroTrackBar_LapDistance_Scroll(object sender, ScrollEventArgs e) {
            //this function adjusts the lap distance based on the slider value.
            lapDistance = metroTrackBar_LapDistance.Value;
            metroTextBox_LapDistance.Text = lapDistance.ToString();
        }

        private void metroTile_Export_Click(object sender, EventArgs e) {
            //this function checks whether to import or export.
            if (metroTile_ImportExport.Text == "Import") {
                importData();
            } else if (metroTile_ImportExport.Text == "Export") {
                exportData();
            }
        }

        private void exportData() {
            //this function exports the datatable to a csv file ready for reimporting later.
            try {
                //get file path to export
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "csv files (*.csv)|*.csv";
                saveFile.RestoreDirectory = true;

                if (saveFile.ShowDialog() == DialogResult.OK) {

                    System.IO.StreamWriter sw = new StreamWriter(saveFile.FileName, false);
                    //headers    
                    for (int i = 0; i < currentRaceDataTable.Columns.Count; i++) {
                        sw.Write(currentRaceDataTable.Columns[i]);
                        if (i < currentRaceDataTable.Columns.Count - 1) {
                            sw.Write(",");
                        }
                    }
                    sw.Write(sw.NewLine);
                    foreach (DataRow dr in currentRaceDataTable.Rows) {
                        for (int i = 0; i < currentRaceDataTable.Columns.Count; i++) {
                            if (!Convert.IsDBNull(dr[i])) {
                                string value = dr[i].ToString();
                                if (value.Contains(',')) {
                                    value = String.Format("\"{0}\"", value);
                                    sw.Write(value);
                                } else {
                                    sw.Write(dr[i].ToString());
                                }
                            }
                            if (i < currentRaceDataTable.Columns.Count - 1) {
                                sw.Write(",");
                            }
                        }
                        sw.Write(sw.NewLine);
                    }
                    sw.Close();
                    exported = true;
                }
            } catch (Exception ex) {
                MessageBox.Show("Error in exportData. Error Message: " +  ex.Message);
            }
        }

        private void metroTextBox_LapDistance_Change(object sender, KeyPressEventArgs e) {
            //this function will check whether a number was entered into the distance text box. It also updates the lap distance slider and global distance variable.
            try {
                e.Handled = !char.IsDigit(e.KeyChar);
                int distance = int.TryParse(metroTextBox_LapDistance.Text.ToString(), out distance) ? distance : 0;
                metroTrackBar_LapDistance.Value = distance;
                lapDistance = distance;
            } catch (Exception ex) {
                MessageBox.Show("Error in metroTextBox_LapDistance_Change. Error Message: " + ex.Message);
            }
        }

        private void importData() {
            //this function will load a previously exported CSV into the datatable and refresh the data grid.
            try {
                //check if data already imported.
                if  (imported == true) {
                    //already imported. Check if we want to clear data and import again.
                    DialogResult reimportDialog = MessageBox.Show("You have already imported data. If you immport again, existing imported data will be overwritten?", "WARNING", MessageBoxButtons.YesNo);
                    if (reimportDialog == DialogResult.Yes) {
                        imported = true;
                        currentRaceDataTable.Clear();
                        dataGridView1.Refresh();

                    } else if (reimportDialog == DialogResult.No) {
                        return;
                    }
                }

                //get file path to import
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Filter = "csv files (*.csv)|*.csv";
                openFile.RestoreDirectory = true;

                //open file
                if (openFile.ShowDialog() == DialogResult.OK) {
                    System.IO.StreamReader sr = new StreamReader(openFile.FileName, false);
                    //we will read the first row which will contain headers.
                    string[] headers = sr.ReadLine().Split(',');
                    while (!sr.EndOfStream) {
                        //now iterate through each row and add it to the datatable.
                        string[] rows = sr.ReadLine().Split(',');
                        DataRow dr = currentRaceDataTable.NewRow();
                        for (int i = 0; i < headers.Length; i++) {
                            dr[i] = rows[i];
                        }
                        currentRaceDataTable.Rows.Add(dr);
                    }
                    imported = true;

                    bindData();

                    //refresh the dataGridView.
                    dataGridView1.Refresh();
                }
            } catch (Exception ex) {
                MessageBox.Show("Error in importData. Error Message: " + ex.Message);
            }
        }

        private void stopRace() {
            //this function frees up the camera resource and stops the race.
            try {
                timer_CamRefresh.Enabled = false;
                timer_CamRefresh.Stop();
                finalFrame.Stop();
                metroTile_StopRace.Enabled = false;
                metroTrackBar_LapDistance.Enabled = true;
            } catch (Exception ex) {
                MessageBox.Show("Error in stopRace. Error Message: " + ex.Message);
            }
        }

        private void startRace() {
            //this function will kick off the camera process, setup the datagrid and enable the timer
            try {
                //setup Video Capture
                finalFrame = new VideoCaptureDevice(captureDevice[metroComboBox_Cameras.SelectedIndex].MonikerString);
                finalFrame.NewFrame += new NewFrameEventHandler(finalFrame_NewFrame);
                finalFrame.Start();

                //setup DataGrid
                bindData();

                //configure start/stop buttons.
                metroTile_StopRace.Enabled = true;
                metroTrackBar_LapDistance.Enabled = false;
                metroTile_ImportExport.Text = "Export";

                //Pause for 4 seconds to allow camera feed to start.
                Thread.Sleep(4000);

                //Enable timer so scanning can commence.
                timer_CamRefresh.Enabled = true;
                timer_CamRefresh.Start();
            } catch (Exception ex) {
                MessageBox.Show("Error in startRace. Error Message: " + ex.Message);
            }
        }

        private void metroToggle_Sound_CheckedChanged(object sender, EventArgs e) {
            //this function is invoked when the sound toggle is changed and updates whether a tone will play.
            if (metroToggle_Sound.Checked == true) {
                lapSound = true;
            } else if (metroToggle_Sound.Checked == false) {
                lapSound = false;
            }
        }
    }
}
