namespace nodepool.UserControl
{
    partial class NodeInstanceMainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NodeInstanceMainMenu));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.instanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nodeVersionChooser = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.startButton = new System.Windows.Forms.ToolStripMenuItem();
            this.debugButton = new System.Windows.Forms.ToolStripMenuItem();
            this.stopButton = new System.Windows.Forms.ToolStripMenuItem();
            this.restartButton = new System.Windows.Forms.ToolStripMenuItem();
            this.restartOnCrashButton = new System.Windows.Forms.ToolStripMenuItem();
            this.restartOnSourceChangeButton = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.White;
            this.menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.instanceToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1196, 27);
            this.menu.TabIndex = 0;
            this.menu.Text = "menu";
            // 
            // instanceToolStripMenuItem
            // 
            this.instanceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nodeVersionChooser,
            this.startButton,
            this.debugButton,
            this.stopButton,
            this.restartButton,
            this.restartOnCrashButton,
            this.restartOnSourceChangeButton});
            this.instanceToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("instanceToolStripMenuItem.Image")));
            this.instanceToolStripMenuItem.Name = "instanceToolStripMenuItem";
            this.instanceToolStripMenuItem.Size = new System.Drawing.Size(79, 23);
            this.instanceToolStripMenuItem.Text = "Instance";
            // 
            // nodeVersionChooser
            // 
            this.nodeVersionChooser.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.nodeVersionChooser.Enabled = false;
            this.nodeVersionChooser.Image = ((System.Drawing.Image)(resources.GetObject("nodeVersionChooser.Image")));
            this.nodeVersionChooser.Name = "nodeVersionChooser";
            this.nodeVersionChooser.Size = new System.Drawing.Size(203, 22);
            this.nodeVersionChooser.Text = "Node version";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Checked = true;
            this.toolStripMenuItem2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem2.Text = "0.6.6";
            // 
            // startButton
            // 
            this.startButton.Image = ((System.Drawing.Image)(resources.GetObject("startButton.Image")));
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(203, 22);
            this.startButton.Text = "Start";
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // debugButton
            // 
            this.debugButton.Image = ((System.Drawing.Image)(resources.GetObject("debugButton.Image")));
            this.debugButton.Name = "debugButton";
            this.debugButton.Size = new System.Drawing.Size(203, 22);
            this.debugButton.Text = "Debug";
            this.debugButton.Click += new System.EventHandler(this.debugButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Image = ((System.Drawing.Image)(resources.GetObject("stopButton.Image")));
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(203, 22);
            this.stopButton.Text = "Stop";
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // restartButton
            // 
            this.restartButton.Image = ((System.Drawing.Image)(resources.GetObject("restartButton.Image")));
            this.restartButton.Name = "restartButton";
            this.restartButton.Size = new System.Drawing.Size(203, 22);
            this.restartButton.Text = "Restart";
            this.restartButton.Click += new System.EventHandler(this.restartButton_Click);
            // 
            // restartOnCrashButton
            // 
            this.restartOnCrashButton.Name = "restartOnCrashButton";
            this.restartOnCrashButton.Size = new System.Drawing.Size(203, 22);
            this.restartOnCrashButton.Text = "RestartOnCrash";
            this.restartOnCrashButton.Click += new System.EventHandler(this.restartOnCrashButton_Click);
            // 
            // restartOnSourceChangeButton
            // 
            this.restartOnSourceChangeButton.Checked = true;
            this.restartOnSourceChangeButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.restartOnSourceChangeButton.Name = "restartOnSourceChangeButton";
            this.restartOnSourceChangeButton.Size = new System.Drawing.Size(203, 22);
            this.restartOnSourceChangeButton.Text = "RestartOnSourceChange";
            this.restartOnSourceChangeButton.Click += new System.EventHandler(this.restartOnSourceChangeButton_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 23);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // NodeInstanceMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.menu);
            this.Name = "NodeInstanceMainMenu";
            this.Size = new System.Drawing.Size(1196, 27);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem instanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nodeVersionChooser;
        private System.Windows.Forms.ToolStripMenuItem stopButton;
        private System.Windows.Forms.ToolStripMenuItem startButton;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem restartButton;
        private System.Windows.Forms.ToolStripMenuItem restartOnCrashButton;
        private System.Windows.Forms.ToolStripMenuItem restartOnSourceChangeButton;
        private System.Windows.Forms.ToolStripMenuItem debugButton;
    }
}
