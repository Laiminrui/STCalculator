using System.Windows.Forms;

namespace Calculator
{
    partial class CoefficientEditForm
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
            this.CoedataGridView = new System.Windows.Forms.DataGridView();
            this.Confirmbutton = new System.Windows.Forms.Button();
            this.Cancalbutton = new System.Windows.Forms.Button();
            this.Insertbutton = new System.Windows.Forms.Button();
            this.NewRowsbutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CoedataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // CoedataGridView
            // 
            this.CoedataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CoedataGridView.Location = new System.Drawing.Point(10, 8);
            this.CoedataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CoedataGridView.Name = "CoedataGridView";
            this.CoedataGridView.RowHeadersVisible = false;
            this.CoedataGridView.RowTemplate.Height = 25;
            this.CoedataGridView.Size = new System.Drawing.Size(503, 147);
            this.CoedataGridView.TabIndex = 0;
            // 
            // Confirmbutton
            // 
            this.Confirmbutton.Location = new System.Drawing.Point(12, 168);
            this.Confirmbutton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Confirmbutton.Name = "Confirmbutton";
            this.Confirmbutton.Size = new System.Drawing.Size(64, 30);
            this.Confirmbutton.TabIndex = 1;
            this.Confirmbutton.Text = "确定";
            this.Confirmbutton.UseVisualStyleBackColor = true;
            this.Confirmbutton.Click += new System.EventHandler(this.Confirmbutton_Click);
            // 
            // Cancalbutton
            // 
            this.Cancalbutton.Location = new System.Drawing.Point(157, 168);
            this.Cancalbutton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Cancalbutton.Name = "Cancalbutton";
            this.Cancalbutton.Size = new System.Drawing.Size(64, 30);
            this.Cancalbutton.TabIndex = 2;
            this.Cancalbutton.Text = "取消";
            this.Cancalbutton.UseVisualStyleBackColor = true;
            this.Cancalbutton.Click += new System.EventHandler(this.Cancalbutton_Click);
            // 
            // Insertbutton
            // 
            this.Insertbutton.Location = new System.Drawing.Point(302, 168);
            this.Insertbutton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Insertbutton.Name = "Insertbutton";
            this.Insertbutton.Size = new System.Drawing.Size(64, 30);
            this.Insertbutton.TabIndex = 3;
            this.Insertbutton.Text = "插入";
            this.Insertbutton.UseVisualStyleBackColor = true;
            // 
            // NewRowsbutton
            // 
            this.NewRowsbutton.Location = new System.Drawing.Point(447, 168);
            this.NewRowsbutton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NewRowsbutton.Name = "NewRowsbutton";
            this.NewRowsbutton.Size = new System.Drawing.Size(64, 30);
            this.NewRowsbutton.TabIndex = 4;
            this.NewRowsbutton.Text = "新建";
            this.NewRowsbutton.UseVisualStyleBackColor = true;
            this.NewRowsbutton.Click += new System.EventHandler(this.NewRowsbutton_Click);
            // 
            // CoefficientEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 209);
            this.Controls.Add(this.NewRowsbutton);
            this.Controls.Add(this.Insertbutton);
            this.Controls.Add(this.Cancalbutton);
            this.Controls.Add(this.Confirmbutton);
            this.Controls.Add(this.CoedataGridView);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "CoefficientEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CoefficientEditForm";
            this.Load += new System.EventHandler(this.CoefficientEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CoedataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView CoedataGridView;
        private Button Confirmbutton;
        private Button Cancalbutton;
        private Button Insertbutton;
        private Button NewRowsbutton;
    }
}