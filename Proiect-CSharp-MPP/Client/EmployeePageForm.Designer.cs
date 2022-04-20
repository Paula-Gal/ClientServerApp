namespace Client
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
            ((System.ComponentModel.ISupportInitialize) (this.dataGridViewFlights)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridViewFilteredFlights)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewFlights
            // 
            this.dataGridViewFlights.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFlights.Location = new System.Drawing.Point(11, 117);
            this.dataGridViewFlights.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewFlights.Name = "dataGridViewFlights";
            this.dataGridViewFlights.RowHeadersWidth = 51;
            this.dataGridViewFlights.RowTemplate.Height = 24;
            this.dataGridViewFlights.Size = new System.Drawing.Size(414, 285);
            this.dataGridViewFlights.TabIndex = 0;
            // 
            // buttonLogout
            // 
            this.buttonLogout.Location = new System.Drawing.Point(543, 358);
            this.buttonLogout.Margin = new System.Windows.Forms.Padding(2);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(81, 30);
            this.buttonLogout.TabIndex = 1;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // textBoxSearchDestination
            // 
            this.textBoxSearchDestination.Location = new System.Drawing.Point(604, 48);
            this.textBoxSearchDestination.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxSearchDestination.Name = "textBoxSearchDestination";
            this.textBoxSearchDestination.Size = new System.Drawing.Size(180, 20);
            this.textBoxSearchDestination.TabIndex = 3;
            // 
            // labelTextBoxSearch
            // 
            this.labelTextBoxSearch.AutoSize = true;
            this.labelTextBoxSearch.Location = new System.Drawing.Point(540, 48);
            this.labelTextBoxSearch.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTextBoxSearch.Name = "labelTextBoxSearch";
            this.labelTextBoxSearch.Size = new System.Drawing.Size(60, 13);
            this.labelTextBoxSearch.TabIndex = 4;
            this.labelTextBoxSearch.Text = "Destination";
            // 
            // labelDatePickerDeparture
            // 
            this.labelDatePickerDeparture.AutoSize = true;
            this.labelDatePickerDeparture.Location = new System.Drawing.Point(541, 82);
            this.labelDatePickerDeparture.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDatePickerDeparture.Name = "labelDatePickerDeparture";
            this.labelDatePickerDeparture.Size = new System.Drawing.Size(54, 13);
            this.labelDatePickerDeparture.TabIndex = 5;
            this.labelDatePickerDeparture.Text = "Departure";
            // 
            // dateTimePickerDeparture
            // 
            this.dateTimePickerDeparture.Location = new System.Drawing.Point(604, 78);
            this.dateTimePickerDeparture.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerDeparture.Name = "dateTimePickerDeparture";
            this.dateTimePickerDeparture.Size = new System.Drawing.Size(180, 20);
            this.dateTimePickerDeparture.TabIndex = 6;
            // 
            // dataGridViewFilteredFlights
            // 
            this.dataGridViewFilteredFlights.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFilteredFlights.Location = new System.Drawing.Point(538, 117);
            this.dataGridViewFilteredFlights.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewFilteredFlights.Name = "dataGridViewFilteredFlights";
            this.dataGridViewFilteredFlights.RowHeadersWidth = 51;
            this.dataGridViewFilteredFlights.RowTemplate.Height = 24;
            this.dataGridViewFilteredFlights.Size = new System.Drawing.Size(320, 174);
            this.dataGridViewFilteredFlights.TabIndex = 7;
            // 
            // labelFlightsWelcome
            // 
            this.labelFlightsWelcome.AutoSize = true;
            this.labelFlightsWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.labelFlightsWelcome.Location = new System.Drawing.Point(34, 25);
            this.labelFlightsWelcome.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFlightsWelcome.Name = "labelFlightsWelcome";
            this.labelFlightsWelcome.Size = new System.Drawing.Size(155, 24);
            this.labelFlightsWelcome.TabIndex = 8;
            this.labelFlightsWelcome.Text = "Available flights";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(797, 71);
            this.buttonSearch.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(62, 25);
            this.buttonSearch.TabIndex = 9;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonPurchaseTicket
            // 
            this.buttonPurchaseTicket.Location = new System.Drawing.Point(538, 308);
            this.buttonPurchaseTicket.Margin = new System.Windows.Forms.Padding(2);
            this.buttonPurchaseTicket.Name = "buttonPurchaseTicket";
            this.buttonPurchaseTicket.Size = new System.Drawing.Size(86, 28);
            this.buttonPurchaseTicket.TabIndex = 10;
            this.buttonPurchaseTicket.Text = "Purchase";
            this.buttonPurchaseTicket.UseVisualStyleBackColor = true;
            this.buttonPurchaseTicket.Click += new System.EventHandler(this.buttonPurchaseTicket_Click);
            // 
            // EmployeePageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 428);
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
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "EmployeePageForm";
            this.Text = "Flights";
            this.Load += new System.EventHandler(this.EmployeePageForm_Load);
            ((System.ComponentModel.ISupportInitialize) (this.dataGridViewFlights)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridViewFilteredFlights)).EndInit();
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