namespace SG_WorkManager.Item
{
    public class DailyReportItem
    {
        public DateTime ReportDate { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Note { get; set; }
        public bool IsHoliday { get; set; }
        public bool IsVacation { get; set; }

        public bool IsSaved { get; set; }

        public DailyReportItem()
        {
            IsHoliday = false;
        }
    }
}