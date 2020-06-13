namespace Hide_and_Seek
{
    partial class Game
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.time_elapsed = new System.Windows.Forms.Label();
            this.roomName = new System.Windows.Forms.Label();
            this.timerRoom = new System.Windows.Forms.Timer(this.components);
            this.timerHall = new System.Windows.Forms.Timer(this.components);
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.Log = new System.Windows.Forms.DataGridView();
            this.hiderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roomDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountOfSecondsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.verstopperLogBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.verstoppertjeDatabaseDataSet1 = new Hide_and_Seek.VerstoppertjeDatabaseDataSet1();
            this.verstopperLogBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.verstoppertjeDatabaseDataSet = new Hide_and_Seek.VerstoppertjeDatabaseDataSet();
            this.verstopperLogTableAdapter = new Hide_and_Seek.VerstoppertjeDatabaseDataSetTableAdapters.VerstopperLogTableAdapter();
            this.buttonBathroom = new System.Windows.Forms.Button();
            this.buttonBedroom = new System.Windows.Forms.Button();
            this.buttonHallway = new System.Windows.Forms.Button();
            this.buttonKitchen = new System.Windows.Forms.Button();
            this.buttonLivingroom = new System.Windows.Forms.Button();
            this.buttonToilet = new System.Windows.Forms.Button();
            this.labelWin = new System.Windows.Forms.Label();
            this.pictureBoxLoser = new System.Windows.Forms.PictureBox();
            this.pictureBoxWin = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelLoos = new System.Windows.Forms.Label();
            this.labelAgain = new System.Windows.Forms.Label();
            this.verstopperLogTableAdapter1 = new Hide_and_Seek.VerstoppertjeDatabaseDataSet1TableAdapters.VerstopperLogTableAdapter();
            this.verstoppertjeDatabaseDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Log)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.verstopperLogBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.verstoppertjeDatabaseDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.verstopperLogBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.verstoppertjeDatabaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.verstoppertjeDatabaseDataSet1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 508);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hider is in room:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 558);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Time elapsed:";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // time_elapsed
            // 
            this.time_elapsed.AutoSize = true;
            this.time_elapsed.Location = new System.Drawing.Point(189, 558);
            this.time_elapsed.Name = "time_elapsed";
            this.time_elapsed.Size = new System.Drawing.Size(36, 17);
            this.time_elapsed.TabIndex = 3;
            this.time_elapsed.Text = "0:00";
            // 
            // roomName
            // 
            this.roomName.AutoSize = true;
            this.roomName.Location = new System.Drawing.Point(189, 508);
            this.roomName.Name = "roomName";
            this.roomName.Size = new System.Drawing.Size(135, 17);
            this.roomName.TabIndex = 5;
            this.roomName.Text = "Garden (Pre-Game)";
            // 
            // webBrowser1
            // 
            this.webBrowser1.AllowNavigation = false;
            this.webBrowser1.AllowWebBrowserDrop = false;
            this.webBrowser1.Location = new System.Drawing.Point(78, 30);
            this.webBrowser1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.ScrollBarsEnabled = false;
            this.webBrowser1.Size = new System.Drawing.Size(684, 423);
            this.webBrowser1.TabIndex = 6;
            this.webBrowser1.TabStop = false;
            this.webBrowser1.Url = new System.Uri("http://localhost:8080/#/Floorplans", System.UriKind.Absolute);
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // Log
            // 
            this.Log.AllowUserToDeleteRows = false;
            this.Log.AutoGenerateColumns = false;
            this.Log.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Log.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.hiderDataGridViewTextBoxColumn,
            this.roomDataGridViewTextBoxColumn,
            this.amountOfSecondsDataGridViewTextBoxColumn});
            this.Log.DataSource = this.verstopperLogBindingSource;
            this.Log.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.Log.Location = new System.Drawing.Point(786, 94);
            this.Log.Name = "Log";
            this.Log.ReadOnly = true;
            this.Log.RowHeadersWidth = 51;
            this.Log.RowTemplate.Height = 24;
            this.Log.Size = new System.Drawing.Size(586, 302);
            this.Log.TabIndex = 7;
            // 
            // hiderDataGridViewTextBoxColumn
            // 
            this.hiderDataGridViewTextBoxColumn.DataPropertyName = "Hider";
            this.hiderDataGridViewTextBoxColumn.HeaderText = "Hider";
            this.hiderDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.hiderDataGridViewTextBoxColumn.Name = "hiderDataGridViewTextBoxColumn";
            this.hiderDataGridViewTextBoxColumn.Width = 125;
            // 
            // roomDataGridViewTextBoxColumn
            // 
            this.roomDataGridViewTextBoxColumn.DataPropertyName = "Room";
            this.roomDataGridViewTextBoxColumn.HeaderText = "Room";
            this.roomDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.roomDataGridViewTextBoxColumn.Name = "roomDataGridViewTextBoxColumn";
            this.roomDataGridViewTextBoxColumn.Width = 125;
            // 
            // amountOfSecondsDataGridViewTextBoxColumn
            // 
            this.amountOfSecondsDataGridViewTextBoxColumn.DataPropertyName = "AmountOfSeconds";
            this.amountOfSecondsDataGridViewTextBoxColumn.HeaderText = "AmountOfSeconds";
            this.amountOfSecondsDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.amountOfSecondsDataGridViewTextBoxColumn.Name = "amountOfSecondsDataGridViewTextBoxColumn";
            this.amountOfSecondsDataGridViewTextBoxColumn.Width = 125;
            // 
            // verstopperLogBindingSource1
            // 
            this.verstopperLogBindingSource1.DataMember = "VerstopperLog";
            this.verstopperLogBindingSource1.DataSource = this.verstoppertjeDatabaseDataSet1;
            // 
            // verstoppertjeDatabaseDataSet1
            // 
            this.verstoppertjeDatabaseDataSet1.DataSetName = "VerstoppertjeDatabaseDataSet1";
            this.verstoppertjeDatabaseDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // verstopperLogBindingSource
            // 
            this.verstopperLogBindingSource.DataMember = "VerstopperLog";
            this.verstopperLogBindingSource.DataSource = this.verstoppertjeDatabaseDataSet;
            // 
            // verstoppertjeDatabaseDataSet
            // 
            this.verstoppertjeDatabaseDataSet.DataSetName = "VerstoppertjeDatabaseDataSet";
            this.verstoppertjeDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // verstopperLogTableAdapter
            // 
            this.verstopperLogTableAdapter.ClearBeforeFill = true;
            // 
            // buttonBathroom
            // 
            this.buttonBathroom.Location = new System.Drawing.Point(192, 123);
            this.buttonBathroom.Name = "buttonBathroom";
            this.buttonBathroom.Size = new System.Drawing.Size(109, 23);
            this.buttonBathroom.TabIndex = 8;
            this.buttonBathroom.Text = "Bathroom";
            this.buttonBathroom.UseVisualStyleBackColor = true;
            this.buttonBathroom.Visible = false;
            this.buttonBathroom.Click += new System.EventHandler(this.buttonBathroom_Click);
            // 
            // buttonBedroom
            // 
            this.buttonBedroom.Location = new System.Drawing.Point(192, 283);
            this.buttonBedroom.Name = "buttonBedroom";
            this.buttonBedroom.Size = new System.Drawing.Size(109, 28);
            this.buttonBedroom.TabIndex = 9;
            this.buttonBedroom.Text = "Bedroom";
            this.buttonBedroom.UseVisualStyleBackColor = true;
            this.buttonBedroom.Visible = false;
            this.buttonBedroom.Click += new System.EventHandler(this.buttonBedroom_Click);
            // 
            // buttonHallway
            // 
            this.buttonHallway.Location = new System.Drawing.Point(410, 170);
            this.buttonHallway.Name = "buttonHallway";
            this.buttonHallway.Size = new System.Drawing.Size(75, 27);
            this.buttonHallway.TabIndex = 10;
            this.buttonHallway.Text = "Hallway";
            this.buttonHallway.UseVisualStyleBackColor = true;
            this.buttonHallway.Visible = false;
            this.buttonHallway.Click += new System.EventHandler(this.buttonHallway_Click);
            // 
            // buttonKitchen
            // 
            this.buttonKitchen.Location = new System.Drawing.Point(543, 300);
            this.buttonKitchen.Name = "buttonKitchen";
            this.buttonKitchen.Size = new System.Drawing.Size(117, 28);
            this.buttonKitchen.TabIndex = 11;
            this.buttonKitchen.Text = "Kitchen";
            this.buttonKitchen.UseVisualStyleBackColor = true;
            this.buttonKitchen.Visible = false;
            this.buttonKitchen.Click += new System.EventHandler(this.buttonKitchen_Click);
            // 
            // buttonLivingroom
            // 
            this.buttonLivingroom.Location = new System.Drawing.Point(543, 141);
            this.buttonLivingroom.Name = "buttonLivingroom";
            this.buttonLivingroom.Size = new System.Drawing.Size(117, 30);
            this.buttonLivingroom.TabIndex = 12;
            this.buttonLivingroom.Text = "Livingroom";
            this.buttonLivingroom.UseVisualStyleBackColor = true;
            this.buttonLivingroom.Visible = false;
            this.buttonLivingroom.Click += new System.EventHandler(this.buttonLivingroom_Click);
            // 
            // buttonToilet
            // 
            this.buttonToilet.Location = new System.Drawing.Point(516, 249);
            this.buttonToilet.Name = "buttonToilet";
            this.buttonToilet.Size = new System.Drawing.Size(75, 23);
            this.buttonToilet.TabIndex = 13;
            this.buttonToilet.Text = "Toilet";
            this.buttonToilet.UseVisualStyleBackColor = true;
            this.buttonToilet.Visible = false;
            this.buttonToilet.Click += new System.EventHandler(this.buttonToilet_Click);
            // 
            // labelWin
            // 
            this.labelWin.AutoSize = true;
            this.labelWin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.labelWin.Location = new System.Drawing.Point(928, 501);
            this.labelWin.Name = "labelWin";
            this.labelWin.Size = new System.Drawing.Size(208, 25);
            this.labelWin.TabIndex = 16;
            this.labelWin.Text = "YOU WIN THE GAME";
            this.labelWin.Visible = false;
            // 
            // pictureBoxLoser
            // 
            this.pictureBoxLoser.Image = global::Hide_and_Seek.Properties.Resources.LOSER;
            this.pictureBoxLoser.Location = new System.Drawing.Point(78, 30);
            this.pictureBoxLoser.Name = "pictureBoxLoser";
            this.pictureBoxLoser.Size = new System.Drawing.Size(684, 423);
            this.pictureBoxLoser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLoser.TabIndex = 17;
            this.pictureBoxLoser.TabStop = false;
            this.pictureBoxLoser.Visible = false;
            // 
            // pictureBoxWin
            // 
            this.pictureBoxWin.Image = global::Hide_and_Seek.Properties.Resources.WINNER;
            this.pictureBoxWin.Location = new System.Drawing.Point(78, 30);
            this.pictureBoxWin.Name = "pictureBoxWin";
            this.pictureBoxWin.Size = new System.Drawing.Size(684, 423);
            this.pictureBoxWin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxWin.TabIndex = 14;
            this.pictureBoxWin.TabStop = false;
            this.pictureBoxWin.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Hide_and_Seek.Properties.Resources.Floorplan_with_names;
            this.pictureBox1.Location = new System.Drawing.Point(78, 30);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(684, 423);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // labelLoos
            // 
            this.labelLoos.AutoSize = true;
            this.labelLoos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLoos.ForeColor = System.Drawing.Color.Red;
            this.labelLoos.Location = new System.Drawing.Point(913, 526);
            this.labelLoos.Name = "labelLoos";
            this.labelLoos.Size = new System.Drawing.Size(223, 25);
            this.labelLoos.TabIndex = 18;
            this.labelLoos.Text = "YOU LOST THE GAME";
            this.labelLoos.Visible = false;
            // 
            // labelAgain
            // 
            this.labelAgain.AutoSize = true;
            this.labelAgain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAgain.Location = new System.Drawing.Point(966, 476);
            this.labelAgain.Name = "labelAgain";
            this.labelAgain.Size = new System.Drawing.Size(124, 25);
            this.labelAgain.TabIndex = 19;
            this.labelAgain.Text = "TRY AGAIN!";
            this.labelAgain.Visible = false;
            // 
            // verstopperLogTableAdapter1
            // 
            this.verstopperLogTableAdapter1.ClearBeforeFill = true;
            // 
            // verstoppertjeDatabaseDataSet1BindingSource
            // 
            this.verstoppertjeDatabaseDataSet1BindingSource.DataSource = this.verstoppertjeDatabaseDataSet1;
            this.verstoppertjeDatabaseDataSet1BindingSource.Position = 0;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1401, 672);
            this.Controls.Add(this.labelAgain);
            this.Controls.Add(this.labelLoos);
            this.Controls.Add(this.pictureBoxLoser);
            this.Controls.Add(this.labelWin);
            this.Controls.Add(this.pictureBoxWin);
            this.Controls.Add(this.buttonToilet);
            this.Controls.Add(this.buttonLivingroom);
            this.Controls.Add(this.buttonKitchen);
            this.Controls.Add(this.buttonHallway);
            this.Controls.Add(this.buttonBedroom);
            this.Controls.Add(this.buttonBathroom);
            this.Controls.Add(this.Log);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.roomName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.time_elapsed);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Game";
            this.Text = "Game";
            this.Load += new System.EventHandler(this.Game_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Log)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.verstopperLogBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.verstoppertjeDatabaseDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.verstopperLogBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.verstoppertjeDatabaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.verstoppertjeDatabaseDataSet1BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label time_elapsed;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label roomName;
        private System.Windows.Forms.Timer timerRoom;
        private System.Windows.Forms.Timer timerHall;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.DataGridView Log;
        private VerstoppertjeDatabaseDataSet verstoppertjeDatabaseDataSet;
        private System.Windows.Forms.BindingSource verstopperLogBindingSource;
        private VerstoppertjeDatabaseDataSetTableAdapters.VerstopperLogTableAdapter verstopperLogTableAdapter;
        private System.Windows.Forms.Button buttonBathroom;
        private System.Windows.Forms.Button buttonBedroom;
        private System.Windows.Forms.Button buttonHallway;
        private System.Windows.Forms.Button buttonKitchen;
        private System.Windows.Forms.Button buttonLivingroom;
        private System.Windows.Forms.Button buttonToilet;
        private System.Windows.Forms.PictureBox pictureBoxWin;
        private System.Windows.Forms.Label labelWin;
        private System.Windows.Forms.PictureBox pictureBoxLoser;
        private System.Windows.Forms.Label labelLoos;
        private System.Windows.Forms.Label labelAgain;
        private VerstoppertjeDatabaseDataSet1 verstoppertjeDatabaseDataSet1;
        private System.Windows.Forms.BindingSource verstopperLogBindingSource1;
        private VerstoppertjeDatabaseDataSet1TableAdapters.VerstopperLogTableAdapter verstopperLogTableAdapter1;
        private System.Windows.Forms.BindingSource verstoppertjeDatabaseDataSet1BindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn hiderDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn roomDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountOfSecondsDataGridViewTextBoxColumn;
    }
}