using System;
using System.Diagnostics;
using Quartz;
using Spring.Scheduling.Quartz;

namespace ITGateWorkDesk.Business.Jobs
{
    public class TestJob : QuartzJobObject
    {
        protected override void ExecuteInternal(JobExecutionContext context)
        {
            Debug.WriteLine("test jobs " + DateTime.Now);
            //MySqlConnection con = new MySqlConnection("Server=localhost;Port=3306;Database=itg_wd;Uid=root;Pwd=root;");
            //con.Open();
            //MySqlCommand cmd = con.CreateCommand();
            //cmd.CommandText = "insert into test_table(test_date) values (current_timestamp)";
            //cmd.ExecuteNonQuery();
        }
    }
}