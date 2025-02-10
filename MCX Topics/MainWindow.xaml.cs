using System.Windows;
using Microsoft.Win32;
using ClosedXML.Excel;
using System.IO;
using System.Data;
using DocumentFormat.OpenXml.Spreadsheet;

namespace MCX_Topics
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string selectedFilePath;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BTSearch_Click(object sender, RoutedEventArgs e)
        {
            string search = TBSearch.Text.Trim();

            if (string.IsNullOrEmpty(search))
            {
                MessageBox.Show("Please enter a search term.");
                return;
            }

            if (ListBoxUploaded.Items.Count == 0)
            {
                MessageBox.Show("Please upload an Excel file first.");
                return;
            }

            if (string.IsNullOrEmpty(selectedFilePath) || !File.Exists(selectedFilePath))
            {
                MessageBox.Show("File not found or invalid path.");
                return;
            }

            try
            {
                using (var workbook = new XLWorkbook(selectedFilePath))
                {
                    ListBoxTopics.Items.Clear();
                    bool found = false;

                    foreach (var worksheet in workbook.Worksheets)
                    {
                        if (worksheet.Cell(1, 1).GetString() == "Code")
                        {
                            for (int row = 2; row <= worksheet.LastRowUsed().RowNumber(); row++)
                            {
                                var rowData = new RowData(
                                    worksheet.Cell(row, 1).GetString(),
                                    worksheet.Cell(row, 2).GetString(),
                                    worksheet.Cell(row, 3).GetString(),
                                    worksheet.Cell(row, 4).GetString(),
                                    worksheet.Cell(row, 5).GetString(),
                                    worksheet.Cell(row, 6).GetString()
                                );

                                if (rowData.Topic.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                                    rowData.Description.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                                    rowData.HowToUse.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                                    rowData.WhenToUse.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                                    rowData.Others.Contains(search, StringComparison.OrdinalIgnoreCase))
                                {
                                    ListBoxTopics.Items.Add(rowData);
                                    found = true;
                                }
                            }
                        }
                    }

                    if (!found)
                    {
                        MessageBox.Show("No matching results found.");
                    }

                    DataCount.Text = ListBoxTopics.Items.Count.ToString(); // Update count
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching file: {ex.Message}");
            }
        }

        private void BTUpload_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Multiselect = false,
                Filter = "Excel Files|*.xlsx;*.xls",
                Title = "Select a File"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                selectedFilePath = openFileDialog.FileName;
                string fileName = Path.GetFileName(selectedFilePath);

                if (ListBoxUploaded.Items.Contains(fileName))
                {
                    MessageBox.Show("File already uploaded.");
                    return;
                }

                ListBoxUploaded.Items.Add(fileName);
            }
        }

        private void BTCheck_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxUploaded.SelectedItem != null)
            {
                if (string.IsNullOrEmpty(selectedFilePath) || !File.Exists(selectedFilePath))
                {
                    MessageBox.Show("File not found or invalid path.");
                    return;
                }

                try
                {
                    using (var workbook = new XLWorkbook(selectedFilePath))
                    {
                        bool hasValidData = false;
                        var tempList = new List<RowData>(); // Temporary list to store new data

                        foreach (var worksheet in workbook.Worksheets)
                        {
                            if (worksheet.Cell(1, 1).GetString() == "Code")
                            {
                                for (int row = 2; row <= worksheet.LastRowUsed().RowNumber(); row++)
                                {
                                    var rowData = new RowData(
                                        worksheet.Cell(row, 1).GetString(),
                                        worksheet.Cell(row, 2).GetString(),
                                        worksheet.Cell(row, 3).GetString(),
                                        worksheet.Cell(row, 4).GetString(),
                                        worksheet.Cell(row, 5).GetString(),
                                        worksheet.Cell(row, 6).GetString()
                                    );

                                    tempList.Add(rowData);
                                }

                                hasValidData = tempList.Count > 0;
                            }
                        }

                        if (hasValidData)
                        {
                            ListBoxTopics.Items.Clear(); // Clear only if valid data is found
                            foreach (var item in tempList)
                            {
                                ListBoxTopics.Items.Add(item);
                            }
                            DataCount.Text = ListBoxTopics.Items.Count.ToString();
                        }
                        else
                        {
                            MessageBox.Show("No valid sheets found. Please check the file format.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error reading file: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please select a file first.");
            }
        }



        private void BTDelete_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxUploaded.SelectedItem != null)
            {
                ListBoxUploaded.Items.Remove(ListBoxUploaded.SelectedItem);
                ListBoxTopics.Items.Clear();
                selectedFilePath = string.Empty; // Clear the path to prevent access to deleted files
            }
            else
            {
                MessageBox.Show("Please select an item to delete.");
            }
        }

        private void ListBoxTopics_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ListBoxTopics.SelectedItem != null)
            {
                if (ListBoxTopics.SelectedItem is RowData selectedRow)
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
            
        }

        public class RowData
        {
            public string Code { get; set; }
            public string Topic { get; set; }
            public string Description { get; set; }
            public string HowToUse { get; set; }
            public string WhenToUse { get; set; }
            public string Others { get; set; }

            public RowData(string code, string topic, string description, string howToUse, string whenToUse, string others)
            {
                Code = code;
                Topic = topic;
                Description = description;
                HowToUse = howToUse;
                WhenToUse = whenToUse;
                Others = others;
            }

            public override string ToString()
            {
                return $"Topic: {Topic}\nDescription: {Description}";
            }
        }

        private void BTClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); 
        }
    }
}
