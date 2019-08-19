using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloHiApi
{
    public class Greet
    {
        public static string greetPeople(string greet)
        {
            if (greet == "hello")
            {
                return "hi";
            }
            else if (greet == "hi")
            {
                return "hello";
            }
            else
            {
                return "greet";
            }
        }
    }
}
