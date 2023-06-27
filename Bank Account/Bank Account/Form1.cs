using System.Windows.Forms;

namespace Bank_Account
{
    public partial class Form1 : Form
    {
        static List<Customer> customers = new List<Customer>();
        public Form1()
        {
            InitializeComponent();
            CreateCustmors();
            DisplayCustomers();
        }

        public static void CreateCustmors()
        {

            Customer newcustomer1 = new PublicAccount("Andre", "Campos");
            Account newaccount = new Everyday(250);
            newcustomer1.NewAccount(newaccount);
            Account newaccount1 = new Inverstiment(15, 500);
            newcustomer1.NewAccount(newaccount1);
            Account newaccount5 = new Omni(10, 6, 500, 100);
            newcustomer1.NewAccount(newaccount5);
            customers.Add(newcustomer1);

            Customer newcustomer2 = new PublicAccount("Oliver", "Campos");
            Account newaccount2 = new Inverstiment(10, 200);
            newcustomer2.NewAccount(newaccount2);
            customers.Add(newcustomer2);

            Customer newcustomer3 = new StaffAccount("Beatriz", "Campos");
            Account newaccount3 = new Inverstiment(10, 200);
            newcustomer3.NewAccount(newaccount3);
            customers.Add(newcustomer3);

            Customer newcustomer4 = new StaffAccount("Miguel", "Campos");
            Account newaccount4 = new Omni(10, 4, 1500, 3000);
            newcustomer4.NewAccount(newaccount4);
            customers.Add(newcustomer4);

        }

