using System.Windows.Forms;

namespace Calculator
{
    partial class ItemEditForm
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
            this.DCStabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ATSdataGridView = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.CIdataGridView = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ATPdataGridView = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.DCSdataGridView = new System.Windows.Forms.DataGridView();
            this.Confirmbutton = new System.Windows.Forms.Button();
            this.Cancelbutton = new System.Windows.Forms.Button();
            this.DCStabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ATSdataGridView)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CIdataGridView)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ATPdataGridView)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DCSdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // DCStabControl
            // 
            this.DCStabControl.Controls.Add(this.tabPage1);
            this.DCStabControl.Controls.Add(this.tabPage2);
            this.DCStabControl.Controls.Add(this.tabPage3);
            this.DCStabControl.Controls.Add(this.tabPage4);
            this.DCStabControl.Location = new System.Drawing.Point(10, 8);
            this.DCStabControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DCStabControl.Name = "DCStabControl";
            this.DCStabControl.SelectedIndex = 0;
            this.DCStabControl.Size = new System.Drawing.Size(510, 205);
            this.DCStabControl.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ATSdataGridView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(502, 179);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ATS";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ATSdataGridView
            // 
            this.ATSdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ATSdataGridView.Location = new System.Drawing.Point(1, 1);
            this.ATSdataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ATSdataGridView.Name = "ATSdataGridView";
            this.ATSdataGridView.RowHeadersVisible = false;
            this.ATSdataGridView.RowTemplate.Height = 25;
            this.ATSdataGridView.Size = new System.Drawing.Size(502, 183);
            this.ATSdataGridView.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.CIdataGridView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(502, 179);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "联锁";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // CIdataGridView
            // 
            this.CIdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CIdataGridView.Location = new System.Drawing.Point(-2, 1);
            this.CIdataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CIdataGridView.Name = "CIdataGridView";
            this.CIdataGridView.RowHeadersVisible = false;
            this.CIdataGridView.RowTemplate.Height = 25;
            this.CIdataGridView.Size = new System.Drawing.Size(502, 180);
            this.CIdataGridView.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ATPdataGridView);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage3.Size = new System.Drawing.Size(502, 179);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "ATP";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // ATPdataGridView
            // 
            this.ATPdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ATPdataGridView.Location = new System.Drawing.Point(1, 2);
            this.ATPdataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ATPdataGridView.Name = "ATPdataGridView";
            this.ATPdataGridView.RowHeadersVisible = false;
            this.ATPdataGridView.RowTemplate.Height = 25;
            this.ATPdataGridView.Size = new System.Drawing.Size(500, 179);
            this.ATPdataGridView.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.DCSdataGridView);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage4.Size = new System.Drawing.Size(502, 179);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "DCS";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // DCSdataGridView
            // 
            this.DCSdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DCSdataGridView.Location = new System.Drawing.Point(2, 1);
            this.DCSdataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DCSdataGridView.Name = "DCSdataGridView";
            this.DCSdataGridView.RowHeadersVisible = false;
            this.DCSdataGridView.RowTemplate.Height = 25;
            this.DCSdataGridView.Size = new System.Drawing.Size(496, 181);
            this.DCSdataGridView.TabIndex = 0;
            // 
            // Confirmbutton
            // 
            this.Confirmbutton.Location = new System.Drawing.Point(52, 222);
            this.Confirmbutton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Confirmbutton.Name = "Confirmbutton";
            this.Confirmbutton.Size = new System.Drawing.Size(64, 24);
            this.Confirmbutton.TabIndex = 2;
            this.Confirmbutton.Text = "确定";
            this.Confirmbutton.UseVisualStyleBackColor = true;
            this.Confirmbutton.Click += new System.EventHandler(this.Confirmbutton_Click);
            // 
            // Cancelbutton
            // 
            this.Cancelbutton.Location = new System.Drawing.Point(399, 222);
            this.Cancelbutton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Cancelbutton.Name = "Cancelbutton";
            this.Cancelbutton.Size = new System.Drawing.Size(64, 24);
            this.Cancelbutton.TabIndex = 3;
            this.Cancelbutton.Text = "取消";
            this.Cancelbutton.UseVisualStyleBackColor = true;
            // 
            // ItemEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 267);
            this.Controls.Add(this.Cancelbutton);
            this.Controls.Add(this.Confirmbutton);
            this.Controls.Add(this.DCStabControl);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ItemEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ItemEditForm";
            this.Load += new System.EventHandler(this.ItemEditForm_Load);
            this.DCStabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ATSdataGridView)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CIdataGridView)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ATPdataGridView)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DCSdataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl DCStabControl;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private DataGridView ATSdataGridView;
        private DataGridView CIdataGridView;
        private DataGridView ATPdataGridView;
        private DataGridView DCSdataGridView;
        private Button Confirmbutton;
        private Button Cancelbutton;
    }
}