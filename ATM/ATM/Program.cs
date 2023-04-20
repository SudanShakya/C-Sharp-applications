﻿using System;

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
            Console.WriteLine("4. Exit")
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
    }
}