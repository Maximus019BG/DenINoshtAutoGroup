namespace CarCare;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
        Password = new System.Windows.Forms.Label();
        textBox1 = new System.Windows.Forms.TextBox();
        Submit = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // Password
        // 
        Password.Font = new System.Drawing.Font("Dubai Medium", 24F);
        Password.ForeColor = System.Drawing.SystemColors.ButtonFace;
        Password.Location = new System.Drawing.Point(243, 17);
        Password.Name = "Password";
        Password.Size = new System.Drawing.Size(333, 75);
        Password.TabIndex = 0;
        Password.Text = "Password";
        Password.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        Password.Click += label1_Click_1;
        // 
        // textBox1
        // 
        textBox1.BackColor = System.Drawing.Color.FromArgb(((int)((byte)34)), ((int)((byte)34)), ((int)((byte)34)));
        textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
        textBox1.ForeColor = System.Drawing.Color.White;
        textBox1.Location = new System.Drawing.Point(243, 126);
        textBox1.Name = "textBox1";
        textBox1.Size = new System.Drawing.Size(343, 16);
        textBox1.TabIndex = 1;
        textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        textBox1.UseWaitCursor = true;
        textBox1.TextChanged += textBox1_TextChanged_1;
        // 
        // Submit
        // 
        Submit.Cursor = System.Windows.Forms.Cursors.Hand;
        Submit.Font = new System.Drawing.Font("Segoe UI Black", 9F);
        Submit.Location = new System.Drawing.Point(290, 198);
        Submit.Name = "Submit";
        Submit.Size = new System.Drawing.Size(252, 47);
        Submit.TabIndex = 2;
        Submit.Text = "Submit";
        Submit.UseVisualStyleBackColor = true;
        Submit.Click += button1_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.FromArgb(((int)((byte)24)), ((int)((byte)24)), ((int)((byte)24)));
        BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(Submit);
        Controls.Add(textBox1);
        Controls.Add(Password);
        Cursor = System.Windows.Forms.Cursors.Hand;
        Text = "CarCare";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Button Submit;

    private System.Windows.Forms.TextBox textBox1;

    private System.Windows.Forms.Label Password;

    #endregion
}