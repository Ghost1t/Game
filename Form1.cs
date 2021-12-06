using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        
        List<Units> Light = new();
        List<Units> Light2 = new();
        List<Units> darkness = new();
        List<Units> darkness2 = new();
        List<Units> AllUnits = new();
        List<Units> AllUnits2 = new();

        public Form1()
        {
            InitializeComponent();
        }

        void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            Light.Clear();
            darkness.Clear();
            AllUnits.Clear();
            AllUnits2.Clear();
            Light.Add(new Units { Name = "Кентавр-странник", Confrontation = "Свет", Price = 7, Damage = 13, Health = 35, Initiative = 7 });
            Light.Add(new Units { Name = "Ангел", Confrontation = "Свет", Price = 12, Damage = 20, Health = 60, Initiative = 10 });
            darkness.Add(new Units { Name = "Изверг", Confrontation = "Тьма", Price = 6, Damage = 15, Health = 50, Initiative = 10 });
            darkness.Add(new Units { Name = "Тёмный паладин", Confrontation = "Тьма", Price = 6, Damage = 10, Health = 34, Initiative = 10 });
            textBox1.Text += "Свет" + "\r\n";

            AllUnits = Light.Concat(darkness).ToList();

            for (int i = 0; i < Light.Count; i++) // Запись коллекции Light в textBox.
            {

                textBox1.Text += Light[i].Name.ToString() + "\r\n";

            }

            textBox1.Text += "\r\n";
            textBox1.Text += "Тьма" + "\r\n";

            for (int i = 0; i < darkness.Count; i++) // Запись коллекции darkness в textBox.
            {

                textBox1.Text += darkness[i].Name.ToString() + "\r\n";

            }

            // Перемешать общий список
            for (int i = AllUnits.Count - 1; i >= 1; i--)
            {
                int j = new Random().Next(i + 1);                
                var temp = AllUnits[j];
                AllUnits[j] = AllUnits[i];
                AllUnits[i] = temp;
            }

            for (int i = 0; i < AllUnits.Count; i++) // Запись коллекции AllUnits в textBox2.
            {

                textBox2.Text += AllUnits[i].Name.ToString() + "\r\n";

            }

            // Отсортированть общий список по убыванию
            AllUnits2 = AllUnits.OrderByDescending(u => u.Initiative).ToList();

            for (int i = 0; i < AllUnits2.Count; i++) // Запись коллекции AllUnits2 в textBox2.
            {

                textBox2.Text += AllUnits2[i].Name.ToString() + "\r\n";

            }






        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        void button2_Click(object sender, EventArgs e)
        {
            int win_Light = 0;
            int win_darkness = 0;
            int Battle = 100000;

            while (Battle > 0)
            {
                Light2 = Light.GetRange(0, Light.Count);
                darkness2 = darkness.GetRange(0, darkness.Count);

                while (Light2.Count > 0 && darkness2.Count > 0)
                {
                    foreach (Units Unit in Light2)
                    {
                        int value = new Random().Next(6);
                        if (value <= 4 && darkness2.Count > 0)
                        {
                            darkness2[0].Health = darkness2[0].Health - Unit.Damage;

                            if (darkness2[0].Health <= 0)
                            {
                                darkness2.RemoveAt(0);
                            }
                        }
                    }

                    foreach (Units Unit in darkness2)
                    {
                        int value = new Random().Next(6);
                        if (value <= 4 && Light2.Count > 0)
                        {
                            Light2[0].Health = Light2[0].Health - Unit.Damage;

                            if (Light2[0].Health <= 0)
                            {
                                Light2.RemoveAt(0);
                            }
                        }
                    }


                    if (Light2.Count == 0)
                    {
                        win_darkness++;
                    }
                    if (darkness2.Count == 0)
                    {
                        win_Light++;
                    }

                }
                Battle--;
            }

            textBox2.Text += "Свет победил " + win_Light + " раз" + "\r\n";
            textBox2.Text += "Тьма победила " + win_darkness + " раз" + "\r\n";

        }
    }
}
