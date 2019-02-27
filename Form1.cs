﻿using System;
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

        void SelectBranch(string branchName)
        {
            // switch branch
            ;

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
            if (key == Keys.S)
            {
                // STAGE
                ;

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
                    SelectBranch(bn);
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
            var path = "c:/p2p";
            _gitModel.Populate(path);
            UpdateBranches();
            UpdateStatusList();
            BindEvents();
        }
    }
}
