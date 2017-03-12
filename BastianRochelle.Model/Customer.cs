using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BastianRochelle.Model
{
    public class Customer
    {
        public string FirstName;
        public string LastName;
        public string ContactNo;
        public string Address;
        public double CashTendered;

        public Customer(string firstName, string lastName, string contactNo, string address, double cashTendered)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.ContactNo = contactNo;
            this.Address = address;
            this.CashTendered = cashTendered;
        }

        public string[] GetCustomerDetails()
        {
            string[] customerDetails = new string[3];
            customerDetails[0] = this.FirstName.ToString();
            customerDetails[1] = this.LastName.ToString();
            customerDetails[2] = this.ContactNo.ToString();
            customerDetails[3] = this.Address.ToString();
            return customerDetails;
        }
    }
}
