using Quartz;
using System;
using System.Threading;
namespace HelloWorldQuartzDotNet
{
    class AutoJob : IJob
    {
        private string jobName;
        private string activityPath;
        private bool captureAfterFinishJob;
        public AutoJob()
        {
        }

        public void Execute(IJobExecutionContext context)        
        {
            try
            {
                JobDataMap dataMap = context.JobDetail.JobDataMap;
                jobName = dataMap.GetString("jobName");
                activityPath = dataMap.GetString("activityPath");
                captureAfterFinishJob = dataMap.GetBoolean("captureAfterFinishJob");

                Console.WriteLine("{0}****{0}Job {1} fired @ {2} next scheduled for {3}{0}***{0}", 
                                                                        Environment.NewLine,
                                                                        context.JobDetail.Key,
                                                                        context.FireTimeUtc.Value.ToString("r"), 
                                                                        context.NextFireTimeUtc.Value.ToString("r"));


                Console.WriteLine("job " + jobName + " , activityPath " + activityPath);
                Utils.RunFile(activityPath, 1);
                if (captureAfterFinishJob)
                {
                    Thread.Sleep(20000);
                    Utils.Capture3();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}***{0}Failed: {1}{0}***{0}", Environment.NewLine, ex.Message);
            }
        }
    }
}
