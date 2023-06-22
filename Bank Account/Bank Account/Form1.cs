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
            Account newaccount = new Everyday();
            newcustomer1.NewAccount(newaccount);
            Account newaccount1 = new Omni(10, 6, 500, 100);
            newcustomer1.NewAccount(newaccount1);
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
    }
}