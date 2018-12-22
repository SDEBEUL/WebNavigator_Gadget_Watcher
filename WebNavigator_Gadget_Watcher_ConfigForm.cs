using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
//
namespace WebNavigator_Gadget_Watcher
{
    public partial class WebNavigator_Gadget_Watcher_ConfigForm : Form
    {
        //instance of log4Net logger
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //instance of dataobject (to store config)
        DataTable configData = new DataTable();

        public WebNavigator_Gadget_Watcher_ConfigForm()
        {
            log.Info("Application started");
            //
            InitializeComponent();
            //read settings form user file into form.
            tb_xmlConfig.Text = (string)WebNavigator_Gadget_Watcher.Properties.Settings.Default["xmlConfig"];
            cb_WatchConfig.Checked = (Boolean)WebNavigator_Gadget_Watcher.Properties.Settings.Default["WatchConfig"];
            tb_ExportedFile.Text = (string)WebNavigator_Gadget_Watcher.Properties.Settings.Default["ExportedFile"];

            tb_netExportLocation.Text = (string)WebNavigator_Gadget_Watcher.Properties.Settings.Default["netExportLocation"];
            tb_netExportUser.Text = (string)WebNavigator_Gadget_Watcher.Properties.Settings.Default["netExportUser"];
            tb_netExportPass.Text = (string)WebNavigator_Gadget_Watcher.Properties.Settings.Default["netExportPass"];
            tb_HtmlExportPath.Text = (string)WebNavigator_Gadget_Watcher.Properties.Settings.Default["htmlExportPath"];
            tb_INETCachePath.Text = (string)WebNavigator_Gadget_Watcher.Properties.Settings.Default["InetCachePath"];
            cb_EnblInetCachClean.Checked = (Boolean)WebNavigator_Gadget_Watcher.Properties.Settings.Default["InetCachePathEnbl"];

            //build colums for datagrid
            configData.Columns.Add("screen", System.Type.GetType("System.String"));
            configData.Columns.Add("cycle", System.Type.GetType("System.Int32"));
            configData.Columns.Add("height", System.Type.GetType("System.Int32"));
            configData.Columns.Add("width", System.Type.GetType("System.Int32"));
            configData.Columns.Add("ypos", System.Type.GetType("System.Int32"));
            configData.Columns.Add("xpos", System.Type.GetType("System.Int32"));
            configData.Columns.Add("lastPublised", System.Type.GetType("System.String"));
            //link to datagrid
            dgv_data.DataSource = configData;
            //if cb_WatchConfig.Checked make file system watcher to check for changes and read the file at startup.
            if (cb_WatchConfig.Checked)
            {
                log.Info("Watching for config changes");
                FileSystemWatcher ConifgWatcher = new FileSystemWatcher();
                try
                {
                    ConifgWatcher.Path = Path.GetDirectoryName(tb_xmlConfig.Text);
                    ConifgWatcher.Filter = "*.xml"; ;
                    ConifgWatcher.InternalBufferSize = (ConifgWatcher.InternalBufferSize * 2); //2 times default buffer size 
                    ConifgWatcher.Error += ConifgWatcher_Error;
                    ConifgWatcher.Created += ConifgWatcher_Changed;
                    ConifgWatcher.EnableRaisingEvents = true;
                    log.Info("ConifgWatcher config done");
                }
                catch (Exception ex)
                {
                        log.Fatal("Failed to set up ConifgWatcher", ex);
                        //if something realy bad happens wait 10 seconds and restart. 
                        System.Threading.Thread.Sleep(10000);
                        Environment.Exit(999);
                }
            }

            //start auto cleaning of InetCache 
            var startTimeSpan = TimeSpan.Zero;
            var periodCleanoutTimeSpan = TimeSpan.FromMinutes(5);
            if (cb_EnblInetCachClean.Checked)
            {
                log.Info("CleanInetCache started (every 5 minutes");
                var timer = new System.Threading.Timer((e) =>
                {
                    CleanInetCache();
                }, null, startTimeSpan, periodCleanoutTimeSpan);
            }
            //get autostart commandline args
            string[] args = Environment.GetCommandLineArgs();
            //if autostart
            if  ((Boolean)WebNavigator_Gadget_Watcher.Properties.Settings.Default["autostart"] || args.Contains("-autostart"))
            {
                log.Info("Application autostart");
                //read xml config. (auto startup)
                ReadXmlConfig();
                //map network drive
                map_drive();
                //
                buildHTMLPages();
                //
                MonitorForPublisedImages();
                //Start monitoring
                MonitorForPublisedImages();
                //
                this.Visible = false;
            }
            else
            {
                //show window
                this.Show();
                this.Visible = true;
            }
        }

