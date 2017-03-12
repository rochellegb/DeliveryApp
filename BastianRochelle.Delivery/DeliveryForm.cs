using BastianRochelle.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BastianRochelle.Delivery
{
    public partial class DeliveryForm : Form
    {
        Customer customer;
        OrderManager orderManager;
        Cart cart;

        public DeliveryForm()
        {
            InitializeComponent();
            cart = new Cart();
            orderManager = new OrderManager();
            listboxFood.DataSource = orderManager.FoodCategories;

            listViewCartItems.Columns.Add("ID", 50);
            listViewCartItems.Columns.Add("Name", 190);
            listViewCartItems.Columns.Add("Price", 70);
            listViewCartItems.Columns.Add("Quantity", 60);
            listViewCartItems.View = View.Details;
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            try
            {
                var cashTendered = Convert.ToDouble(txtCashTendered.Text);
                customer = new Customer(txtFirstName.Text, txtLastName.Text, txtContactNo.Text, txtAddress.Text, cashTendered);
                if (cashTendered < this.cart.TotalAmount)
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("You have entered invalid amount", "", MessageBoxButtons.OK);
                txtCashTendered.BackColor = Color.Red;
            }
        }

        private void listboxFood_SelectedValueChanged(object sender, EventArgs e)
        {
            var selectedFood = (Food)listboxFood.SelectedItem;
            var subFoods = orderManager.GetSpecificFoods(selectedFood);
            listboxSubFood.DataSource = subFoods;
        }

        private void listboxSubFood_SelectedValueChanged(object sender, EventArgs e)
        {
            var selectedFood = (Food)listboxFood.SelectedItem;
            var selectedSubFood = (Food)listboxSubFood.SelectedItem;
            this.lblPrice.Text = selectedSubFood.Price.ToString();

            txtQuantity.Text = Convert.ToString(selectedSubFood.Quantity);
        }

        private void btnAddtoCart_Click(object sender, EventArgs e)
        {
            var selectedFood = (Food)listboxFood.SelectedItem;
            var selectedSubFood = (Food)listboxSubFood.SelectedItem;
            try
            {
                selectedSubFood.Quantity = Convert.ToInt32(this.txtQuantity.Text);
            }
            catch (Exception)
            {
                txtQuantity.Text = "1";
            }

            if (selectedSubFood.Quantity > 0)
            {
                if (!this.cart.Contains(selectedSubFood))
                {
                    this.cart.Add(selectedSubFood);

                    //- Change UI state
                    string[] item = {
                        selectedSubFood.ID.ToString(),
                        selectedSubFood.Name + " (" + selectedFood.Name + ")",
                        selectedSubFood.Price.ToString(),
                        selectedSubFood.Quantity.ToString()
                    };
                    var listviewItem = new ListViewItem(item);
                    listViewCartItems.Items.Add(listviewItem);
                    lblCount.Text = cart.Count().ToString();
                    lblTotalAmount.Text = this.cart.TotalAmount.ToString();
                }
                else
                {
                    MessageBox.Show("You can't duplicate order", "", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Invalid quantity", "", MessageBoxButtons.OK);
                txtQuantity.BackColor = Color.Red;
            }
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            var selectedItems = listViewCartItems.SelectedItems;
            if (selectedItems.Count > 0)
            {
                foreach (var item in selectedItems)
                {
                    var li = (ListViewItem)item;        //- Cast object into ListViewItem
                    var subItems = li.SubItems;         //- Get sub items of list view
                    var selectedFood = new Food()       //- Create new Food based on the subitems of the ListViewItem
                    {
                        ID = Convert.ToInt32(subItems[0].Text),
                        Name = subItems[1].Text
                    };

                    //Remove from cart
                    cart.Remove(selectedFood);
                    //Remove from listview
                    listViewCartItems.Items.Remove(li);
                }
                lblTotalAmount.Text = this.cart.TotalAmount.ToString();
            }
        }

        private void txtBox_TextChanged(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.Moccasin;
        }
    }
}
