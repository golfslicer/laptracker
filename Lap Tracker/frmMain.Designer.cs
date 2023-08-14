namespace Lap_Tracker {
    partial class frmMain {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.metroTile_Export = new MetroFramework.Controls.MetroTile();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pictureBox_Barcode = new System.Windows.Forms.PictureBox();
            this.metroComboBox_Cameras = new MetroFramework.Controls.MetroComboBox();
            this.metroButton_RefreshCameras = new MetroFramework.Controls.MetroButton();
            this.metroTile_StartRace = new MetroFramework.Controls.MetroTile();
            this.metroTile_StopRace = new MetroFramework.Controls.MetroTile();
            this.timer_CamRefresh = new System.Windows.Forms.Timer(this.components);
            this.metroTrackBar_LapDistance = new MetroFramework.Controls.MetroTrackBar();
            this.metroLabel_RaceDistance = new MetroFramework.Controls.MetroLabel();
            this.metroLabel_Distance = new MetroFramework.Controls.MetroLabel();
            this.metroTextBox_LapDistance = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Barcode)).BeginInit();
            this.SuspendLayout();
            // 
            // metroTile_Export
            // 
            this.metroTile_Export.Location = new System.Drawing.Point(297, 81);
            this.metroTile_Export.Name = "metroTile_Export";
            this.metroTile_Export.Size = new System.Drawing.Size(110, 76);
            this.metroTile_Export.Style = MetroFramework.MetroColorStyle.Purple;
            this.metroTile_Export.TabIndex = 8;
            this.metroTile_Export.Text = "Export";
            this.metroTile_Export.Click += new System.EventHandler(this.metroTile_Export_Click);
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.Location = new System.Drawing.Point(432, 81);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.Size = new System.Drawing.Size(444, 543);
            this.dataGridView1.TabIndex = 9;
            // 
            // pictureBox_Barcode
            // 
            this.pictureBox_Barcode.Location = new System.Drawing.Point(33, 292);
            this.pictureBox_Barcode.Name = "pictureBox_Barcode";
            this.pictureBox_Barcode.Size = new System.Drawing.Size(393, 270);
            this.pictureBox_Barcode.TabIndex = 10;
            this.pictureBox_Barcode.TabStop = false;
            // 
            // metroComboBox_Cameras
            // 
            this.metroComboBox_Cameras.FormattingEnabled = true;
            this.metroComboBox_Cameras.ItemHeight = 23;
            this.metroComboBox_Cameras.Location = new System.Drawing.Point(33, 568);
            this.metroComboBox_Cameras.Name = "metroComboBox_Cameras";
            this.metroComboBox_Cameras.Size = new System.Drawing.Size(290, 29);
            this.metroComboBox_Cameras.TabIndex = 12;
            // 
            // metroButton_RefreshCameras
            // 
            this.metroButton_RefreshCameras.Location = new System.Drawing.Point(329, 568);
            this.metroButton_RefreshCameras.Name = "metroButton_RefreshCameras";
            this.metroButton_RefreshCameras.Size = new System.Drawing.Size(97, 29);
            this.metroButton_RefreshCameras.TabIndex = 13;
            this.metroButton_RefreshCameras.Text = "Refresh Cameras";
            // 
            // metroTile_StartRace
            // 
            this.metroTile_StartRace.Location = new System.Drawing.Point(33, 81);
            this.metroTile_StartRace.Name = "metroTile_StartRace";
            this.metroTile_StartRace.Size = new System.Drawing.Size(110, 76);
            this.metroTile_StartRace.Style = MetroFramework.MetroColorStyle.Green;
            this.metroTile_StartRace.TabIndex = 14;
            this.metroTile_StartRace.Text = "Start Race";
            this.metroTile_StartRace.Click += new System.EventHandler(this.metroTile_StartRace_Click);
            // 
            // metroTile_StopRace
            // 
            this.metroTile_StopRace.Location = new System.Drawing.Point(164, 81);
            this.metroTile_StopRace.Name = "metroTile_StopRace";
            this.metroTile_StopRace.Size = new System.Drawing.Size(110, 76);
            this.metroTile_StopRace.Style = MetroFramework.MetroColorStyle.Red;
            this.metroTile_StopRace.TabIndex = 15;
            this.metroTile_StopRace.Text = "Stop Race";
            this.metroTile_StopRace.Click += new System.EventHandler(this.metroTile_StopRace_Click);
            // 
            // timer_CamRefresh
            // 
            this.timer_CamRefresh.Tick += new System.EventHandler(this.timer_CamRefresh_Tick);
            // 
            // metroTrackBar_LapDistance
            // 
            this.metroTrackBar_LapDistance.BackColor = System.Drawing.Color.Transparent;
            this.metroTrackBar_LapDistance.Location = new System.Drawing.Point(33, 192);
            this.metroTrackBar_LapDistance.Maximum = 3000;
            this.metroTrackBar_LapDistance.Name = "metroTrackBar_LapDistance";
            this.metroTrackBar_LapDistance.Size = new System.Drawing.Size(374, 23);
            this.metroTrackBar_LapDistance.SmallChange = 5;
            this.metroTrackBar_LapDistance.TabIndex = 16;
            this.metroTrackBar_LapDistance.Value = 0;
            this.metroTrackBar_LapDistance.Scroll += new System.Windows.Forms.ScrollEventHandler(this.metroTrackBar_LapDistance_Scroll);
            // 
            // metroLabel_RaceDistance
            // 
            this.metroLabel_RaceDistance.AutoSize = true;
            this.metroLabel_RaceDistance.Location = new System.Drawing.Point(33, 171);
            this.metroLabel_RaceDistance.Name = "metroLabel_RaceDistance";
            this.metroLabel_RaceDistance.Size = new System.Drawing.Size(89, 19);
            this.metroLabel_RaceDistance.TabIndex = 17;
            this.metroLabel_RaceDistance.Text = "Lap Distance: ";
            // 
            // metroLabel_Distance
            // 
            this.metroLabel_Distance.AutoSize = true;
            this.metroLabel_Distance.Location = new System.Drawing.Point(196, 171);
            this.metroLabel_Distance.Name = "metroLabel_Distance";
            this.metroLabel_Distance.Size = new System.Drawing.Size(49, 19);
            this.metroLabel_Distance.TabIndex = 18;
            this.metroLabel_Distance.Text = "Meters";
            this.metroLabel_Distance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // metroTextBox_LapDistance
            // 
            this.metroTextBox_LapDistance.Location = new System.Drawing.Point(115, 170);
            this.metroTextBox_LapDistance.Name = "metroTextBox_LapDistance";
            this.metroTextBox_LapDistance.Size = new System.Drawing.Size(75, 23);
            this.metroTextBox_LapDistance.TabIndex = 19;
            this.metroTextBox_LapDistance.Text = "0";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(33, 605);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(365, 19);
            this.metroLabel1.TabIndex = 20;
            this.metroLabel1.Text = "Built by Chris Scott for Living Waters Lutheran College - 2023";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 638);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroTextBox_LapDistance);
            this.Controls.Add(this.metroLabel_Distance);
            this.Controls.Add(this.metroLabel_RaceDistance);
            this.Controls.Add(this.metroTrackBar_LapDistance);
            this.Controls.Add(this.metroTile_StopRace);
            this.Controls.Add(this.metroTile_StartRace);
            this.Controls.Add(this.metroButton_RefreshCameras);
            this.Controls.Add(this.metroComboBox_Cameras);
            this.Controls.Add(this.pictureBox_Barcode);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.metroTile_Export);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Resizable = false;
            this.Text = "QR Lap Timer";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Barcode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroTile metroTile_Export;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox pictureBox_Barcode;
        private MetroFramework.Controls.MetroComboBox metroComboBox_Cameras;
        private MetroFramework.Controls.MetroButton metroButton_RefreshCameras;
        private MetroFramework.Controls.MetroTile metroTile_StartRace;
        private MetroFramework.Controls.MetroTile metroTile_StopRace;
        private System.Windows.Forms.Timer timer_CamRefresh;
        private MetroFramework.Controls.MetroTrackBar metroTrackBar_LapDistance;
        private MetroFramework.Controls.MetroLabel metroLabel_RaceDistance;
        private MetroFramework.Controls.MetroLabel metroLabel_Distance;
        private MetroFramework.Controls.MetroTextBox metroTextBox_LapDistance;
        private MetroFramework.Controls.MetroLabel metroLabel1;
    }
}

