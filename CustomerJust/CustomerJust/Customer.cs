using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomerJust.Model;
using CustomerJust.Manager;

namespace CustomerJust
{
    public partial class Customer : Form
    {
        Customers customers = new Customers();
        CustomerManager _customerManager = new CustomerManager();
        string verdict;
        List<Customers> customersList = new List<Customers>();

        public Customer()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            GetAllData();

            //MessageBox.Show(saveButton.Text);

            if( saveButton.Text == "Save")
            {
                verdict = _customerManager.CanBeAdded(customers);

                if (verdict.Equals("OK"))
                {
                    _customerManager.AddToRepository(customers);

                    //displayDataGridView.DataSource = null;
                    customersList = _customerManager.ShowAll();
                    FillDataGridView();

                    MessageBox.Show("Data Saved");
                }
                else
                {
                    MessageBox.Show(verdict);
                }

            }

            else
            {
                verdict = _customerManager.CanBeUpdated(customers);

                if (verdict.Equals("OK"))
                {
                    _customerManager.UpdateRepository(customers);

                    //displayDataGridView.DataSource = null;
                    customersList= _customerManager.ShowAll();
                    FillDataGridView();

                    MessageBox.Show("Data Updated");
                }
                else
                {
                    MessageBox.Show(verdict);
                }
            }
            
            
            

        }

        private void SearchButtonClick(object sender, EventArgs e)
        {
            //customersList.Clear();
            GetAllData();
            customersList = _customerManager.Search(customers);

            //displayDataGridView.DataSource = null;
            //displayDataGridView.DataSource = customersList;

            FillDataGridView();

            if (customersList.Count == 0)
            {
                MessageBox.Show("No Data Found!");
            }
        }

        private void FillDataGridView()
        {
            displayDataGridView.DataSource = null;
            displayDataGridView.DataSource = customersList;
            for (int a_i = 0; a_i < customersList.Count; a_i++) displayDataGridView.Rows[a_i].Cells[0].Value = (a_i+1).ToString();
        }

        // Methods
        private void GetAllData()
        {
            customers.Code = codeTextBox.Text;
            customers.Name = nameTextBox.Text;
            customers.Address = addressTextBox.Text;
            customers.Contact = contactTextBox.Text;
            customers.DistrictName = districtComboBox.Text;
        }

        private void DisplayDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            customersList = _customerManager.ShowAll();
            customers = customersList[e.RowIndex];
            SetAllData();
            saveButton.Text = "Update";
            MessageBox.Show("In");
        }

        private void SetAllData()
        {
            codeTextBox.Text = customers.Code;
            nameTextBox.Text = customers.Name;
            addressTextBox.Text = customers.Address;
            contactTextBox.Text = customers.Contact;
            districtComboBox.SelectedItem = customers.DistrictName;
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            districtComboBox.DataSource = _customerManager.GetDistrictsDataSource();
        }
    }
}
