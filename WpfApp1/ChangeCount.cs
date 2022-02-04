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
    abstract class ChangeCount
    {
        public abstract void Change();

        


    }

    class Addcitizen : ChangeCount
    {

        string Filepath { get; }

        List<string> Offrooms { get; }

        List<string> Fakerooms { get; }

        TextBox Room { get; }

        TextBox Pay { get; }

        TextBox Name { get; }

        TextBox Surname { get; }
        public Addcitizen(string filepath, List<string> offrooms, List<string> fakerooms, TextBox room, TextBox pay, TextBox name, TextBox surname) {
            this.Filepath = filepath;
            this.Offrooms = offrooms;
            this.Fakerooms = fakerooms;
            this.Room = room;
            this.Pay = pay;
            this.Name = name;
            this.Surname = surname;
        
        }
        public override void Change()
        {
            using (var streamReader = File.OpenText(Filepath))
            {
                var lines = streamReader.ReadToEnd().Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                foreach (var line in lines)
                {
                    string[] subs = line.Split(';');
                    Offrooms.Add(subs[2]);
                }
            }
            int occasion = 0;
            if (Fakerooms.Contains(Room.Text)) occasion = 0;
            if (!Fakerooms.Contains(Room.Text)) occasion = 1;
            if ((Fakerooms.Contains(String.Join("", Offrooms.ToArray())))) occasion = 2;
            if ((Name.Text == null) || (Surname.Text == null) || (Room.Text == null) || (Pay.Text == null)) occasion = 3;
                switch (occasion)
            {
                case 0:
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@Filepath, true))

                    {
                        string ID = Room.Text + Pay.Text; bool payment = false;
                            file.WriteLine(Name.Text + ";" + Surname.Text + ";" + Room.Text + ";" + Pay.Text + ";" + ID +";"+ payment + "");
                        
                          //  MessageBox.Show("Пустые поля");
                    };
                    break;
                case 1:
                    MessageBox.Show("Комната занята");
                    break;
                case 2:
                    MessageBox.Show("Комната занята");
                    break;
                case 3:
                    MessageBox.Show("Пустые поля");
                    break;

                   
            }
        }
    }
        class RemoveCitezen : ChangeCount
        {
            DataGrid Grid { get; }

            string Filepath { get; }
            public RemoveCitezen(DataGrid grid, string filepath) {
                this.Filepath = filepath;
                this.Grid = grid;
            }
            public override void Change()
            {

                DataGridCellInfo cell = Grid.CurrentCell;
                int rowIndex = Grid.Items.IndexOf(cell.Item);
                int count = Grid.SelectedIndex;

                Paidlist paidlist = new Paidlist();
                List<string> listofpaid = paidlist.vs;
                List<string> allLinesText = File.ReadAllLines(Filepath).ToList();
                if (listofpaid[count].Contains("true"))
                {
                    allLinesText[count] = null;

                    allLinesText = allLinesText.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
                    File.WriteAllLines(Filepath, allLinesText);
                }
                else
                    MessageBox.Show("Человек еще не оплатил проживание");
                
            }

        }

    }

