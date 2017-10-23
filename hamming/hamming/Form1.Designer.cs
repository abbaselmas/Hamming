namespace hamming
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.encoder = new System.Windows.Forms.Button();
            this.corrupt = new System.Windows.Forms.Button();
            this.decoder = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.browse = new System.Windows.Forms.Button();
            this.result = new System.Windows.Forms.RichTextBox();
            this.bitErrorRate = new System.Windows.Forms.TextBox();
            this.save = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.reset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // encoder
            // 
            this.encoder.Enabled = false;
            this.encoder.Location = new System.Drawing.Point(94, 13);
            this.encoder.Name = "encoder";
            this.encoder.Size = new System.Drawing.Size(75, 23);
            this.encoder.TabIndex = 0;
            this.encoder.Text = "Encoder";
            this.encoder.UseVisualStyleBackColor = true;
            this.encoder.Click += new System.EventHandler(this.encoder_Click);
            // 
            // corrupt
            // 
            this.corrupt.Enabled = false;
            this.corrupt.Location = new System.Drawing.Point(197, 42);
            this.corrupt.Name = "corrupt";
            this.corrupt.Size = new System.Drawing.Size(75, 23);
            this.corrupt.TabIndex = 1;
            this.corrupt.Text = "Corrupter";
            this.corrupt.UseVisualStyleBackColor = true;
            this.corrupt.Click += new System.EventHandler(this.corrupt_Click);
            // 
            // decoder
            // 
            this.decoder.Enabled = false;
            this.decoder.Location = new System.Drawing.Point(197, 71);
            this.decoder.Name = "decoder";
            this.decoder.Size = new System.Drawing.Size(75, 23);
            this.decoder.TabIndex = 2;
            this.decoder.Text = "Decoder";
            this.decoder.UseVisualStyleBackColor = true;
            this.decoder.Click += new System.EventHandler(this.decoder_Click);
            // 
            // browse
            // 
            this.browse.Location = new System.Drawing.Point(13, 13);
            this.browse.Name = "browse";
            this.browse.Size = new System.Drawing.Size(75, 23);
            this.browse.TabIndex = 3;
            this.browse.Text = "Browse";
            this.browse.UseVisualStyleBackColor = true;
            this.browse.Click += new System.EventHandler(this.browse_Click);
            // 
            // result
            // 
            this.result.Location = new System.Drawing.Point(13, 42);
            this.result.Name = "result";
            this.result.ReadOnly = true;
            this.result.Size = new System.Drawing.Size(178, 114);
            this.result.TabIndex = 4;
            this.result.Text = "";
            // 
            // bitErrorRate
            // 
            this.bitErrorRate.Enabled = false;
            this.bitErrorRate.Location = new System.Drawing.Point(210, 15);
            this.bitErrorRate.Name = "bitErrorRate";
            this.bitErrorRate.Size = new System.Drawing.Size(63, 20);
            this.bitErrorRate.TabIndex = 5;
            this.bitErrorRate.Text = "0,01";
            this.bitErrorRate.Click += new System.EventHandler(this.bitErrorRate_Click);
            // 
            // save
            // 
            this.save.Enabled = false;
            this.save.Location = new System.Drawing.Point(197, 100);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 8;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(175, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "BER";
            // 
            // reset
            // 
            this.reset.Location = new System.Drawing.Point(198, 130);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(75, 23);
            this.reset.TabIndex = 10;
            this.reset.Text = "Reset";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 183);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bitErrorRate);
            this.Controls.Add(this.save);
            this.Controls.Add(this.result);
            this.Controls.Add(this.browse);
            this.Controls.Add(this.decoder);
            this.Controls.Add(this.corrupt);
            this.Controls.Add(this.encoder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Hamming 8,4 - Abbas ELMAS";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button encoder;
        private System.Windows.Forms.Button corrupt;
        private System.Windows.Forms.Button decoder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button browse;
        private System.Windows.Forms.RichTextBox result;
        private System.Windows.Forms.TextBox bitErrorRate;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button reset;
    }
}

