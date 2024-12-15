using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static Dictionary;
using Microsoft.FSharp.Collections;
using Microsoft.FSharp.Core;

namespace WinFormsApp1.WIndowForms
{
    public partial class MainForm : Form
    {
        private TextBox dictionaryDisplay;

        public MainForm()
        {
            InitializeComponent();
            InitializeDictionaryDisplay();
            UpdateDictionaryDisplay();
        }

        private void InitializeDictionaryDisplay()
        {
            dictionaryDisplay = new TextBox
            {
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                ReadOnly = true,
                Dock = DockStyle.Fill,
                Font = new Font("Arial", 12),
                BackColor = Color.White,
                Size = new Size(400, 300)
            };
            UpdateDictionaryDisplay();
        }

        private void UpdateDictionaryDisplay()
        {
            FSharpMap<string, FSharpOption<string>> dictionary = Dictionary.dictionary;
            var items = MapModule.ToArray(dictionary);

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine("Dictionary Contents:");
            sb.AppendLine("-----------------------");
            foreach (var item in items)
            {
                string key = item.Item1;
                string value = item.Item2 != null ? item.Item2.Value : "No Meaning";
                sb.AppendLine(key.ToString() + " : " + value.ToString());
            }


            dictionaryDisplay.Text = sb.ToString();
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
                Margin = new Padding(10),
                BackColor = Color.DodgerBlue

            };
            mainContentPanel.Controls.Add(btnSearch);

