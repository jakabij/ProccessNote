using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClassLibrary1;

namespace WpfProcessNote
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            

        }

        private void buttonList_Click(object sender, RoutedEventArgs e)
        {
            AllProcess allProcess = new AllProcess();
            
            dataGrid1.ItemsSource = allProcess.ListOfProcesses;
            foreach (var process in Process.GetProcesses())
            {
                ProcessingProgram p = new ProcessingProgram(process);
                allProcess.ListOfProcesses.Add(p);
            }
            dataGrid1.Visibility = Visibility.Visible ;
            
        }

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProcessingProgram p = (ProcessingProgram)dataGrid1.SelectedItem;
            if (p != null)
            {
                textCPU.Text = $"CPU usage:\n{p.CPU}";
                textMemory.Text = $"Memory usage:\n{p.Memory}";
                textStartTime.Text = $"Start Time:\n{p.StartTime}";
                textRunningTime.Text = $"Running Time: \n{p.RunningTime}";
            }
        }

        private void dataGrid1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ProcessingProgram p = (ProcessingProgram)dataGrid1.SelectedItem;
            p.refreshProcess(p);
            textCPU.Text = $"CPU usage:\n{p.CPU}";
            textMemory.Text = $"Memory usage:\n{p.Memory}";
            textStartTime.Text = $"Start Time:\n{p.StartTime}";
            textRunningTime.Text = $"Running Time: \n{p.RunningTime}";
            textComment.Text = $"{p.Comment}";
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            
            DataManager dataManager = new DataManager();
            if ((List<ProcessingProgram>)dataGrid1.ItemsSource != null)
            {
                dataManager.WriteTOXml((List<ProcessingProgram>)dataGrid1.ItemsSource);
                MessageBox.Show("List succesfully saved.");
                CommentBox.Text = "";
            }
            else
            {
                MessageBox.Show("Nothing to save!");
            }
        }

        private void buttonAddComment_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
                ProcessingProgram p = (ProcessingProgram)dataGrid1.SelectedItem;
                Utility.AddComent(p, CommentBox.Text);
                MessageBox.Show("Comment added.");
            }
            catch(Exception)
            {
                MessageBox.Show("You have to select an item first!");
            }
            finally
            {
                CommentBox.Text = "";
            }
        }

        private void buttonLoad_Click(object sender, RoutedEventArgs e)
        {
            AllProcess allProcess = new AllProcess();
            DataManager dataManager = new DataManager();
            
            dataGrid1.ItemsSource = dataManager.ReadFromXml();
            dataGrid1.Visibility = Visibility.Visible;
        }
        
    }
}
