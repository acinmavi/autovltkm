using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
namespace HelloWorldQuartzDotNet
{
    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                string path = args.Length > 0 ? args[0] : "D:\\auto_setting.csv";
                List<SettingPo> settings = Utils.ReadCsvFile(path, true);
                foreach (var item in settings)
                {
                    Utils.ScheduleJob(item.Name, item.CrontExp, item.FilePath);
                }
                Console.ReadKey();
            }  catch (Exception ex)
                {
                    Console.WriteLine("Failed: {0}", ex.Message);
                    Console.ReadKey();
                }
        }


       
    }
}
