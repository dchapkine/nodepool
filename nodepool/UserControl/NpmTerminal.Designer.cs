namespace nodepool.UserControl
{
    partial class NpmTerminal
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.outTextBox = new System.Windows.Forms.TextBox();
            this.inTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // outTextBox
            // 
            this.outTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.outTextBox.BackColor = System.Drawing.Color.Black;
            this.outTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.outTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outTextBox.ForeColor = System.Drawing.Color.White;
            this.outTextBox.Location = new System.Drawing.Point(0, 0);
            this.outTextBox.Multiline = true;
            this.outTextBox.Name = "outTextBox";
            this.outTextBox.ReadOnly = true;
            this.outTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.outTextBox.Size = new System.Drawing.Size(880, 597);
            this.outTextBox.TabIndex = 5;
            this.outTextBox.Text = "sfddfd";
            // 
            // inTextBox
            // 
            this.inTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.inTextBox.BackColor = System.Drawing.Color.Black;
            this.inTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.inTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inTextBox.ForeColor = System.Drawing.Color.White;
            this.inTextBox.Location = new System.Drawing.Point(0, 595);
            this.inTextBox.Name = "inTextBox";
            this.inTextBox.Size = new System.Drawing.Size(880, 20);
            this.inTextBox.TabIndex = 6;
            this.inTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.inTextBox_KeyUp);
            // 
            // Terminal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.outTextBox);
            this.Controls.Add(this.inTextBox);
            this.Name = "Terminal";
            this.Size = new System.Drawing.Size(880, 618);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox outTextBox;
        private System.Windows.Forms.TextBox inTextBox;
    }
}
