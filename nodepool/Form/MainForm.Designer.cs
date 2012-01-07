namespace nodepool
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.systray = new System.Windows.Forms.NotifyIcon(this.components);
            this.systrayMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.addNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.startAllNodesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.killAllNodesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartAllNodesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systrayMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // systray
            // 
            this.systray.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.systray.BalloonTipText = "NodePool";
            this.systray.BalloonTipTitle = "NodePool";
            this.systray.ContextMenuStrip = this.systrayMenuStrip;
            this.systray.Icon = ((System.Drawing.Icon)(resources.GetObject("systray.Icon")));
            this.systray.Text = "NodePool";
            this.systray.Visible = true;
            this.systray.MouseClick += new System.Windows.Forms.MouseEventHandler(this.systray_MouseClick);
            // 
            // systrayMenuStrip
            // 
            this.systrayMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator2,
            this.addNodeToolStripMenuItem,
            this.toolStripSeparator3,
            this.startAllNodesToolStripMenuItem,
            this.killAllNodesToolStripMenuItem,
            this.restartAllNodesToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.systrayMenuStrip.Name = "systrayMenuStrip";
            this.systrayMenuStrip.Size = new System.Drawing.Size(158, 132);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(154, 6);
            // 
            // addNodeToolStripMenuItem
            // 
            this.addNodeToolStripMenuItem.Image = global::nodepool.Properties.Resources.add_16;
            this.addNodeToolStripMenuItem.Name = "addNodeToolStripMenuItem";
            this.addNodeToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.addNodeToolStripMenuItem.Text = "add node";
            this.addNodeToolStripMenuItem.Click += new System.EventHandler(this.addNodeToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(154, 6);
            // 
            // startAllNodesToolStripMenuItem
            // 
            this.startAllNodesToolStripMenuItem.Image = global::nodepool.Properties.Resources.play_16;
            this.startAllNodesToolStripMenuItem.Name = "startAllNodesToolStripMenuItem";
            this.startAllNodesToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.startAllNodesToolStripMenuItem.Text = "start all nodes";
            this.startAllNodesToolStripMenuItem.Click += new System.EventHandler(this.startAllNodesToolStripMenuItem_Click);
            // 
            // killAllNodesToolStripMenuItem
            // 
            this.killAllNodesToolStripMenuItem.Image = global::nodepool.Properties.Resources.stop_16;
            this.killAllNodesToolStripMenuItem.Name = "killAllNodesToolStripMenuItem";
            this.killAllNodesToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.killAllNodesToolStripMenuItem.Text = "stop all nodes";
            this.killAllNodesToolStripMenuItem.Click += new System.EventHandler(this.killAllNodesToolStripMenuItem_Click);
            // 
            // restartAllNodesToolStripMenuItem
            // 
            this.restartAllNodesToolStripMenuItem.Image = global::nodepool.Properties.Resources.restart_16;
            this.restartAllNodesToolStripMenuItem.Name = "restartAllNodesToolStripMenuItem";
            this.restartAllNodesToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.restartAllNodesToolStripMenuItem.Text = "restart all nodes";
            this.restartAllNodesToolStripMenuItem.Click += new System.EventHandler(this.restartAllNodesToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(154, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::nodepool.Properties.Resources.exit_16;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.exitToolStripMenuItem.Text = "exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(116, 0);
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.systrayMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon systray;
        private System.Windows.Forms.ContextMenuStrip systrayMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addNodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem killAllNodesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem startAllNodesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartAllNodesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

