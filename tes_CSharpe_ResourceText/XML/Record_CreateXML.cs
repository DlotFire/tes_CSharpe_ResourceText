using System;
using System.Xml;
using System.IO;
using System.Collections.Generic;

namespace tes_CSharpe_ResourceText.XML
{
    class Record_CreateXML
    {
        private string outputPath;
        public string OutputPath
        {
            get
            {
                if (outputPath == null)
                {
                    outputPath = "F:/";
                }
                return outputPath;
            }
        }

        /// <summary> 创建XML 
        /// </summary>
        /// <param name="path"></param>
        public void CreatXML(string path)
        {
            if (!File.Exists(OutputPath))
            {
                Directory.CreateDirectory(OutputPath);
            }
            if (File.Exists(path)) return;

            XmlDocument xml = new XmlDocument();
            XmlElement root = xml.CreateElement("root");
            xml.AppendChild(root);
            xml.Save(path);
        }

        /// <summary> 添加某个（单个）xml节点 
        /// </summary>
        /// <param name="Path">xml路径</param>
        /// <param name="parentName">将要添加的XML的父节点</param>
        /// <param name="id">将要添加XML的ID号</param>
        /// <param name="name">将要添加XML的名字</param>
        /// <param name="value">将要添加XML的值</param>
        public void AddXML(string Path, string parentName, int id, string name, string value)
        {
            if (!File.Exists(Path)) return;

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(Path);
            XmlNode root = xmldoc.SelectSingleNode("root");
            XmlNodeList node = root.SelectNodes(parentName);

            XmlElement id_i, name_i;
            if (node.Count == 0)
            {
                XmlElement secondNode = xmldoc.CreateElement(parentName);
                root.AppendChild(secondNode);

                id_i = xmldoc.CreateElement("id_i");
                id_i.InnerText = id.ToString();
                secondNode.AppendChild(id_i);

                name_i = xmldoc.CreateElement(name);
                name_i.InnerText = value;
                secondNode.AppendChild(name_i);

                goto saveXML;
            }

            XmlNode nodElement;
            if (AddXMLID(node, id.ToString(), out nodElement))//存在id这个节点
            {
                XmlNode node_name = nodElement.SelectSingleNode(name);
                if (node_name == null)
                {
                    XmlElement node_name_ele = xmldoc.CreateElement(name);
                    nodElement.AppendChild(node_name_ele);
                    node_name = nodElement.SelectSingleNode(name);
                }
                node_name.InnerText = value;
            }
            else
            {
                XmlElement secondNode = xmldoc.CreateElement(parentName);
                root.AppendChild(secondNode);

                id_i = xmldoc.CreateElement("id_i");
                id_i.InnerText = id.ToString();
                secondNode.AppendChild(id_i);

                name_i = xmldoc.CreateElement(name);
                name_i.InnerText = value;
                secondNode.AppendChild(name_i);
            }

        saveXML:
            xmldoc.Save(Path);
        }

        /// <summary> 如何没有该ID，则在子节点添加一个ID节点 
        /// </summary>
        /// <param name="secondNodeList"></param>
        /// <param name="id"></param>
        /// <returns>是否存在该节点ID</returns>
        private bool AddXMLID(XmlNodeList secondNodeList, string id, out XmlNode node)
        {
            //foreach (XmlNode element in secondNodeList)
            //{
            //    if (element.SelectSingleNode("id_i").InnerText == id)
            //    {
            //        node = element;
            //        return true;
            //    }
            //}

            for (int i = 0; i < secondNodeList.Count; i++)
            {
                if (secondNodeList[i].SelectSingleNode("id_i").InnerText == id)
                {
                    node = secondNodeList[i];
                    return true;
                }
            }
            node = null;
            return false;
        }

        /// <summary> 更新某个（单个）XML节点值 
        /// </summary>
        /// <param name="Path">XML的路径</param>
        /// <param name="id">将要更新的XML的ID</param>
        /// <param name="name">将要更新的XML的名字</param>
        /// <param name="value">将要更新的XML的值</param>
        public void UpdataXML(string Path, string parentName, int id, string name, string value)
        {
            if (!File.Exists(Path)) return;

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(Path);
            XmlNode root = xmldoc.SelectSingleNode("root");
            XmlNodeList node = root.SelectNodes(parentName);
            foreach (XmlElement element in node)
            {
                if (element.SelectSingleNode("id_i").InnerText == id.ToString())
                {
                    XmlNode XMLname = element.SelectSingleNode(name);
                    XMLname.InnerText = value;
                }
            }

            xmldoc.Save(Path);
        }
    }
}
