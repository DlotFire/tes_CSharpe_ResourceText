using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace tes_CSharpe_ResourceText.代码生成
{
    public class Tes_MD5
    {
        private string text01Path = "f:/tes01.txt";
        private string recordPath = "f:/record.txt";

        public Tes_MD5()
        {
            Tes_Fanction01();
        }

        /// <summary>
        /// 比较两个文件的MD5
        /// </summary>
        private void Tes_Fanction01()
        {
            FileStream text01stream = File.OpenRead(text01Path);
            Console.WriteLine(text01stream);
            FileStream recordStream = File.Open(recordPath, FileMode.OpenOrCreate);

            MD5 mD5 = MD5.Create();
            byte[] byteStr01 = mD5.ComputeHash(text01stream);
            Console.WriteLine("byteStr01-" + Encoding.ASCII.GetString(byteStr01));

            byte[] recordByte = new byte[recordStream.Length];
            int recrodLeng = (int)recordStream.Length;
            for (int i = 0; i < recrodLeng; i++)
            {
                recordStream.Read(recordByte, i, 1);
            }
            Console.WriteLine("recordStr-" + Encoding.ASCII.GetString(recordByte));

            bool isEqual = true;
            if (byteStr01.Length == recordByte.Length)
            {
                for (int i = 0; i < byteStr01.Length; i++)
                {
                    if (byteStr01[i] != recordByte[i])
                    {
                        isEqual = false;
                    }
                }
            }
            else
            {
                isEqual = false;
            }

            if (!isEqual)
            {
                recordStream.Seek(0, SeekOrigin.Begin);
                recordStream.Write(byteStr01, 0, byteStr01.Length);
                Console.WriteLine("重记");
            }


            text01stream.Close();
            recordStream.Close();

        }
    }
    
}
