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
                Utils.ReadCsvFile("D:\\test_auto.csv", true);
                Utils.MoveOnForeground("koplayer");
                Utils.ScheduleJob("test", "0/20 * * * * ? *", @"D:\Setup\AutoGame\MouseKeyboardLibrary\AutoVL\bin\Debug\Data\02072017-214129");


                Console.ReadKey();

            }  catch (Exception ex)
                {
                    Console.WriteLine("Failed: {0}", ex.Message);
                    Console.ReadKey();
                }
        }


       
    }
}
