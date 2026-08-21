using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pr3._33F
{
    public partial class Form1 : Form
    {
        private double[] treeHeights;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Арзубов Максим
            pictureBox2.Visible = true;
            int n = (int)numericUpDown1.Value;

            
            treeHeights = new double[n];

            
            Random rand = new Random();

            
            listBoxTrees.Items.Clear();
            listBoxTrees.Items.Add("№\tВисота (см)");
            listBoxTrees.Items.Add("--------------------");

            for (int i = 0; i < n; i++)
            {
                
                double height = rand.Next(50, 250) + Math.Round(rand.NextDouble(), 1);

                treeHeights[i] = height; 

                
                listBoxTrees.Items.Add($"{i + 1}\t{treeHeights[i]} см");
            }

            labelStatus.Text = $"Згенеровано масив із {n} ялинок.";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
        }

        private void listBoxTrees_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (treeHeights == null || treeHeights.Length == 0)
            {
                MessageBox.Show("Спочатку сформуйте масив ялинок!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int totalEarnings = 0;
            int countFrom1To150 = 0;
            int countHigher150 = 0;
            int countTooSmall = 0;

            
            for (int i = 0; i < treeHeights.Length; i++)
            {
                double h = treeHeights[i];

                
                if (h >= 100.0 && h <= 150.0)
                {
                    totalEarnings += 200;
                    countFrom1To150++;
                }
                
                else if (h > 150.0)
                {
                    totalEarnings += 300;
                    countHigher150++;
                }
                
                else
                {
                    countTooSmall++;
                }
            }

            
            labelResult.Text = $"Загальний прибуток: {totalEarnings} грн.\n" +
                               $"----------------------------------------\n" +
                               $" Від 1м до 1.5м (200 грн): {countFrom1To150} шт.\n" +
                               $" Вище 1.5м (300 грн): {countHigher150} шт.\n" +
                               $" Замалі для продажу (<1м): {countTooSmall} шт.";
        }

        private void labelResult_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void labelStatus_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            if (treeHeights == null || treeHeights.Length == 0)
            {
                MessageBox.Show("Спочатку згенеруйте масив ялинок (Кнопка 1)!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            int userNumber = (int)numSingleTree.Value;

            
            int arrayIndex = userNumber - 1;

            
            if (arrayIndex < 0 || arrayIndex >= treeHeights.Length)
            {
                labelSinglePrice.Text = $"Ялинки №{userNumber} немає. ";
                return;
            }

            
            double h = treeHeights[arrayIndex];
            int price = 0;

            
            if (h >= 100.0 && h <= 150.0)
            {
                price = 200;
            }
            else if (h > 150.0)
            {
                price = 300;
            }

           
            if (price > 0)
            {
                labelSinglePrice.Text = $"Ялинка №{userNumber} (висота {h} см) коштує: {price} грн.";
            }
            else
            {
                labelSinglePrice.Text = $"Ялинка №{userNumber} (висота {h} см) замала для продажу.";
            }
        }
    }
    }

