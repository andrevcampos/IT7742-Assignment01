using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace bank
{
    public abstract class Customer
    {
        static int nextCustomersID = 1;
        public int customerID;
        private string firstName;
        private string lastName;
        private string accountType;
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
    }
    public class StaffAccount : Customer
    {
        private int discount;
        private string accountType;
        public StaffAccount(string newFirstName, string newLastName) : base(newFirstName, newLastName)
        {
            discount = 50;
            accountType = "Staff";
        }
        private int getDiscount
        {
            get { return discount; }
            set { discount = value; }
        }
        private string getAccountType
        {
            get { return accountType; }
            set { accountType = value; }
        }
    }
    public class PublicAccount : Customer
    {
        private int discount;
        private string accountType;
        public PublicAccount(string newFirstName, string newLastName) : base(newFirstName, newLastName)
        {
            discount = 0;
            accountType = "Public";
        }
        private int getDiscount
        {
            get { return discount; }
            set { discount = value; }
        }
        private string getAccountType
        {
            get { return accountType; }
            set { accountType = value; }
        }
    }

}