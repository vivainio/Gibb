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
            this.statusList.Items.Clear();
            foreach (var status in _gitModel.StatusLines)
            {
                this.statusList.Items.Add(status);
            }
        }

        void SelectBranch(string branchName)
        {
            _gitModel.CheckoutBranch(branchName);
            UpdateStatusList();

        }

        void StatusLineActivated(string statusLine, Keys? key)
        {
            if (String.IsNullOrWhiteSpace(statusLine))
            {
                return;
            }
            var fname = statusLine.Substring(3);
            if (key == null)
            {
                var diff =  _gitModel.GetDiff(fname).Replace("\n", "\r\n");
                this.textArea.Text = diff;
                return;
            }
            void update()
            {
                _gitModel.UpdateStatus();
                UpdateStatusList();
            }
            if (key == Keys.S)
            {
                // STAGE
                _gitModel.FileStage(fname);
                update();
            }
            if (key == Keys.U)
            {
                _gitModel.FileUnstage(fname);
                update();
            }

        }        
       
        void BindEvents()
        {
            this.quickFilter.TextChanged += (o,e) =>  UpdateBranches();
            this.branchList.KeyDown += (o,e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    var bn = this.branchList.SelectedItem as string;
                    this.textArea.Text = "Checking out: " + bn;
                    SelectBranch(bn);
                    var status = _gitModel.RunGit("status");
                    this.textArea.Text = string.Join("\r\n", status);
                }

            };
            this.statusList.SelectedIndexChanged += (o,e) =>
            {
                var curItem = this.statusList.SelectedItem as string;
                StatusLineActivated(curItem, null);
            };

            this.statusList.KeyDown += (o,e) =>
            {
                var curItem = this.statusList.SelectedItem as string;
                StatusLineActivated(curItem, e.KeyCode);
            };
               
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var path = "c:/r/1";
            _gitModel.Populate(path);
            UpdateBranches();
            UpdateStatusList();
            BindEvents();
        }
    }
}
