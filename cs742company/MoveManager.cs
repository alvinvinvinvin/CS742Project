using cs742company.SpecificationCode;
using System.Collections.Generic;
using System.Windows.Forms;

namespace cs742company
{
    public partial class MoveManager : Form
    {
        public HashSet<Division> divisions {get;set;}
        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }
        public MoveManager()
        {
            InitializeComponent();
        }

        public MoveManager(HashSet<Division> input)
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
    }
}
