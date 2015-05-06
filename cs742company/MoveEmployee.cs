using cs742company.SpecificationModel;
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
    public partial class MoveEmployee : Form
    {
        public HashSet<Division> divisions = new HashSet<Division>();
        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }
        public MoveEmployee()
        {
            InitializeComponent();
        }

        public MoveEmployee(HashSet<Division> input)
        {
            InitializeComponent();
            divisions = input;
            foreach (Division d in divisions)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = d.Name.getDIVISION_NAME();
                item.Value = d;
                cbb_from.Items.Add(item);
                cbb_to.Items.Add(item);
            }
        }

        public DIVISION_NAME getfrom()
        {
            return new DIVISION_NAME((cbb_from.SelectedItem as ComboboxItem).Text);
        }

        public DIVISION_NAME getto()
        {
            return new DIVISION_NAME((cbb_to.SelectedItem as ComboboxItem).Text);
        }

        public string getName()
        {
            return tbox_employeeName.Text;
        }
    }
}
