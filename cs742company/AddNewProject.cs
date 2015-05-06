using cs742company.SpecificationCode;
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
    public partial class AddNewProject : Form
    {
        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }
        public AddNewProject()
        {
            InitializeComponent();
        }

        public NAME getProjectName()
        {
            return new NAME(tbox_projectName.Text);
        }

        public string getEstimatedHours()
        {
            return tbox_estimatedHours.Text;
        }
    }
}
