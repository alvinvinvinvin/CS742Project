using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cs742company
{
    public partial class EmployeeAddHours : Form
    {
        public EmployeeAddHours()
        {
            InitializeComponent();
        }

        public string getName()
        {
            return tbox_employeeName.Text;
        }

        public string getHours()
        {
            return tbox_hoursToAdd.Text;
        }
    }
}
