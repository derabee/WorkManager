using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_WorkManager.Item
{
    public class VacationUseItem
    {
        public int Year { get; set; }
        public int Index { get; set; }
        public DateTime VacationDate { get; set; }
        public bool IsNotRegularVacation { get; set; }
        public string Note { get; set; }

        public string GetKey(int max = 16)
        {
            return $"{Index.ToString("00")}/{max}";
        }
    }
}
