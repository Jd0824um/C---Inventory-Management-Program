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
    public partial class formAddProduct : Form
    {

        public string returnName { get; set; }
        public string returnDistributor { get; set; }
        public string returnType { get; set; }
        public string returnPrice { get; set; }
        public string returnQuanitity { get; set; }
        public string returnPicture { get; set; }

        public formAddProduct()
        {
            InitializeComponent();
            pictureBoxAddProduct.SizeMode = PictureBoxSizeMode.StretchImage; //Sets picture box size to streach which
                                                        //sets the size of the image to the size of the picture box

            string[] productTypes = { "Produce", "Dairy", "Meat", "Equipment", "Misc" }; //Strings for the combobox

            foreach(string type in productTypes) //Assigns the strings to the combobox
            {
                comboType.Items.Add(type);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (isValidData()) //Checks if data is valid
            {
                DialogResult proceed = MessageBox.Show("Are you sure you want to add this item?", "Add Item?", MessageBoxButtons.YesNo, 
                                                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button2); //Yes/no message box to verify item to be added
                if (proceed == DialogResult.Yes)
                {
                    //Assigns global variables to the inputed data
                    this.returnName = txtName.Text;
                    this.returnPrice = txtPrice.Text;
                    this.returnQuanitity = txtQuantity.Text;
                    this.returnDistributor = txtDistributor.Text;
                    this.returnType = comboType.Text;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
        public void clearFutureValues()
            //Clears values from global variables
        {
            this.returnDistributor = null;
            this.returnName = null;
            this.returnPicture = null;
            this.returnPrice = null;
            this.returnQuanitity = null;
            this.returnType = null;
        }

        private bool isValidData()
            //Checks to see if the data entered in is valid data
        {
            if(isPresent(txtName, "Product Name") &&
                isPresent(txtPrice, "Price") &&
                isPresent(txtQuantity, "Quantitiy") &&
                isPresent(txtDistributor, "Distributor") &&

                isComboBoxSelected(comboType, "Product Type") &&
                
                isDecimal(txtPrice, "Price") &&
                isDecimal(txtQuantity, "Quantity"))
            {
                return true;
            }
            return false;
        }

        private bool isComboBoxSelected(ComboBox combobox, String name)
            //Validates if a selection has been made on the combobox
        {
            if(combobox.SelectedItem == null)
            {
                MessageBox.Show(name + " must be selected ");
                combobox.Focus();
                return false;
            }
            return true;
        }
        private bool isPresent(TextBox txtbox, String name)
            //Validates textbox for empty string
        {
            if(txtbox.Text == " ")
            {
                MessageBox.Show(name + " is a required field. Please enter in a " + name);
                txtbox.Focus();
                return false;
            }
            return true;
        }

        private bool isDecimal(TextBox txtbox, String name)
            //Validates textbox for a decimal number
        {
            Decimal number = 0m;

            if(Decimal.TryParse(txtbox.Text, out number))
            {
                return true;
            }
            MessageBox.Show(name + " must be an decimal");
            txtbox.Focus();
            return false;
        }

        private void btnExit_Click(object sender, EventArgs e)
            //Closes add product form
        {
            this.Close();
        }

        private void btnImage_Click(object sender, EventArgs e)
            //Adds a image to the picture box when the image button is clicked
        {
            OpenFileDialog openFileDialogPicture = new OpenFileDialog();

            openFileDialogPicture.InitialDirectory = "c:\\";//Opens in starting directory
            openFileDialogPicture.Filter = "Image Files(*.jpeg;*.bmp;*.png;*.jpg)|*.jpeg;*.bmp;*.png;*.jpg"; //Resticts the type of file that can be chosen
            openFileDialogPicture.Title = "Search for image to add"; //Sets the title
            if (openFileDialogPicture.ShowDialog() == DialogResult.OK)
            {
                string selectedImage = openFileDialogPicture.FileName; //Gets the selected image from the file
                pictureBoxAddProduct.Image = Image.FromFile(selectedImage); //Adds it to the picture box to preview
                this.returnPicture = selectedImage; //Sets global variable to image path
            }
            openFileDialogPicture.Dispose();
        }
    }
}
