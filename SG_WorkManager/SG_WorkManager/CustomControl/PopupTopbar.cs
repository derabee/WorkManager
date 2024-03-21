using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SG_WorkManager.CustomControl
{
    public partial class PopupTopbar : UserControl
    {
        public PopupTopbar()
        {
            InitializeComponent();
        }

        private void InitEvent()
        {
            btnExit.Click += delegate
            {

            };
            btnMin.Click += delegate
            {

            };
        }

    }
}
