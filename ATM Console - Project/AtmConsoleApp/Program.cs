// See https://aka.ms/new-console-template for more information
using System;

public class cardHolder
{
    string cardId;
    int pin;
    string firstName;
    string lastName;
    double balance; 

    public cardHolder(string cardId, int pin, string firstName, string lastName, double balance)
    {
        this.cardId = cardId;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public String getCardId()
    {
        return cardId;
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

    public void setCardId(String newcardId)
    {
        cardId = newcardId;
    }
    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setFirstName(String newfirstName)
    {
        firstName = newfirstName;
    }

    public void setLastName(String newLastName)
    {
        lastName = newLastName; 
    }
    public void setBalance(double newbalance)
    {
        balance = newbalance + balance;
    }

    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose one of the following options:");
            Console.WriteLine("1.Deposit money");
            Console.WriteLine("2.Withdraw money");
            Console.WriteLine("3.Show the Balance");
            Console.WriteLine("4.Exit");
        }
        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to deposit?");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(deposit);
            Console.WriteLine("Your deposit had been done successfull!" + currentUser.getBalance());
        }
        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much money you like to withdraw: ");
            double withdrawal = Double.Parse(Console.ReadLine());
            //Check if the user has enough money
            if(currentUser.getBalance() > withdrawal)
            {
                Console.WriteLine("You don't have so much money!");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("Your current balance is: " + currentUser.getBalance());
            }
        }
        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Your current balance is: " + currentUser.getBalance());
        }
        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("4532772818527395", 1234, "John", "Griffith", 150.31));
        cardHolders.Add(new cardHolder("4532761841325802", 1234, "Ashley", "Jones", 321.13));
        cardHolders.Add(new cardHolder("5128381368581872", 1234, "Frida", "Dickerson", 105.59));
        cardHolders.Add(new cardHolder("6011188364697109", 1234, "Muneeb", "Harding", 851.84));
        cardHolders.Add(new cardHolder("3490693153147110", 1234, "Dawn", "Smith", 54.27));

        //Prompt User
        Console.WriteLine("Welcome to SimpleATM");
        Console.WriteLine("Please insert your debit card: ");
        String debitCardNum = "";
        cardHolder currentUser;

        while(true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                //Check against our db
                currentUser = cardHolders.FirstOrDefault(a => a.cardId == debitCardNum);
                if (currentUser != null) { break; }
                else { Console.WriteLine("Card not recognized. Please try again");  }
            }
            catch { Console.WriteLine("Card not recognized. Please try again"); }
        }
        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                //Check against our db
                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Incorrect pin. Please try again"); }
            }
            catch { Console.WriteLine("Incorrect pin. Please try again"); }
        }
        Console.WriteLine("Welcome " + currentUser.getFirstName() + " :) ");
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if (option == 1) { deposit(currentUser); }
            else if (option == 2) { withdraw(currentUser); }
            else if (option == 3) { balance(currentUser); }
            else if (option == 4) { break; }
            else {  option = 0; }
        }
        while (option != 4);
        Console.WriteLine("Thank you! Have a nice day :)");
    }


}
