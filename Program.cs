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

            

            

            unpackRar();
           
           
        }
    }
}
    
