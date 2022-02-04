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
using System.Windows.Shapes;
using System.IO;
using MySql.Data.MySqlClient;



namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для TaskWindow.xaml
    /// </summary>
    public partial class TaskWindow : Window
    {
        //   public string ViewModel { get; set; }
        public TaskWindow()
        {
            InitializeComponent();
        }

        private void Escape_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mwindow = new MainWindow();
            mwindow.Show();
            Close();
        }

        private void citizens_Click(object sender, RoutedEventArgs e)
        {
            Window1 wndow = new Window1();
            wndow.Show();
            Close();
        }

        private void add_citizens_Click(object sender, RoutedEventArgs e)
        {
            Addcit addcit = new Addcit();
            addcit.Show();
            Close();
        }

        private void list_of_free_room_Click(object sender, RoutedEventArgs e)
        {
            Rooms rooms = new Rooms();
            rooms.Show();
            Close();
        }

        private void money_Click(object sender, RoutedEventArgs e)
        {
            Paidlist paidlist = new Paidlist();
            paidlist.Show();
            this.Close();
        }

        private void remove_sitizens_Click(object sender, RoutedEventArgs e)
        {
            Removecit removecit = new Removecit();
            removecit.Show();
            Close();
        }

        private void Sender_button_Click(object sender, RoutedEventArgs e)

        {
            string name = "", surname = "", room = "";
            int penny = 0;
            string MyConnection2 = "datasource=localhost;port=3306;username=root";
            MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
            string filepath = "C:\\debug\\base.csv";

            using (var streamReader = File.OpenText(filepath))
            {
                var lines = streamReader.ReadToEnd().Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                foreach (var line in lines)
                {
                    string[] subs = line.Split(';');
                    name = subs[0];
                    surname = subs[1];
                    room = subs[2];
                    penny = Int32.Parse(subs[3]);
                    string ID = subs[4];
                    bool PaymentStatus = Convert.ToBoolean(subs[5]);
                    string Query = "insert ignore into base.base (name,surname,room,penny,ID,PaymentStatus) values ('" + name + "','" + surname + "','" + room + "','" + penny + "','" + ID + "','" + PaymentStatus + "') ;";
                    MySqlCommand cmdDataBase = new MySqlCommand(Query, MyConn2);
                    MySqlDataReader myReader;
                    try
                    {

                        MyConn2.Open();
                        myReader = cmdDataBase.ExecuteReader();
                        MessageBox.Show("УСПЕШНО");
                        while (myReader.Read()) { }
                        MyConn2.Close();
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }

            }


            // public void ShowViewModel() {
            //     MessageBox.Show(ViewModel);
            // }
        }

        private void Download_button_Click(object sender, RoutedEventArgs e)
        {
            string MyConnection2 = "datasource=localhost;port=3306;username=root";
            MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
            string Query = "ALTER IGNORE TABLE base.base ADD UNIQUE INDEX(`ID`);";
            MySqlCommand cmdDataBase = new MySqlCommand(Query, MyConn2);
            MySqlDataReader myReader;
            try
            {
                MyConn2.Open();
                myReader = cmdDataBase.ExecuteReader();
                // MessageBox.Show("УСПЕШНО");
                while (myReader.Read()) { }
                MyConn2.Close();


            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            List<string> QueryResult = new List<string>();
            Query = "SELECT * FROM base.base";
            MySqlCommand cmdDataBase2 = new MySqlCommand(Query, MyConn2);
            MySqlDataReader myReader2;
          
            try
            {
                MyConn2.Open();
                myReader2 = cmdDataBase2.ExecuteReader();
                MessageBox.Show("УСПЕШНО");
                while (myReader2.Read())
                {
                  
                   QueryResult.Add(myReader2.GetString(0) + ";" + myReader2.GetString(1)+ ";" + myReader2.GetString(2)+";"+ myReader2.GetString(3)+";"+ myReader2.GetString(4)+";"+myReader2.GetString(5)+";");
                   

                }
                MyConn2.Close();
                var message = string.Join(Environment.NewLine, QueryResult.ToArray());
                MessageBox.Show(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
           // string
            string filepath = "C:\\debug\\base.csv";
            File.WriteAllLines(filepath,QueryResult );
        }
    }
}
