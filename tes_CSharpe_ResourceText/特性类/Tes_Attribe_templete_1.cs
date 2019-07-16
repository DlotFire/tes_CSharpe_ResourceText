using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tes_CSharpe_ResourceText.特性类
{
    class Tes_Attribe_templete_1
    {
        public void tes_func_1()
        {
            Console.WriteLine("tes_func_1");
        }

        [TESModleAttribe("attribe 2")]
        public void tes_func_2()
        {
            Console.WriteLine("tes_func_1");
        }

        public void tes_func_3()
        {
            Console.WriteLine("tes_func_1");
        }

        [TESModleAttribe("attribe 4")]
        public void tes_func_4()
        {
            Console.WriteLine("tes_func_1");
        }

        public void tes_func_5()
        {
            Console.WriteLine("tes_func_1");
        }

        [TESModleAttribe("attribe 6")]
        public void tes_func_6()
        {
            Console.WriteLine("tes_func_1");
        }
        
        [TESModleAttribe("attribe 6")]
        private void tes_func_7()
        {
            Console.WriteLine("tes_func_1");
        }


    }
}
