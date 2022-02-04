using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
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
    /// Логика взаимодействия для Addcit.xaml
    /// </summary>
    public partial class Addcit : Window
    {   
        public Addcit()
        {
            InitializeComponent();
        }
        // public event System.Windows.RoutedEventHandler GotFocus;
        private void Name_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb != null)
            {
                tb.Clear(); //select all text in TextBox
            }
        }


        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string filepath = "C:\\debug\\base.csv";
            Rooms roms = new Rooms();
             List<string> Fakerooms = roms.rooms;

             List<string> offrooms = new List<string> { };
            Addcitizen addcitizen = new Addcitizen(filepath, offrooms, Fakerooms, Room, Pay, Name, Surname);
            addcitizen.Change();
            /* string filepath = "C:\\debug\\base.csv";

            

             using (var streamReader = File.OpenText(filepath))
             {
                 var lines = streamReader.ReadToEnd().Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                 foreach (var line in lines)
                 {
                     string[] subs = line.Split(';');
                     offrooms.Add(subs[2]);
                 }
             }
             int occasion = 0;
             if (Fakerooms.Contains(Room.Text)) occasion = 0;
             if (!Fakerooms.Contains(Room.Text)) occasion = 1;
             if ((Fakerooms.Contains(String.Join("", offrooms.ToArray())))) occasion = 2;
             switch (occasion)
             {
                 case 0:
                     using (System.IO.StreamWriter file = new System.IO.StreamWriter(@filepath, true))

                     {   if ((Name.Text != null) & (Surname.Text != null) & (Room.Text != null) & (Pay.Text != null))
                             file.WriteLine(Name.Text + ";" + Surname.Text + ";" + Room.Text + ";" + Pay.Text + ";" + "");
                         else
                             MessageBox.Show("Пустые поля");
                     };
                     break;
                 case 1:
                     MessageBox.Show(String.Join("", Fakerooms.ToArray()));
                     break;
                 case 2:
                     MessageBox.Show("Комната занята");
                     break;


             






        }*/
        }
            private void Escape_Click(object sender, RoutedEventArgs e)
            {
                TaskWindow window = new TaskWindow();
                window.Show();
                this.Close();
            }
        }
    }


 

