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


        /*
        private void dataGrid1_Selected(object sender, RoutedEventArgs e)
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
        */
        /*private void datagrid1_selectionchanged(object sender, SelectionChangedEventArgs e)
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
            dataManager.WriteTOXml((List<ProcessingProgram>)dataGrid1.ItemsSource);
            MessageBox.Show("List succesfully saved.");
            CommentBox.Text = "";
        }

        private void buttonAddComment_Click(object sender, RoutedEventArgs e)
        {
            ProcessingProgram p = (ProcessingProgram)dataGrid1.SelectedItem;
            Utility.AddComent(p, CommentBox.Text);
            MessageBox.Show("Comment added.");
            CommentBox.Text = "";
        }



        //private void dataGrid1_Selected(object sender, RoutedEventArgs e)
        //{
        //    ProcessingProgram p = (ProcessingProgram)dataGrid1.SelectedItem;

        //}

        ////private void dataGrid1_Selected(object sender, RoutedEventArgs e)
        ////{
        ////    ProcessingProgram p = (ProcessingProgram)dataGrid1.SelectedItem;
        ////    if (p != null)
        ////    {
        ////        textCPU.Text = $"CPU usage:\n{p.CPU.ToString()} %";
        ////        textMemory.Text = $"Memory usage:\n{(p.Memory / 1000000).ToString()} MB";
        ////        textStartTime.Text = $"Start Time:\n{p.StartTime.ToString()}";
        ////    }
        ////}
    }
}