        //safe settings
        private void btn_saveConfig_Click(object sender, EventArgs e)
        {
            //Save settings form user file into form.
           WebNavigator_Gadget_Watcher.Properties.Settings.Default["xmlConfig"] = tb_xmlConfig.Text;
           WebNavigator_Gadget_Watcher.Properties.Settings.Default["WatchConfig"] = cb_WatchConfig.Checked;
           WebNavigator_Gadget_Watcher.Properties.Settings.Default["ExportedFile"] = tb_ExportedFile.Text;

           WebNavigator_Gadget_Watcher.Properties.Settings.Default["netExportLocation"] = tb_netExportLocation.Text;
           WebNavigator_Gadget_Watcher.Properties.Settings.Default["netExportUser"] = tb_netExportUser.Text;
           WebNavigator_Gadget_Watcher.Properties.Settings.Default["netExportPass"] = tb_netExportPass.Text;
           WebNavigator_Gadget_Watcher.Properties.Settings.Default["htmlExportPath"] =  tb_HtmlExportPath.Text;
           WebNavigator_Gadget_Watcher.Properties.Settings.Default["InetCachePath"] = tb_INETCachePath.Text;
            WebNavigator_Gadget_Watcher.Properties.Settings.Default["InetCachePathEnbl"] = cb_EnblInetCachClean.Checked;

            WebNavigator_Gadget_Watcher.Properties.Settings.Default.Save();
        }

        //This triggers when the config file changes.
        private void ConifgWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            //we log the action and respawn ourselfs.
            log.Info("ConifgWatcher Change in config detected (Rereading.)");
            System.Threading.Thread.Sleep(5000); //just watch 5 seconds 
            //read config again
            ReadXmlConfig();
        }

        //in case of error with configWatchter
        private void ConifgWatcher_Error(object sender, ErrorEventArgs e)
        {
            log.Fatal("ConifgWatcher error detected (Shutting down)", e.GetException());
            //if something realy bad happens wait 10 seconds and restart. 
            System.Threading.Thread.Sleep(10000);
            Environment.Exit(999);
        }

        //reads the _gadet Xml config file.
        public void ReadXmlConfig()
        {
            log.Info("Reading XML");
            //if already a config pressent clear it.
            configData.Rows.Clear();
            //try to read config
            try
            {
                //read xml file
                var xml = XDocument.Load(tb_xmlConfig.Text);
                // Query the data and write out a subset of contacts
                var screens = from config in xml.Root.Descendants("screen")
                              select config;
                //populate datatable with config
                foreach (var screen in screens)
                {
                    DataRow newScreen = configData.NewRow();
                    newScreen["screen"] = screen.Value;
                    newScreen["cycle"] = screen.Attribute("cycle").Value;
                    newScreen["height"] = screen.Attribute("height").Value;
                    newScreen["width"] = screen.Attribute("width").Value;
                    newScreen["ypos"] = screen.Attribute("ypos").Value;
                    newScreen["xpos"] = screen.Attribute("xpos").Value;
                    configData.Rows.Add(newScreen);
                }
                dgv_data.AutoResizeColumns();
            }
            catch(Exception ex)
            {
                log.Fatal("failed to read config file. (Shutting down)",ex);
                //if something realy bad happens wait 10 seconds and restart. 
                System.Threading.Thread.Sleep(10000);
                Environment.Exit(999);
            }

            //check that all Sizes are unique
            var duplicateScreenSizes = (from row in configData.AsEnumerable()
                                   let height = row.Field<int>("height")
                                   let width = row.Field<int>("width")
                                   group row by new {height, width } into grp
                                   where grp.Count() > 1
                                   select new
                                   {
                                       height = grp.Key.height,
                                       width = grp.Key.width
                                   }).ToList();
            string dupValue = string.Empty;
            foreach (var dup in duplicateScreenSizes)
            {
                dupValue = dup.width + " - " + dup.height;
                log.Warn("Duplicate size entry:" + dupValue);
                if (this.Visible)
                {
                    MessageBox.Show("Duplicate size entry!!!!!!:" + dupValue);
                }
            }
        }

