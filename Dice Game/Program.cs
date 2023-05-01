// Our variables for the game
int dice1 = 1;
int dice2 = 0;
int bet1;
int money = 0;
int totalMoney = 1000;

// Using the Random class to roll the dice
Random rollDice = new Random();

// Introducing the game
Console.WriteLine("Hello, welcome to our dice game we like to call Double Dragons! \n" +
    "\nYou will start by making your bet.  After making your bet, you will then roll both the dice once. \n" +
    "In Double Dragons, your bet will be trippled if both dice roll the same number. \n" +
    "If you roll a 6 on either dice, your bet will simply be doubled.\n" +
    "If you roll Double Dragons, which is a 6 on both dice, your bet is multiplied by 5!\n" +
    "If you do not roll the same number on both dice, unfortunately your bet is lost.\n" +
    "So let's get started!  Best of luck to you.\n"); 

// Restart point for the application
RestartApplication:

// Check point to see if user still has enough money to bet
if (totalMoney <= 0)
{
    Console.WriteLine("Unfortunately you have lost all your money, and we're not a charity.\n" +
        "Come back when you have more money to spend on Double Dragons.");
    Environment.Exit(0);
}

// Entry point to input player bet
Console.WriteLine("You currently have ${0} to bet.\n", totalMoney);
Console.WriteLine("Please enter your bet: ");
string input = Console.ReadLine();
bool isInt = int.TryParse(input, out bet1);

// If statement to check if text input if a number
if (isInt)
{
    // dice roll
    if (totalMoney > 0)
    {
            dice1 = rollDice.Next(1, 7);
            dice2 = rollDice.Next(1, 7);
            Console.WriteLine("-----------------------");
            Console.WriteLine("Dice 1 Rolls {0}", dice1);
            Console.WriteLine("Dice 2 Rolls {0}", dice2);
       
    }

    // Statement if you do not win either roll
    if (dice1 != dice2)
    {
        Console.WriteLine("\nOh no, you have lost your bet! Please try again and good luck.");
        Console.WriteLine("-----------------------");
        totalMoney = totalMoney - bet1;
        goto RestartApplication;
    }
    // Statement if you roll two sixes 
    else if (dice1 == 6 && dice2 == 6)
    {
        Console.WriteLine("\nWe have a winner!  Congratulations, your bet has been multiplied by 5!");
        money = bet1 * 5;
        totalMoney = totalMoney + money;
        Console.WriteLine("You won {0}, and have a total of {1}", money, totalMoney);
        goto RestartApplication;
    }
    // Statement if you win a double roll
    else if (dice1 == dice2)
    {
        Console.WriteLine("\nWe have a winner!  Congratulations, your bet has been trippled!");
        money = bet1 * 3;
        totalMoney = totalMoney + money;
        Console.WriteLine("You won {0}, and have a total of {1}", money, totalMoney);
        goto RestartApplication;
    }
    // Statement if you win a single 6
    else if (dice1 == 6 || dice2 == 6)
    {
        Console.WriteLine("\nWe have a winner!  Congratulations, your bet has been doubled!");
        money = bet1 * 2;
        totalMoney = totalMoney + money;
        Console.WriteLine("You won {0}, and have a total of {1}", money, totalMoney);
        goto RestartApplication;
    }
    
}

// Statement to catch if input was not a number
else
{
    Console.WriteLine("That is not a number, please try again.");
    goto RestartApplication;
}

