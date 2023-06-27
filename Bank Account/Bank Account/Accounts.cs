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
        public int GetAccountID
        {
            get { return AccountID; }
            set { AccountID = value; }
        }
        public string GetAccountType
        {
            get { return accountType; }
            set { accountType = value; }
        }
        public int GetBalance
        {
            get { return balance; }
            set { balance = value; }
        }
        public void Deposit(int amount)
        {
            int newbalance = balance + amount;
            balance = newbalance;
        }
        public void Withdrawal(int amount)
        {
            int newbalance = balance - amount;
            balance = newbalance;
        }
        public virtual string AccountName()
        {
            return "(ID:" + AccountID.ToString() + ") " + accountType;
        }
        public virtual int Balance()
        {
            return balance;
        }
        public abstract int GetFees();
        public abstract int GetInterest();
        public abstract string GetInterestrandom();
        public abstract int GetOverdraft();

        public override string ToString()
        {
            return AccountName();
        }
        public virtual string FullInfo()
        {
            return "(ID:" + AccountID.ToString() + ") " + accountType;
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
        public override string FullInfo()
        {
            return base.FullInfo() + "; Balance: " + base.Balance();
        }

        public override int GetFees(){return 0;}
        public override int GetInterest(){return 0;}
        public override string GetInterestrandom(){return "n/a";}
        public override int GetOverdraft(){return 0;}

        
    }
    public class Inverstiment : Account
    {
        private string accountType;
        private int interestmin = 10;
        private int interestmax = 20;
        private int fees;
  
        public Inverstiment() : base("Inverstiment")
        {
        }
        public Inverstiment(int newFee, int newbalance) : base("Inverstiment", newbalance)
        {
            fees = newFee;
        }
        public override int GetFees()
        {
            return fees;
        }
        public override int GetInterest()
        {
            Random rnd = new Random();
            int randomnumber = rnd.Next(interestmin, interestmax);
            return randomnumber;
        }
        public override int GetOverdraft() { return 0; }
        public override string GetInterestrandom()
        {
            return "(Varied) " + interestmin.ToString() + "% - " + interestmax.ToString() + "%";
        }
        public override string FullInfo()
        {
            return base.FullInfo() + ", Interest Rate:" + GetInterest() + "; Fee: $" + fees + "; Balance: " + base.Balance();
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
        public override int GetFees()
        {
            return fees;
        }
        public override int GetInterest()
        {
            return interest;
        }
        public override int GetOverdraft()
        {
            return overdraft;
        }
        public override string GetInterestrandom() { return "n/a"; }
        public override string FullInfo()
        {
            return base.FullInfo() + ", Interest Rate: " + interest + "%; Overdraft Limit: $" + overdraft + "; Fee: $" + fees + "; Balance: " + base.Balance();
        }
    }
}