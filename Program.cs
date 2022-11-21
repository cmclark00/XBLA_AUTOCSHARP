using System.Diagnostics;
using System.Runtime.InteropServices;

namespace XBLA_AUTOCSHARP
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());

            static void unpackRar()
            {
                string homePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                string packedPath = homePath + "\\XBLA\\";
                string unpackedPath = homePath + "\\XBLA_Unpacked\\";
                string unrarPath = homePath + "\\unRAR.exe";


                var process = Process.Start(unrarPath, " x " + packedPath + "*.rar  " + unpackedPath);
                process.WaitForExit();

                return;


            }

            static List<string> GetAllFiles(string unpackedPath)
            {

                return Directory.GetFiles(unpackedPath, "*", SearchOption.AllDirectories).ToList();

            }

            [DllImport("user32.dll")]
            static extern bool SetForegroundWindow(IntPtr hWnd);
            static void unPirs()
            {

                string homePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                string unpackedPath = homePath + "\\XBLA_Unpacked\\";
                string wxPirsPath = homePath + "\\wxPirs.exe";
                var files = GetAllFiles(unpackedPath);



                foreach (var file in files)
                {
                    Console.WriteLine(file);
                    var process = Process.Start(wxPirsPath, "\"" + file + "\"");
                    Thread.Sleep(5000);
                    IntPtr hWnd = process.MainWindowHandle;
                    SetForegroundWindow(hWnd);
                    SendKeys.SendWait("%{F}");
                    Thread.Sleep(1000);
                    SendKeys.SendWait("{ENTER}");
                    Thread.Sleep(1000);
                    SendKeys.SendWait("{DOWN}");
                    Thread.Sleep(1000);
                    SendKeys.SendWait("{ENTER}");
                    Thread.Sleep(1000);
                    SendKeys.SendWait("{TAB}");
                    Thread.Sleep(1000);
                    SendKeys.SendWait("{TAB}");
                    Thread.Sleep(1000);
                    SendKeys.SendWait("{UP}");
                    Thread.Sleep(1000);
                    SendKeys.SendWait("{UP}");
                    Thread.Sleep(1000); 
                    SendKeys.SendWait("{ENTER}");
                    Thread.Sleep(10000);

                    process.Kill();
                    process.WaitForExit();
                }

            }

            static void ReNamePirs()
            {
                string homePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                string unpackedPath = homePath + "\\XBLA_Unpacked\\";
                string renamePath = homePath + "\\XBLA_Unpacked";
                List<string> sourceName = Directory.GetFiles(unpackedPath, "default.xex", SearchOption.AllDirectories).ToList();


                for (int i = 0; i < sourceName.Count; i++)
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(renamePath);
                    FileInfo fileInfo = directoryInfo.GetFiles("default.xex", SearchOption.AllDirectories).FirstOrDefault();

                    if (fileInfo != null)
                    {
                        string newFileName = fileInfo.FullName.Replace(Path.GetFileNameWithoutExtension(fileInfo.Name), fileInfo.Directory.Name);
                        fileInfo.MoveTo(newFileName);
                    }

                }

                return;
            }

            static void ReNameDirectory()
            {
                string homePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                string unpackedPath = homePath + "\\XBLA_Unpacked\\";
                string renamePath = homePath + "\\XBLA_Unpacked";
                List<string> directoryName = Directory.GetDirectories(unpackedPath, "*", SearchOption.TopDirectoryOnly).ToList();

                for (int i = 0; i < directoryName.Count; i++)
                {
                    Directory.Move(directoryName[i], directoryName[i] + ".xex");
                }
                return;
            }

            

            unpackRar();
            unPirs();
            ReNamePirs();
            ReNameDirectory();
           
        }
    }
}
    
