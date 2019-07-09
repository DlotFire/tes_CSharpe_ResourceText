using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace tes_CSharpe_ResourceText.序列化与反序列化
{
    public class Tes_BinaryFormatter
    {
        public Tes_BinaryFormatter()
        {
            test_BinaryFormatter_1();
        }

        /// <summary>
        /// 测试序列化
        /// </summary>
        private void test_BinaryFormatter_1()
        {
            //序列化
            FileStream fileStream = new FileStream(@"E:/ObjRecordTrans.txt", FileMode.OpenOrCreate);
            byte[] streamByte = new byte[fileStream.Length];
            fileStream.Read(streamByte, 0, (int)fileStream.Length);
            Console.WriteLine(Encoding.ASCII.GetString(streamByte));
            FileStream fs = new FileStream("fs.dat", FileMode.Create);

            BinaryFormatter binaryFormat = new BinaryFormatter();
            binaryFormat.Serialize(fs, streamByte);
            fileStream.Close();
            fs.Close();

            //反序列化
            FileStream fileSteam = new FileStream("fs.dat", FileMode.Open);

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            byte[] str = (byte[])binaryFormatter.Deserialize(fileSteam);

            Console.WriteLine(Encoding.Default.GetString(str));
            fileSteam.Close();
        }
    }

}
