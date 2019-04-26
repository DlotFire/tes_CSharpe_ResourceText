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

        public string strPro;
        public string StrPro
        {
            get
            {
                if (strPro == null)
                {
                    strPro = "this property call name strPro";
                }
                return strPro;
            }
        }

        public TestClassOrder()
        {
            Console.WriteLine("this is testClassOrder consturct.");
        }
        public TestClassOrder(string str)
        {
            Console.WriteLine("this is testClassOrder consturct that has parameter one.");
        }

        public void FunctionPublic()
        {
            Console.WriteLine("call public FunctionPublic.");
        }

       
    }
}
