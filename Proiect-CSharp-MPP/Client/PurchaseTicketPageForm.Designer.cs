namespace Client
{
    public partial class PurchaseTicketPageForm
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
            this.listViewTourists = new System.Windows.Forms.ListView();
            this.textBoxCustomerName = new System.Windows.Forms.TextBox();
            this.labelCustomerName = new System.Windows.Forms.Label();
            this.labelCustomerCnp = new System.Windows.Forms.Label();
            this.textBoxCustomerCnp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCustomerAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxTouristName = new System.Windows.Forms.TextBox();
            this.buttonAddTourist = new System.Windows.Forms.Button();
            this.buttonFinish = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewTourists
            // 
            this.listViewTourists.HideSelection = false;
            this.listViewTourists.Location = new System.Drawing.Point(33, 266);
            this.listViewTourists.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listViewTourists.Name = "listViewTourists";
            this.listViewTourists.Size = new System.Drawing.Size(172, 88);
            this.listViewTourists.TabIndex = 0;
            this.listViewTourists.UseCompatibleStateImageBehavior = false;
            // 
            // textBoxCustomerName
            // 
            this.textBoxCustomerName.Location = new System.Drawing.Point(33, 59);
            this.textBoxCustomerName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxCustomerName.Name = "textBoxCustomerName";
            this.textBoxCustomerName.Size = new System.Drawing.Size(172, 20);
            this.textBoxCustomerName.TabIndex = 1;
            // 
            // labelCustomerName
            // 
            this.labelCustomerName.AutoSize = true;
            this.labelCustomerName.Location = new System.Drawing.Point(82, 43);
            this.labelCustomerName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCustomerName.Name = "labelCustomerName";
            this.labelCustomerName.Size = new System.Drawing.Size(82, 13);
            this.labelCustomerName.TabIndex = 2;
            this.labelCustomerName.Text = "Customer Name";
            // 
            // labelCustomerCnp
            // 
            this.labelCustomerCnp.AutoSize = true;
            this.labelCustomerCnp.Location = new System.Drawing.Point(82, 96);
            this.labelCustomerCnp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCustomerCnp.Name = "labelCustomerCnp";
            this.labelCustomerCnp.Size = new System.Drawing.Size(76, 13);
            this.labelCustomerCnp.TabIndex = 4;
            this.labelCustomerCnp.Text = "Customer CNP";
            // 
            // textBoxCustomerCnp
            // 
            this.textBoxCustomerCnp.Location = new System.Drawing.Point(33, 112);
            this.textBoxCustomerCnp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxCustomerCnp.Name = "textBoxCustomerCnp";
            this.textBoxCustomerCnp.Size = new System.Drawing.Size(172, 20);
            this.textBoxCustomerCnp.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 146);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Customer Address";
            // 
            // textBoxCustomerAddress
            // 
            this.textBoxCustomerAddress.Location = new System.Drawing.Point(33, 162);
            this.textBoxCustomerAddress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxCustomerAddress.Name = "textBoxCustomerAddress";
            this.textBoxCustomerAddress.Size = new System.Drawing.Size(172, 20);
            this.textBoxCustomerAddress.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 196);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Tourist Name";
            // 
            // textBoxTouristName
            // 
            this.textBoxTouristName.Location = new System.Drawing.Point(33, 212);
            this.textBoxTouristName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxTouristName.Name = "textBoxTouristName";
            this.textBoxTouristName.Size = new System.Drawing.Size(172, 20);
            this.textBoxTouristName.TabIndex = 7;
            // 
            // buttonAddTourist
            // 
            this.buttonAddTourist.Location = new System.Drawing.Point(73, 235);
            this.buttonAddTourist.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonAddTourist.Name = "buttonAddTourist";
            this.buttonAddTourist.Size = new System.Drawing.Size(86, 27);
            this.buttonAddTourist.TabIndex = 9;
            this.buttonAddTourist.Text = "Add";
            this.buttonAddTourist.UseVisualStyleBackColor = true;
            this.buttonAddTourist.Click += new System.EventHandler(this.buttonAddTourist_Click);
            // 
            // buttonFinish
            // 
            this.buttonFinish.Location = new System.Drawing.Point(73, 368);
            this.buttonFinish.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonFinish.Name = "buttonFinish";
            this.buttonFinish.Size = new System.Drawing.Size(86, 25);
            this.buttonFinish.TabIndex = 10;
            this.buttonFinish.Text = "Finish";
            this.buttonFinish.UseVisualStyleBackColor = true;
            this.buttonFinish.Click += new System.EventHandler(this.buttonFinish_Click);
            // 
            // PurchaseTicketPageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 412);
            this.Controls.Add(this.buttonFinish);
            this.Controls.Add(this.buttonAddTourist);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxTouristName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxCustomerAddress);
            this.Controls.Add(this.labelCustomerCnp);
            this.Controls.Add(this.textBoxCustomerCnp);
            this.Controls.Add(this.labelCustomerName);
            this.Controls.Add(this.textBoxCustomerName);
            this.Controls.Add(this.listViewTourists);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "PurchaseTicketPageForm";
            this.Text = "Purchase Ticket";
            this.Load += new System.EventHandler(this.PurchaseTicketPageForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ListView listViewTourists;
        private System.Windows.Forms.TextBox textBoxCustomerName;
        private System.Windows.Forms.Label labelCustomerName;
        private System.Windows.Forms.Label labelCustomerCnp;
        private System.Windows.Forms.TextBox textBoxCustomerCnp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCustomerAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxTouristName;
        private System.Windows.Forms.Button buttonAddTourist;
        private System.Windows.Forms.Button buttonFinish;
    }
}