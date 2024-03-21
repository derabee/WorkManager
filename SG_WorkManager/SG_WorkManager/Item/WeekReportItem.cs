using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_WorkManager.Item
{
    public class WeekReportItem
    {
        public DateTime ReportWeekStartDate { get; set; }
        public string Summary { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public bool IsSaved { get; set; }
    }
}
