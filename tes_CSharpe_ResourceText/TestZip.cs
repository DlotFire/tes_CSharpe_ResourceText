using System;
using System.Collections.Generic;
using System.IO.Compression;

namespace tes_CSharpe_ResourceText
{
    /// <summary>
    /// 测试Zip压缩
    /// </summary>
    class TestZip
    {
        public TestZip(string str)
        {
            //test_CreatZip();
        }

        /// <summary>
        /// 创建压缩文件
        /// </summary>
        private void test_CreatZip()
        {
            //ZipFile.CreateFromDirectory(@"f:/1", @"f:/zip1.zip");  //压缩文件夹，参数1是被压缩的文件夹，参数2是压缩文件的名字
            ZipArchive archive = ZipFile.Open(@"f:/zip1.zip", ZipArchiveMode.Update);   //打开压缩文件
            archive.CreateEntryFromFile(@"f:/5.txt", "ap/7.txt");   //添加文件到压缩文件，参数1是被添加文件路径，参数2是添加到压缩文件里的路径
            archive.ExtractToDirectory(@"f:/zip2"); //解压到文件夹，参数是文件夹的名字
        }
    }
}
