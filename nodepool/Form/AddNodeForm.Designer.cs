namespace nodepool
{
    partial class AddNodeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddNodeForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.browseMainFileButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.saveLocalConfigCheckBox = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nodeJsComboBox = new System.Windows.Forms.ComboBox();
            this.restartOnFileChangesCheckBox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.restartOnCrashCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.instanceNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.instanceNameErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.browseMainFileErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.instanceNameErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.browseMainFileErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.browseMainFileButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.saveLocalConfigCheckBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.nodeJsComboBox);
            this.groupBox1.Controls.Add(this.restartOnFileChangesCheckBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.restartOnCrashCheckBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.instanceNameTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(521, 324);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add node instance...";
            // 
            // browseMainFileButton
            // 
            this.browseMainFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.browseMainFileButton.Location = new System.Drawing.Point(215, 36);
            this.browseMainFileButton.Name = "browseMainFileButton";
            this.browseMainFileButton.Size = new System.Drawing.Size(269, 23);
            this.browseMainFileButton.TabIndex = 13;
            this.browseMainFileButton.Text = "Browse";
            this.browseMainFileButton.UseVisualStyleBackColor = true;
            this.browseMainFileButton.Click += new System.EventHandler(this.browseMainFileButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Main .js file:";
            // 
            // saveLocalConfigCheckBox
            // 
            this.saveLocalConfigCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.saveLocalConfigCheckBox.AutoSize = true;
            this.saveLocalConfigCheckBox.Enabled = false;
            this.saveLocalConfigCheckBox.Location = new System.Drawing.Point(341, 222);
            this.saveLocalConfigCheckBox.Name = "saveLocalConfigCheckBox";
            this.saveLocalConfigCheckBox.Size = new System.Drawing.Size(15, 14);
            this.saveLocalConfigCheckBox.TabIndex = 11;
            this.saveLocalConfigCheckBox.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 222);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Save this node in local config:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "NodeJS version:";
            // 
            // nodeJsComboBox
            // 
            this.nodeJsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nodeJsComboBox.FormattingEnabled = true;
            this.nodeJsComboBox.Location = new System.Drawing.Point(215, 114);
            this.nodeJsComboBox.Name = "nodeJsComboBox";
            this.nodeJsComboBox.Size = new System.Drawing.Size(269, 21);
            this.nodeJsComboBox.TabIndex = 8;
            // 
            // restartOnFileChangesCheckBox
            // 
            this.restartOnFileChangesCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.restartOnFileChangesCheckBox.AutoSize = true;
            this.restartOnFileChangesCheckBox.Checked = true;
            this.restartOnFileChangesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.restartOnFileChangesCheckBox.Location = new System.Drawing.Point(341, 188);
            this.restartOnFileChangesCheckBox.Name = "restartOnFileChangesCheckBox";
            this.restartOnFileChangesCheckBox.Size = new System.Drawing.Size(15, 14);
            this.restartOnFileChangesCheckBox.TabIndex = 7;
            this.restartOnFileChangesCheckBox.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(187, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Restart instance on main file changes:";
            // 
            // restartOnCrashCheckBox
            // 
            this.restartOnCrashCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.restartOnCrashCheckBox.AutoSize = true;
            this.restartOnCrashCheckBox.Location = new System.Drawing.Point(341, 152);
            this.restartOnCrashCheckBox.Name = "restartOnCrashCheckBox";
            this.restartOnCrashCheckBox.Size = new System.Drawing.Size(15, 14);
            this.restartOnCrashCheckBox.TabIndex = 5;
            this.restartOnCrashCheckBox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Restart instance on crash:";
            // 
            // instanceNameTextBox
            // 
            this.instanceNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.instanceNameTextBox.Location = new System.Drawing.Point(215, 77);
            this.instanceNameTextBox.Name = "instanceNameTextBox";
            this.instanceNameTextBox.Size = new System.Drawing.Size(269, 20);
            this.instanceNameTextBox.TabIndex = 1;
            this.instanceNameTextBox.TextChanged += new System.EventHandler(this.instanceNameTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Instance name:";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(392, 343);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Create node instance >";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // instanceNameErrorProvider
            // 
            this.instanceNameErrorProvider.ContainerControl = this;
            // 
            // browseMainFileErrorProvider
            // 
            this.browseMainFileErrorProvider.ContainerControl = this;
            // 
            // AddNodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 378);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(562, 416);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(562, 416);
            this.Name = "AddNodeForm";
            this.Text = "Add node instance form";
            this.Load += new System.EventHandler(this.AddNodeForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.instanceNameErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.browseMainFileErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox instanceNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox restartOnFileChangesCheckBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox restartOnCrashCheckBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox nodeJsComboBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ErrorProvider instanceNameErrorProvider;
        private System.Windows.Forms.ErrorProvider browseMainFileErrorProvider;
        private System.Windows.Forms.CheckBox saveLocalConfigCheckBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button browseMainFileButton;
        private System.Windows.Forms.Label label2;
    }
}