using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bank
{
    class Account
    {
        static int nextAccountID = 1;
        public int AccountID;
        public string type;
        public string lastName;
        public bool staff;
        private int balance;
    }
}