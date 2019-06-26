using System;
using System.Collections.Generic;
using System.Reflection;

namespace tes_CSharpe_ResourceText.反射
{
    //反射，不仅可以动态创建，还可以附加到已存在的实例，并操作它
    class TestReflection_Type
    {
        private Type orderType;

        public TestReflection_Type()
        {
            orderType = typeof(TestClassOrder);
            TypeConstructorInfo();
            GetProperty();
            GetFile();
            GetMethod();
        }

        private void TypeConstructorInfo()
        {
            //几个构造函数，就有几个
            Console.WriteLine($"Constructor nums: { orderType.GetConstructors().Length}\n");
            ConstructorInfo constructorInfo;

            constructorInfo = orderType.GetConstructor(
                BindingFlags.Instance | BindingFlags.Public, null,
                new Type[] { }, null);
            constructorInfo.Invoke(new object[] { });

            constructorInfo = orderType.GetConstructor(
                BindingFlags.Instance | BindingFlags.Public, null,
                new Type[] { typeof(string) }, null);
            constructorInfo.Invoke(new object[] { "os" });

            constructorInfo = orderType.GetConstructor(
                BindingFlags.Instance | BindingFlags.Public, null,
                new Type[] { typeof(int) }, null);
            constructorInfo.Invoke(new object[] { 2 });

        }

        private void GetProperty()
        {
            Console.WriteLine("\n========== GetProperty ==========");


            PropertyInfo[] properties = orderType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine(properties.Length);
            for (int i = 0; i < properties.Length; i++)
            {
                Console.WriteLine(properties[i].Name);
            }

            //动态创建，取值与赋值
            Console.WriteLine();
            PropertyInfo property = orderType.GetProperty("StrPro");
            Console.WriteLine($"property: {property}");
            object o = orderType.Assembly.CreateInstance("tes_CSharpe_ResourceText.反射.TestClassOrder");
            Console.WriteLine($"property value: {property.GetValue(o)}");
            property.SetValue(o, "instance");
            Console.WriteLine($"property value: {property.GetValue(o)}");

            //从实例取值与赋值
            Console.WriteLine();
            TestClassOrder order = new TestClassOrder();
            order.StrPro = "new pro";
            Console.WriteLine($"order value : {order.StrPro}");
            Console.WriteLine($"property value: {property.GetValue(order)}");

        }

        private void GetFile()
        {
            Console.WriteLine("\n========== GetFile ==========");

            FieldInfo[] fields = orderType.GetFields();
            Console.WriteLine($"order field length: {fields.Length}");
            for (int i = 0; i < fields.Length; i++)
            {
                Console.WriteLine($"field {i} : {fields[i].Name}");
            }

            //动态创建，取值与赋值
            object o = orderType.Assembly.CreateInstance("tes_CSharpe_ResourceText.反射.TestClassOrder");
            FieldInfo field = orderType.GetField("integer");
            Console.WriteLine($"order integer field: {field.GetValue(o)}");
            field.SetValue(o, 10);
            Console.WriteLine($"order integer field: {field.GetValue(o)}");

            //从实例取值与赋值
            TestClassOrder order = new TestClassOrder();
            order.integer = 33;
            field.SetValue(order, 52);//object，绑定的对象（反射它！）
            Console.WriteLine($"instances order integer field: {field.GetValue(order)}");
            Console.WriteLine("------complete-------\n");
        }

        private void GetMethod()
        {
            Console.WriteLine("\n========== GetMethod ==========");

            MethodInfo methodInfo = orderType.GetMethod("FunctionPublic");
            TestClassOrder order = new TestClassOrder();
            methodInfo.Invoke(order, null);
        }
    }
}
