using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using nodepool.Model;

namespace nodepool
{
    public partial class AddNodeForm : System.Windows.Forms.Form
    {
        public AddNodeForm()
        {
            InitializeComponent();
            nodeJsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            //nodeJsComboBox.Items.Add("node0.4.0-on-cygwin");
            //nodeJsComboBox.Items.Add("node0.5.8");
            nodeJsComboBox.Items.Add("node0.6.6");
            nodeJsComboBox.SelectedIndex = 0;

        }

        // On specifie le fichier principal
        private void browseMainFileButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != null &&
                openFileDialog1.FileName != "openFileDialog1")
            {
                if (instanceNameTextBox.Text.Trim() == "")
                {
                    instanceNameTextBox.Text = System.IO.Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
                }
            }
            validate();
        }

        // valide le formulaire
        private bool validate()
        {
            bool isValid = true;

            if (openFileDialog1.FileName == null ||
                openFileDialog1.FileName.Trim() == "" ||
                openFileDialog1.FileName == "openFileDialog1")
            {
                isValid = false;
                browseMainFileErrorProvider.SetError(browseMainFileButton, "Please choose a main file for this instance of node");
            }
            else if (!File.Exists(openFileDialog1.FileName))
            {
                isValid = false;
                browseMainFileErrorProvider.SetError(browseMainFileButton, "Filename you have choose doesn't exist. Please choose a correct one.");
            }
            else
            {
                bool alreadyexist = false;
                foreach (NodeInstance i in NodePool.getInstance().getAllNodeInstances())
                {
                    if (Path.GetFullPath(i.mainJsFilePath) == Path.GetFullPath(openFileDialog1.FileName))
                    {
                        browseMainFileErrorProvider.SetError(browseMainFileButton, "A node with the same main file already exist. Please choose another main file");
                        alreadyexist = true;
                        isValid = false;
                        break;
                    }
                }
                if (!alreadyexist)
                    browseMainFileErrorProvider.SetError(browseMainFileButton, "");
            }







            if (instanceNameTextBox.Text.Trim() == "")
            {
                isValid = false;
                instanceNameErrorProvider.SetError(instanceNameTextBox, "Please choose a name for this instance of node");
            }
            else
            {
                bool alreadyexist = false;
                foreach (NodeInstance i in NodePool.getInstance().getAllNodeInstances())
                {
                    if (i.name == instanceNameTextBox.Text.Trim())
                    {
                        instanceNameErrorProvider.SetError(instanceNameTextBox, "A node with the same name already exist. Please choose another name");
                        alreadyexist = true;
                        isValid = false;
                        break;
                    }
                }
                if (!alreadyexist)
                    instanceNameErrorProvider.SetError(instanceNameTextBox, "");
            }

            return isValid;
        }

        // On tente de creer
        private void button1_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                var node = NodePool.getInstance().createNodeInstance((String)(nodeJsComboBox.Items[nodeJsComboBox.SelectedIndex]), instanceNameTextBox.Text.Trim(), openFileDialog1.FileName);
                node.restartOnCrash = restartOnCrashCheckBox.Checked;
                node.restartOnMainJsFileChange = restartOnFileChangesCheckBox.Checked;
                node.run();
                Close();
                new Form.NodeInstanceStandardOutputForm(node).Show();
            }
        }

        // On modifie le nom d'instance du node
        private void instanceNameTextBox_TextChanged(object sender, EventArgs e)
        {
            validate();
        }
        
        // Au chargement du formulaire
        private void AddNodeForm_Load(object sender, EventArgs e)
        {
            validate();
        }
    }
}
