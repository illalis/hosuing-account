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
    /// Логика взаимодействия для Paidlist.xaml
    /// </summary>
    public partial class Paidlist : Window
    {
        public List<string> vs = new List<string> { };
        public Paidlist()
        {
            InitializeComponent();
            string paid;
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
                    int pay = Convert.ToInt32(subs[3]);
                    if (name == "ilya") paid = "false";
                    else
                        paid = "true";
                    vs.Add("Клиент:"+name+" "+surname+" Проживающий в комнате:" + room + " Стоимость аренды:" + pay + " Статус оплаты:" + paid);
                    List.ItemsSource = vs;
                }

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TaskWindow task = new TaskWindow();
            task.Show();
            Close();

        }
    }
}
