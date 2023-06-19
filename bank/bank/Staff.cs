using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace bank
{
    class Staff : Customers
    {
        private int customerID;
        private int customerID2;
        public Staff(int newcustomerID)
        {
            customerID = newcustomerID;
        }
        public int CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }
    }
}