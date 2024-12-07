using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WinFormsApp1.WinForms
{
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();
        }

        private void WelcomeForm_Load(object sender, EventArgs e)
        {
            
            this.Text = "Online Quiz Platform";   
            this.Padding = new Padding(10);
            
            Label lblTitle = new Label();
            lblTitle.Text = "Welcome to our Online Quiz Platform";
            lblTitle.Font = new Font("Arial", 18, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.BackColor = Color.MidnightBlue;  
            lblTitle.AutoSize = true;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter; 
            lblTitle.Padding = new Padding(10);  
            lblTitle.Location = new Point(100, 100);  
            this.Controls.Add(lblTitle);  

            Label lblPressKey = new Label();
            lblPressKey.Text = "Press any key to continue";
            lblPressKey.Font = new Font("Arial", 12, FontStyle.Italic);
            lblPressKey.ForeColor = Color.White;
            lblPressKey.AutoSize = true;
            lblPressKey.TextAlign = ContentAlignment.MiddleCenter;  
            lblPressKey.Location = new Point(180, 250);  
            lblPressKey.BackColor = Color.Transparent;  
            this.Controls.Add(lblPressKey); 

            
            foreach (Control control in this.Controls)
            {
                control.Location = new Point(control.Location.X + 20, control.Location.Y + 20);  
            }

            
            this.Paint += new PaintEventHandler(WelcomeForm_Paint);  

            this.KeyDown += new KeyEventHandler(WelcomeForm_KeyDown); 
        }


        private void WelcomeForm_Paint(object sender, PaintEventArgs e)
        {
            LinearGradientBrush gradientBrush = new LinearGradientBrush(
                this.ClientRectangle,
                Color.SkyBlue,  
                Color.MidnightBlue,  
                45f); 
            e.Graphics.FillRectangle(gradientBrush, this.ClientRectangle);  
        }

        private void WelcomeForm_KeyDown(object sender, KeyEventArgs e)
        {
            this.Hide();
            Form1 loginForm = new Form1();
            loginForm.ShowDialog();
        }
    }
}
