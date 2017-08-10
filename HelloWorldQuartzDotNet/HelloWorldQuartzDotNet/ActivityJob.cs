using Quartz;
using System;
using MouseKeyboardLibrary;
namespace HelloWorldQuartzDotNet
{
    class ActivityJob : IJob
    {
        private string jobName;
        public ActivityJob()
        {
        }

        public void Execute(IJobExecutionContext context)        
        {
            try
            {
                JobDataMap dataMap = context.JobDetail.JobDataMap;
                jobName = dataMap.GetString("jobName");

                Console.WriteLine("{0}****{0}Job {1} fired @ {2} next scheduled for {3}{0}***{0}", 
                                                                        Environment.NewLine,
                                                                        context.JobDetail.Key,
                                                                        context.FireTimeUtc.Value.ToString("r"), 
                                                                        context.NextFireTimeUtc.Value.ToString("r"));


                uint idleTime = Utils.GetLastInputTime();
                if (idleTime > Utils.MAX_IDLE_TIME_SECOND)
                {
                    Console.WriteLine("[idle detected] user idle time = " + idleTime + " , max idle time = " + Utils.MAX_IDLE_TIME_SECOND);
                   int x = 1508;
                   int y = 1062;
                   MouseSimulator.X=x;
                   MouseSimulator.Y=y;
                   MouseSimulator.MouseDown(MouseButton.Left);
                   MouseSimulator.MouseUp(MouseButton.Left);
                }
                else
                {
                    Console.WriteLine("[activity normal] user idle time = " + idleTime + " , max idle time = " + Utils.MAX_IDLE_TIME_SECOND);
                }

                Console.WriteLine("job " + jobName + " is finish");

            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}***{0}Failed: {1}{0}***{0}", Environment.NewLine, ex.Message);
            }
        }
    }
}
