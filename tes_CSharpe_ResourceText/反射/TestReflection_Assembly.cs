using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;

namespace tes_CSharpe_ResourceText.反射
{
    class TestReflection_Assembly
    {

        private Assembly assembly;
        //private Type 

        public TestReflection_Assembly()
        {
            assembly = typeof(TestReflection_Assembly).Assembly;

            GetAssemblyInfo();
            CreateInstance();

        }

        public void GetAssemblyInfo()
        {
            Console.WriteLine($"assembly.FullName:\n{assembly.FullName}\n");
            //Console.WriteLine(assembly.GetName());
            Console.WriteLine($"assembly.CodeBase:\n{assembly.CodeBase}\n");

            string[] ResourceNames = assembly.GetManifestResourceNames();
            Console.WriteLine("ResourceNames:");
            for (int i = 0; i < ResourceNames.Length; i++)
            {
                Console.WriteLine(ResourceNames[i]);
            }

            FileStream[] fileStream = assembly.GetFiles();
            Console.WriteLine("\nfileStream:");
            for (int i = 0; i < fileStream.Length; i++)
            {
                Console.WriteLine(fileStream[i].Name);
            }

            IEnumerable<Attribute> attributes = assembly.GetCustomAttributes();
            Console.WriteLine("\nattributes:");
            foreach (Attribute item in attributes)
            {
                Console.WriteLine(item);
            }

            IEnumerable<TypeInfo> definedTypes = assembly.DefinedTypes;
            Console.WriteLine("\ndefinedTypes:");
            foreach (TypeInfo item in definedTypes)
            {
                Console.WriteLine(item.Name);
            }

            Console.Write($"\nBoolean ReflectionOnly: {assembly.ReflectionOnly}");
        }

        public void CreateInstance()
        {
            object o = assembly.CreateInstance("tes_CSharpe_ResourceText.反射.TestClassOrder");

            Console.WriteLine($"\n{o}");
        }

    }
}
