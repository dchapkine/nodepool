namespace nodepool.UserControl
{
    partial class NodeInstanceTerminal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NodeInstanceTerminal));
            this.outTextBox = new System.Windows.Forms.TextBox();
            this.inTextBox = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.startButton = new System.Windows.Forms.ToolStripButton();
            this.debugButton = new System.Windows.Forms.ToolStripSplitButton();
            this.debugInExternalBrowserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopButton = new System.Windows.Forms.ToolStripButton();
            this.restartButton = new System.Windows.Forms.ToolStripButton();
            this.clearButton = new System.Windows.Forms.ToolStripButton();
            this.openInExplorerButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
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
            this.outTextBox.Location = new System.Drawing.Point(0, 28);
            this.outTextBox.Multiline = true;
            this.outTextBox.Name = "outTextBox";
            this.outTextBox.ReadOnly = true;
            this.outTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.outTextBox.Size = new System.Drawing.Size(880, 569);
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
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startButton,
            this.debugButton,
            this.stopButton,
            this.restartButton,
            this.clearButton,
            this.openInExplorerButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(880, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // startButton
            // 
            this.startButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.startButton.Image = global::nodepool.Properties.Resources.play_16;
            this.startButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(23, 22);
            this.startButton.Text = "Run";
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // debugButton
            // 
            this.debugButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.debugButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.debugInExternalBrowserToolStripMenuItem});
            this.debugButton.Image = ((System.Drawing.Image)(resources.GetObject("debugButton.Image")));
            this.debugButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.debugButton.Name = "debugButton";
            this.debugButton.Size = new System.Drawing.Size(32, 22);
            this.debugButton.Text = "Debug";
            this.debugButton.ButtonClick += new System.EventHandler(this.debugButton_ButtonClick);
            // 
            // debugInExternalBrowserToolStripMenuItem
            // 
            this.debugInExternalBrowserToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("debugInExternalBrowserToolStripMenuItem.Image")));
            this.debugInExternalBrowserToolStripMenuItem.Name = "debugInExternalBrowserToolStripMenuItem";
            this.debugInExternalBrowserToolStripMenuItem.Size = new System.Drawing.Size(526, 22);
            this.debugInExternalBrowserToolStripMenuItem.Text = "Debug in External browser (works on chrome only) - Just hit refresh if it shows e" +
                "rror ;-)";
            this.debugInExternalBrowserToolStripMenuItem.Click += new System.EventHandler(this.debugInExternalBrowserToolStripMenuItem_Click_1);
            // 
            // stopButton
            // 
            this.stopButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stopButton.Image = global::nodepool.Properties.Resources.stop_16;
            this.stopButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(23, 22);
            this.stopButton.Text = "Stop";
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // restartButton
            // 
            this.restartButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.restartButton.Image = global::nodepool.Properties.Resources.restart_16;
            this.restartButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.restartButton.Name = "restartButton";
            this.restartButton.Size = new System.Drawing.Size(23, 22);
            this.restartButton.Text = "Restart";
            this.restartButton.Click += new System.EventHandler(this.restartButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.clearButton.Image = ((System.Drawing.Image)(resources.GetObject("clearButton.Image")));
            this.clearButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(23, 22);
            this.clearButton.Text = "Clear Console";
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // openInExplorerButton
            // 
            this.openInExplorerButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openInExplorerButton.Image = ((System.Drawing.Image)(resources.GetObject("openInExplorerButton.Image")));
            this.openInExplorerButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openInExplorerButton.Name = "openInExplorerButton";
            this.openInExplorerButton.Size = new System.Drawing.Size(23, 22);
            this.openInExplorerButton.Text = "Open in explorer";
            this.openInExplorerButton.Click += new System.EventHandler(this.openInExplorerButton_Click);
            // 
            // NodeInstanceTerminal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.outTextBox);
            this.Controls.Add(this.inTextBox);
            this.Name = "NodeInstanceTerminal";
            this.Size = new System.Drawing.Size(880, 618);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox outTextBox;
        private System.Windows.Forms.TextBox inTextBox;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton startButton;
        private System.Windows.Forms.ToolStripSplitButton debugButton;
        private System.Windows.Forms.ToolStripMenuItem debugInExternalBrowserToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton stopButton;
        private System.Windows.Forms.ToolStripButton restartButton;
        private System.Windows.Forms.ToolStripButton clearButton;
        private System.Windows.Forms.ToolStripButton openInExplorerButton;
    }
}
