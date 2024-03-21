using SG_WorkManager.ViewControl.ViewInterface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SG_WorkManager.Manager
{
    public class ViewControlManager
    {
        private Dictionary<Button, IViewControl> dictViewControl = new Dictionary<Button, IViewControl>();

        private IViewControl lastViewControl;
        public IViewControl LastViewControl
        {
            get { return lastViewControl; }
        }

        private Button lastviewControlKey;
        public Button LastViewControlKey
        {
            get { return lastviewControlKey; }
        }

        public List<Button> Keys
        {
            get { return dictViewControl.Keys.ToList(); }
        }

        public bool AddViewControl(Button key, IViewControl viewControl)
        {
            if (GetViewControl(key) == null)
            {
                dictViewControl.Add(key, viewControl);
                return true;
            }
            return false;
        }

        public IViewControl GetViewControl(Button key)
        {
            if (dictViewControl.TryGetValue(key, out var viewControl))
            {
                return viewControl;
            }
            return null;
        }

        public void UpdateLastViewControl(Button key, IViewControl viewControl)
        {
            lastviewControlKey = key;
            lastViewControl = viewControl;
        }
    }
}
