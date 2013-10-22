using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Xml;
using System.Xml.Serialization;
using TerrariViewer.UI;

namespace TerrariViewer
{
    public class Updater
    {
        private const string INTRO = "An update is available for TerrariViewer";
        private const string DESCRIPTION = "This program allows you to edit Terraria characters.";
        private const string MANIFEST_URL = "https://dl.dropboxusercontent.com/u/15236565/Manifest.xml";

        private string manifestXML;
        private System.Reflection.Assembly assembly;
        private UpdateInfo info;

        Window window;
        //Button
        //Button

        #region Properties

        private string appCurrentVersion
        {
            get
            {
                return myAssembly.GetName().Version.ToString();
            }
        }

        private System.Reflection.Assembly myAssembly
        {
            get
            {
                if (assembly == null)
                {
                    assembly = System.Reflection.Assembly.GetExecutingAssembly();
                }
                return assembly;
            }
        }

        #endregion

        public Updater()
        {
            info = new UpdateInfo()
            {
                LatestAvailableVersion = "0.0.0.0",
                TimeStamp = System.DateTime.Now,
                UpdateIsAvailableAndValid = false
            };
            if (CheckforUpdate())
            {
                ShowUpdateWindow();
            } 
        }

        private bool CheckforUpdate()
        {
            var currentVersionInts = appCurrentVersion.Split(".".ToCharArray()).ToList<String>().ConvertAll(s => Convert.ToInt32(s));
            GetUpdateInfo();
            var latestVersionInts = info.LatestAvailableVersion.Split(".".ToCharArray()).ToList<String>().ConvertAll(s => Convert.ToInt32(s));

            bool canUpdate = false;
            for (int i = 0; i < currentVersionInts.Count; i++)
            {
                if (i < latestVersionInts.Count)
                {
                    if (currentVersionInts[i] < latestVersionInts[i])
                        canUpdate = true;
                    else if (currentVersionInts[i] > latestVersionInts[i])
                        break;
                }
                if (canUpdate) break;
            }
            return canUpdate;

        }

        private void GetUpdateInfo()
        {
            manifestXML = HttpGetString(MANIFEST_URL);
            if (manifestXML == null)
            {
                return;   
            }

            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.PreserveWhitespace = true;
            xmlDoc.LoadXml(manifestXML);

            XmlSerializer serializer = new XmlSerializer(typeof(UpdateInfo));
            using (var reader = new StringReader(manifestXML))
            {
                info = (UpdateInfo)serializer.Deserialize(new System.Xml.XmlTextReader(reader));
                info.UpdateIsAvailableAndValid = true;
            }
            return;
        }

        private string HttpGetString(string url)
        {
            string result = null;
            System.Net.WebRequest req = System.Net.WebRequest.Create(url);

            try
            {
                System.Net.WebResponse resp = req.GetResponse();
                System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
                result = sr.ReadToEnd().Trim();
            }
            catch { }
            return result;
        }

        private void ShowUpdateWindow()
        {
            window = new UpdateWindow();
            window.Show();
        }

    }

    [XmlRoot(Namespace = "urn:TerrariViewer.Apps.Updates")]
    public class UpdateInfo
    {
        public UpdateInfo() { TimeStamp = System.DateTime.Now; }

        [XmlElement]
        public string LatestAvailableVersion;

        [XmlElement]
        public String ImageName;

        [XmlElement]
        public String AssemblyFullName;

        [XmlElement]
        public DateTime TimeStamp;

        [XmlElement]
        public string DownloadLocation;

        [XmlIgnore]
        public bool UpdateIsAvailableAndValid;
    }
}
