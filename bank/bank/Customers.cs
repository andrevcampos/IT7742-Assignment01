using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace bank
{
    class Customers
    {
        static int nextCustomersID = 1;
        public int customerID;
        public string firstName;
        public string lastName;
        public bool staff;
        private int balance;

        public Customers()
        {
            customerID = nextCustomersID;
            nextCustomersID++;
        }
        public Customers(string newFirstName, string newLastName) : this()
        {
            //constructor with parameters. :this ensures the default constructor is alwatys called first.
            firstName = newFirstName;
            lastName = newLastName;
            balance = 0;
            staff = false;
        }
        public Customers(string newFirstName, string newLastName, int newDeposit, bool newStaff) : this()
        {
            //constructor with parameters. :this ensures the default constructor is alwatys called first.
            firstName = newFirstName;
            lastName = newLastName;
            balance = newDeposit;
            staff = newStaff;   
        }

        public int Balance
        {
            get { return balance; }
            set { balance = value; }
        }

    }
}