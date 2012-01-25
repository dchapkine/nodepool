using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using nodepool.Tools;

namespace nodepool.Model
{
    public class UserProfile
    {
        #region Contructors

        private UserProfile(string name = "DefaultProfile")
        {
            _isLoaded = false;
            _profileName = name;
            _profilePath = Path.Combine("Profiles", _profileName + ".xml");
        }

        #endregion


        #region Attributes

        private bool _isLoaded;
        private string _profileName;
        private string _profilePath;

        #endregion


        #region Properties


        #endregion


        #region Methods

        public void load()
        {
            if (!_isLoaded)
            {
                //
                // Do we have the profiles directory ?
                //
                if (!Directory.Exists("Profiles"))
                {
                    Directory.CreateDirectory("Profiles");
                }

                //
                // Creating profile if file does not exist
                //
                if (!File.Exists(_profilePath))
                {
                    save();
                }
                //
                // ...Or read it, if it exist, and load everything
                //
                else
                {
                    //
                    String str = File.ReadAllText(_profilePath, Encoding.UTF8);
                    System.Xml.XmlDocument doc = new XmlDocument();
                    doc.LoadXml(str);

                    //
                    foreach (System.Xml.XmlNode i in doc.GetElementsByTagName("NodeInstance"))
                    {
                        if (File.Exists(i.Attributes.GetNamedItem("mainFile").InnerText))
                        {
                            NodeInstance ni = NodePool.getInstance().createNodeInstance(
                                LocalHost.getLatestInstalledNodeVersion(),
                                i.Attributes.GetNamedItem("name").InnerText,
                                i.Attributes.GetNamedItem("mainFile").InnerText
                            );

                            ni.restartOnMainJsFileChange = i.Attributes.GetNamedItem("restartOnFileChange").InnerText == "true" ? true : false;
                            ni.restartOnCrash = i.Attributes.GetNamedItem("restartOnCrash").InnerText == "true" ? true : false;

                            if (i.FirstChild != null && i.FirstChild.Name == "RestartOnFileChangePatternsString")
                            {
                                ni.restartOnFileChangePatternsString = i.FirstChild.InnerText;
                            }
                        }
                    }
                }

                //
                _isLoaded = true;
            }
        }


        public void save()
        {
            FileStream fs = File.Create(_profilePath);
            if (fs.CanWrite)
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;

                XmlWriter w = XmlWriter.Create(fs, settings);

                w.WriteStartDocument();

                // Profile
                w.WriteStartElement("Profile");

                // Profile > NodeInstances
                w.WriteStartElement("NodeInstances");

                foreach (NodeInstance i in NodePool.getInstance().getAllNodeInstances())
                {
                    // Profile > NodeInstances > NodeInstance
                    w.WriteStartElement("NodeInstance");

                    w.WriteAttributeString("mainFile", i.mainJsFilePath);
                    w.WriteAttributeString("name", i.name);
                    w.WriteAttributeString("restartOnCrash", i.restartOnCrash ? "true" : "false");
                    w.WriteAttributeString("restartOnFileChange", i.restartOnMainJsFileChange ? "true" : "false");

                    // Profile > NodeInstances > NodeInstance > RestartOnFileChangePatternsString
                    w.WriteStartElement("RestartOnFileChangePatternsString", i.mainJsFilePath);
                    w.WriteCData(i.restartOnFileChangePatternsString);
                    w.WriteEndElement();

                    w.WriteEndElement();
                }

                w.WriteEndElement();

                w.WriteEndDocument();
                w.Flush();
                w.Close();
            }
            fs.Close();
        }

        #endregion


        #region Singleton

        private static UserProfile _instance = null;

        public static UserProfile getInstance()
        {
            if (_instance == null)
                _instance = new UserProfile();
            return _instance;
        }

        #endregion

        
    }
}
