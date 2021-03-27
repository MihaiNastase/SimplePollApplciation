using System;
using System.Collections.Generic;
using System.Text;

namespace PollClassLibrary
{
    public class PollClass
    {
        public uint responseMaleYes { get; private set; }
        public uint responseMaleNo { get; private set; }
        public uint responseFemaleYes { get; private set; }
        public uint responseFemaleNo { get; private set; }

        public PollClass()
        {
            responseMaleYes = 0;
            responseMaleNo = 0;
            responseFemaleYes = 0;
            responseFemaleNo = 0;
        }

        public PollClass(uint maleYes, uint maleNo, uint femaleYes, uint femaleNo)
        {
            responseMaleYes = maleYes;
            responseMaleNo = maleNo;
            responseFemaleYes = femaleYes;
            responseFemaleNo = femaleNo;
        }

        /// <summary>
        /// Method used to log a response from a user. Since both the available types of users and responses are binary, then it would be fitting to use boolans to represent
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
                    responseMaleYes++;
                }
                else 
                { 
                    responseMaleNo++; 
                }
            }
            else
            {
                if (answer)
                {
                    responseFemaleYes++;
                }
                else
                {
                    responseFemaleNo++;
                }
            }
        }



    }
}
