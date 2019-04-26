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
        }

        private void Tes_ModuleInfo()
        {
            Console.WriteLine($"module name: {module.Name}\n");
            Console.WriteLine($"module Scope name: {module.ScopeName}\n");
            Console.WriteLine($"module VersionId: {module.ModuleVersionId}\n");
            Console.WriteLine($"module Handle: {module.ModuleHandle}\n");
            Console.WriteLine($"module Handle MDStream: {module.ModuleHandle.MDStreamVersion}\n");
            Console.WriteLine($"module MetadataToken: {module.MetadataToken}\n");

        }
        
    }
}
