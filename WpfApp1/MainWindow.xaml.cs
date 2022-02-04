using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
     
        
        public MainWindow()

        {   
            InitializeComponent();
     
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TaskWindow taskWindow = new TaskWindow();
            taskWindow.Show();
            Close();
        }
        private void Button_Click_Start(object sender,EventArgs e) {
            TaskWindow taskwindow = new TaskWindow();
            taskwindow.Show();
            Close();

        }
        private void Button_Click_Instruction(object sender, EventArgs e) {
            Instructions instruction = new Instructions();
            instruction.Show();
            Close();


        }
        private void Button_Click_Author(object sender, EventArgs e) { }
        private void Button_Click_Exit(object sender, EventArgs e) 
        {
            this.Close();
        }

        private void Button_Click_Author(object sender, RoutedEventArgs e)
        {
            Window2 window2 = new Window2();
            window2.Show();
        }



        // private void Button_Click(object sender, RoutedEventArgs e)
        // {

        // }


        // private void Button_Click() { }
        //private void Button_Click() { }
        //    private void Button_Click() { }


    }
}
