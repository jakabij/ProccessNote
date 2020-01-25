using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using ClassLibrary1;

namespace WpfProcessNote
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer onlineModeTimer = new DispatcherTimer();
        ProcessingProgram processingProgram;
        bool processesListed = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonList_Click(object sender, RoutedEventArgs e)
        {
            AllProcess allProcess = new AllProcess();
            processesListed = true;

            dataGrid1.ItemsSource = allProcess.ListOfProcesses;
            foreach (var process in Process.GetProcesses())
            {
                processingProgram = new ProcessingProgram(process);
                allProcess.ListOfProcesses.Add(processingProgram);
            }
            dataGrid1.Visibility = Visibility.Visible;

        }

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            processingProgram = (ProcessingProgram)dataGrid1.SelectedItem;
            if (processingProgram != null)
            {
                textCPU.Text = $"CPU usage:\n{processingProgram.CPU}";
                textMemory.Text = $"Memory usage:\n{processingProgram.Memory}";
                textStartTime.Text = $"Start Time:\n{processingProgram.StartTime}";
                textRunningTime.Text = $"Running Time: \n{processingProgram.RunningTime}";
            }
        }

        private void dataGrid1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            processingProgram = (ProcessingProgram)dataGrid1.SelectedItem;
            processingProgram.refreshProcess(processingProgram);
            textCPU.Text = $"CPU usage:\n{processingProgram.CPU}";
            textMemory.Text = $"Memory usage:\n{processingProgram.Memory}";
            textStartTime.Text = $"Start Time:\n{processingProgram.StartTime}";
            textRunningTime.Text = $"Running Time: \n{processingProgram.RunningTime}";
            textComment.Text = $"{processingProgram.Comment}";
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
                processingProgram = (ProcessingProgram)dataGrid1.SelectedItem;
                Utility.AddComent(processingProgram, CommentBox.Text);
                MessageBox.Show("Comment added.");
            }
            catch (Exception)
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

        private void toggleOnlineMode_Check(object sender, RoutedEventArgs e)
        {
            if (processesListed)
            {
                onlineModeTimer.Interval = new TimeSpan(0, 0, 1);
                onlineModeTimer.Tick += onlineModeTimer_Tick;
                onlineModeTimer.Start();
            }
            else
            {
                MessageBox.Show("List processes first!", "Warning");
                toggleOnlineMode.IsChecked = false;
            }
        }

        private void toggleOnlineMode_Uncheck(object sender, RoutedEventArgs e)
        {
            if (onlineModeTimer.IsEnabled == true)
                onlineModeTimer.Stop();
        }

        private void onlineModeTimer_Tick(object sender, EventArgs e)
        {
            processingProgram.refreshProcess(processingProgram);

            textCPU.Text = $"CPU usage:\n{processingProgram.CPU}";
            textMemory.Text = $"Memory usage:\n{processingProgram.Memory}";
            textStartTime.Text = $"Start Time:\n{processingProgram.StartTime}";
            textRunningTime.Text = $"Running Time: \n{processingProgram.RunningTime}";
            textComment.Text = $"{processingProgram.Comment}";
            /* textComment.Text = $"{i}";
            i++; */
        }

        private void checkboxAlwaysOnTop_Check(object sender, RoutedEventArgs e)
        {
            if (checkBoxAlwaysOnTop.IsChecked == true)
            {
                Topmost = true;
            }
            else
            {
                Topmost = false;
            }
        }
    }
}