        //make html pages based on the configuration
        private void buildHTMLPages()
        {
            buildIndexPage();
            foreach (DataRow screen in configData.Rows)
            {
                buildScreenPage(screen.Field<string>("screen"));
            }
        }

        //make the index page
        private void buildIndexPage()
        {
            string htmIndexPageScelaton =
@"
<html>
<META HTTP-EQUIV='CACHE-CONTROL' CONTENT='NO-CACHE'>
    <meta http-equiv='refresh' content='50'>
      <head><title>Index of greenfield supervisie</title></head>
<h1>Index of greenfield supervisie</h1>
<hr>
        <body id='mainContainer'>
           {0}
        </body>
 </html>
                   ";

            string pageitemScelaton = "<p><a href='{0}'> {1} </a></p>";

            StringBuilder sb = new StringBuilder();

            foreach (DataRow screen in configData.Rows)
            {
                sb.AppendLine(string.Format(pageitemScelaton, Path.Combine(tb_HtmlExportPath.Text, screen.Field<string>("screen")+".html"), screen.Field<string>("screen")));
            }

            //build html
            string output = string.Format(htmIndexPageScelaton, sb.ToString());
            //output path
            string path = Path.Combine(tb_netExportLocation.Text, "index.html");
            // create HTML
            try
            {
                File.WriteAllText(path, output);
            }
            catch (Exception ex)
            {
                log.Error("unable to write html to netlocation", ex);
            }
        }

        //make a single screen page
        private void buildScreenPage(string screenname)
        {
            string htmlScreenPageScelaton =
@"
<html>
<META HTTP-EQUIV='CACHE-CONTROL' CONTENT='NO-CACHE'>
    <meta http-equiv='refresh' content='50'>
      <head><title>{0}</title></head>
<h1>{0}</h1>
                <body id='mainContainer'>
                     <p><img border='0' src='{1}'></p>
                     <p><a href='index.html'> Home </a></p>
                 </body>
 </html>
                   ";

            //build html
            string output = string.Format(htmlScreenPageScelaton,screenname, Path.Combine(tb_HtmlExportPath.Text, screenname + ".jpg"));
            //output path
            string path = Path.Combine(tb_netExportLocation.Text, screenname + ".html");
            // create HTML
            try
            {
                File.WriteAllText(path, output);
            }
            catch (Exception ex)
            {
                log.Error("unable to write html to netlocation",ex);
            }
        }

        //Manual request to read config file.
        private void btn_readConfig_Click(object sender, EventArgs e)
        {
            ReadXmlConfig();
            //
            map_drive();
            //
            buildHTMLPages();
        }

        //map the network drive where we export the file
        private void map_drive()
        {
            log.Info("Mapping drive");
            try
            {
                var credentials = new NetworkCredential(tb_netExportUser.Text, tb_netExportPass.Text);
                NetworkConnection networkConnection = new NetworkConnection(tb_netExportLocation.Text, credentials);
                log.Info("logged in on network using incode credentials");
            }
            catch (Exception ex)
            {
                log.Error("logon failed using incode credentials", ex);
            }
        }

        //Start monitoring output location for changes
        private void MonitorForPublisedImages()
        {
            log.Info("Setting up watcher for published files");
            btn_StartMonitoring.Enabled = false;

            FileSystemWatcher PublishWatcher = new FileSystemWatcher();
            try
            {
                PublishWatcher.Path = Path.GetDirectoryName(tb_ExportedFile.Text);
                PublishWatcher.Filter = "*.jpg"; ;
                PublishWatcher.InternalBufferSize = (PublishWatcher.InternalBufferSize * 2); //2 times default buffer size 
                PublishWatcher.Error += PublishWatcher_Error;
                PublishWatcher.Changed += PublishWatcher_Changed;
                PublishWatcher.EnableRaisingEvents = true;
                log.Info("PublishWatcher config done");
            }
            catch (Exception ex)
            {
                    log.Fatal("Failed to set up PublishWatcher", ex);
                    //if something realy bad happens wait 10 seconds and restart. 
                    System.Threading.Thread.Sleep(10000);
                    Environment.Exit(999);
            }

        }

