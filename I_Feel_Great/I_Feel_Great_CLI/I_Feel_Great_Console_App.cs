using System;
using PollClassLibrary;

namespace I_Feel_Great_CLI
{
    class I_Feel_Great_Console_App
    {
        //In the test case, we have 65% male responses which are all "No" and 17.5 female responses with "No", giving us that 82.5% of users 
        //are not feeling great.
        //82.5% of total responses = 100% of total "No" responses
        //65% of total responses = X % of total "No" responses are coming from males
        //Solving for X gives us the formula {X = (100 / Total percentage of "No" responses) * Percentage of male responses} Therefore, the algorithm goes as follows:
        public static decimal CalculateProbability(PollClass poll)
        {
            decimal totalNo = poll.getPercentageMaleNoResponse() + poll.getPercentageFemaleNoResponse();
            decimal X = (100 / totalNo) * poll.getPercentageMaleNoResponse();
            return X;
        }
        static void Main(string[] args)
        {
            uint maleYes;
            uint maleNo;
            uint femaleYes;
            uint femaleNo;

            Console.WriteLine("Create new poll by specifing the number of user responses:\n");

            //Getting input from the user + continous validation:
            while (true)
            {
            //I wanted to create a decent CLI so the user is prompted for each value and provide validation for each input at the same time.
            //I used goto to avoid using extra loops but mainly to keep the code clean and readable since it's a small aplication (technically using goto
            //creates a loop because the program iterates over the same block of instructions until the user provides valid input).
            MaleYes:
                Console.WriteLine("Enter number of 'Yes' responses from male users:");
                if (!uint.TryParse(Console.ReadLine(), out maleYes))
                {
                    Console.Write("Please provide a positive integer value!\n");
                    goto MaleYes;
                }
            MaleNo:
                Console.WriteLine("Enter number of 'No' responses from male users:");
                if (!uint.TryParse(Console.ReadLine(), out maleNo))
                {
                    Console.Write("Please provide a positive integer value!\n");
                    goto MaleNo;
                }
            FemaleYes:
                Console.WriteLine("Enter number of 'Yes' responses from female users:");
                if (!uint.TryParse(Console.ReadLine(), out femaleYes))
                {
                    Console.Write("Please provide a positive integer value!\n");
                    goto FemaleYes;
                }
            FemaleNo:
                Console.WriteLine("Enter number of 'No' responses from female users:");
                if (!uint.TryParse(Console.ReadLine(), out femaleNo))
                {
                    Console.Write("Please provide a positive integer value!\n");
                    goto FemaleNo;
                }

                //If the poll would be empty, we would get a DivideByZeroException. Validating here averts a crash and also grants the user the chance to 
                //input valid responses, since the loop restarts.
                if((maleYes + femaleYes + maleNo + femaleNo) != 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("The poll cannot be empty!");
                }
                
            }
            //Creating new class based on collected parameters.
            PollClass newPoll = new PollClass(maleYes, maleNo, femaleYes, femaleNo);
            //Printing the poll status:
            Console.WriteLine(newPoll);
            //Displaying the answer to the exercise problem:
            Console.WriteLine(String.Format("There is a {0:0.##}% probability that a 'No' answer comes from a male user.", CalculateProbability(newPoll)));
            
        }
    }
}
