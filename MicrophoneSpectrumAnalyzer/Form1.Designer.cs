namespace MicrophoneSpectrumAnalyzer
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbRecordingSource = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbBackgroundSource = new System.Windows.Forms.ComboBox();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblColorToRemove = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbSpectrumMode = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbSpectrumVisualizer = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNumLines = new System.Windows.Forms.NumericUpDown();
            this.horizontalSpectrumVisualizer1 = new MicrophoneSpectrumAnalyzer.AudioSpectrumVisualizers.HorizontalSpectrumVisualizer();
            this.circleSpectrumVisualizer1 = new MicrophoneSpectrumAnalyzer.AudioSpectrumVisualizers.CircleSpectrumVisualizer();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label7 = new System.Windows.Forms.Label();
            this.txtKeyColor = new System.Windows.Forms.TextBox();
            this.btnKeyColor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumLines)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbRecordingSource
            // 
            this.cmbRecordingSource.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRecordingSource.FormattingEnabled = true;
            this.cmbRecordingSource.Location = new System.Drawing.Point(8, 85);
            this.cmbRecordingSource.Margin = new System.Windows.Forms.Padding(2);
            this.cmbRecordingSource.Name = "cmbRecordingSource";
            this.cmbRecordingSource.Size = new System.Drawing.Size(207, 27);
            this.cmbRecordingSource.TabIndex = 0;
            this.cmbRecordingSource.SelectedIndexChanged += new System.EventHandler(this.CmbRecordingSource_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 67);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Audio input device :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(239, 67);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Background source :";
            // 
            // cmbBackgroundSource
            // 
            this.cmbBackgroundSource.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBackgroundSource.FormattingEnabled = true;
            this.cmbBackgroundSource.Items.AddRange(new object[] {
            "None (transparent)",
            "Color",
            "Image / Animated gif",
            "Video"});
            this.cmbBackgroundSource.Location = new System.Drawing.Point(243, 85);
            this.cmbBackgroundSource.Margin = new System.Windows.Forms.Padding(2);
            this.cmbBackgroundSource.Name = "cmbBackgroundSource";
            this.cmbBackgroundSource.Size = new System.Drawing.Size(206, 27);
            this.cmbBackgroundSource.TabIndex = 3;
            this.cmbBackgroundSource.SelectedIndexChanged += new System.EventHandler(this.CmbBackgroundSource_SelectedIndexChanged);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Enabled = false;
            this.txtFilePath.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilePath.Location = new System.Drawing.Point(9, 142);
            this.txtFilePath.Margin = new System.Windows.Forms.Padding(2);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(564, 27);
            this.txtFilePath.TabIndex = 5;
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilePath.Location = new System.Drawing.Point(6, 123);
            this.lblFilePath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(203, 17);
            this.lblFilePath.TabIndex = 6;
            this.lblFilePath.Text = "File path to display as background :";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(576, 141);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(2);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(110, 29);
            this.btnBrowse.TabIndex = 7;
            this.btnBrowse.Text = "&Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lblColorToRemove
            // 
            this.lblColorToRemove.AutoSize = true;
            this.lblColorToRemove.Location = new System.Drawing.Point(8, 171);
            this.lblColorToRemove.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblColorToRemove.Name = "lblColorToRemove";
            this.lblColorToRemove.Size = new System.Drawing.Size(178, 13);
            this.lblColorToRemove.TabIndex = 8;
            this.lblColorToRemove.Text = "The key color to remove is #00b140";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Spectrum mode :";
            // 
            // cmbSpectrumMode
            // 
            this.cmbSpectrumMode.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSpectrumMode.FormattingEnabled = true;
            this.cmbSpectrumMode.Items.AddRange(new object[] {
            "Fast Fourier Transform (FFT)",
            "Amplitude"});
            this.cmbSpectrumMode.Location = new System.Drawing.Point(8, 28);
            this.cmbSpectrumMode.Margin = new System.Windows.Forms.Padding(2);
            this.cmbSpectrumMode.Name = "cmbSpectrumMode";
            this.cmbSpectrumMode.Size = new System.Drawing.Size(207, 27);
            this.cmbSpectrumMode.TabIndex = 9;
            this.cmbSpectrumMode.SelectedIndexChanged += new System.EventHandler(this.CmbSpectrumMode_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(240, 9);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Spectrum visualizer :";
            // 
            // cmbSpectrumVisualizer
            // 
            this.cmbSpectrumVisualizer.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSpectrumVisualizer.FormattingEnabled = true;
            this.cmbSpectrumVisualizer.Items.AddRange(new object[] {
            "Circle bar",
            "Horizontal bar"});
            this.cmbSpectrumVisualizer.Location = new System.Drawing.Point(242, 28);
            this.cmbSpectrumVisualizer.Margin = new System.Windows.Forms.Padding(2);
            this.cmbSpectrumVisualizer.Name = "cmbSpectrumVisualizer";
            this.cmbSpectrumVisualizer.Size = new System.Drawing.Size(207, 27);
            this.cmbSpectrumVisualizer.TabIndex = 11;
            this.cmbSpectrumVisualizer.SelectedIndexChanged += new System.EventHandler(this.CmbSpectrumVisualizer_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(477, 7);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "Number of lines";
            // 
            // txtNumLines
            // 
            this.txtNumLines.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumLines.Location = new System.Drawing.Point(480, 28);
            this.txtNumLines.Margin = new System.Windows.Forms.Padding(2);
            this.txtNumLines.Maximum = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.txtNumLines.Name = "txtNumLines";
            this.txtNumLines.Size = new System.Drawing.Size(206, 27);
            this.txtNumLines.TabIndex = 15;
            this.txtNumLines.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.txtNumLines.ValueChanged += new System.EventHandler(this.TxtNumLines_ValueChanged);
            // 
            // horizontalSpectrumVisualizer1
            // 
            this.horizontalSpectrumVisualizer1.Location = new System.Drawing.Point(10, 263);
            this.horizontalSpectrumVisualizer1.Margin = new System.Windows.Forms.Padding(2);
            this.horizontalSpectrumVisualizer1.Name = "horizontalSpectrumVisualizer1";
            this.horizontalSpectrumVisualizer1.Size = new System.Drawing.Size(676, 280);
            this.horizontalSpectrumVisualizer1.TabIndex = 16;
            this.horizontalSpectrumVisualizer1.Text = "horizontalSpectrumVisualizer1";
            // 
            // circleSpectrumVisualizer1
            // 
            this.circleSpectrumVisualizer1.Img = null;
            this.circleSpectrumVisualizer1.Location = new System.Drawing.Point(115, 220);
            this.circleSpectrumVisualizer1.Margin = new System.Windows.Forms.Padding(2);
            this.circleSpectrumVisualizer1.Name = "circleSpectrumVisualizer1";
            this.circleSpectrumVisualizer1.Size = new System.Drawing.Size(470, 560);
            this.circleSpectrumVisualizer1.TabIndex = 2;
            this.circleSpectrumVisualizer1.Text = "circleSpectrumVisualizer1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(477, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Key color :";
            // 
            // txtKeyColor
            // 
            this.txtKeyColor.Location = new System.Drawing.Point(480, 85);
            this.txtKeyColor.MinimumSize = new System.Drawing.Size(119, 27);
            this.txtKeyColor.Name = "txtKeyColor";
            this.txtKeyColor.Size = new System.Drawing.Size(119, 27);
            this.txtKeyColor.TabIndex = 18;
            // 
            // btnKeyColor
            // 
            this.btnKeyColor.Location = new System.Drawing.Point(611, 85);
            this.btnKeyColor.Name = "btnKeyColor";
            this.btnKeyColor.Size = new System.Drawing.Size(75, 27);
            this.btnKeyColor.TabIndex = 19;
            this.btnKeyColor.Text = "Apply";
            this.btnKeyColor.UseVisualStyleBackColor = true;
            this.btnKeyColor.Click += new System.EventHandler(this.btnKeyColor_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(702, 790);
            this.Controls.Add(this.btnKeyColor);
            this.Controls.Add(this.txtKeyColor);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.horizontalSpectrumVisualizer1);
            this.Controls.Add(this.txtNumLines);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbSpectrumVisualizer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbSpectrumMode);
            this.Controls.Add(this.lblColorToRemove);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.lblFilePath);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbBackgroundSource);
            this.Controls.Add(this.circleSpectrumVisualizer1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbRecordingSource);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Microphone Spectrum Analyzer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtNumLines)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbRecordingSource;
        private System.Windows.Forms.Label label1;
        private AudioSpectrumVisualizers.CircleSpectrumVisualizer circleSpectrumVisualizer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbBackgroundSource;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblColorToRemove;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbSpectrumMode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbSpectrumVisualizer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown txtNumLines;
        private AudioSpectrumVisualizers.HorizontalSpectrumVisualizer horizontalSpectrumVisualizer1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtKeyColor;
        private System.Windows.Forms.Button btnKeyColor;
    }
}

