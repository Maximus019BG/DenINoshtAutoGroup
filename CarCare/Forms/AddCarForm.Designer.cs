using System;
using System.Windows.Forms;

namespace CarCare
{
    partial class AddCarForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtReg, txtBrand, txtModel, txtProblem, txtName, txtPhone;
        private Label lblReg, lblBrand, lblModel, lblProblem, lblName, lblPhone;
        private Button btnOK;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtReg = new TextBox();
            this.txtBrand = new TextBox();
            this.txtModel = new TextBox();
            this.txtProblem = new TextBox();
            this.txtName = new TextBox();
            this.txtPhone = new TextBox();
        
            this.lblReg = new Label();
            this.lblBrand = new Label();
            this.lblModel = new Label();
            this.lblProblem = new Label();
            this.lblName = new Label();
            this.lblPhone = new Label();
        
            this.btnOK = new Button();
        
            int leftLabel = 20, leftInput = 150, top = 20, spacing = 30;
        
            void Setup(Label label, TextBox textBox, string text, int i)
            {
                label.Text = text;
                label.Location = new System.Drawing.Point(leftLabel, top + i * spacing);
                label.AutoSize = true;
                label.ForeColor = System.Drawing.Color.White; 
        
                textBox.Location = new System.Drawing.Point(leftInput, top + i * spacing);
                textBox.Width = 200;
                textBox.BackColor = System.Drawing.Color.FromArgb(45, 45, 45); 
                textBox.ForeColor = System.Drawing.Color.White; 
                textBox.BorderStyle = BorderStyle.FixedSingle;
            }
        
            Setup(lblReg, txtReg, "Registration Number:", 0);
            Setup(lblBrand, txtBrand, "Brand:", 1);
            Setup(lblModel, txtModel, "Model:", 2);
            Setup(lblProblem, txtProblem, "Problem:", 3);
            Setup(lblName, txtName, "Client Name:", 4);
            Setup(lblPhone, txtPhone, "Client Phone:", 5);
        
            btnOK.Text = "Add Car";
            btnOK.Location = new System.Drawing.Point(leftInput, top + 6 * spacing);
            btnOK.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
            btnOK.ForeColor = System.Drawing.Color.White; 
            btnOK.FlatStyle = FlatStyle.Flat;
            btnOK.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(30, 30, 30); 
            btnOK.Click += new System.EventHandler(this.btnOK_Click);
        
            this.Text = "Add New Car";
            this.ClientSize = new System.Drawing.Size(400, 250);
            this.BackColor = System.Drawing.Color.FromArgb(30, 30, 30); 
            this.Controls.AddRange(new Control[] {
                lblReg, txtReg, lblBrand, txtBrand, lblModel, txtModel, lblProblem, txtProblem,
                lblName, txtName, lblPhone, txtPhone, btnOK
            });
        }
    }
}
