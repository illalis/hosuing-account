using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Removecit.xaml
    /// </summary>
    /// 
   
    public partial class Removecit : Window
    {
        public string filepath = "C:\\debug\\base.csv";
        
        public Removecit() 
        { 
            InitializeComponent();
            
        }
        private void grid_Loaded(object sender, RoutedEventArgs e)
        {   
            //string filepath = "C:\\debug\\base.csv";
            List<MyTable> result = new List<MyTable>(3);
            int id = 0;
            using (var streamReader = File.OpenText(filepath))
            {
                var lines = streamReader.ReadToEnd().Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                foreach (var line in lines)
                {
                    string[] subs = line.Split(';');
                    string name = subs[0];
                    string surname = subs[1];
                    string room = subs[2];
                    string penny = subs[3];
                    string ID = subs[4];
                    bool payment = bool.Parse(subs[5]);
                    result.Add(new MyTable(name, surname, room, Convert.ToInt32(penny), ID, payment));
                    


                }




                grid.ItemsSource = result;

            }
            

        }

        private void Escape_Click(object sender, RoutedEventArgs e)
        {
            TaskWindow taskWindow = new TaskWindow();
            taskWindow.Show();
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RemoveCitezen removeCitezen = new RemoveCitezen(grid,filepath);
            removeCitezen.Change();
            

           /* DataGridCellInfo cell = grid.CurrentCell;
            int rowIndex = grid.Items.IndexOf(cell.Item);
            int count = grid.SelectedIndex;

            Paidlist paidlist = new Paidlist();
            List<string> listofpaid = paidlist.vs;
            List<string> allLinesText = File.ReadAllLines(filepath).ToList();
            if (listofpaid[count].Contains("true"))
            {
                allLinesText[count] = null;

                allLinesText = allLinesText.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
                File.WriteAllLines(filepath, allLinesText);
            }
            else
                MessageBox.Show("Человек еще не оплатил проживание");
           */
        }
    }
}
