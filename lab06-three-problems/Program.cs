/*
* Name: Evan Clark
* Course: CSCI 1250, Section 201
* Assignment: Lab 06, Three Short Problems
* Date: October 25, 2026
* Description: A menu that keeps running until the user quits with three
* different exercises or all three at once. Each exercise
* practices decisions with one of the four loops.
*/
int choice = 0;
int grade = 0;
Random rng = new Random(4000);
int die1 = 0;
int die2 = 0;
char yn = 'y';
int rolls = 1;
int total = 0;
int[] scores = new int [5];
int scoreNum = 1;
double divide = scores.Length;
int scoreTotal = 0;
int highest = 0;
int passed = 0;

// This loop allows the program to run indefinitely until a 5 is reached
// where other loops would take much more code.
do 
{
    
    System.Console.WriteLine("=== CSCI 1250 Lab 06 ===");
    System.Console.WriteLine("1. The Grade Checker");
    System.Console.WriteLine("2. The Dice Table");
    System.Console.WriteLine("3. The Score Report");
    System.Console.WriteLine("4. All three");
    System.Console.WriteLine("5. Quit");
    System.Console.Write("Choose a number 1-5: ");
    choice = Convert.ToInt32(Console.ReadLine());
    
    //I chose a while statement here because it is a simple check
    //of the value threshold that will repeat if it is still incorrect

    while (choice > 5 || choice < 1)
    {
        System.Console.Write("Choose a number from 1-5: ");
        choice = Convert.ToInt32(Console.ReadLine());
    }

    //These if statements with nested ORs allow for a smooth choice of
    //one or all programs at once 

    if (choice == 1 || choice == 4)
    {
        System.Console.WriteLine();
        System.Console.WriteLine("=== Exercise 1: The Grade Checker ===");
        System.Console.Write("Score: ");
        grade = Convert.ToInt32(Console.ReadLine());
        while (grade > 100 || grade < 0)
        {
            System.Console.WriteLine("A score must be between 0 and 100.");
            System.Console.Write("Score: ");
            grade = Convert.ToInt32(Console.ReadLine());
        }

        //Else if chain is much cleaner than
        //needing fully separate if statements

        if (grade >= 90)
        {
            System.Console.WriteLine(grade + " earns an A.");
        } else if (grade >= 80)
        {
            System.Console.WriteLine(grade + " earns a B.");
        } else if (grade >= 70)
        {
            System.Console.WriteLine(grade + " earns a C.");
        } else if (grade >= 60)
        {
            System.Console.WriteLine(grade + " earns a D.");
        } else
        {
            System.Console.WriteLine(grade + " earns an F.");
        }
        System.Console.WriteLine();
    }
    if (choice == 2 || choice == 4)
    {
        System.Console.WriteLine("=== Exercise 2: The Dice Table ===");
        //Do while allows the player to keep playing until 'N' is reached
        do
        {
            
            die1 = rng.Next(1,7);
            die2 = rng.Next(1,7);
            total = die1 + die2;
            System.Console.Write("Roll " + rolls + ": " + die1 + " and " + die2 + ", total " + total + ". ");
            
            //These ifs allow me to check for any special rolls
            //Using an else if here would provide undesirable results
            if (die1 == die2 && die1 > 1)
            {
                System.Console.Write("Doubles!");
            }
            if (total == 7 || total == 11)
            {
                System.Console.Write("A winner.");
            }
            if (die1 == die2 && die1 == 1)
            {
                System.Console.Write("Snake eyes.");
            }
            System.Console.Write("\nRoll again? (y/n): ");
            yn = Convert.ToChar(Console.ReadLine());

            //I chose the while loop to continuously check this condition
            while (yn != 'y' && yn != 'n')
            {
                
                System.Console.Write("\nRoll again? (y/n): ");
                yn = Convert.ToChar(Console.ReadLine());
            }
            rolls++;
        }while (yn != 'n');
        System.Console.WriteLine();
    }
    if (choice == 3 || choice == 4)
    {
        System.Console.WriteLine("=== Exercise 3: The Score Report ===");

        //loops for an index value
        for (int i = 0; i < scores.Length; i++)
        {
            System.Console.Write("Score " + scoreNum + ": ");
            scores[i] = Convert.ToInt32(Console.ReadLine());
            scoreNum++;
            scoreTotal = scoreTotal + scores[i];

            //Repeatedly checks for the highest entered value thus far, 
            //other loops would not check each iteration
            if (scores[i] > highest)
            {
                highest = scores[i];
            }
            //Repeatedly checks each [i] if they have passed, 
            //other loops would not check it each iteration
            if (scores[i] >= 60)
            {
                passed++;
            }
        }
        System.Console.WriteLine();
        System.Console.WriteLine("Scores entered: " + scores.Length);
        double average = scoreTotal / scores.Length;
        System.Console.WriteLine("Average: " + average);
        System.Console.WriteLine("Highest: " + highest);
        System.Console.WriteLine("Passing: " + passed + " out of " + scores.Length);
        System.Console.WriteLine();

    }

    

    
} while (choice != 5);

System.Console.WriteLine("Goodbye.");