using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using System.Collections.Specialized;
using System.Configuration;
using Quartz;
using Quartz.Impl;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using MouseKeyboardLibrary;
using System.Windows.Forms;
using System.Net.Mime;
using System.Net.Mail;
using System.Net;
using System;
using System.Drawing;
using System.Drawing.Imaging;
namespace HelloWorldQuartzDotNet
{
    class Utils
    {
        public static bool isCancel = false;
        public static string RECIPIENT = "noreplyteacher@gmail.com";
        public static string MAIL_SUBJECT = "[AutoReport] ";

        //smtp client configuration
        public static string SMTP_CLIENT = "smtp.gmail.com";
        public static int SMTP_PORT = 587;
        public static string USERNAME = "noreplyteacher@gmail.com";
        public static string PASSWORD = "1234567890a@";
        public static string CAPTURE_JOB = "CAPTURE_JOB";
        public static void CaptureAndMail()
        {
            try
            {
                //print the screen
                Bitmap printscreen = new Bitmap(SystemInformation.VirtualScreen.Width,
                               SystemInformation.VirtualScreen.Height,
                               PixelFormat.Format32bppArgb);
                Graphics graphics = Graphics.FromImage(printscreen as Image);
                graphics.CopyFromScreen(SystemInformation.VirtualScreen.X,
                           SystemInformation.VirtualScreen.Y,
                           0,
                           0,
                           SystemInformation.VirtualScreen.Size,
                           CopyPixelOperation.SourceCopy);
                string path = Path.GetTempFileName();
                printscreen.Save(path, ImageFormat.Jpeg);

                //Send the mail with attachment
                MailMessage mm = new MailMessage();
                mm.From = new MailAddress(USERNAME);
                mm.To.Add(RECIPIENT);

                mm.Subject = MAIL_SUBJECT + DateTime.Now.ToString("yyyyMMdd HH:mm:ss");
                mm.Body = mm.Subject;

                mm.IsBodyHtml = true;

                Attachment att = new Attachment(path, MediaTypeNames.Image.Jpeg);
                mm.Attachments.Add(att);

                sendEmail(mm);

                mm.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void sendEmail(MailMessage mm)
        {
            var client = new SmtpClient(SMTP_CLIENT, SMTP_PORT)
            {
                Credentials = new NetworkCredential(USERNAME, PASSWORD),
                EnableSsl = true
            };
            client.Send(mm);
        }

        public static List<SettingPo> ReadCsvFile(string csvPath, bool ignoreTitle)
        {
            List<SettingPo> r = new List<SettingPo>();
            bool checkFirstLine = false;
            using (var reader = new StreamReader(csvPath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    if (ignoreTitle && !checkFirstLine)
                    {
                        checkFirstLine = true;
                        continue;
                    }
                    Console.WriteLine(line);
                    var values = line.Split(',');
                    if (values.Length >= 3)
                    {
                        SettingPo po = new SettingPo();
                        po.Name = values[0];
                        po.CrontExp = values[1];
                        po.FilePath = values[2];
                        r.Add(po);
                    }
                }
            }
            return r;
        }

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        private static extern bool IsIconic(IntPtr hWnd);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private const int SW_HIDE = 0;
        private const int SW_SHOWNORMAL = 1;
        private const int SW_SHOWMINIMIZED = 2;
        private const int SW_SHOWMAXIMIZED = 3;
        private const int SW_SHOWNOACTIVATE = 4;
        private const int SW_RESTORE = 9;
        private const int SW_SHOWDEFAULT = 10;

        public static void MoveOnForeground(string processName)
        {
            // get our process
            Process[] processes = Process.GetProcessesByName(processName);
            if (processes.Length <= 0) return;
            // get the window handle
            IntPtr hWnd = processes[0].MainWindowHandle;
            // if iconic, we need to restore the window
            if (IsIconic(hWnd))
            {
                ShowWindowAsync(hWnd, SW_RESTORE);
            }
            ShowWindow(hWnd, SW_RESTORE);
            // bring it to the foreground
            SetForegroundWindow(hWnd);
            Console.WriteLine("bring process " + processName + " to foreground");
            // exit our process
            return;
        }

        public static void ScheduleJob(string name, string crontExp, string activityPath, bool captureAfterFinishJob)
        {
            // Get an instance of the Quartz.Net scheduler
            var schd = StdSchedulerFactory.GetDefaultScheduler();

            // Start the scheduler if its in standby
            if (!schd.IsStarted)
                schd.Start();

            // Define the Job to be scheduled
            IJobDetail job = null;
            if (activityPath.Contains(CAPTURE_JOB))
            {
                job = JobBuilder.Create<CaptureJob>()
                                .WithIdentity(name, name)
                                .UsingJobData("jobName", name)
                                .RequestRecovery()
                                .Build();
            }
            else
            {
                job = JobBuilder.Create<AutoJob>()
                .WithIdentity(name, name)
                .UsingJobData("jobName", name)
                .UsingJobData("activityPath", activityPath)
                .UsingJobData("captureAfterFinishJob", captureAfterFinishJob)
                .RequestRecovery()
                .Build();
            }

            // Associate a trigger with the Job
            var trigger = (ICronTrigger)TriggerBuilder.Create()
                .WithIdentity(name, name)
                .WithCronSchedule(crontExp)
                .WithPriority(1)
                .Build();

            // Validate that the job doesn't already exists
            if (schd.CheckExists(new JobKey(name, name)))
            {
                schd.DeleteJob(new JobKey(name, name));
            }

            var schedule = schd.ScheduleJob(job, trigger);
            Console.WriteLine("Job '{0}' scheduled for '{1}'", name, schedule.ToString("r"));

            // schd.Start();
        }

        public static void SerializeObject(string filename, ObjectToSerialize objectToSerialize)
        {
            Stream stream = File.Open(filename, FileMode.Create);
            BinaryFormatter bFormatter = new BinaryFormatter();
            bFormatter.Serialize(stream, objectToSerialize);
            stream.Close();
        }

        public static ObjectToSerialize DeSerializeObject(string filename)
        {
            ObjectToSerialize objectToSerialize;
            Stream stream = File.Open(filename, FileMode.Open);
            BinaryFormatter bFormatter = new BinaryFormatter();
            objectToSerialize = (ObjectToSerialize)bFormatter.Deserialize(stream);
            stream.Close();
            return objectToSerialize;
        }

        public static void ConvertEvent(List<MacroEvent> events)
        {
            foreach (var item in events)
            {
                if (item.EventArgs is MouseEventArgs)
                {
                    MouseEventArgs arg = (MouseEventArgs)item.EventArgs;
                    MyMouseEventArgs myArgs = new MyMouseEventArgs(arg.Button, arg.Clicks, arg.X, arg.Y, arg.Delta);
                    item.EventArgs = myArgs;
                }
                else if (item.EventArgs is KeyEventArgs)
                {
                    KeyEventArgs arg = (KeyEventArgs)item.EventArgs;
                    MyKeyEventArgs myArgs = new MyKeyEventArgs(arg.KeyCode);
                    item.EventArgs = myArgs;
                }
            }
        }

        public static void RunFile(string filePath , int times) 
        {
            try
            {
                isCancel = false;
                ObjectToSerialize ots = DeSerializeObject(filePath);
                Thread thread = new Thread(() => WorkThreadFunction(ots.Events , times));
                thread.Start();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void WorkThreadFunction(List<MacroEvent> events , int times)
        {
            try
            {
                ConvertEvent(events);
                isCancel = false;
                for (int i = 0; i < times; i++)
                {
                    foreach (MacroEvent macroEvent in events)
                    {
                        if (isCancel) break;
                        Thread.Sleep(macroEvent.TimeSinceLastEvent);

                        switch (macroEvent.MacroEventType)
                        {
                            case MacroEventType.MouseMove:
                                {
                                    MyMouseEventArgs mouseArgs = (MyMouseEventArgs)macroEvent.EventArgs;

                                    MouseSimulator.X = mouseArgs.X;
                                    MouseSimulator.Y = mouseArgs.Y;
                                }
                                break;

                            case MacroEventType.MouseDown:
                                {
                                    MyMouseEventArgs mouseArgs = (MyMouseEventArgs)macroEvent.EventArgs;

                                    MouseSimulator.MouseDown(mouseArgs.Button);
                                }
                                break;

                            case MacroEventType.MouseUp:
                                {
                                    MyMouseEventArgs mouseArgs = (MyMouseEventArgs)macroEvent.EventArgs;

                                    MouseSimulator.MouseUp(mouseArgs.Button);
                                }
                                break;

                            case MacroEventType.KeyDown:
                                {
                                    MyKeyEventArgs keyArgs = (MyKeyEventArgs)macroEvent.EventArgs;

                                    KeyboardSimulator.KeyDown(keyArgs.KeyCode);
                                }
                                break;

                            case MacroEventType.KeyUp:
                                {
                                    MyKeyEventArgs keyArgs = (MyKeyEventArgs)macroEvent.EventArgs;

                                    KeyboardSimulator.KeyUp(keyArgs.KeyCode);
                                }
                                break;

                            default:
                                break;
                        }
                    }
                    if (times > 1)
                    {
                        Thread.Sleep(1000);
                    }
                }

            }
            catch (Exception ex)
            {
               Console.WriteLine(ex.ToString());
            }
        }

    }
}