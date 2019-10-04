using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerJust.Model;
using CustomerJust.Repository;

namespace CustomerJust.Manager
{
    public class CustomerManager
    {
        CustomerRepository _customerRepository = new CustomerRepository();
        List<Customers> customersList = new List<Customers>();
        public string CanBeAdded(Customers customers)
        {
            customersList = ShowAll();
            if( customers.Code.Length != 4)
            {
                return "Code must be 4 Character Long.";
            }
            if( String.IsNullOrEmpty(customers.Name))
            {
                return "Name can't be empty";
            }
            if (customers.Contact.Length != 11)
            {
                return "Contact must be 11 Character Long.";
            }
            if (customers.DistrictName.Equals("-Select-"))
            {
                return "Select a District";
            }
            if( !IsValidContact(customers.Contact))
            {
                return "Contact can contain only digits!";
            }
            if(!IsUniqueName(customers))
            {
                return "Name is already taken\nUse different one.";
            }
            if (!IsUniqueCode(customers))
            {
                return "Code is already taken\nUse different one.";
            }
            if (!IsUniqueContact(customers))
            {
                return "Contact is already taken\nUse different one.";
            }

            return "OK";
        }

        public string CanBeUpdated(Customers customers)
        {
            customersList = ShowAll();
            if (customers.Code.Length != 4)
            {
                return "Code must be 4 Character Long.";
            }
            if (String.IsNullOrEmpty(customers.Name))
            {
                return "Name can't be empty";
            }
            if (customers.Contact.Length != 11)
            {
                return "Contact must be 11 Character Long.";
            }
            if (customers.DistrictName.Equals("-Select-"))
            {
                return "Select a District";
            }
            if (!IsValidContact(customers.Contact))
            {
                return "Contact can contain only digits!";
            }

            if (!IsUniqueName(customers))
            {
                return "Name is already taken\nUse different one.";
            }
            if (!IsUniqueCode(customers))
            {
                return "Code is already taken\nUse different one.";
            }
            if (!IsUniqueContact(customers))
            {
                return "Contact is already taken\nUse different one.";
            }

            return "OK";
        }

        public void AddToRepository(Customers customers)
        {
            _customerRepository.AddToRepository(customers);
        }

        public void UpdateRepository(Customers customers)
        {
            _customerRepository.UpdateRepository(customers);
        }

        public List<Customers> ShowAll()
        {
            return _customerRepository.ShowAll();
        }

        public List<Customers> Search( Customers customers)
        {
            return _customerRepository.Search(customers);
        }

        public List<Districts> GetDistrictsDataSource()
        {
            return _customerRepository.GetDistrictsDataSource();
        }



        // Private Methods------o--------

        private bool IsValidContact(string contact)
        {
            foreach(char ch in contact) if (ch < '0' || ch > '9') return false;
            return true;
        }

        private bool IsUniqueName(Customers customers)
        {
            foreach( Customers cuCustomers in customersList)
            {
                if (cuCustomers.Name.Equals(customers.Name) && customers.ID != cuCustomers.ID) return false;
            }
            return true;
        }

        private bool IsUniqueCode(Customers customers)
        {
            foreach (Customers cuCustomers in customersList)
            {
                if (cuCustomers.Code.Equals(customers.Code) && customers.ID != cuCustomers.ID) return false;
            }
            return true;
        }

        private bool IsUniqueContact(Customers customers)
        {
            foreach (Customers cuCustomers in customersList)
            {
                if (cuCustomers.Contact.Equals(customers.Contact) && customers.ID != cuCustomers.ID) return false;
            }
            return true;
        }



    }
}
