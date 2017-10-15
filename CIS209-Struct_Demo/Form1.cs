using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace CIS209_Struct_Demo
{
    // Define a struct for an automobile
    struct Automobile
    {
        public string make;
        public int year;
        public double mileage;
    }

    public partial class Form1 : Form
    {
        // Create a class list for automobiles
        private List<Automobile> carList = new List<Automobile>();

        public Form1()
        {
            InitializeComponent();
        }

        // Method to get the data from the form and 
        // set the properties of the instance
        private bool GetData(ref Automobile car)
        {
            try
            {
                car.make = tbxMake.Text;
                car.year = int.Parse(tbxYear.Text);
                car.mileage = double.Parse(textBox2.Text);
                return true;           
            }
            catch (Exception)
            {
                MessageBox.Show("Check input fields for missing or invalid data",
                    "Data Entry Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnAddCar_Click(object sender, EventArgs e)
        {
            // Create a new car instance
            Automobile newCar = new Automobile();

            // Get the properties of the new car
            // from the form.  If there is an error,
            // don't add the item
            if (GetData(ref newCar))
            {
                // Add the new car to the list
                carList.Add(newCar);

                // Clear the form
                tbxMake.Clear();
                tbxYear.Clear();
                textBox2.Clear();

                // Reset the focus
                tbxMake.Focus();

                // Refresh the inventory list box
                refreshInventoryList();
            }
        }

        private void btnRemoveCar_Click(object sender, EventArgs e)
        {
            // Get the index of the selected item
            int selectedCar = lbxInventory.SelectedIndex;

            // Was something selected?
            if (selectedCar >= 0)
            {
                // Confirm it's OK to remove the item
                DialogResult result = MessageBox.Show("OK to Delete " + lbxInventory.SelectedItem.ToString(),
                    "Confirm Delete ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    // Remove it from the list
                    carList.RemoveAt(selectedCar);

                    // Refresh the inventory list box
                    refreshInventoryList();
                }
            }
        }

        private void refreshInventoryList()
        {
            // Clear the inventory list box
            lbxInventory.Items.Clear();

            // Show the car list in the inventory list
            foreach (Automobile each in carList)
            {
                string output = each.year + " " + each.make +
                    " with " + each.mileage + " miles ";

                lbxInventory.Items.Add(output);
            }
        }
    }
}
