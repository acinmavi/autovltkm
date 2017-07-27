using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
namespace HelloWorldQuartzDotNet
{
    class Program
    {
         [STAThread]
        static void Main(string[] args)
        {
            try
            {
                string path = args.Length > 0 ? args[0] : "D:\\auto_setting.csv";
                bool captureAfterFinishJob = args.Length > 1 ? (args[1].ToUpper().Contains("TRUE")) : true;
                if (args.Length > 3)
                {
                    Utils.USERNAME = args[2]; Utils.PASSWORD = args[3];
                }
                //
                List<SettingPo> settings = Utils.ReadCsvFile(path, true);
                foreach (var item in settings)
                {
                    Utils.ScheduleJob(item.Name, item.CrontExp, item.FilePath, captureAfterFinishJob);
                }
                Utils.AddToStartup();
                Console.ReadKey();
            }  catch (Exception ex)
                {
                    Console.WriteLine("Failed: {0}", ex.ToString());
                    Console.ReadKey();
                }
        }


       
    }
}
