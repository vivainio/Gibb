namespace Gibb
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.branchList = new System.Windows.Forms.ListBox();
            this.statusList = new System.Windows.Forms.ListBox();
            this.quickFilter = new System.Windows.Forms.TextBox();
            this.textArea = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            //
            // branchList
            //
            this.branchList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.branchList.FormattingEnabled = true;
            this.branchList.ItemHeight = 16;
            this.branchList.Location = new System.Drawing.Point(1, 33);
            this.branchList.Name = "branchList";
            this.branchList.Size = new System.Drawing.Size(516, 532);
            this.branchList.TabIndex = 0;
            //
            // statusList
            //
            this.statusList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusList.FormattingEnabled = true;
            this.statusList.ItemHeight = 16;
            this.statusList.Location = new System.Drawing.Point(523, 1);
            this.statusList.Name = "statusList";
            this.statusList.Size = new System.Drawing.Size(417, 324);
            this.statusList.TabIndex = 1;
            //
            // quickFilter
            //
            this.quickFilter.Location = new System.Drawing.Point(1, 5);
            this.quickFilter.Name = "quickFilter";
            this.quickFilter.Size = new System.Drawing.Size(516, 22);
            this.quickFilter.TabIndex = 2;
            //
            // textArea
            //
            this.textArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textArea.Location = new System.Drawing.Point(527, 332);
            this.textArea.Multiline = true;
            this.textArea.Name = "textArea";
            this.textArea.Size = new System.Drawing.Size(412, 237);
            this.textArea.TabIndex = 3;
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 565);
            this.Controls.Add(this.textArea);
            this.Controls.Add(this.quickFilter);
            this.Controls.Add(this.statusList);
            this.Controls.Add(this.branchList);
            this.Name = "Form1";
            this.Text = "Gibb";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox branchList;
        private System.Windows.Forms.ListBox statusList;
        private System.Windows.Forms.TextBox quickFilter;
        private System.Windows.Forms.TextBox textArea;
    }
}