        public void DisplayCustomers()
        {
            //make sure listbox is empty
            listBox2.Items.Clear();
            //Add the book titles to the listBox
            foreach (Customer c in customers)
            {
                listBox2.Items.Add(c);
            }
            //Select the first item
            listBox2.SelectedIndex = -1;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the currently selected item in the ListBox.
            Customer customer = (Customer)listBox2.SelectedItem;
            List<Account> accounts = customer.accounts;

            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            numericUpDown1.Visible = false;
            button2.Visible = false;
            label15.Visible = false;
            numericUpDown2.Visible = false;
            button3.Visible = false;
            button1.Visible = false;
            label16.Visible = false;
            label17.Visible = false;

            String className = customer.GetType().Name;
            if (className == "StaffAccount")
            {
                label18.Visible = true;
                label19.Visible = true;
            }
            else
            {
                label18.Visible = false;
                label19.Visible = false;
            }

            listBox1.Items.Clear();
            foreach (Account a in accounts)
            {
                listBox1.Items.Add(a);
            }
            listBox1.SelectedIndex = -1;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            Account account = (Account)listBox1.SelectedItem;

            int Balance = account.Balance();
            label4.Visible = true;
            label5.Visible = true;
            label5.Text = "$" + Balance.ToString();
            int Fees = account.GetFees();
            label6.Visible = true;
            label7.Visible = true;
            label7.Text = "$" + Fees.ToString();

            if (account.GetAccountType == "Inverstiment")
            {
                string Interest = account.GetInterestrandom();
                label8.Visible = true;
                label9.Visible = true;
                label9.Text = Interest;
            }
            else
            {
                int Interest = account.GetInterest();
                label8.Visible = true;
                label9.Visible = true;
                label9.Text = Interest.ToString() + "%";
            }

            int Overdraft = account.GetOverdraft();
            label10.Visible = true;
            label11.Visible = true;
            label11.Text = "$" + Overdraft.ToString();

            label12.Visible = true;
            label13.Visible = true;
            label12.Text = account.FullInfo();

            label14.Visible = true;
            numericUpDown1.Visible = true;
            button2.Visible = true;
            button2.Tag = account;

            label15.Visible = true;
            numericUpDown2.Visible = true;
            button3.Visible = true;
            button3.Tag = account;

            button1.Visible = true;
            button1.Tag = account;

            label16.Visible = true;
            label17.Visible = false;


        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int deposit = (int)numericUpDown1.Value;
            Button button = (Button)sender;
            Account account = (Account)button.Tag;
            account.Deposit(deposit);


            int balance = account.Balance();
            label5.Text = "$" + balance.ToString();

            label17.Visible = true;
            label17.Text = "You made a deposit of $" + deposit + " in your account. Balance of $" + balance;

            label12.Text = account.FullInfo();

            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int withdrawal = (int)numericUpDown2.Value;
            Button button = (Button)sender;
            Account account = (Account)button.Tag;

            string type = account.GetAccountType;
            int balance = account.GetBalance;

            if (balance >= withdrawal)
            {
                account.Withdrawal(withdrawal);

                int balance1 = account.Balance();
                label5.Text = "$" + balance1.ToString();

                label17.Visible = true;
                label17.Text = "You withdrawal &" + withdrawal.ToString() + " from your account. Balance: $" + balance1;

                label12.Text = account.FullInfo();

                numericUpDown1.Value = 0;
                numericUpDown2.Value = 0;
                return;
            }

            if (type == "Everyday")
            {
                label17.Visible = true;
                label17.Text = "You don't have available funds to complete this transaction. No Fee charged.";
                numericUpDown1.Value = 0;
                numericUpDown2.Value = 0;
                return;
            }
            if (type == "Inverstiment")
            {
                int fee = account.GetFees();
                if(label18.Visible == true)
                {
                    int newfee = (fee / 2);
                    fee = newfee;
                    label17.Visible = true;
                    label17.Text = "You don't have available funds. $" + fee + " for failed transactions (50% Discount)";
                }
                else
                {
                    label17.Visible = true;
                    label17.Text = "You don't have available funds. $" + fee + " for failed transactions";
                }

                account.Withdrawal(fee);

                int balance1 = account.Balance();
                label5.Text = "$" + balance1.ToString();

                label12.Text = account.FullInfo();

                numericUpDown1.Value = 0;
                numericUpDown2.Value = 0;
                return;
            }
            if (type == "Omni")
            {
                int overdraft = account.GetOverdraft();
                int totalvalor = balance + overdraft;

                if (totalvalor < withdrawal)
                {
                    int fee1 = account.GetFees();
                    label17.Visible = true;
                    label17.Text = "You don't have available funds. $" + fee1 + " for failed transactions";
                    account.Withdrawal(fee1);

                    int balance2 = account.Balance();
                    label5.Text = "$" + balance2.ToString();

                    label12.Text = account.FullInfo();

                    numericUpDown1.Value = 0;
                    numericUpDown2.Value = 0;
                    return;
                }
                else
                {
                    account.Withdrawal(withdrawal);
                    int balance2 = account.Balance();
                    label5.Text = "$" + balance2.ToString();

                    label12.Text = account.FullInfo();

                    label17.Visible = true;
                    label17.Text = "You withdrawal &" + withdrawal.ToString() + " from your account. Balance: $" + balance2;

                    numericUpDown1.Value = 0;
                    numericUpDown2.Value = 0;
                    return;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Account account = (Account)button.Tag;
            string type = account.GetAccountType;

            if (type == "Everyday")
            {
                label17.Visible = true;
                label17.Text = "Interest not applied for you";
                numericUpDown1.Value = 0;
                numericUpDown2.Value = 0;
                return;
            }
            else
            {
                double interest = Convert.ToDouble(account.GetInterest());
                double balance = Convert.ToDouble(account.Balance());

                if (balance > 0)
                {

                    double amount = (interest / 100) * balance;
                    account.Deposit(Convert.ToInt32(amount));

                    label17.Visible = true;
                    label17.Text = "Interest of " + interest + "%. $" + amount + " deposit in your account";

                    int balance2 = account.Balance();
                    label5.Text = "$" + balance2.ToString();

                    label12.Text = account.FullInfo();

                    numericUpDown1.Value = 0;
                    numericUpDown2.Value = 0;
                    return;
                }
                else
                {
                    double amount = (interest / 100) * (balance * -1);
                    account.Withdrawal(Convert.ToInt32(amount));

                    label17.Visible = true;
                    label17.Text = "Interest of " + interest + "%. $" + amount + " Withdrawal from your account";

                    int balance2 = account.Balance();
                    label5.Text = "$" + balance2.ToString();

                    label12.Text = account.FullInfo();

                    numericUpDown1.Value = 0;
                    numericUpDown2.Value = 0;
                    return;
                }

            }
        }
    }
}