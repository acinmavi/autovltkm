using Quartz;
using System;

namespace HelloWorldQuartzDotNet
{
    class CaptureJob : IJob
    {
        private string jobName;
        public CaptureJob()
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


                Utils.CaptureAndMail();
                Console.WriteLine("job " + jobName + " is finish");

            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}***{0}Failed: {1}{0}***{0}", Environment.NewLine, ex.Message);
            }
        }
    }
}
