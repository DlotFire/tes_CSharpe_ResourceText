using System;
using System.Collections.Generic;
using System.Reflection;


namespace tes_CSharpe_ResourceText.反射
{
    class TestReflection_module
    {
        Module module;

        public TestReflection_module()
        {
            module = typeof(TestClassOrder).Module;

            Tes_ModuleInfo();
            Tes_Module_GetFields();
        }

        private void Tes_ModuleInfo()
        {
            Console.WriteLine($"module name:\n {module.Name}");
            Console.WriteLine($"module Scope name:\n {module.ScopeName}");
            Console.WriteLine($"module VersionId:\n {module.ModuleVersionId}");
            Console.WriteLine($"module Handle:\n {module.ModuleHandle}");
            Console.WriteLine($"module Handle MDStream:\n {module.ModuleHandle.MDStreamVersion}");
            Console.WriteLine($"module MetadataToken:\n {module.MetadataToken}");
            Console.WriteLine("");
        }

        private void Tes_Module_GetFields()
        {
            FieldInfo[] infos = module.GetFields();
            Console.WriteLine($"GetFields length:  {infos.Length}");
            for (int i = 0; i < infos.Length; i++)
            {
                Console.WriteLine(infos[i]);
            }
        }
        
    }
}
