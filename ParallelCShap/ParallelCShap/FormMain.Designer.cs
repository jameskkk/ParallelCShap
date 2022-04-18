namespace ParallelCShap
{
    partial class FormMain
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
            this.btnTest = new System.Windows.Forms.Button();
            this.btnColor2Grey = new System.Windows.Forms.Button();
            this.btnColor2GreyTPL = new System.Windows.Forms.Button();
            this.picResult = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(25, 24);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(114, 64);
            this.btnTest.TabIndex = 0;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnColor2Grey
            // 
            this.btnColor2Grey.Location = new System.Drawing.Point(25, 105);
            this.btnColor2Grey.Name = "btnColor2Grey";
            this.btnColor2Grey.Size = new System.Drawing.Size(114, 64);
            this.btnColor2Grey.TabIndex = 1;
            this.btnColor2Grey.Text = "Color 2 Grey";
            this.btnColor2Grey.UseVisualStyleBackColor = true;
            this.btnColor2Grey.Click += new System.EventHandler(this.btnColor2Grey_Click);
            // 
            // btnColor2GreyTPL
            // 
            this.btnColor2GreyTPL.Location = new System.Drawing.Point(203, 105);
            this.btnColor2GreyTPL.Name = "btnColor2GreyTPL";
            this.btnColor2GreyTPL.Size = new System.Drawing.Size(142, 64);
            this.btnColor2GreyTPL.TabIndex = 2;
            this.btnColor2GreyTPL.Text = "Color 2 Grey TPL";
            this.btnColor2GreyTPL.UseVisualStyleBackColor = true;
            this.btnColor2GreyTPL.Click += new System.EventHandler(this.btnColor2GreyTPL_Click);
            // 
            // picResult
            // 
            this.picResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picResult.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.picResult.Location = new System.Drawing.Point(25, 192);
            this.picResult.Name = "picResult";
            this.picResult.Size = new System.Drawing.Size(320, 240);
            this.picResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picResult.TabIndex = 5;
            this.picResult.TabStop = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 444);
            this.Controls.Add(this.picResult);
            this.Controls.Add(this.btnColor2GreyTPL);
            this.Controls.Add(this.btnColor2Grey);
            this.Controls.Add(this.btnTest);
            this.Name = "FormMain";
            this.Text = "Parallel CShap";
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnColor2Grey;
        private System.Windows.Forms.Button btnColor2GreyTPL;
        private System.Windows.Forms.PictureBox picResult;
    }
}

