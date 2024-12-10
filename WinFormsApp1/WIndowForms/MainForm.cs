using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static Dictionary; // Reference to your F# namespace

namespace WinFormsApp1.WIndowForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            
            mainContentPanel.Controls.Clear();

           
            Label lblTitle = new Label
            {
                Text = "Welcome to My Dictionary App",
                Font = new Font("Arial", 18, FontStyle.Bold),
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter,
                Padding = new Padding(10)
            };
            mainContentPanel.Controls.Add(lblTitle);

            
            TextBox txtSearch = new TextBox
            {
                PlaceholderText = "Enter word to search...",
                Font = new Font("Arial", 12),
                Dock = DockStyle.Top,
                Margin = new Padding(10),
                Height = 30
            };
            mainContentPanel.Controls.Add(txtSearch);

           
            Button btnSearch = new Button
            {
                Text = "Search",
                Font = new Font("Arial", 12),
                Dock = DockStyle.Top,
                Height = 40,
                Margin = new Padding(10)
            };
            mainContentPanel.Controls.Add(btnSearch);

            // Event handler for the search button click
            btnSearch.Click += (s, args) =>
            {
                string word = txtSearch.Text;

                if (!string.IsNullOrWhiteSpace(word))
                {
                    string result = Dictionary.searchWord(word);

                    if (string.IsNullOrEmpty(result))
                    {
                        MessageBox.Show($"'{word}' not found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"'{word}' means: {result}", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a word to search.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            mainContentPanel.Controls.Clear();

           
            Label lblWord = new Label
            {
                Text = "Word:",
                Font = new Font("Arial", 12),
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(10)
            };
            mainContentPanel.Controls.Add(lblWord);

            
            TextBox txtWord = new TextBox
            {
                Font = new Font("Arial", 12),
                Dock = DockStyle.Top,
                Margin = new Padding(10),
                Height = 30
            };
            mainContentPanel.Controls.Add(txtWord);

            
            Label lblTranslation = new Label
            {
                Text = "Translation:",
                Font = new Font("Arial", 12),
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(10)
            };
            mainContentPanel.Controls.Add(lblTranslation);

            
            TextBox txtTranslation = new TextBox
            {
                Font = new Font("Arial", 12),
                Dock = DockStyle.Top,
                Margin = new Padding(10),
                Height = 30
            };
            mainContentPanel.Controls.Add(txtTranslation);

            
            Button btnAdd = new Button
            {
                Text = "Add",
                Font = new Font("Arial", 12),
                Dock = DockStyle.Top,
                Height = 40,
                Margin = new Padding(10)
            };
            mainContentPanel.Controls.Add(btnAdd);

            
            Button btnSave = new Button
            {
                Text = "Save to JSON",
                Font = new Font("Arial", 12),
                Dock = DockStyle.Top,
                Height = 40,
                Margin = new Padding(10)
            };
            mainContentPanel.Controls.Add(btnSave);

            
            btnAdd.Click += (s, args) =>
            {
                string word = txtWord.Text;
                string translation = txtTranslation.Text;

                if (!string.IsNullOrWhiteSpace(word) && !string.IsNullOrWhiteSpace(translation))
                {
                    Dictionary.addWord(word, translation);
                    MessageBox.Show($"Added: {word} -> {translation}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please fill out both fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };

            
            btnSave.Click += (s, args) =>
            {
                string filePath = "dictionary.json";
                Dictionary.saveToJson(filePath);
                MessageBox.Show($"Dictionary saved to {filePath}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            mainContentPanel.Controls.Clear();

           
            Label lblDeleteWord = new Label
            {
                Text = "Word to Delete:",
                Font = new Font("Arial", 12),
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(10)
            };
            mainContentPanel.Controls.Add(lblDeleteWord);

           
            TextBox txtDeleteWord = new TextBox
            {
                Font = new Font("Arial", 12),
                Dock = DockStyle.Top,
                Margin = new Padding(10),
                Height = 30
            };
            mainContentPanel.Controls.Add(txtDeleteWord);

           
            Button btnDelete = new Button
            {
                Text = "Delete",
                Font = new Font("Arial", 12),
                Dock = DockStyle.Top,
                Height = 40,
                Margin = new Padding(10)
            };
            mainContentPanel.Controls.Add(btnDelete);

            
            btnDelete.Click += (s, args) =>
            {
                string wordToDelete = txtDeleteWord.Text;

                if (!string.IsNullOrWhiteSpace(wordToDelete))
                {
                    Dictionary.deleteWord(wordToDelete);
                    MessageBox.Show($"Deleted: {wordToDelete}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please enter a word to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mainContentPanel.Controls.Clear();

            
            Label lblUpdateWord = new Label
            {
                Text = "Word to Update:",
                Font = new Font("Arial", 12),
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(10)
            };
            mainContentPanel.Controls.Add(lblUpdateWord);

           
            TextBox txtUpdateWord = new TextBox
            {
                Font = new Font("Arial", 12),
                Dock = DockStyle.Top,
                Margin = new Padding(10),
                Height = 30
            };
            mainContentPanel.Controls.Add(txtUpdateWord);

           
            Label lblNewTranslation = new Label
            {
                Text = "New Translation:",
                Font = new Font("Arial", 12),
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(10)
            };
            mainContentPanel.Controls.Add(lblNewTranslation);

           
            TextBox txtNewTranslation = new TextBox
            {
                Font = new Font("Arial", 12),
                Dock = DockStyle.Top,
                Margin = new Padding(10),
                Height = 30
            };
            mainContentPanel.Controls.Add(txtNewTranslation);

           
            Button btnUpdate = new Button
            {
                Text = "Update",
                Font = new Font("Arial", 12),
                Dock = DockStyle.Top,
                Height = 40,
                Margin = new Padding(10)
            };
            mainContentPanel.Controls.Add(btnUpdate);

            
            btnUpdate.Click += (s, args) =>
            {
                string wordToUpdate = txtUpdateWord.Text;
                string newTranslation = txtNewTranslation.Text;

                if (!string.IsNullOrWhiteSpace(wordToUpdate) && !string.IsNullOrWhiteSpace(newTranslation))
                {
                    Dictionary.updateWord(wordToUpdate, newTranslation);
                    MessageBox.Show($"Updated: {wordToUpdate} -> {newTranslation}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please fill out both fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };
        }
    }
}
