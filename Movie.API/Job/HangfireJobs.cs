using Hangfire;

namespace Movie.API.Job;
public static class HangfireJobs
{
    public static void Init()
    {
        RecurringJob.AddOrUpdate("myrecurringjob", () => Batch.SendMostRatedMovie("ozturkfurkan1994@hotmail.com"), "0 30 19 ? * SUN");
    }
}
