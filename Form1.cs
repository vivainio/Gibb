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

        void UpdateBranches()
        {
            var filt = this.quickFilter.Text;
            this.branchList.Items.Clear();
            foreach (var branch in _gitModel.Brances)
            {
                if (!string.IsNullOrWhiteSpace(filt) && !branch.Contains(filt))
                {
                    continue;
                }
                this.branchList.Items.Add(branch);
            }
        }
        void UpdateStatusList()
        {
            foreach (var status in _gitModel.StatusLines)
            {
                this.statusList.Items.Add(status);
            }

        }

        void BindEvents()
        {
            this.quickFilter.TextChanged += (o,e) =>  UpdateBranches();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var path = "c:/p2p";
            _gitModel.Populate(path);
            UpdateBranches();
            UpdateStatusList();
            BindEvents();
        }
    }
}
