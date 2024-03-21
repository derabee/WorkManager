namespace SG_WorkManager.ViewControl.ViewInterface
{
    public interface IViewControl
    {
        string ControlName { get; set; }
        string DisplayText { get; set; }
        bool IsSaved { get; set; }
        int PageNumber { get; set; }

        bool Save();

        bool CanProcess();
    }
}
