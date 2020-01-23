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
//using Caliburn.Micro;
using ClassLibrary1;


namespace WpfProcessNote
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public BindableCollection<ProcessingProgram> Processes { get; set; }
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
            //Processes = new BindableCollection<ProcessingProgram>(allProcess.ListOfProcesses);
            
        }

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProcessingProgram p = (ProcessingProgram)dataGrid1.SelectedItem;
            if (p != null)
            {
                textCPU.Text = $"CPU usage:\n{p.CPU.ToString()} %";
                textMemory.Text = $"Memory usage:\n{(p.Memory / 1000000).ToString()} MB";
                textStartTime.Text = $"Start Time:\n{p.StartTime.ToString()}";
                textRunningTime.Text = $"Running Time: \n{p.RunningTime}";
            }
        }

        private void dataGrid1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ProcessingProgram p = (ProcessingProgram)dataGrid1.SelectedItem;
            
        }

        //private void dataGrid1_Selected(object sender, RoutedEventArgs e)
        //{
        //    ProcessingProgram p = (ProcessingProgram)dataGrid1.SelectedItem;
        //    if (p != null)
        //    {
        //        textCPU.Text = $"CPU usage:\n{p.CPU.ToString()} %";
        //        textMemory.Text = $"Memory usage:\n{(p.Memory / 1000000).ToString()} MB";
        //        textStartTime.Text = $"Start Time:\n{p.StartTime.ToString()}";
        //    }
        //}
    }
}
