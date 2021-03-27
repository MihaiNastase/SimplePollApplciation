using System;

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

            while (true)
            {
            MaleYes:
                Console.WriteLine("Enter number of 'Yes' responses from male users:");
                if (!uint.TryParse(Console.ReadLine(), out maleYes)){
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
            PollClassLibrary.PollClass newPoll = new PollClassLibrary.PollClass(maleYes, maleNo, femaleYes, femaleNo);
            Console.WriteLine(newPoll);


        }
    }
}
