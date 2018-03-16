namespace Inventory_Management
{
    partial class formMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listViewInventory = new System.Windows.Forms.ListView();
            this.btnGo = new System.Windows.Forms.Button();
            this.comboChoice = new System.Windows.Forms.ComboBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblChoice = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listViewInventory
            // 
            this.listViewInventory.Location = new System.Drawing.Point(12, 13);
            this.listViewInventory.Name = "listViewInventory";
            this.listViewInventory.Size = new System.Drawing.Size(403, 149);
            this.listViewInventory.TabIndex = 0;
            this.listViewInventory.UseCompatibleStateImageBehavior = false;
            // 
            // btnGo
            // 
            this.btnGo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnGo.Location = new System.Drawing.Point(34, 233);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 1;
            this.btnGo.Text = "Go!";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // comboChoice
            // 
            this.comboChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboChoice.FormattingEnabled = true;
            this.comboChoice.Location = new System.Drawing.Point(125, 187);
            this.comboChoice.Name = "comboChoice";
            this.comboChoice.Size = new System.Drawing.Size(121, 21);
            this.comboChoice.TabIndex = 2;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(159, 233);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblChoice
            // 
            this.lblChoice.AutoSize = true;
            this.lblChoice.Location = new System.Drawing.Point(50, 190);
            this.lblChoice.Name = "lblChoice";
            this.lblChoice.Size = new System.Drawing.Size(43, 13);
            this.lblChoice.TabIndex = 4;
            this.lblChoice.Text = "Choice:";
            // 
            // formMain
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(427, 268);
            this.Controls.Add(this.lblChoice);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.comboChoice);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.listViewInventory);
            this.Name = "formMain";
            this.Text = "Product Inventory Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewInventory;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.ComboBox comboChoice;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblChoice;
    }
}

