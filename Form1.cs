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
            Light.Add(new Units { Name = "Кентавр-латник", Confrontation = "Свет", Price = 6, Damage = 8, Health = 43, Initiative = 7 });
            Light.Add(new Units { Name = "Рыцарь", Confrontation = "Свет", Price = 9, Damage = 15, Health = 40, Initiative = 10 });
            Light.Add(new Units { Name = "Паладин", Confrontation = "Свет", Price = 5, Damage = 10, Health = 30, Initiative = 10 });
            Light.Add(new Units { Name = "Ангел", Confrontation = "Свет", Price = 12, Damage = 20, Health = 60, Initiative = 10, Big = true });
            darkness.Add(new Units { Name = "Изверг", Confrontation = "Тьма", Price = 6, Damage = 15, Health = 50, Initiative = 10, Big = true });
            darkness.Add(new Units { Name = "Тёмный паладин", Confrontation = "Тьма", Price = 6, Damage = 10, Health = 34, Initiative = 10 });
            darkness.Add(new Units { Name = "Рыцарь Ада", Confrontation = "Тьма", Price = 10, Damage = 15, Health = 44, Initiative = 10 });
            darkness.Add(new Units { Name = "Исчадие ада", Confrontation = "Тьма", Price = 2, Damage = 10, Health = 34, Initiative = 7, Big = true });
            darkness.Add(new Units { Name = "Одержимый", Confrontation = "Тьма", Price = 1, Damage = 5, Health = 24, Initiative = 10 });
            textBox1.Text += "Свет" + "\r\n";

            Light.RemoveAt(new Random().Next(Light.Count));
            Light.RemoveAt(new Random().Next(Light.Count));
            darkness.RemoveAt(new Random().Next(darkness.Count));
            darkness.RemoveAt(new Random().Next(darkness.Count));


            AllUnits = Light.Concat(darkness).ToList();
            int LightPrice = 0;
            for (int i = 0; i < Light.Count; i++) // Запись коллекции Light в textBox.
            {

                textBox1.Text += Light[i].Name.ToString() + "\r\n";
                LightPrice = LightPrice + Light[i].Price;
            }

            textBox1.Text += "Стомость армии: " + LightPrice + "\r\n";
            textBox1.Text += "Тьма" + "\r\n";

            int darknessPrice = 0;


            for (int i = 0; i < darkness.Count; i++) // Запись коллекции darkness в textBox.
            {

                textBox1.Text += darkness[i].Name.ToString() + "\r\n";
                darknessPrice = darknessPrice + darkness[i].Price;                
            }

            textBox1.Text += "Стомость армии: " + darknessPrice + "\r\n";








        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        void button2_Click(object sender, EventArgs e)
        {
            int win_Light = 0;
            int win_darkness = 0;
            int Battle = 10000;
            

            while (Battle > 0)
            {
                

                Light2 = Light.GetRange(0, Light.Count);
                darkness2 = darkness.GetRange(0, darkness.Count);

                while (Light2.Count > 0 && darkness2.Count > 0)
                {
                    // Перемешать общий список
                    for (int i = AllUnits.Count - 1; i >= 1; i--)
                    {
                        int j = new Random().Next(i + 1);
                        var temp = AllUnits[j];
                        AllUnits[j] = AllUnits[i];
                        AllUnits[i] = temp;
                    }

                    // Отсортированть общий список по убыванию
                    AllUnits.OrderByDescending(u => u.Initiative).ToList();

                    foreach (Units Unit in AllUnits.ToList())
                    {
                        int value = new Random().Next(6);
                        if (value <= 4 && Light2.Count > 0 && darkness2.Count > 0)
                        {
                            if (Unit.Confrontation == "Свет")
                            {
                                darkness2[0].Health = darkness2[0].Health - Unit.Damage;

                                if (darkness2[0].Health <= 0)
                                {
                                    for (int i = AllUnits.Count - 1; i >= 0; i--)
                                    {
                                        if (AllUnits[i].Name == darkness2[0].Name)
                                        {
                                            AllUnits.RemoveAt(i);

                                        }
                                    }                                        
                                    
                                    darkness2.RemoveAt(0);

                                }

                            }   
                            else
                            {
                                Light2[0].Health = Light2[0].Health - Unit.Damage;

                                if (Light2[0].Health <= 0)
                                {
                                    for (int i = AllUnits.Count - 1; i >= 0; i--)
                                    {
                                        if (AllUnits[i].Name == Light2[0].Name)
                                        {
                                            AllUnits.RemoveAt(i);

                                        }
                                    }
                                    Light2.RemoveAt(0);
                                }
                            }
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

                Battle--;
            }

            textBox2.Text += "Свет победил " + win_Light + " раз" + "\r\n";
            textBox2.Text += "Тьма победила " + win_darkness + " раз" + "\r\n";
            textBox2.Text += "\r\n";

        }
    }
}
