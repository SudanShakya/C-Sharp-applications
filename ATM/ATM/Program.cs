using System;

public class cardHolder
{
    String cardNumber;
    int pin;
    String firstName;
    String lastName;
    double balance;

    public cardHolder(string cardNumber, int pin, string firstName, string lastName, double balance)
    {
        this.cardNumber = cardNumber;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public String getCardNumber()
    {
        return cardNumber;
    }

    public int getPin()
    {
        return pin;
    }

    public String getFirstName() 
    { 
        return firstName;
    }

    public String getLastName()
    {
        return lastName;
    }

    public double getBalance()
    {
        return balance;
    }

    public void setCardNumber(String newCardNumber)
    {
        cardNumber = newCardNumber;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setFirstName(String newFirstName)
    {
        firstName = newFirstName;
    }

    public void setLastName(String newLastName)
    {
        lastName = newLastName;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to deposit? ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(deposit);
            Console.WriteLine("Thank you. Your new balance is: " + currentUser.getBalance);
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to withdraw? ");
            double withdrawal = Double.Parse(Console.ReadLine());

            //To check if the user has enough money
            if(currentUser.getBalance() > withdrawal) 
            {
                Console.WriteLine("Insufficient balance...");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("Thank you. Have a great day.");
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current balance: " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("1234", 1111, "Ram", "Yadav", 22340));
        cardHolders.Add(new cardHolder("5678", 2222, "Hari", "Rai", 223));
        cardHolders.Add(new cardHolder("1928", 3333, "Sita", "Tamang", 9485));
        cardHolders.Add(new cardHolder("8765", 4444, "Gita", "Magar", 88));
        cardHolders.Add(new cardHolder("4321", 5555, "Durga", "Limbu", 98));

        //Prompt user
        Console.WriteLine("Welcome To our ATM");
        Console.WriteLine("Please insert your ATM card number: ");
        String atmCardNum = "";
        cardHolder currentUser;

        while(true)
        {
            try
            {
                atmCardNum= Console.ReadLine();
                //check against our db
                currentUser = cardHolders.FirstOrDefault(a => a.cardNumber == atmCardNum);
                if(currentUser != null) { break; }
                else { Console.WriteLine("Card not recognized. Please try again."); }
            }
            catch { Console.WriteLine("Card not recognized. Please try again."); }
        }

        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Incorrect pin. Please try again."); }
            }
            catch { Console.WriteLine("Incorrect pin. Please try again."); }
        }

        Console.WriteLine("Welcome, " + currentUser.getFirstName() + " " + currentUser.getLastName());
        int option = 0;

        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if(option == 1) { deposit(currentUser); }
            else if(option == 2) { withdraw(currentUser); }
            else if(option == 3) { balance(currentUser); }
            else if(option == 4) { break; }
            else { option = 0; }
        } 
        while (option != 4);
        Console.WriteLine("Thank you! Have a great day.");
    }
}