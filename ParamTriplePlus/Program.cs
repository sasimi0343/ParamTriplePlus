using System.Diagnostics;

namespace ParamTriplePlus
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            var procs = Process.GetProcessesByName("ParamTriplePlus");
            Trace.WriteLine("procs: " + procs.Length);
            if (procs.Length > 1)
            {
                foreach (var item in procs)
                {
                    if (item.Id != Process.GetCurrentProcess().Id)
                    {
                        item.Kill();
                    }
                }
            }
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainWindow(args));

            var path = Path.Combine(Application.StartupPath, "running");
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}