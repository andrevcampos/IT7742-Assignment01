using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Account
{
    public abstract class Account
    {
        static int nextAccountID = 1;
        private int AccountID;
        private int balance;
        private string accountType;

        public Account(string newAccountType)
        {
            AccountID = nextAccountID;
            nextAccountID++;
            accountType = newAccountType;
        }
        public Account(string newAccountType, int newBalance)
        {
            AccountID = nextAccountID;
            nextAccountID++;
            accountType = newAccountType;
            balance = newBalance;
        }
        private int GetAccountID
        {
            get { return AccountID; }
            set { AccountID = value; }
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
        public virtual string Info()
        {
            return accountType + " " + AccountID.ToString() + ", Balance: " + balance;
        }
        public override string ToString()
        {
            return Info();
        }

    }
    public class Everyday : Account
    {
        //fee is not applied
        //overdraft is not allowed
        //interest is not applied
        public Everyday() : base("Everyday")
        {
        }
        public Everyday(int newbalance) : base("Everyday", newbalance)
        {
        }
    }
    public class Inverstiment : Account
    {
        private string accountType;
        private int fees;
        //interest is varied
        public Inverstiment(int newFee) : base("Inverstiment")
        {
            fees = newFee;
        }
        public Inverstiment(int newFee, int newbalance) : base("Inverstiment", newbalance)
        {
            fees = newFee;
        }
        private int GetFees
        {
            get { return fees; }
            set { fees = value; }
        }

        public override string Info()
        {
            return accountType + base.Info() + "; Fee: $" + fees;
        }
    }

    public class Omni : Account
    {
        private string accountType;
        private int interest;
        private int overdraft;
        private int fees;

        public Omni(int newFee, int newInterest, int newOverdraft) : base("Omni")
        {
            fees = newFee;
            interest = newInterest;
            overdraft = newOverdraft;
        }
        public Omni(int newFee, int newInterest, int newOverdraft, int newbalance) : base("Omni", newbalance)
        {
            fees = newFee;
            interest = newInterest;
            overdraft = newOverdraft;
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
            return accountType + base.Info() + ", Interest Rate:" + interest + "%; Overdraft Limit: " + overdraft + "; Fee: $" + fees;
        }
    }
}