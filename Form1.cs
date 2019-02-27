using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gitz
{
    public partial class Form1 : Form
    {
        readonly GitModel _gitModel = new GitModel();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var path = "c:/p2p";
            _gitModel.Populate(path);
            foreach (var branch in _gitModel.Brances)
            {
                this.branchList.Items.Add(branch);
            }

            foreach (var status in _gitModel.StatusLines)
            {
                this.statusList.Items.Add(status);
            }
        }
    }
}
