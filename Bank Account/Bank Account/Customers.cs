using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Account
{
    public abstract class Customer
    {
        static int nextCustomersID = 1;
        public int customerID;
        private string firstName;
        private string lastName;
        public List<Account> accounts = new List<Account>();

        public Customer(string newFirstName, string newLastName)
        {
            //constructor with parameters. :this ensures the default constructor is alwatys called first.
            customerID = nextCustomersID;
            nextCustomersID++;
            firstName = newFirstName;
            lastName = newLastName;
        }
        private string getFistName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        private string getLastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        private int GetAccountNumber
        {
            get
            {
                int number = accounts.Count;
                return number;
            }
        }
        private List<Account> GetAccountList
        {
            get { return accounts; }
            set { accounts = value; }
        }
        public void NewAccount(Account newAccount)
        {
            accounts.Add(newAccount);
        }
        public virtual string Info()
        {
            return firstName + " " + lastName;
        }
        public override string ToString()
        {
            return Info();
        }
    }
    public class StaffAccount : Customer
    {
        private int discount;
        public StaffAccount(string newFirstName, string newLastName) : base(newFirstName, newLastName)
        {
            discount = 50;
        }
        private int getDiscount
        {
            get { return discount; }
            set { discount = value; }
        }
        public override string Info()
        {
            return base.Info() + "; (Employee Account)";
        }
    }
    public class PublicAccount : Customer
    {
        private int discount;
        public PublicAccount(string newFirstName, string newLastName) : base(newFirstName, newLastName)
        {
            discount = 0;
        }
        private int getDiscount
        {
            get { return discount; }
            set { discount = value; }
        }
    }

}