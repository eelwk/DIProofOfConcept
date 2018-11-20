using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    class PrimaryImplementation : IPrimaryInterface
    {
        public string ThisIsAMethod(string hello, string world)
        {
            return $"You sent me {hello} {world}. Thank you for calling me! Have a nice day!";
        }
    }
}
