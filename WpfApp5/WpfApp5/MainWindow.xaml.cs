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
using MySql.Data.MySqlClient;
namespace WpfApp5
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

        private void CheckPayment_Click(object sender, RoutedEventArgs e)
        {
            string MyConnection2 = "datasource=localhost;port=3306;username=root";
            MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
            string Query = "SELECT * FROM base.base WHERE `ID` = '" + ID.Text.ToString() + "'";
            string Query2 = "UPDATE base.base SET `PaymentStatus` = 1 WHERE `ID`='" + ID.Text.ToString() + "'";
            MySqlCommand cmdDataBase = new MySqlCommand(Query, MyConn2);
            MySqlDataReader myReader;
            bool Ans;
            string Price = "";
            try
            {

                MyConn2.Open();
                myReader = cmdDataBase.ExecuteReader();
                // MessageBox.Show(myReader.ToString());
                while (myReader.Read()) {
                    Price = myReader.GetInt32(3).ToString();
                    MessageBox.Show(Price);
                }

                MyConn2.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
           
            if (Price == Money.Text.ToString())
            {
                MySqlConnection MyConn3 = new MySqlConnection(MyConnection2);
                MySqlCommand cmdDataBase2 = new MySqlCommand(Query2, MyConn3); 
                
                try
                {
                    MyConn3.Open();
                    myReader = cmdDataBase2.ExecuteReader();
                    while (myReader.Read())
                    { MessageBox.Show(myReader.GetInt64(6).ToString()); }
                    MyConn3.Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else
                MessageBox.Show("NO");

      
        }
    }
}
