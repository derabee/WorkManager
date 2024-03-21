using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_WorkManager.ViewControl.ViewInterface
{
    public interface IViewSplitable : IViewControl
    {

        public List<int> GetSplitDistance();
        public void SetSplitDistance(int idx, int splitDistance);

    }
}
