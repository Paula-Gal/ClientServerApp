namespace Proiect_CSharp_MPP
{
    partial class PurchaseTicketPageForm
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
            this.listViewTourists.Location = new System.Drawing.Point(44, 328);
            this.listViewTourists.Name = "listViewTourists";
            this.listViewTourists.Size = new System.Drawing.Size(228, 108);
            this.listViewTourists.TabIndex = 0;
            this.listViewTourists.UseCompatibleStateImageBehavior = false;
            // 
            // textBoxCustomerName
            // 
            this.textBoxCustomerName.Location = new System.Drawing.Point(44, 73);
            this.textBoxCustomerName.Name = "textBoxCustomerName";
            this.textBoxCustomerName.Size = new System.Drawing.Size(228, 22);
            this.textBoxCustomerName.TabIndex = 1;
            // 
            // labelCustomerName
            // 
            this.labelCustomerName.AutoSize = true;
            this.labelCustomerName.Location = new System.Drawing.Point(109, 53);
            this.labelCustomerName.Name = "labelCustomerName";
            this.labelCustomerName.Size = new System.Drawing.Size(109, 17);
            this.labelCustomerName.TabIndex = 2;
            this.labelCustomerName.Text = "Customer Name";
            //this.labelCustomerName.Click += new System.EventHandler(this.labelCustomerName_Click);
            // 
            // labelCustomerCnp
            // 
            this.labelCustomerCnp.AutoSize = true;
            this.labelCustomerCnp.Location = new System.Drawing.Point(109, 118);
            this.labelCustomerCnp.Name = "labelCustomerCnp";
            this.labelCustomerCnp.Size = new System.Drawing.Size(100, 17);
            this.labelCustomerCnp.TabIndex = 4;
            this.labelCustomerCnp.Text = "Customer CNP";
            //this.labelCustomerCnp.Click += new System.EventHandler(this.labelCustomerCnp_Click);
            // 
            // textBoxCustomerCnp
            // 
            this.textBoxCustomerCnp.Location = new System.Drawing.Point(44, 138);
            this.textBoxCustomerCnp.Name = "textBoxCustomerCnp";
            this.textBoxCustomerCnp.Size = new System.Drawing.Size(228, 22);
            this.textBoxCustomerCnp.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Customer Address";
            // 
            // textBoxCustomerAddress
            // 
            this.textBoxCustomerAddress.Location = new System.Drawing.Point(44, 200);
            this.textBoxCustomerAddress.Name = "textBoxCustomerAddress";
            this.textBoxCustomerAddress.Size = new System.Drawing.Size(228, 22);
            this.textBoxCustomerAddress.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(109, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Tourist Name";
            // 
            // textBoxTouristName
            // 
            this.textBoxTouristName.Location = new System.Drawing.Point(44, 261);
            this.textBoxTouristName.Name = "textBoxTouristName";
            this.textBoxTouristName.Size = new System.Drawing.Size(228, 22);
            this.textBoxTouristName.TabIndex = 7;
            // 
            // buttonAddTourist
            // 
            this.buttonAddTourist.Location = new System.Drawing.Point(97, 289);
            this.buttonAddTourist.Name = "buttonAddTourist";
            this.buttonAddTourist.Size = new System.Drawing.Size(114, 33);
            this.buttonAddTourist.TabIndex = 9;
            this.buttonAddTourist.Text = "Add tourist";
            this.buttonAddTourist.UseVisualStyleBackColor = true;
            this.buttonAddTourist.Click += new System.EventHandler(this.buttonAddTourist_Click);
            // 
            // buttonFinish
            // 
            this.buttonFinish.Location = new System.Drawing.Point(97, 453);
            this.buttonFinish.Name = "buttonFinish";
            this.buttonFinish.Size = new System.Drawing.Size(114, 31);
            this.buttonFinish.TabIndex = 10;
            this.buttonFinish.Text = "Finish";
            this.buttonFinish.UseVisualStyleBackColor = true;
            this.buttonFinish.Click += new System.EventHandler(this.buttonFinish_Click);
            // 
            // PurchaseTicketPageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 507);
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
            this.Name = "PurchaseTicketPageForm";
            this.Text = "Purchase Ticket";
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