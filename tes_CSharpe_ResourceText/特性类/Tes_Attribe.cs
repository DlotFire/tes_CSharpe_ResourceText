using System;
using System.Reflection;
using System.Collections.Generic;

namespace tes_CSharpe_ResourceText.特性类
{
    class Tes_Attribe
    {
        public Tes_Attribe()
        {
            Console.WriteLine("\n====== Tes_Attribe construction ======");

            FindAllMehod();
            //FindAllMethodIsAttrib();
            //FindAllAttribeFunctionInfo();
        }

        /// <summary>
        /// 查看检索到的所有函数
        /// </summary>
        private void FindAllMehod()
        {
            Type type = typeof(Tes_Attribe_templete_1);
            //type = typeof(Tes_Attribe_templete_2);
            MethodInfo[] methods = type.GetMethods();
            for (int i = 0; i < methods.Length; i++)
            {
                Console.WriteLine(methods[i]);

            }
        }

        /// <summary>
        /// 检索所有函数是否有特性
        /// </summary>
        private void FindAllMethodIsAttrib()
        {
            Type type = typeof(Tes_Attribe_templete_1);
            MethodInfo[] methods = type.GetMethods();
            Attribute attribe;
            for (int i = 0; i < methods.Length; i++)
            {
                attribe = methods[i].GetCustomAttribute(typeof(TESModleAttribe));
                if (attribe == null)
                {
                    Console.WriteLine($"{methods[i].Name} is null !!");
                }
            }
        }

        /// <summary>
        /// 检索所有具有特性的函数的信息
        /// </summary>
        private void FindAllAttribeFunctionInfo()
        {
            Type type = typeof(Tes_Attribe_templete_1);
            MethodInfo[] method = type.GetMethods();
            Attribute attribute;
            for (int i = 0; i < method.Length; i++)
            {
                attribute = Attribute.GetCustomAttribute(method[i], typeof(TESModleAttribe));
                if (attribute != null)
                {
                    Console.WriteLine(attribute);
                    Console.WriteLine($"  -Info: {(attribute as TESModleAttribe).describe}.");
                }
            }
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    class TESModleAttribe : Attribute
    {
        public string describe;
        public TESModleAttribe(string describe)
        {
            this.describe = describe;
        }
    }
}
