using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaDelivery1
{
    public partial class Pizza : Form
    {
        private string order;
        private double totalCost;
        public Pizza()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {

            double drinkcost,
                   pizzacost,
                   sidescost;


            order = "";
            order += comboBox1.SelectedItem.ToString() + " - ";
            order += comboBox2.SelectedItem.ToString() + " \n ";

            if (checkedListBox1.SelectedItems.Count > 0)
            {
                order += "Toppings: ";
                foreach (string s in checkedListBox1.CheckedItems)
                {
                    order += "\n" + s;
                }
            }

            pizzacost = DeterminePizzaCost();
            if (pizzacost != 0)
                order += "\nPizza Total: " + pizzacost.ToString("C");

            drinkcost = DeterminePopCost();
            if (drinkcost != 0)
                order += "\nDrink Total: " + drinkcost;

            sidescost = DetermineSideCost();
            if (sidescost != 0)
            {
                order += "\nSides Cost: " + comboBox3.SelectedItem.ToString();
            }

            order += "\n\nAmount Due: " +
                (pizzacost+ drinkcost + sidescost).ToString("C");
            MessageBox.Show("Name: " + textBox1.Text + "\n " + "Address: " + textBox2.Text + "\n " +
                "Phone: " + textBox3.Text + "\n " + "Email: " + textBox4.Text + "\n " + order, "Pizza\n");

         }

        public double DeterminePizzaCost()
        {
            double cost;
            if (comboBox1.SelectedIndex == 0)
                cost = 9.00;
            else
                if (comboBox1.SelectedIndex == 1)
                    cost = 12.00;
                else
                    if (comboBox1.SelectedIndex == 2)
                        cost = 15.00;
                    else
                         cost = 20.00;

            return cost + (checkedListBox1.CheckedItems.Count * 1.50 + comboBox2.SelectedIndex*2.00);
                        
        }
        public double DeterminePopCost()
        {
            return (checkedListBox2.CheckedItems.Count * 1.00);

        }
        public double DetermineSideCost()
        {
            double cost;
            if (comboBox3.SelectedIndex == 0)
                cost = 3.00;
            else
                if (comboBox3.SelectedIndex == 1)
                    cost = 5.00;
                else
                    if (comboBox3.SelectedIndex == 2)
                        cost = 2.00;
                    else
                        if (comboBox3.SelectedIndex == 3)
                            cost = 3.00;
                    else
                        cost = 4.00;

            return cost;

        }
        private void Pizza_Load(object sender, EventArgs e)
        {
            this.comboBox1.SelectedIndex = 0;
            this.comboBox2.SelectedIndex = 0;
            this.comboBox3.SelectedIndex = 0;
            order = "";
            totalCost = 0;

        }


    }
}
