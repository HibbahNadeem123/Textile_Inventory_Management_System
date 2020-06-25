using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectSDA.Design_Patterns
{
    public class SingletonPattern
    {
            public static SingletonPattern _obj;
            public int counter = 0;
            private SingletonPattern()
            {

            }
            public static SingletonPattern getObject()
            {
                if (_obj == null)
                {
                    _obj = new SingletonPattern();
                    _obj.counter++;
                }
                return _obj;
            }

            public void Username(string s)
            {
                Console.WriteLine(s + " has logged in");
            }

        }

}