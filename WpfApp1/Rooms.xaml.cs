using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Rooms.xaml
    /// </summary>
    public partial class Rooms : Window
    {
       public List<string> rooms = new List<string>() {
            "101B",
            "101A",
            "101C",
            "102B",
            "102A",
            "102C",
            "103B",
            "103A",
            "103C",
            "104B",
            "104A",
            "104C",
            };
        
        public Rooms()
        {
            InitializeComponent();
            

            string filepath = "C:\\debug\\base.csv";
            using (var streamReader = File.OpenText(filepath))
            {
                var lines = streamReader.ReadToEnd().Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                foreach (var line in lines)
                {
                    string[] subs = line.Split(';');
                    
                    string room = subs[2];
                    string name = subs[0];
                    string surname = subs[1];

                    rooms.Remove(room);
                    rooms.Add("Комната:" + room + " занята - " + name +" "+surname);

                }
            }
            Info.Text = String.Join(", " , rooms.ToArray());

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TaskWindow window = new TaskWindow();
            window.Show();
            Close();
        }
    }
}
