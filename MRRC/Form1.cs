using MRRCManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MRRC {
    public partial class Form1 : Form {

        //Author: Jericho Duggan

        private Vehicle vehicle;
        private Customer customer;
        private Fleet fleet;
        private CRM crm;

        private Vehicle selectedVehicle = null;
        private Customer selectedCustomer = null;
        private const int V_REG = 0;
        private const int ID_COL = 0;

        public Form1() {
            //Author: Jericho Duggan

            InitializeComponent();            
            SetupComponents();

            SetupdvgFleetColumns();
            SetupdvgCustomerColumns();

            PopulatCustomerGrid();
            PopulateFleetGrid();

            gbUpdateAddCustomer.Visible = false;
            gbModifyAddVehicle.Visible = false;
        }

        private string[] customerColumns = new string[] { "CustomerID", "Title", "FirstName", "LastName", "Gender", "DOB" };
        
        

        private void SetupdvgCustomerColumns() {

            //Author: Jericho Duggan

            dgvCustomers.ColumnCount = customerColumns.Length;
            for (int i = 0; i < customerColumns.Length; i++) {
                dgvCustomers.Columns[i].Name = customerColumns[i];
            }
        }

        private string[] fleetColumns = new string[] { "Rego", "Make", "Model", "Year", "Vehicle Class", "Seats", "Transmisison", "Fuel", "GPS", "Sunroof", "Colour", "Daily Rate" };
        
        private void SetupdvgFleetColumns() {

            //Author: Jericho Duggan
            dgvFleet.ColumnCount = fleetColumns.Length;
            for (int i = 0; i < fleetColumns.Length; i++)
            {
                dgvFleet.Columns[i].Name = fleetColumns[i];
            }
        }
        
        private void SetupComponents() {

            //Author: Jericho Duggan

            crm = new CRM();
            crm.LoadFromFile();
            fleet = new Fleet();
            fleet.LoadFromFile();
        }

        public void PopulatCustomerGrid() {
            //Author: Jericho Duggan

            dgvCustomers.Rows.Clear();

            foreach (Customer cust in crm.GetCustomers()) {
                dgvCustomers.Rows.Add(new string[] { cust._CustomerID.ToString(), cust._Title, cust._FirstNames, cust._LastName, cust._Gender.ToString(), cust._DateOfBirth });
            }
        }

        private void PopulateFleetGrid() {
            //Author: Jericho Duggan

            dgvFleet.Rows.Clear();

            foreach (Vehicle variable in fleet.GetFleet())
            {
                dgvFleet.Rows.Add(new string[] {variable._VehicleRego,variable._Model,variable._Make,
                variable._Year.ToString(), variable._VehicleClass.ToString(), variable._NumSeats.ToString(),
                    variable._Transmissiontype.ToString(), variable._FuelType.ToString(),
                variable._gps.ToString(), variable._SunRoof.ToString(), variable._Colour,
                variable._DailyRate.ToString()});
            }
        }

        private void btnModifyVehicle_Click(object sender, EventArgs e)
        {

            //Author: Jericho Duggan

            gbModifyFleet.Enabled = false;
            gbModifyAddVehicle.Visible = true;
            dgvFleet.Enabled = false;
            btnSubmitVehicle.Enabled = false;



        
        
          
}

        private void btnCancelVehicle_Click(object sender, EventArgs e) {
            //Author: Jericho Duggan

            gbModifyAddVehicle.Visible = false;
            gbModifyFleet.Enabled = true;
            dgvFleet.Enabled = true;
        }

        private void dgvFleet_SelectionChanged(object sender, EventArgs e) {
            //Author: Jericho Duggan

            int rowsCount = dgvFleet.SelectedRows.Count;
            if (rowsCount == 0 || rowsCount > 1)
            {
                selectedVehicle = null;
            }
            else
            {

                string selectedRego = (dgvFleet.SelectedRows[0].Cells[V_REG].Value.ToString());
                selectedVehicle = fleet.GetVehicle(selectedRego);
            }

        }

        private void btnRemoveVehicle_Click(object sender, EventArgs e) {
            //Author: Jericho Duggan
            DialogResult dialogResult = MessageBox.Show(String.Format("Do you really want to remove vehicle {0}?", selectedVehicle._VehicleRego), "Remove vehicle confirmation", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                fleet.RemoveVehicle(selectedVehicle);
            }
            PopulateFleetGrid();

        }

        private void dgvCustomers_SelectionChanged(object sender, EventArgs e) {
            //Author: Jericho Duggan

            int rowsCount = dgvCustomers.SelectedRows.Count;
            if (rowsCount == 0 || rowsCount > 1) {
                selectedCustomer = null;
            } else {
                int selectedId = int.Parse(dgvCustomers.SelectedRows[0].Cells[0].Value.ToString());
                selectedCustomer = crm.GetCustomer(selectedId);
            }
        }

        private void btnRemoveCustomer_Click(object sender, EventArgs e) {
            //Author: Jericho Duggan
            DialogResult dialogResult = MessageBox.Show(String.Format("Do you really want to remove customer {0}?", selectedCustomer._CustomerID), "Remove customer confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes) {
                crm.RemoveCustomer(selectedCustomer, fleet);
            }
            PopulatCustomerGrid();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            //Author: Paolo Jaldon
            MessageBox.Show(String.Format("See you next time!"));          
            crm.SaveToFile();
            fleet.SaveToFile();
            
           
        }

        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Author: Paolo Jaldon
            string searchValue = textBox1.Text;
            
           /* if (Vehicle._vehicleRegos.Contains(searchValue))
            {
                dgvResults.
            } */
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAddVehicle_Click(object sender, EventArgs e)
        {
            //Author: Jericho Duggan
            gbModifyFleet.Enabled = false;
            gbModifyAddVehicle.Visible = true;
            dgvFleet.Enabled = false;
            txtbRego.Enabled = true;
            gbModifyAddVehicle.Text = "Add vehicle";
        }

        private void btnSubmitVehicle_Click(object sender, EventArgs e)
        {
            //Author: Paolo Jaldon
            if (gbModifyAddVehicle.Text == "Modify Vehicle")
            {
                selectedVehicle._VehicleRego = txtbRego.Text;
                selectedVehicle._Make = txtbMake.Text;
                selectedVehicle._Model = txtbModel.Text;
                selectedVehicle._VehicleClass = (Vehicle.VehicleClass)Enum.Parse(typeof(Vehicle.VehicleClass), cbobClass.Text);
                selectedVehicle._Year = int.Parse((txtbYear.Text));
                selectedVehicle._Transmissiontype = (Vehicle.TransmissionType)Enum.Parse(typeof(Vehicle.TransmissionType), cbobTransmission.Text);
                selectedVehicle._FuelType = (Vehicle.FuelType)Enum.Parse(typeof(Vehicle.FuelType), cbobFuel.Text);
                selectedVehicle._NumSeats = int.Parse(nudSeats.Text);

                if (chbxGPS.Checked)
                {
                    selectedVehicle._gps = true;
                }
                else
                {
                    selectedVehicle._gps = false;
                }

                if (chbxSunroof.Checked)
                {
                    selectedVehicle._SunRoof = true;
                }
                else
                {
                    selectedVehicle._SunRoof = false;
                }

                selectedVehicle._Colour= txtbColour.Text;
                selectedVehicle._DailyRate = int.Parse(nudDailyRate.Text);
                
            }
            else
            {
                Vehicle newVehicle = new Vehicle(txtbRego.Text, (Vehicle.VehicleClass)Enum.Parse(typeof(Vehicle.VehicleClass), cbobClass.Text), txtbMake.Text, txtbModel.Text, int.Parse(txtbYear.Text), int.Parse(nudSeats.Text), (Vehicle.TransmissionType)Enum.Parse(typeof(Vehicle.TransmissionType) ,cbobTransmission.Text), (Vehicle.FuelType)Enum.Parse(typeof(Vehicle.FuelType), cbobFuel.Text), selectedVehicle._gps, selectedVehicle._SunRoof, int.Parse(nudDailyRate.Text), txtbColour.Text);
                fleet.AddVehicle(newVehicle);
            }

            PopulateFleetGrid();

            //txtbCustomerID.Enabled = true;
            //txtbCustomerID.Text = "";
            //txtbFirstName.Text = "";
            //txtbLastName.Text = "";
            //txtbDOB.Text = "";
        }

        private void cbobClass_SelectedIndexChanged(object sender, EventArgs e)
        {
          /*  foreach (var item in Enum.GetValues(typeof(VehicleClass)))
            {
                cbobClass.Items.Add(item);
            }*/

           cbobClass.DataSource = Enum.GetNames(typeof(VehicleClass));
        }
        enum VehicleClass
        {
        Family ,
        Luxury,
        Economy,
        Commercial
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            //Author: Jericho Duggan
            dgvCustomers.Enabled = false;
            gbModifyCustomer.Enabled = false;
            gbUpdateAddCustomer.Text = "Add customer";
            gbUpdateAddCustomer.Visible = true;
        }

        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            //Author: Jericho Duggan
            dgvCustomers.Enabled = false;
            txtbCustomerID.Enabled = false;
            gbModifyCustomer.Enabled = false;
            gbUpdateAddCustomer.Text = "Update customer details";
            gbUpdateAddCustomer.Visible = true;

            txtbCustomerID.Text = selectedCustomer._CustomerID.ToString();
            cbobTitle.Text = selectedCustomer._Title;
            txtbFirstName.Text = selectedCustomer._FirstNames;
            txtbLastName.Text = selectedCustomer._LastName;
            cbobGender.SelectedIndex = (int)selectedCustomer._Gender;
            txtbDOB.Text = selectedCustomer._DateOfBirth;
        }

        private void btnCancelCustomer_Click(object sender, EventArgs e)
        {
            //Author: Jericho Duggan
            dgvCustomers.Enabled = true;
            gbModifyCustomer.Enabled = true;
            gbUpdateAddCustomer.Visible = false;
            txtbCustomerID.Enabled = true;

            txtbCustomerID.Text = "";
            txtbFirstName.Text = "";
            txtbLastName.Text = "";
            txtbDOB.Text = "";
        }

        private void btnSubmitCustomer_Click(object sender, EventArgs e)
        {
            //Author: Jericho Duggan
            if (gbUpdateAddCustomer.Text == "Update customer details")
            {
                selectedCustomer._FirstNames = txtbFirstName.Text;
                selectedCustomer._LastName = txtbLastName.Text;
                selectedCustomer._DateOfBirth = txtbDOB.Text;
                selectedCustomer._Gender = (Customer.Gender)Enum.Parse(typeof(Customer.Gender), cbobGender.Text);
                selectedCustomer._Title = cbobTitle.Text;
            }
            else
            {
                Customer newCustomer = new Customer(int.Parse(txtbCustomerID.Text), cbobTitle.Text, txtbFirstName.Text, txtbLastName.Text, (Customer.Gender)Enum.Parse(typeof(Customer.Gender), cbobGender.Text), txtbDOB.Text);
                crm.AddCustomer(newCustomer);
            }

            PopulatCustomerGrid();

            txtbCustomerID.Enabled = true;
            txtbCustomerID.Text = "";
            txtbFirstName.Text = "";
            txtbLastName.Text = "";
            txtbDOB.Text = "";

        }
    }
    }
    

