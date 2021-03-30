using System;
using System.Collections.Generic;
using System.Text;

namespace PollClassLibrary
{/// <summary>
/// Class used to collect user responses and display statistical data.
/// </summary>
    public class PollClass
    {
        //Choosing a data type with certain constraints for a variable can avert bugs and extra validation in the future.
        //Therefore, since a number of users can only be a whole number and positive, unsigned integers were used.
        public uint ResponseMaleYes { get; private set; }
        public uint ResponseMaleNo { get; private set; }
        public uint ResponseFemaleYes { get; private set; }
        public uint ResponseFemaleNo { get; private set; }
        private decimal _totalResponses; //Used a decimal type for this field to let C# make the type conversion when calculating percentages.

        /// <summary>
        /// Simple constructor used to intialise the class with fresh results.
        /// </summary>
        public PollClass()
        {
            ResponseMaleYes = 0;
            ResponseMaleNo = 0;
            ResponseFemaleYes = 0;
            ResponseFemaleNo = 0;
            _totalResponses = 0;
        }

        /// <summary>
        /// Constructor in which we can specify an already existing number of different responses. Helps with testing and with the given assingment. 
        /// </summary>
        /// <param name="maleYes">Number of "Yes" responses from male users</param>
        /// <param name="maleNo">Number of "No" responses from male users</param>
        /// <param name="femaleYes">Number of "Yes" responses from female users</param>
        /// <param name="femaleNo">Number of "No" responses from female users</param>
        public PollClass(uint maleYes, uint maleNo, uint femaleYes, uint femaleNo)
        {
            ResponseMaleYes = maleYes;
            ResponseMaleNo = maleNo;
            ResponseFemaleYes = femaleYes;
            ResponseFemaleNo = femaleNo;
            _totalResponses = ResponseMaleYes + ResponseMaleNo + ResponseFemaleYes + ResponseFemaleNo;
        }

        /// <summary>
        /// Method used to log a response from a user. Since both the available types of users and responses are binary, then it would be fitting to use booleans to represent
        /// them. We can only have either female or male users, and their answers can be either yes or no, and this data type provides the perfect constraints to represent
        /// them.
        /// </summary>
        /// <param name="gender">TRUE = male, FALSE = female</param>
        /// <param name="answer">TRUE = yes, FALSE = no</param>
        public void logRespone(bool gender, bool answer)
        {
            if (gender)
            {
                if (answer)
                {
                    ResponseMaleYes++;
                    _totalResponses++;
                }
                else 
                { 
                    ResponseMaleNo++;
                    _totalResponses++;
                }
            }
            else
            {
                if (answer)
                {
                    ResponseFemaleYes++;
                    _totalResponses++;
                }
                else
                {
                    ResponseFemaleNo++;
                    _totalResponses++;
                }
            }
        }


        /// <summary>
        /// Returns the percentage of how many male users have responded with "Yes" from the total count.
        /// </summary>
        /// <returns>Percentage as decimal value</returns>
        public decimal getPercentageMaleYesResponse() 
        {
            if (_totalResponses != 0)
            {
                return (ResponseMaleYes / _totalResponses) * 100;
            }
            else
            {
                return -1;
            }
            
        }

        /// <summary>
        /// Returns the percentage of how many male users have responded with "No" from the total count.
        /// </summary>
        /// <returns>Percentage as decimal value</returns>
        public decimal getPercentageMaleNoResponse()
        {
            if (_totalResponses != 0)
            {
                return (ResponseMaleNo / _totalResponses) * 100;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// Returns the percentage of how many female users have responded with "Yes" from the total count.
        /// </summary>
        /// <returns>Percentage as decimal value</returns>
        public decimal getPercentageFemaleYesResponse()
        {
            if (_totalResponses != 0)
            {
                return (ResponseFemaleYes / _totalResponses) * 100;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// Returns the percentage of how many female users have responded with "No" from the total count.
        /// </summary>
        /// <returns>Percentage as decimal value</returns>
        public decimal getPercentageFemaleNoResponse()
        {
            if (_totalResponses != 0)
            {
                return (ResponseFemaleNo / _totalResponses) * 100;
            }
            else
            {
                return -1;
            }
        }

        //In the test case, we have 65% male responses which are all "No" and 17.5 female responses with "No", giving us that 82.5% of users 
        //are not feeling great.
        //82.5% of total responses = 100% of total "No" responses
        //65% of total responses = X % of total "No" responses are coming from males
        //Solving for X gives us the formula {X = (100 / Total percentage of "No" responses) * Percentage of male responses} Therefore, the algorithm goes as follows:
        public decimal CalculateProbability()
        {
            decimal totalNo = this.getPercentageMaleNoResponse() + this.getPercentageFemaleNoResponse();
            decimal X = (100 / totalNo) * this.getPercentageMaleNoResponse();
            return X;
        }

        /// <summary>
        /// Override of the ToString() method. 
        /// Used for testing purposes.
        /// Provides information regarding the current state of the poll.
        /// </summary>
        /// <returns>Formatted poll results as String</returns>
        public override string ToString()
        {
            return "We have " + _totalResponses + " user responses, from which:\n" +
                   String.Format(" {0:0.##}% are from male users,\n", this.getPercentageMaleYesResponse() + this.getPercentageMaleNoResponse()) +
                   String.Format(" {0:0.##}% are from female users;\n", this.getPercentageFemaleYesResponse() + this.getPercentageFemaleNoResponse()) +
                   String.Format(" {0:0.##}% of users have responded with 'Yes',\n", this.getPercentageMaleYesResponse() + this.getPercentageFemaleYesResponse()) +
                   String.Format(" {0:0.##}% of users have responded with 'No'.\n", this.getPercentageMaleNoResponse() + this.getPercentageFemaleNoResponse());
        }

    }
}
