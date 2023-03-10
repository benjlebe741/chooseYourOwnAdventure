namespace chooseYourOwnAdventure
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
            this.option1Label = new System.Windows.Forms.Label();
            this.option2Label = new System.Windows.Forms.Label();
            this.option3Label = new System.Windows.Forms.Label();
            this.option4Label = new System.Windows.Forms.Label();
            this.outputLabel = new System.Windows.Forms.Label();
            this.imageBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // option1Label
            // 
            this.option1Label.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.option1Label.Font = new System.Drawing.Font("Cascadia Mono", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.option1Label.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.option1Label.Location = new System.Drawing.Point(12, 615);
            this.option1Label.Name = "option1Label";
            this.option1Label.Size = new System.Drawing.Size(209, 137);
            this.option1Label.TabIndex = 5;
            this.option1Label.Text = "option1Label";
            this.option1Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.option1Label.Click += new System.EventHandler(this.option1Label_Click);
            // 
            // option2Label
            // 
            this.option2Label.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.option2Label.Font = new System.Drawing.Font("Cascadia Mono", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.option2Label.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.option2Label.Location = new System.Drawing.Point(227, 615);
            this.option2Label.Name = "option2Label";
            this.option2Label.Size = new System.Drawing.Size(209, 136);
            this.option2Label.TabIndex = 6;
            this.option2Label.Text = "option2Label";
            this.option2Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.option2Label.Click += new System.EventHandler(this.option2Label_Click);
            // 
            // option3Label
            // 
            this.option3Label.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.option3Label.Font = new System.Drawing.Font("Cascadia Mono", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.option3Label.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.option3Label.Location = new System.Drawing.Point(447, 616);
            this.option3Label.Name = "option3Label";
            this.option3Label.Size = new System.Drawing.Size(209, 136);
            this.option3Label.TabIndex = 7;
            this.option3Label.Text = "option3Label";
            this.option3Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.option3Label.Click += new System.EventHandler(this.option3Label_Click);
            // 
            // option4Label
            // 
            this.option4Label.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.option4Label.Font = new System.Drawing.Font("Cascadia Mono", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.option4Label.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.option4Label.Location = new System.Drawing.Point(662, 616);
            this.option4Label.Name = "option4Label";
            this.option4Label.Size = new System.Drawing.Size(209, 136);
            this.option4Label.TabIndex = 8;
            this.option4Label.Text = "option4Label";
            this.option4Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.option4Label.Click += new System.EventHandler(this.option4Label_Click);
            // 
            // outputLabel
            // 
            this.outputLabel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.outputLabel.Font = new System.Drawing.Font("Cascadia Mono", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.outputLabel.Location = new System.Drawing.Point(11, 9);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(860, 72);
            this.outputLabel.TabIndex = 9;
            this.outputLabel.Text = "outputLabel";
            this.outputLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imageBox
            // 
            this.imageBox.BackgroundImage = global::chooseYourOwnAdventure.Properties.Resources.deepBrush;
            this.imageBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.imageBox.Location = new System.Drawing.Point(11, 83);
            this.imageBox.Margin = new System.Windows.Forms.Padding(2);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(859, 526);
            this.imageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageBox.TabIndex = 10;
            this.imageBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(883, 757);
            this.Controls.Add(this.outputLabel);
            this.Controls.Add(this.option4Label);
            this.Controls.Add(this.option3Label);
            this.Controls.Add(this.option2Label);
            this.Controls.Add(this.option1Label);
            this.Controls.Add(this.imageBox);
            this.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label option1Label;
        private System.Windows.Forms.Label option2Label;
        private System.Windows.Forms.Label option3Label;
        private System.Windows.Forms.Label option4Label;
        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.PictureBox imageBox;
    }
}

