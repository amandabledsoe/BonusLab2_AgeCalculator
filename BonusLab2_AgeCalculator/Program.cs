Console.WriteLine("Welcome to the Age Calculator Application!");
CleanScreen();

bool calculatingAges = true;
while (calculatingAges)
{
    Console.WriteLine("Let's calculate your birthday!");
    int month = isANumber("birth month");
    int day = isANumber("birth day");
    int year = isANumber("birth year");
    
    DateTime userBirthday = Convert.ToDateTime($"{month}/{day}/{year}");
    PrintTheRightThing(userBirthday);
    calculatingAges = WannaRestart();
}
Console.WriteLine("Thank you for using the Age Calculator Application!");
Console.WriteLine("Goodbye...");

static void CleanScreen()
{
    Console.WriteLine("");
    Console.WriteLine("Press Enter to Continue.");
    Console.ReadLine();
    Console.Clear();
}
static bool WannaRestart()
{
    bool askingUser = true;
    while (askingUser)
    {
        Console.WriteLine("Would you like to calculate another age?");
        Console.WriteLine("Enter 'YES' or 'Y' to restart, or enter 'NO' or 'N' to end the program.");
        Console.WriteLine("");
        Console.Write("Your Choice: ");
        string userAnswer = Console.ReadLine();
        if (userAnswer == "yes" || userAnswer == "y")
        {
            CleanScreen();
            return true;
        }
        else if (userAnswer == "no" || userAnswer == "n")
        {
            CleanScreen();
            return false;
        }
        else
        {
            Console.WriteLine("");
            Console.WriteLine("I'm sorry, I don't understand that response. Let's try again.");
            Console.WriteLine("");
        }
    }
    return false;
}
static int isANumber(string neededItem)
{
    bool gettingANumber = true;
    while (gettingANumber)
    {
        Console.Write($"Enter your {neededItem}: ");
        string userResponse = Console.ReadLine();

        bool isANumber = int.TryParse(userResponse, out int realNumber);
        if (isANumber)
        {
            if (neededItem == "birth day" && (realNumber <= 0 || realNumber >= 32))
            {
                Console.WriteLine("");
                Console.WriteLine("I'm sorry, I'm not aware of a calendar date like that. \n" +
                    "Let's try and enter another birth day..");
                Console.WriteLine("");
            }
            else if (neededItem == "birth month" && (realNumber <= 0 || realNumber >= 13))
            {
                Console.WriteLine("");
                Console.WriteLine("I'm sorry, I'm not aware of a calendar month of that number. \n" +
                    "Let's try and enter another birth month.");
                Console.WriteLine("");

            }
            else if (neededItem == "birth year" && (realNumber <=0 || realNumber > DateTime.Now.Year))
            {
                Console.WriteLine("");
                Console.WriteLine("I'm sorry, we can only calculate ages for those already born. \n" +
                    "Let's try and enter another birth year.");
                Console.WriteLine("");

            }
            else
            {
                return realNumber;
            }
        }
        else
        {
            Console.WriteLine("");
            Console.WriteLine("I'm sorry, that doesnt appear to be a number. Let's try again.");
            Console.WriteLine("");
        }
    }
    return -1;
}
static string CalculateTheirAge(DateTime userBirthday)
{
    DateTime Now = DateTime.Now;
    int years = new DateTime(DateTime.Now.Subtract(userBirthday).Ticks).Year - 1;
    DateTime PastYearDate = userBirthday.AddYears(years);
    int months = 0;
    for (int i = 1; i <= 12; i++)
    {
        if (PastYearDate.AddMonths(i) == Now)
        {
            months = i;
            break;
        }
        else if (PastYearDate.AddMonths(i) >= Now)
        {
            months = i - 1;
            break;
        }
    }
    int days = Now.Subtract(PastYearDate.AddMonths(months)).Days;
    //int hours = Now.Subtract(PastYearDate).Hours;
    //int minutes = Now.Subtract(PastYearDate).Minutes;
    //int seconds = Now.Subtract(PastYearDate).Seconds;
    return $"Your age is: {years} Year(s), {months} Month(s), and {days} Day(s) old!";
}
static void PrintTheRightThing(DateTime userBirthday)
{
    if (userBirthday > DateTime.Today)
    {
        Console.WriteLine("");
        Console.WriteLine("Sorry, it appears the birthday you entered is past today's date. \n" +
            "We can only calculate the ages of those already born. Let's try again.");
        Console.WriteLine("");
    }
    else if (userBirthday == DateTime.Today)
    {
        Console.WriteLine("");
        Console.WriteLine("By golly - it looks like you were born today! Happy birthday, friend!");
        Console.WriteLine("");
    }
    else
    {
        Console.WriteLine("");
        Console.WriteLine(CalculateTheirAge(userBirthday));
        Console.WriteLine("");

    }

}