        //wait for file ready
        const int ERROR_SHARING_VIOLATION = 32;
        const int ERROR_LOCK_VIOLATION = 33;
        private bool IsFileLocked(string file)
        {
            //check that problem is not in destination file
            if (File.Exists(file) == true)
            {
                FileStream stream = null;
                try
                {
                    stream = File.Open(file, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
                }
                catch (Exception ex2)
                {
                    //_log.WriteLog(ex2, "Error in checking whether file is locked " + file);
                    int errorCode = Marshal.GetHRForException(ex2) & ((1 << 16) - 1);
                    if ((ex2 is IOException) && (errorCode == ERROR_SHARING_VIOLATION || errorCode == ERROR_LOCK_VIOLATION))
                    {
                        return true;
                    }
                }
                finally
                {
                    if (stream != null)
                        stream.Close();
                }
            }
            return false;
        }

        //chandle published file
        private void PublishWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            //wait for file ready (event fire when WIN cc start writing file so I need to wait until he is done
            int checkCount = 0;
            while (IsFileLocked(e.FullPath))
            {
               // log.Info("File stil locked");
                System.Threading.Thread.Sleep(20);
                checkCount += 1;
                if (checkCount > 10)
                {
                    log.Error("Was not able to acces file");
                    break;
                }
            }
            //handle file if available
            if (!IsFileLocked(e.FullPath))
            {
                string Screenname = "";
                try
                {
                    //get file size
                    System.Drawing.Image img = System.Drawing.Image.FromFile(e.FullPath);
                    //match with table
                    Screenname = (from Screens in configData.AsEnumerable()
                                  where Screens.Field<int>("height") == img.Height && Screens.Field<int>("width") == img.Width
                                  select Screens.Field<string>("screen")).ToList().First();
                    //dispose of img
                    img.Dispose();

                    //push to network location
                    try
                    {
                        string publishFullname = Path.Combine(tb_netExportLocation.Text, Screenname + ".jpg");
                        File.Copy(e.FullPath, publishFullname, true);
                        //feedback info to screen
                        log.Info("Published screen:" + Screenname);
                        DataRow rowToUpdate = configData.AsEnumerable().Where(r => r.Field<string>("screen") == Screenname).First();
                        rowToUpdate.SetField("lastPublised", System.DateTime.Now.ToString());
                    }
                    catch (Exception ex)
                    {
                        log.Error("Failed to copy file to net location", ex);

                        //after a while password was always failing so need to remap the drive than ?
                        //13:32:17,669[47] ERROR WebNavigator_Gadget_Watcher.WebNavigator_Gadget_Watcher_ConfigForm - Failed to copy file to net location System.IO.IOException: The user name or password is incorrect.
                            log.Warn("try remapping drive");
                            map_drive();


                    }

                }
                catch (Exception ex)
                {
                    log.Fatal("Failed to read image size", ex);
                    //if something bad happens wait 10 seconds and restart. 
                    System.Threading.Thread.Sleep(10000);
                    Environment.Exit(999);
                }
            }
            else
            {
                log.Error("did not handle file");
            }
        }

        //in case of error with publish watcher
        private void PublishWatcher_Error(object sender, ErrorEventArgs e)
        {
            log.Fatal("PublishWatcher error detected (Shutting down)", e.GetException());
            //if something bad happens wait 10 seconds and restart. 
            System.Threading.Thread.Sleep(10000);
            Environment.Exit(999);
        }

        //manually start monitoring
        private void btn_StartMonitoring_Click(object sender, EventArgs e)
        {
            log.Info("PublishWatcher manual click");
            MonitorForPublisedImages();
        }

        //manually clean out directory
        private void button1_Click(object sender, EventArgs e)
        {
            CleanInetCache();
        }

        public void CleanInetCache()
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(tb_INETCachePath.Text);
                FileInfo[] files = di.GetFiles("*.pd_")
                                     .Where(p => p.Extension == ".pd_").ToArray();
                foreach (FileInfo file in files)
                    try
                    {
                        file.Attributes = FileAttributes.Normal;
                        File.Delete(file.FullName);
                    }
                    catch(Exception ex)
                    {
                        log.Error("Failed to delete file", ex);
                    }
                log.Info("CleanInetCache success");

            }
            catch(Exception ex)
            {
                log.Error("CleanInetCache", ex);
            }
        }
    }
}
