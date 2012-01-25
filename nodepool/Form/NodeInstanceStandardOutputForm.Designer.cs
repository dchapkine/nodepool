namespace nodepool.Form
{
    partial class NodeInstanceStandardOutputForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NodeInstanceStandardOutputForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.stdioTabPage = new System.Windows.Forms.TabPage();
            this.npmTabPage = new System.Windows.Forms.TabPage();
            this.nodeInstanceMainMenu1 = new nodepool.UserControl.NodeInstanceMainMenu();
            this.nodeTerminal = new nodepool.UserControl.NodeInstanceTerminal();
            this.npmTerminal = new nodepool.UserControl.NpmTerminal();
            this.tabControl.SuspendLayout();
            this.stdioTabPage.SuspendLayout();
            this.npmTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.stdioTabPage);
            this.tabControl.Controls.Add(this.npmTabPage);
            this.tabControl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabControl.Location = new System.Drawing.Point(0, 29);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(851, 557);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            this.tabControl.Click += new System.EventHandler(this.tabControl_Click);
            // 
            // stdioTabPage
            // 
            this.stdioTabPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.stdioTabPage.Controls.Add(this.nodeTerminal);
            this.stdioTabPage.Location = new System.Drawing.Point(4, 22);
            this.stdioTabPage.Name = "stdioTabPage";
            this.stdioTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.stdioTabPage.Size = new System.Drawing.Size(843, 531);
            this.stdioTabPage.TabIndex = 0;
            this.stdioTabPage.Text = "stdio";
            this.stdioTabPage.UseVisualStyleBackColor = true;
            // 
            // npmTabPage
            // 
            this.npmTabPage.Controls.Add(this.npmTerminal);
            this.npmTabPage.Location = new System.Drawing.Point(4, 22);
            this.npmTabPage.Name = "npmTabPage";
            this.npmTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.npmTabPage.Size = new System.Drawing.Size(843, 531);
            this.npmTabPage.TabIndex = 1;
            this.npmTabPage.Text = "npm ( local )";
            this.npmTabPage.UseVisualStyleBackColor = true;
            // 
            // nodeInstanceMainMenu1
            // 
            this.nodeInstanceMainMenu1.Location = new System.Drawing.Point(0, 0);
            this.nodeInstanceMainMenu1.Name = "nodeInstanceMainMenu1";
            this.nodeInstanceMainMenu1.nodeInstance = null;
            this.nodeInstanceMainMenu1.Size = new System.Drawing.Size(851, 29);
            this.nodeInstanceMainMenu1.TabIndex = 1;
            // 
            // nodeTerminal
            // 
            this.nodeTerminal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nodeTerminal.Location = new System.Drawing.Point(3, 3);
            this.nodeTerminal.Name = "nodeTerminal";
            this.nodeTerminal.nodeInstance = null;
            this.nodeTerminal.Size = new System.Drawing.Size(837, 525);
            this.nodeTerminal.TabIndex = 1;
            // 
            // npmTerminal
            // 
            this.npmTerminal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.npmTerminal.Location = new System.Drawing.Point(3, 3);
            this.npmTerminal.Name = "npmTerminal";
            this.npmTerminal.nodeInstance = null;
            this.npmTerminal.Size = new System.Drawing.Size(837, 525);
            this.npmTerminal.TabIndex = 0;
            // 
            // NodeInstanceStandardOutputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(851, 586);
            this.Controls.Add(this.nodeInstanceMainMenu1);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NodeInstanceStandardOutputForm";
            this.Text = "Node\'s stardard output";
            this.tabControl.ResumeLayout(false);
            this.stdioTabPage.ResumeLayout(false);
            this.npmTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage stdioTabPage;
        private System.Windows.Forms.TabPage npmTabPage;
        private UserControl.NodeInstanceTerminal nodeTerminal;
        private UserControl.NpmTerminal npmTerminal;
        private UserControl.NodeInstanceMainMenu nodeInstanceMainMenu1;
    }
}