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
            imageList.ImageSize = new Size(50, 50);
            listViewInventory.SmallImageList = imageList;
            listViewInventory.Columns.Add("Picture", 70);
            listViewInventory.Columns.Add("Type", 60);
            listViewInventory.Columns.Add("Name", 100);
            listViewInventory.Columns.Add("Price", 50);
            listViewInventory.Columns.Add("Quanity", 50);
            listViewInventory.Columns.Add("Distributor", 100);
            listViewInventory.View = View.Details;
            listViewInventory.GridLines = true;
            listViewInventory.FullRowSelect = true;

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

        private void add_Item()
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
                    addForm.clearFutureValues();
                }
            }
        }


        private void delete_Item()
        {
            DialogResult proceed = MessageBox.Show("Are you sure you want to delete this item?", "Delete Item?", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if(proceed == DialogResult.Yes)
            {
                var index = listViewInventory.FocusedItem.Index;
                listViewInventory.Items.RemoveAt(index);
            }
            
        }
        private void btnGo_Click(object sender, EventArgs e)
        {
           
            switch (comboChoice.SelectedItem.ToString())
            {
                case "Add Product": //Brings up the add product form
                    add_Item();
                    break;
                case "Delete Product":
                    delete_Item();
                    break;
                case "Update Product":
                    break;
                default:
                    break;
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
            //Closes program
        {
            this.Close();
        }
    }
}
