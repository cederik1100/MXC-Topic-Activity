using System.Windows;
using Microsoft.Win32;
using ClosedXML.Excel;
using System.IO;
using System.Data;
using DocumentFormat.OpenXml.Spreadsheet;
using System.DirectoryServices;

namespace MCX_Topics
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string selectedFilePath;
        List<TopicData> topicDataList = new List<TopicData>();


        public MainWindow()
        {
            InitializeComponent();
        }

        private void BTUpload_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Multiselect = true,
                Filter = "Excel Files|*.xlsx;*.xls",
                Title = "Select a File"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string[] selectedFileNames = openFileDialog.FileNames;
                string uploadDirectory = AppDomain.CurrentDomain.BaseDirectory + @"Uploads";

                if (!Directory.Exists(uploadDirectory))
                {
                    Directory.CreateDirectory(uploadDirectory);
                }

                foreach (string fileName in selectedFileNames)
                {
                    string file = Path.GetFileName(fileName); // Extract file name
                    string destinationPath = Path.Combine(uploadDirectory, file);

                    if (ListBoxUploaded.Items.Contains(file))
                    {
                        MessageBox.Show("File already uploaded.");
                        return;
                    }

                    ListBoxUploaded.Items.Add(file);

                    try
                    {
                        File.Copy(fileName, destinationPath, true);
                        MessageBox.Show("File uploaded successfully: " + file);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error copying file: " + ex.Message);
                    }
                }
            }
        }

       

        private void BTCheck_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxUploaded.SelectedItem == null)
            {
                MessageBox.Show("Please select a file from the uploaded list.");
                return;
            }

            // Clear previous items
            ListBoxTopics.Items.Clear();

            // Get the selected file name
            string selectedFileName = ListBoxUploaded.SelectedItem.ToString();
            string uploadDirectory = AppDomain.CurrentDomain.BaseDirectory + @"Uploads";
            selectedFilePath = Path.Combine(uploadDirectory, selectedFileName); // Store file path globally

            if (!File.Exists(selectedFilePath))
            {
                MessageBox.Show("File not found in Uploads folder.");
                return;
            }

            try
            {
                using (var workbook = new XLWorkbook(selectedFilePath))
                {
                    var worksheet = workbook.Worksheets.FirstOrDefault();

                    if (worksheet == null)
                    {
                        MessageBox.Show("No worksheet found in the file.");
                        return;
                    }

                    // Validate headers
                    string[] expectedHeaders = { "Code", "Topic", "Description", "How to Use", "When to Use", "Other" };
                    for (int col = 1; col <= expectedHeaders.Length; col++)
                    {
                        if (worksheet.Cell(1, col).GetString() != expectedHeaders[col - 1])
                        {
                            MessageBox.Show($"Invalid file format. Expected column {col} to be '{expectedHeaders[col - 1]}'.");
                            return;
                        }
                    }

                    ListBoxTopics.Items.Clear();
                    ListBoxTopics.DisplayMemberPath = "FormattedDisplay";

                    

                    // Read data
                    for (int row = 2; row <= worksheet.LastRowUsed().RowNumber(); row++)
                    {
                        string code = worksheet.Cell(row, 1).GetString();
                        string topic = worksheet.Cell(row, 2).GetString();
                        string description = worksheet.Cell(row, 3).GetString();
                        string howToUse = worksheet.Cell(row, 4).GetString();
                        string whenToUse = worksheet.Cell(row, 5).GetString();
                        string others = worksheet.Cell(row, 6).GetString();

                        TopicData topicData = new TopicData(code, topic, description, howToUse, whenToUse, others);

                        topicDataList.Add(topicData);
                        // Add to ListBoxTopics
                        ListBoxTopics.Items.Add(topicData); // Store TopicData object instead of a formatted string

                    }

                    DataCount.Text = ListBoxTopics.Items.Count.ToString();
                    MessageBox.Show("Data loaded successfully.");   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading file: " + ex.Message);
            }
        }



        private void BTSearch_Click(object sender, RoutedEventArgs e)
        {
            string search = TBSearch.Text.Trim();

            if (string.IsNullOrEmpty(search))
            {
                MessageBox.Show("Please enter a search term.");
                return;
            }

            if (topicDataList == null || topicDataList.Count == 0)
            {
                MessageBox.Show("No data loaded. Please upload and check a file first.");
                return;
            }

            try
            {
                // Perform case-insensitive search in the Topic and Description fields
                var searchResult = topicDataList
                    .Where(t => t.Topic.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                                t.Description.Contains(search, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                // Update ListBox with filtered results
                ListBoxTopics.Items.Clear();
                foreach (var topic in searchResult)
                {
                    ListBoxTopics.Items.Add(topic);
                }

                DataCount.Text = searchResult.Count.ToString();

                if (searchResult.Count == 0)
                {
                    MessageBox.Show("No matching results found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching file: {ex.Message}");
            }
        }


        public class TopicData
        {
            public string Code { get; set; }
            public string Topic { get; set; }
            public string Description { get; set; }
            public string HowToUse { get; set; }
            public string WhenToUse { get; set; }
            public string Others { get; set; }
            
            public TopicData( string code, string topic, string description, string howToUse, string whenToUse, string others)
            {
                   Code = code;
                   Topic = topic;
                   Description = description;
                   HowToUse = howToUse;
                   WhenToUse = whenToUse;
                   Others = others;
            }

            public string FormattedDisplay => $"{Topic}\nDescription: {Description}"; 


        }


        private void BTDelete_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxUploaded.SelectedItem != null)
            {
                ListBoxUploaded.Items.Remove(ListBoxUploaded.SelectedItem);
                ListBoxTopics.Items.Clear();
                selectedFilePath = string.Empty; 
            }
            else
            {
                MessageBox.Show("Please select an item to delete.");
            }
        }

        private void ListBoxTopics_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ListBoxTopics.SelectedItem is TopicData selectedRow)
            {
                Window1 window1 = new Window1();
                window1.TxtCode.Text = selectedRow.Code;
                window1.TxtTopic.Text = selectedRow.Topic;
                window1.TxtDecription.Text = selectedRow.Description;
                window1.TxtHowToUse.Text = selectedRow.HowToUse;
                window1.TxtWhenToUse.Text = selectedRow.WhenToUse;
                window1.TxtOthers.Text = selectedRow.Others;
                window1.Show();
            }
        }


        private void BTClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); 
        }
    }
}