            Panel resultPanel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };
            mainContentPanel.Controls.Add(resultPanel);
            btnSearch.Click += (s, args) =>
            {
                string word = txtSearch.Text;
                if (!string.IsNullOrWhiteSpace(word))
                {
                    string result = Dictionary.searchWord(word);
                    MessageBox.Show(result, "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            TableLayoutPanel layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                Padding = new Padding(10)
            };

            Panel inputPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 250
            };

            Label lblWord = new Label
            {
                Text = "Word:",
                Font = new Font("Arial", 12),
                Dock = DockStyle.Top,
                Padding = new Padding(10)
            };
            inputPanel.Controls.Add(lblWord);

            TextBox txtWord = new TextBox
            {
                PlaceholderText = "Enter Your Word Here ... ",
                Font = new Font("Arial", 12),
                Dock = DockStyle.Top,
                Height = 30,
                Margin = new Padding(10)
            };
            inputPanel.Controls.Add(txtWord);

            Label lblTranslation = new Label
            {
                Text = "Translation:",
                Font = new Font("Arial", 12),
                Dock = DockStyle.Top,
                Padding = new Padding(10)
            };
            inputPanel.Controls.Add(lblTranslation);

            TextBox txtTranslation = new TextBox
            {
                PlaceholderText = "Enter The Translation Here ...",
                Font = new Font("Arial", 12),
                Dock = DockStyle.Top,
                Height = 30,
                Margin = new Padding(10)
            };
            inputPanel.Controls.Add(txtTranslation);

            Button btnAdd = new Button
            {
                Text = "Add",
                Font = new Font("Arial", 12),
                Dock = DockStyle.Top,
                Height = 40,
                Margin = new Padding(10),
                BackColor = Color.DodgerBlue
            };
            inputPanel.Controls.Add(btnAdd);

            Button btnSave = new Button
            {
                Text = "Save to JSON",
                Font = new Font("Arial", 12),
                Dock = DockStyle.Top,
                Height = 40,
                Margin = new Padding(10),
                BackColor = Color.FromArgb(161, 245, 39)
            };
            inputPanel.Controls.Add(btnSave);

            layout.Controls.Add(inputPanel, 0, 0);
            layout.Controls.Add(dictionaryDisplay, 0, 1);
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            mainContentPanel.Controls.Add(layout);

            btnAdd.Click += (s, args) =>
            {
                string word = txtWord.Text;
                string translation = txtTranslation.Text;

                if (!string.IsNullOrWhiteSpace(word) && !string.IsNullOrWhiteSpace(translation))
                {
                    Dictionary.addWord(word, translation);
                    UpdateDictionaryDisplay();
                    txtWord.Clear();
                    txtTranslation.Clear();
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

            TableLayoutPanel layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                Padding = new Padding(10)
            };

            Panel deletePanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 150
            };

            Label lblDeleteWord = new Label
            {
                Text = "Word to Delete:",
                Font = new Font("Arial", 12),
                Dock = DockStyle.Top,
                Padding = new Padding(10)
            };
            deletePanel.Controls.Add(lblDeleteWord);

            TextBox txtDeleteWord = new TextBox
            {
                PlaceholderText = "Enter The Word To Delete Here ...",

                Font = new Font("Arial", 12),
                Dock = DockStyle.Top,
                Height = 30,
                Margin = new Padding(10)
            };
            deletePanel.Controls.Add(txtDeleteWord);

            Button btnDelete = new Button
            {
                Text = "Delete",
                Font = new Font("Arial", 12),
                Dock = DockStyle.Top,
                Height = 40,
                Margin = new Padding(10),
                BackColor = Color.Red

            };
            deletePanel.Controls.Add(btnDelete);

            layout.Controls.Add(deletePanel, 0, 0);
            layout.Controls.Add(dictionaryDisplay, 0, 1);
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            mainContentPanel.Controls.Add(layout);

            btnDelete.Click += (s, args) =>
            {
                string wordToDelete = txtDeleteWord.Text;
                if (!string.IsNullOrWhiteSpace(wordToDelete))
                {
                    Dictionary.deleteWord(wordToDelete);
                    UpdateDictionaryDisplay();
                    txtDeleteWord.Clear();
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

            TableLayoutPanel layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                Padding = new Padding(10)
            };

            Panel updatePanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 200
            };

            Label lblUpdateWord = new Label
            {
                Text = "Word to Update:",
                Font = new Font("Arial", 12),
                Dock = DockStyle.Top,
                Padding = new Padding(10)
            };
            updatePanel.Controls.Add(lblUpdateWord);

            TextBox txtUpdateWord = new TextBox
            {
                PlaceholderText = "Enter The Word Here ...",

                Font = new Font("Arial", 12),
                Dock = DockStyle.Top,
                Height = 30,
                Margin = new Padding(10)
            };
            updatePanel.Controls.Add(txtUpdateWord);

            Label lblNewTranslation = new Label
            {
                Text = "New Translation:",
                Font = new Font("Arial", 12),
                Dock = DockStyle.Top,
                Padding = new Padding(10)
            };
            updatePanel.Controls.Add(lblNewTranslation);

            TextBox txtNewTranslation = new TextBox
            {
                PlaceholderText = "Enter The New Translation Here ...",
                Font = new Font("Arial", 12),
                Dock = DockStyle.Top,
                Height = 30,
                Margin = new Padding(10)
            };
            updatePanel.Controls.Add(txtNewTranslation);

            Button btnUpdate = new Button
            {
                Text = "Update",
                Font = new Font("Arial", 12),
                Dock = DockStyle.Top,
                Height = 40,
                Margin = new Padding(10),
                BackColor = Color.DodgerBlue

            };
            updatePanel.Controls.Add(btnUpdate);

            layout.Controls.Add(updatePanel, 0, 0);
            layout.Controls.Add(dictionaryDisplay, 0, 1);
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            mainContentPanel.Controls.Add(layout);

            btnUpdate.Click += (s, args) =>
            {
                string wordToUpdate = txtUpdateWord.Text;
                string newTranslation = txtNewTranslation.Text;

                if (!string.IsNullOrWhiteSpace(wordToUpdate) && !string.IsNullOrWhiteSpace(newTranslation))
                {
                    Dictionary.updateWord(wordToUpdate, newTranslation);
                    UpdateDictionaryDisplay();
                    txtUpdateWord.Clear();
                    txtNewTranslation.Clear();
                    MessageBox.Show($"Updated: {wordToUpdate} -> {newTranslation}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please fill out both fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };
        }

        private void button1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mainContentPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mainContentPanel_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}