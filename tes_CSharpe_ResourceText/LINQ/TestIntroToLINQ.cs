using System;
using System.Collections.Generic;
using System.Linq;

namespace tes_CSharpe_ResourceText.LINQ
{
    class TestIntroToLINQ
    {
        // Create a data source by using a collection initializer.
        static List<Student> students = new List<Student>
{
   new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores= new List<int> {97, 92, 81, 60}},
   new Student {First="Claire", Last="O'Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
   new Student {First="Sven", Last="Mortensen", ID=113, Scores= new List<int> {88, 94, 65, 91}},
   new Student {First="Cesar", Last="Garcia", ID=114, Scores= new List<int> {97, 89, 85, 82}},
   new Student {First="Debra", Last="Garcia", ID=115, Scores= new List<int> {35, 72, 91, 70}},
   new Student {First="Fadi", Last="Fakhouri", ID=116, Scores= new List<int> {99, 86, 90, 94}},
   new Student {First="Hanying", Last="Feng", ID=117, Scores= new List<int> {93, 92, 80, 87}},
   new Student {First="Hugo", Last="Garcia", ID=118, Scores= new List<int> {92, 90, 83, 78}},
   new Student {First="Lance", Last="Tucker", ID=119, Scores= new List<int> {68, 79, 88, 92}},
   new Student {First="Terry", Last="Adams", ID=120, Scores= new List<int> {99, 82, 81, 79}},
   new Student {First="Eugene", Last="Zabokritski", ID=121, Scores= new List<int> {96, 85, 91, 60}},
   new Student {First="Michael", Last="Tucker", ID=122, Scores= new List<int> {94, 92, 91, 91} }
};

        public TestIntroToLINQ()
        {
            //Test_LINQArray();
            //Test_LINQBaseOperation();
            Test_LINQGroup();
        }

        private class Student
        {
            public string First { get; set; }
            public string Last { get; set; }
            public int ID { get; set; }
            public List<int> Scores;
        }

        /// <summary>
        /// 常用方式
        /// </summary>
        private void Test_LINQArray()
        {
            // The Three Parts of a LINQ Query:
            //  1. Data source.
            int[] numbers = new int[7] { 0, 1, 2, 3, 4, 5, 6 };

            // 2. Query creation.
            // numQuery is an IEnumerable<int>
            var numQuery =
                from num in numbers
                where (num % 2) != 0
                select num;

            // 3. Query execution.
            foreach (int num in numQuery)
            {
                Console.WriteLine("{0,1} ", num);
            }

        }

        /// <summary>
        /// LINQ where 关键字用法
        /// </summary>
        private void Test_LINQBaseOperation()
        {
            IEnumerable<Student> studentQuery =
                from stun in students
                where stun.Scores[0] > 90
                select stun;

            foreach (var item in studentQuery)
            {
                Console.WriteLine(item.ID);
            }
        }

        /// <summary>
        /// LINQ graoup关键字用法
        /// </summary>
        private void Test_LINQGroup()
        {
            var studentQuery1 =
       from student in students
       group student by student.Last[0];

            foreach (var item in studentQuery1)
            {
                Console.WriteLine($"Key: {item.Key} ,value: {item}");
            }
        }


    }
}
