using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bank
{
    public abstract class Account
    {
        static int nextAccountID = 1;
        private int AccountID;
        

        public Account()
        {
            AccountID = nextAccountID;
            nextAccountID++;
        }
        private int GetAccountID
        {
            get { return AccountID; }
            set { AccountID = value; }
        }
        public virtual string Info()
        {
            return AccountID.ToString();
        }
        public override string ToString()
        {
            return Info();
        }

    }
    public class Everyday : Account
    {
        private string accountType;
        private int balance;
        public Everyday() : base()
        {
            accountType = "Everyday";
        }
        public Everyday(int newbalance) : base()
        {
            accountType = "Everyday";
            balance = newbalance;
        }
        private string GetAccountType
        {
            get { return accountType; }
            set { accountType = value; }
        }
        private int GetBalance
        {
            get { return balance; }
            set { balance = value; }
        }
        public override string Info() 
        { 
            return accountType + base.Info() + ", Balance:" + balance;
        }
    }
    public class Inverstiment : Account
    {
        private string accountType;
        private int balance;
        private int interest;
        private int fees;
        public Inverstiment() : base()
        {
            accountType = "Inverstiment";
            interest = 0;
            fees = 0;
        }
        public Inverstiment(int newbalance) : base()
        {
            accountType = "Inverstiment";
            interest = 0;
            fees = 0;
        }
        private string GetAccountType
        {
            get { return accountType; }
            set { accountType = value; }
        }
        private int GetBalance
        {
            get { return balance; }
            set { balance = value; }
        }
        private int GetFees
        {
            get { return fees; }
            set { fees = value; }
        }
        private int GetInterest
        {
            get { return interest; }
            set { interest = value; }
        }
        public override string Info()
        {
            return accountType + base.Info() + ", Interest Rate:" + interest + "%; Fee: $" + fees + "; Balance:" + balance;
        }
    }

    public class Omni : Account
    {
        private string accountType;
        private int balance;
        private int interest;
        private int overdraft;
        private int fees;
        public Omni() : base()
        {
            accountType = "Inverstiment";
            interest = 0;
            fees = 0;
        }
        public Omni(int newbalance) : base()
        {
            accountType = "Inverstiment";
            interest = 0;
            fees = 0;
        }
        private string GetAccountType
        {
            get { return accountType; }
            set { accountType = value; }
        }
        private int GetBalance
        {
            get { return balance; }
            set { balance = value; }
        }
        private int GetFees
        {
            get { return fees; }
            set { fees = value; }
        }
        private int GetInterest
        {
            get { return interest; }
            set { interest = value; }
        }
        private int GetOverdraft
        {
            get { return overdraft; }
            set { overdraft = value; }
        }
        public override string Info()
        {
            return accountType + base.Info() + ", Interest Rate:" + interest + "%; Overdraft Limit: " + overdraft + "; Fee: $" + fees + "; Balance:" + balance;
        }
    }
}