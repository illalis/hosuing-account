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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
 class MyTable
    {
        public MyTable(string Name, string Surname, string flat, int penny, string ID, bool Paymentstatus)
    {
        this.Name = Name;
        this.Surname = Surname;
        this.flat = flat;
        this.penny = penny;
        this.ID = ID;
            this.Paymentstatus = Paymentstatus;
    }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string flat { get; set; }
    public int penny { get; set; }

    public string ID { get; set; }

    public bool Paymentstatus { get; set; }

}
public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

        }
        private void grid_Loaded(object sender, RoutedEventArgs e)
        {
            string filepath = "C:\\debug\\base.csv";
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
                    result.Add(new MyTable(name, surname, room, Convert.ToInt32(penny),ID,payment));
                    


                }

                
           
                grid.ItemsSource = result;
               
            }
        }
        //Получаем данные из таблицы
        private void grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MyTable path = grid.SelectedItem as MyTable;
            MessageBox.Show(" Name: " + path.Name + "\n Surname " + path.Surname + "\n Flat: " + path.flat
                + "\n penny: " + path.penny +"\n ID:" + path.ID +"\n PaymenStatus:" + path.Paymentstatus );
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TaskWindow window = new TaskWindow();
            window.Show();
            Close();
        }
    }
}
