using System;
using PollClassLibrary;

namespace I_Feel_Great_CLI
{
    class Program
    {
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

                break;
            }
            PollClass newPoll = new PollClass(maleYes, maleNo, femaleYes, femaleNo);
            Console.WriteLine(newPoll);

            //In the test case, we have 65% male responses which are all "No" and 17.5 female responses with "No", giving us that 82.5% of users 
            //are not feeling great. Must be Monday.
            //82.5% of total responses = 100% of total "No" responses
            //65% of total responses = X % of total "No" responses are coming from males
            //Solving for X gives us the formula {X = (100 / Total percentage of "No" responses) * Percentage of male responses} Therefore, the algorithm goes as follows:

            try
            {
                decimal totalNo = newPoll.getPercentageMaleNoResponse() + newPoll.getPercentageFemaleNoResponse();
                decimal X = (100 / totalNo) * newPoll.getPercentageMaleNoResponse();
                Console.WriteLine(String.Format("There is a {0:0.##}% probability that a 'No' answer comes from a male user.", X));
            }
            catch (PollClassInvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
