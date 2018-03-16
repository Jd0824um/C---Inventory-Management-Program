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
        public formMain()
        {
            InitializeComponent();

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

        private void btnGo_Click(object sender, EventArgs e)
        {
            switch (comboChoice.SelectedItem.ToString())
            {
                case "Add Product": //Brings up the add product form

                    using (var addForm = new formAddProduct())
                    {
                        var result = addForm.ShowDialog();
                        if(result == DialogResult.OK)
                        {
                            ImageList imagelist = new ImageList();
                            imagelist.ImageSize = new Size(50, 50);

                            if(addForm.returnPicture != null)
                            {
                                imagelist.Images.Add(Image.FromFile(addForm.returnPicture));
                                listViewInventory.SmallImageList = imagelist;
                            }                            
                            string[] newItem = new string[6];
                            newItem[1] = addForm.returnType;
                            newItem[2] = addForm.returnName;
                            newItem[3] = addForm.returnPrice;
                            newItem[4] = addForm.returnQuanitity;
                            newItem[5] = addForm.returnDistributor;

                            listViewInventory.Items.Add(new ListViewItem(newItem, 0));
                            addForm.clearFutureValues();
                        }
                    }
                    break;
                case "Delete Product":
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
