using System;
using System.Collections.Generic;
using System.Linq;


namespace Assignment1Q1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1
            Console.WriteLine("Q1 : Enter the number of rows for the triangle:");
            int n = Convert.ToInt32(Console.ReadLine());
            PrintTriangle(n);
            Console.WriteLine();

            //Question 2:
            Console.WriteLine("Q2 : Enter the number of terms in the Pell Series:");
            int n2 = Convert.ToInt32(Console.ReadLine());
            PrintPellSeries(n2);
            Console.WriteLine();

            //Question 3;
            Console.WriteLine("Q3 : Enter the number to check if squareSums exist:");
            int n3 = Convert.ToInt32(Console.ReadLine());
            SquareSums(n3);
            Console.WriteLine();

            //Question 4;
            Console.WriteLine("Q4: Enter the values for the array one at a time (and press enter)");
            int[] inputArray = new int[5];
            for (int count = 0; count < inputArray.Length; count++)
            {
                inputArray[count] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Q4: Enter the absolute difference (k) to check");
            int k = Convert.ToInt32(Console.ReadLine());
            DiffPairs(inputArray, k);
            Console.WriteLine();

            //Question 5;
            Console.WriteLine("Q5: Enter the emails, separated by comma");
            string input = Console.ReadLine();
            string[] emailList = input.Split(',');
            UniqueEmails(emailList);
            Console.WriteLine();

            //Question 6
            Console.WriteLine("Q6: Enter the startpoints and endpoints for the paths");
            string[,] paths = new string[3, 2];
            //I apologize for the lengthy input. 
            //I had a difficult time creating a more efficient way to input values into a multi-dimensional string array
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("The path starts at :");
                paths[i, 0] = Console.ReadLine();
                Console.WriteLine("The path ends at :");
                paths[i, 1] = Console.ReadLine();
            }
            DestCity(paths);
        }
        private static void PrintTriangle(int n)
        {
            //Question 1
            int count;
            int subcount;

            for (count = 1; count <= n; count++)
            {
                int total = count * 2 - 1; //total number of *'s to print in a row, creates a sequence of odd numbers
                int noOfSpaces = n - count; //number of spaces before printing, in order to give triangle shape

                for (subcount = 1; subcount <= noOfSpaces; subcount++) //loop to print spaces for triangle shape
                {
                    Console.Write(" ");
                }
                for (subcount = 1; subcount <= total; subcount++) //loop to print the *'s
                {
                    Console.Write("*");
                }
                Console.WriteLine();

            }
        }
        private static void PrintPellSeries(int n2)
        {
            //Question 2
            int count;

            List<int> pell = new List<int>();
            //0 and 1 start the list no matter what, unless the user asks for just 1 term
            if (n2 < 2)
            {
                pell.Add(0);
            }
            else
            {
                pell.Add(0);
                pell.Add(1);
            }

            for (count = 2; count < n2; count++) //Start loop at 2 because we already have pell[0] and pell[1]
            {
                int newPell = pell[count - 1] * 2 + pell[count - 2];
                pell.Add(newPell);
            }

            foreach (int i in pell) //loop to display all of our pell values
            {
                Console.Write(i + "  ");
            }
        }
        private static void SquareSums(int n3)
        {
            //Question 3
            List<string> boolList = new List<string>();
            bool doesListContainTrue;

            //A for-loop nested in a for-loop for (1,2,...,c) will go through every possible pair of values
            for (int i = 0; i <= n3; i++)
            {
                int asquared = i * i;
                for (int j = 0; j <= n3; j++)
                {
                    int bsquared = j * j;

                    //A list of boolean values (true/false) is created to check if a^2+b^2=c for each pair of values
                    if (n3 == asquared + bsquared)
                    {
                        doesListContainTrue = true;
                        boolList.Add(doesListContainTrue.ToString());
                    }
                    else
                    {
                        doesListContainTrue = false;
                        boolList.Add(doesListContainTrue.ToString());
                    }
                }
            }

            //If our boolean list has at least one "True" value, we know there is a possible pair of values to equal c
            if (boolList.Contains("True"))
            {
                Console.WriteLine("Yes, the number can be expressed as a sum of squares of 2 integers");
            }
            else
            {
                Console.WriteLine("No, the number cannot be expressed as a sum of squares of 2 integers");
            }
        }
        private static void DiffPairs(int[] inputArray, int k)
        {
            int[] distinctArray = inputArray.Distinct().ToArray(); //deletes duplicate values
            int noOfPairs = 0;

            if (k != 0) //The code below works simply and very well with simple for-loops but gave me trouble for when k==0 (because of deleted duplicates from before)
                        //Because of this, I have separte blocks of code for when (k==0) and when (k!=0)
            {

                //i and j represent [i,j] while x is the value for i and y is the value for j
                for (int i = 0; i < distinctArray.Length; i++)
                {
                    int x = distinctArray[i];
                    for (int j = i + 1; j < distinctArray.Length; j++) //starting the loop at j=i+1 is to avoid repeated pairs (ex. (3,1) and (1,3))
                    {
                        int y = distinctArray[j];


                        //checks for the difference between x and y and counts the # of pairs that have a difference of k
                        if (Math.Abs(x - y) == k)
                        {
                            noOfPairs++; //adds to the total number of difference-pairs that equal k
                        }
                    }
                }

            }
            else //for when k = 0
            {
                //The "count" starts at 0. Count is like a temporary total for noOfPairs.
                //For example, let's say the array is {1,3,1,5,4}
                //The two for-loops create every posible pair of (i,j), just like before
                //In the first run through the nested loop, 1 cycles through {1,3,1,5,4}. Since there are two instances of 1==1, count now = 2.
                //Since count > 1, we add to the noOfPairs variable. 
                //Every number in the array will have at least one pair of (i,j) where  i==j: this happens when the number is paired with itself. 
                //Because of this, we say (count > 1), not (count>0). 
                //If a number has multiple pairs where i==j, we know that the array has a duplicate of it, which is what k=0 is essentially searching for.
                for (int i = 0; i < distinctArray.Length; i++)
                {
                    int count = 0;
                    for (int j = 0; j < inputArray.Length; j++)
                    {
                        if (distinctArray[i] == inputArray[j])
                        {
                            count++;
                        }
                    }
                    if (count > 1)
                    {
                        noOfPairs++;
                    }
                }


            }

            Console.WriteLine();
            Console.WriteLine("The number of pairs with a k difference: " + noOfPairs);
        }

        private static void UniqueEmails(string[] emailList)
        {
            List<string> updatedEmailList = new List<string>();

            foreach (string email in emailList)
            {
                //We separte the local from the domain by creating SubStrings before and after the @ in the email
                string local = email.Substring(0, email.IndexOf("@"));
                local = local.Replace(".", string.Empty); //remove periods
                if (local.Contains("+"))                  //remove characters after pluses
                {
                    local = local.Substring(0, local.IndexOf("+"));
                }

                string domain = email.Substring(email.IndexOf("@") + 1);
                string newEmail = local + "@" + domain; //create the cleaned-up email and add it to a new list
                updatedEmailList.Add(newEmail);
            }

            //Create a new list of the distinct emails from the cleaned-up emails
            List<string> distinctEmailList = new List<string>();
            foreach (string email in updatedEmailList.Distinct())
            {
                distinctEmailList.Add(email);
            }
            Console.WriteLine("Number of different addresses: " + distinctEmailList.Count);
        }

        private static void DestCity(string[,] paths)
        {
            //Loop to search for the final destination city
            //This logic comes from the idea that the destination city will always appear as a path endpoint, but never as a path startpoint
            //The loop looks at the j value in [i,j]. It then compares that j value to each of the i values, and checks for equality
            //Every time the j value is NOT equal to one of the i's, the count goes up
            //If the count is > 2, then we know it is the destination city
            //This is because if the count is > 2, that means that city never appears as an i value as a path startpoint
            //For example, I will look at [["B","C"],["D","B"],["C","A"]]
            //The example loop starts at "C" and compares it to "B","D", and "C" (the i values, or the path startpoints). 
            //The count would be 2, since there are two startpoints that are unequal to "C" (C is in the list of i's)
            //When the loop gets to "A", "A" never appears in "B","D", and "C". The count is 3, and we know A is the final destination
            for (int j = 0; j <= 2; j++)
            {
                int count = 0;
                string y = paths[j, 1];
                for (int i = 0; i <= 2; i++)
                {
                    string x = paths[i, 0];
                    if (y != x)
                    {
                        count++;
                    }
                }
                if (count > 2)
                {
                    Console.WriteLine(y + " is the final destination");
                }
            }
        }
    }
}

