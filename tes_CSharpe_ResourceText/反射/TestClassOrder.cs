using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tes_CSharpe_ResourceText.反射
{
    class TestClassOrder
    {
        public string str;
        public int integer;
        public static string staticStr;
        public static int staticIntarge;

        public string StrPro
        {
            get;
            set;
        }

        public TestClassOrder()
        {
            Console.WriteLine("this is testClassOrder consturct.");
        }
        public TestClassOrder(string str)
        {
            Console.WriteLine("this is testClassOrder consturct , string.");
        }
        public TestClassOrder(int integer)
        {
            Console.WriteLine("this is testClassOrder consturct , integer.");
        }

        public void FunctionPublic()
        {
            Console.WriteLine("call public FunctionPublic.");
        }


    }
}
