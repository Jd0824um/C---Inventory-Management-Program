using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_Management
{
    public partial class formMain : Form
    {
        ImageList imageList = new ImageList();

        public formMain()
        {
            InitializeComponent();
            imageList.ImageSize = new Size(50, 50); //Sets the size of the list
            listViewInventory.SmallImageList = imageList; //Adds the list to the list view
            listViewInventory.Columns.Add("Picture", 70); //Adds columns
            listViewInventory.Columns.Add("Type", 60);
            listViewInventory.Columns.Add("Name", 100);
            listViewInventory.Columns.Add("Price", 50);
            listViewInventory.Columns.Add("Quanity", 50);
            listViewInventory.Columns.Add("Distributor", 100);
            listViewInventory.View = View.Details;
            listViewInventory.GridLines = true; //Adds gridlines to the view
            listViewInventory.FullRowSelect = true; //Allows the full row to be selected

            string[] comboBoxChoices = { "Add Product", "Delete Product", "Update Product" };

            foreach(string item in comboBoxChoices)
            {
                comboChoice.Items.Add(item);
            }
        }

        private int item_Count() 
        //Counts the number of items within the list view
        {
            int index = 0;
            foreach (ListViewItem item in listViewInventory.Items)
            {
                index += 1;
            }
            return index;
        }
        private void update_Item()
        {
            using (var updateForm = new Update_Product())
            {
                var item = listViewInventory.FocusedItem.SubItems;
                updateForm.returnName = item[0].ToString();


                var result = updateForm.ShowDialog();

            }
        }
        private void add_Item()
        //Adds a item to the list view. Uses a second form to gather information
        {
            using (var addForm = new formAddProduct())
            {
                var result = addForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (addForm.returnPicture == null) //Loads default image if it was left empty
                    {
                        var defaultImage = new Bitmap(Inventory_Management.Properties.Resources.Unknown);
                        imageList.Images.Add(addForm.returnName, defaultImage);

                    }
                    else //Adds selected image with its name as the key
                    {
                        imageList.Images.Add(addForm.returnName, Image.FromFile(addForm.returnPicture));
                    }
                    string[] newItem = new string[6];
                    newItem[1] = addForm.returnType;
                    newItem[2] = addForm.returnName;
                    newItem[3] = addForm.returnPrice;
                    newItem[4] = addForm.returnQuanitity;
                    newItem[5] = addForm.returnDistributor;

                    listViewInventory.Items.Add(new ListViewItem(newItem, item_Count()));
                    MessageBox.Show("Item was added!", "Message");
                    addForm.clearFutureValues();
                }
            }
        }
        private void delete_Item()
         //Deletes a item from user selection
        {
            DialogResult proceed = MessageBox.Show("Are you sure you want to delete this item?", "Delete Item?", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if(proceed == DialogResult.Yes)
            {
                var index = listViewInventory.FocusedItem.Index; //Gets index of selected item
                listViewInventory.Items.RemoveAt(index); //Deletes item
            }
            MessageBox.Show("Item was deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            
        }
        private void update_item()
        {
            DialogResult proceed = MessageBox.Show("Are you sure you want to delete this item?", "Delete Item?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (proceed == DialogResult.Yes)
            {
                var index = listViewInventory.FocusedItem.Index; //Gets index of selected item
                listViewInventory.Items.RemoveAt(index); //Deletes item
            }
            MessageBox.Show("Item was updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private void btnGo_Click(object sender, EventArgs e)
        //Gets the user choice and calls the appropriate function
        {
            switch (comboChoice.SelectedItem.ToString())
            {
                case "Add Product": //Brings up the add product form
                    add_Item();
                    break;
                case "Delete Product": //Brings up the function to delete a product
                    delete_Item();
                    break;
                case "Update Product": //Brings up the update product form
                    update_item();
                    break;
                default:
                    MessageBox.Show("Please select a option...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
         //Closes program
        {
            DialogResult proceed = MessageBox.Show("Quit?", "Exit program",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (proceed == DialogResult.Yes)
                this.Close();
        }
    }
}
