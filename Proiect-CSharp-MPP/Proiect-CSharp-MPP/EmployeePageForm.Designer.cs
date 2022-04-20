namespace Proiect_CSharp_MPP
{
    partial class EmployeePageForm
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
            this.dataGridViewFlights = new System.Windows.Forms.DataGridView();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.textBoxSearchDestination = new System.Windows.Forms.TextBox();
            this.labelTextBoxSearch = new System.Windows.Forms.Label();
            this.labelDatePickerDeparture = new System.Windows.Forms.Label();
            this.dateTimePickerDeparture = new System.Windows.Forms.DateTimePicker();
            this.dataGridViewFilteredFlights = new System.Windows.Forms.DataGridView();
            this.labelFlightsWelcome = new System.Windows.Forms.Label();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonPurchaseTicket = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFlights)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFilteredFlights)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewFlights
            // 
            this.dataGridViewFlights.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFlights.Location = new System.Drawing.Point(44, 144);
            this.dataGridViewFlights.Name = "dataGridViewFlights";
            this.dataGridViewFlights.RowHeadersWidth = 51;
            this.dataGridViewFlights.RowTemplate.Height = 24;
            this.dataGridViewFlights.Size = new System.Drawing.Size(552, 351);
            this.dataGridViewFlights.TabIndex = 0;
            // 
            // buttonLogout
            // 
            this.buttonLogout.Location = new System.Drawing.Point(1129, 12);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(108, 37);
            this.buttonLogout.TabIndex = 1;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // textBoxSearchDestination
            // 
            this.textBoxSearchDestination.Location = new System.Drawing.Point(805, 59);
            this.textBoxSearchDestination.Name = "textBoxSearchDestination";
            this.textBoxSearchDestination.Size = new System.Drawing.Size(239, 22);
            this.textBoxSearchDestination.TabIndex = 3;
            // 
            // labelTextBoxSearch
            // 
            this.labelTextBoxSearch.AutoSize = true;
            this.labelTextBoxSearch.Location = new System.Drawing.Point(720, 59);
            this.labelTextBoxSearch.Name = "labelTextBoxSearch";
            this.labelTextBoxSearch.Size = new System.Drawing.Size(79, 17);
            this.labelTextBoxSearch.TabIndex = 4;
            this.labelTextBoxSearch.Text = "Destination";
            // 
            // labelDatePickerDeparture
            // 
            this.labelDatePickerDeparture.AutoSize = true;
            this.labelDatePickerDeparture.Location = new System.Drawing.Point(721, 101);
            this.labelDatePickerDeparture.Name = "labelDatePickerDeparture";
            this.labelDatePickerDeparture.Size = new System.Drawing.Size(72, 17);
            this.labelDatePickerDeparture.TabIndex = 5;
            this.labelDatePickerDeparture.Text = "Departure";
            //this.labelDatePickerDeparture.Click += new System.EventHandler(this.labelDatePickerDeparture_Click);
            // 
            // dateTimePickerDeparture
            // 
            this.dateTimePickerDeparture.Location = new System.Drawing.Point(806, 96);
            this.dateTimePickerDeparture.Name = "dateTimePickerDeparture";
            this.dateTimePickerDeparture.Size = new System.Drawing.Size(239, 22);
            this.dateTimePickerDeparture.TabIndex = 6;
            //this.dateTimePickerDeparture.ValueChanged += new System.EventHandler(this.dateTimePickerDeparture_ValueChanged);
            // 
            // dataGridViewFilteredFlights
            // 
            this.dataGridViewFilteredFlights.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFilteredFlights.Location = new System.Drawing.Point(718, 144);
            this.dataGridViewFilteredFlights.Name = "dataGridViewFilteredFlights";
            this.dataGridViewFilteredFlights.RowHeadersWidth = 51;
            this.dataGridViewFilteredFlights.RowTemplate.Height = 24;
            this.dataGridViewFilteredFlights.Size = new System.Drawing.Size(427, 214);
            this.dataGridViewFilteredFlights.TabIndex = 7;
            // 
            // labelFlightsWelcome
            // 
            this.labelFlightsWelcome.AutoSize = true;
            this.labelFlightsWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFlightsWelcome.Location = new System.Drawing.Point(45, 31);
            this.labelFlightsWelcome.Name = "labelFlightsWelcome";
            this.labelFlightsWelcome.Size = new System.Drawing.Size(372, 55);
            this.labelFlightsWelcome.TabIndex = 8;
            this.labelFlightsWelcome.Text = "Available flights";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(1063, 87);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(82, 31);
            this.buttonSearch.TabIndex = 9;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonPurchaseTicket
            // 
            this.buttonPurchaseTicket.Location = new System.Drawing.Point(718, 379);
            this.buttonPurchaseTicket.Name = "buttonPurchaseTicket";
            this.buttonPurchaseTicket.Size = new System.Drawing.Size(114, 35);
            this.buttonPurchaseTicket.TabIndex = 10;
            this.buttonPurchaseTicket.Text = "Purchase";
            this.buttonPurchaseTicket.UseVisualStyleBackColor = true;
            this.buttonPurchaseTicket.Click += new System.EventHandler(this.buttonPurchaseTicket_Click);
            // 
            // EmployeePageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 527);
            this.Controls.Add(this.buttonPurchaseTicket);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.labelFlightsWelcome);
            this.Controls.Add(this.dataGridViewFilteredFlights);
            this.Controls.Add(this.dateTimePickerDeparture);
            this.Controls.Add(this.labelDatePickerDeparture);
            this.Controls.Add(this.labelTextBoxSearch);
            this.Controls.Add(this.textBoxSearchDestination);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.dataGridViewFlights);
            this.Name = "EmployeePageForm";
            this.Text = "Flights";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFlights)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFilteredFlights)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewFlights;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.TextBox textBoxSearchDestination;
        private System.Windows.Forms.Label labelTextBoxSearch;
        private System.Windows.Forms.Label labelDatePickerDeparture;
        private System.Windows.Forms.DateTimePicker dateTimePickerDeparture;
        private System.Windows.Forms.DataGridView dataGridViewFilteredFlights;
        private System.Windows.Forms.Label labelFlightsWelcome;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonPurchaseTicket;
    }
}