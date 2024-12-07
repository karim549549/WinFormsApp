using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WinFormsApp1.WinForms
{
    public partial class HomePageForm : Form
    {
        public HomePageForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true; 
        }

        private void HomePageForm_Load(object sender, EventArgs e)
        {

            this.Text = "Home Page";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Size = new Size(800, 600); 

            
            this.Paint += new PaintEventHandler(HomePageForm_Paint);

 
            InitializeSidebar();
            InitializeSearchBar();
        }

        
        private void InitializeSidebar()
        {
            int sidebarWidth = 200;
            Panel sidebarPanel = new Panel();
            sidebarPanel.Size = new Size(sidebarWidth, this.ClientSize.Height);
            sidebarPanel.Location = new Point(0, 0);
            sidebarPanel.BackColor = Color.MidnightBlue;
            this.Controls.Add(sidebarPanel);

 
            Button btnAddWord = CreateSidebarButton("Add Word", new Point(0, 100));
            btnAddWord.Click += (sender, e) => OpenAddWordForm();
            sidebarPanel.Controls.Add(btnAddWord);

            Button btnUpdateWord = CreateSidebarButton("Update Word", new Point(0, 150));
            btnUpdateWord.Click += (sender, e) => OpenUpdateWordForm();
            sidebarPanel.Controls.Add(btnUpdateWord);

            Button btnDeleteWord = CreateSidebarButton("Delete Word", new Point(0, 200));
            btnDeleteWord.Click += (sender, e) => OpenDeleteWordForm();
            sidebarPanel.Controls.Add(btnDeleteWord);
        }


        private Button CreateSidebarButton(string text, Point location)
        {
            Button btn = new Button();
            btn.Text = text;
            btn.Font = new Font("Arial", 12, FontStyle.Regular);
            btn.ForeColor = Color.White;
            btn.BackColor = Color.Transparent;
            btn.FlatStyle = FlatStyle.Flat;
            btn.Size = new Size(200, 40);
            btn.Location = location;
            btn.FlatAppearance.BorderSize = 0; 
            return btn;
        }


        private void InitializeSearchBar()
        {
            int sidebarWidth = 200;
            int padding = 20;

            TextBox txtSearch = new TextBox();
            txtSearch.Name = "txtSearch";
            txtSearch.Font = new Font("Arial", 12, FontStyle.Regular);
            txtSearch.Location = new Point(sidebarWidth + padding, 50);
            txtSearch.Width = 400;
            this.Controls.Add(txtSearch);

            Button btnSearch = new Button();
            btnSearch.Text = "Search";
            btnSearch.Font = new Font("Arial", 12, FontStyle.Regular);
            btnSearch.Location = new Point(txtSearch.Right + 10, 50);
            btnSearch.Size = new Size(100, 30);
            btnSearch.Click += (sender, e) => PerformSearch(txtSearch.Text);
            this.Controls.Add(btnSearch);
        }

        private void PerformSearch(string query)
        {
            MessageBox.Show($"Searching for: {query}");

        }


        private void HomePageForm_Paint(object sender, PaintEventArgs e)
        {
            LinearGradientBrush gradientBrush = new LinearGradientBrush(
                this.ClientRectangle,
                Color.SkyBlue,  
                Color.MidnightBlue,  
                45f);  
            e.Graphics.FillRectangle(gradientBrush, this.ClientRectangle); 
        }


        private void OpenAddWordForm()
        {
            MessageBox.Show("Open Add Word Form");
           
            this.Hide();
            AddWordForm addWordForm = new AddWordForm();  
            addWordForm.ShowDialog();
            this.Show();
        }


        private void OpenUpdateWordForm()
        {
            MessageBox.Show("Open Update Word Form");
 
            this.Hide();
            UpdateWordForm updateWordForm = new UpdateWordForm();  
            updateWordForm.ShowDialog();
            this.Show();
        }


        private void OpenDeleteWordForm()
        {
            MessageBox.Show("Open Delete Word Form");

            this.Hide();
            DeleteWordForm deleteWordForm = new DeleteWordForm();  
            deleteWordForm.ShowDialog();
            this.Show();
        }
    }
}
