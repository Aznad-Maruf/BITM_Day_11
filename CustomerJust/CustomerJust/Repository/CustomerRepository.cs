using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerJust.Model;
using System.Data.SqlClient;
using System.Net.Sockets;

namespace CustomerJust.Repository
{
    public class CustomerRepository
    {
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;

        ConnectionRepository _connectionRepository = new ConnectionRepository();
        List<Customers> customersList = new List<Customers>();
        private List<Districts> districtsList = new List<Districts>();

        private string queryString;
        public void AddToRepository(Customers customers)
        {
            queryString = @"INSERT INTO Customers (Code, Name, Address, Contact, DistrictName) VALUES ('"+customers.Code+"', '"+customers.Name+"', '"+customers.Address+"', '"+customers.Contact+"', '"+customers.DistrictName+"');";
            ExecuteNonQuery();
        }

        public void UpdateRepository(Customers customers)
        {
            queryString = @"UPDATE Customers SET Code = '"+customers.Code+"', Name = '"+customers.Name+"', Address = '"+customers.Address+"', Contact = '"+customers.Contact+"', DistrictName = '"+customers.DistrictName+"' Where ID = "+customers.ID+";";
            ExecuteNonQuery();
        }

        public List<Customers> ShowAll()
        {
            queryString = @"SELECT * FROM Customers";
            ExecuteQuery();
            return customersList;
        }

        public List<Customers> Search(Customers customers)
        {
            queryString = @"SELECT * FROM Customers WHERE Code = '"+customers.Code+"'";
            ExecuteQuery();
            return customersList;
        }

        private int GetCustomerID(Customers customers)
        {
            ShowAll();
            queryString = @"Select ID FROM Customers WHERE Name = " + customers.Name + "";
            
            ExecuteQuery();
            return customersList[0].ID;

        }

        public List<Districts> GetDistrictsDataSource()
        {
            queryString = @"SELECT * FROM Districts ORDER BY Name";
            ExecuteQuery("Districts");
            return districtsList;
        }

        public void ExecuteNonQuery()
        {
            CreateConnectionAndMakeSqlCommand();
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        private void ExecuteQuery()
        {
            CreateConnectionAndMakeSqlCommand();

            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            //SqlDataReader sqlDataReader = _connectionRepository.ExecuteQuery();
            customersList.Clear();
            while (sqlDataReader.Read())
            {
                Customers customers = new Customers();
                customers.ID = Convert.ToInt32(sqlDataReader["ID"]);
                customers.Code = sqlDataReader["Code"].ToString();
                customers.Name = sqlDataReader["Name"].ToString();
                customers.Address = sqlDataReader["Address"].ToString();
                customers.Contact = sqlDataReader["Contact"].ToString();
                customers.DistrictName = sqlDataReader["DistrictName"].ToString();
                customersList.Add(customers);
            }
            sqlConnection.Close();
        }

        private void ExecuteQuery(string whichTable)
        {
            CreateConnectionAndMakeSqlCommand();

            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            //SqlDataReader sqlDataReader = _connectionRepository.ExecuteQuery();
            districtsList.Clear();
            while (sqlDataReader.Read())
            {
                Districts districts = new Districts();
                districts.ID = Convert.ToInt32(sqlDataReader["ID"]);
                districts.Name = sqlDataReader["Name"].ToString();
                districtsList.Add(districts);
            }
            sqlConnection.Close();
        }

        private void CreateConnectionAndMakeSqlCommand()
        {

            string connectionString = @"Server=ROBINHOOD\MARUFROBINSQL; Database=JustCustomers; Integrated Security = True";
            sqlConnection = new SqlConnection(connectionString);

            sqlCommand = new SqlCommand(queryString,sqlConnection);

        }


    }
}
