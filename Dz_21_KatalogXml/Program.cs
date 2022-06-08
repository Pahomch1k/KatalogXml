using System;
using static System.Console;
using System.Xml;
using System.IO;
using System.Text;


namespace Dz_21_KatalogXml 
{
    class Program
    {
        static void Main(string[] args)
        {
            XML xml = new XML();

            int choise = 0;
            int flag = 0;

            while (flag == 0)
            {
                WriteLine("1. Создать файл\n2. Добавить в файла\n3. Чтение из файла\n4. Выход");
                choise = Convert.ToInt32(ReadLine());

                switch (choise)
                {
                    case 1: xml.CreateXml(); break;
                    case 2: xml.AddKat(); break;
                    case 3: xml.ReadXml(); break;
                    case 4: flag++; break;
                    default: WriteLine("try again"); break;
                }
            }
        }
    }

    class XML
    {
        static int Count = 1;
        string x { get; set; }
        string NameFile = "../../Shop.xml";

        string[] Element = new string[5] { "Name", "Creator", "Harack", "Price", "InfoCredit" };
        string[] AtribteName = new string[4] { "NameFirm", "Model", "Seriya", "Number" };
        string[] AtribteCreator = new string[2] { "Country", "Date" };
        string[] AtribteHarack = new string[3] { "Power", "MainHarack", "DopHarack" };
        string[] AtribtePrice = new string[2] { "Rozica", "Opt" };
        string[] AtribteInfoCredit = new string[2] { "Srock", "Symm" };

        public void CreateXml()
        { 
            XmlTextWriter xmlwriter = new XmlTextWriter(NameFile, Encoding.UTF8);
            xmlwriter.WriteStartDocument();

            // Formatting определяет способ форматирования выходных данных
            xmlwriter.Formatting = Formatting.Indented; 
            xmlwriter.IndentChar = '\t'; 
            xmlwriter.Indentation = 1; 

            xmlwriter.WriteStartElement("KatalogShop"); 
            xmlwriter.WriteEndElement(); 
            xmlwriter.Close();

            AddKat();
        }

        public void ReadXml()
        {
            XmlTextReader reader = new XmlTextReader(NameFile);
            string str = null;
            while (reader.Read()) 
            {
                if (reader.NodeType == XmlNodeType.Text)
                    str += reader.Value + "\n";
                 
                if (reader.NodeType == XmlNodeType.Element)
                    if (reader.HasAttributes)
                        while (reader.MoveToNextAttribute()) 
                            str += reader.Value + "\n";
            }
            WriteLine(str);
            reader.Close();
        }
         
        public void AddKat()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(NameFile);
            XmlElement xRoot = xDoc.DocumentElement; 
                 
            WriteLine("Название ?");
            x = ReadLine();
            XmlElement KatalElem = xDoc.CreateElement(x + Count);
            xRoot.AppendChild(KatalElem);
            Count++;

            for (int i = 0; i < 5; i++)
            {
                XmlElement NameElem = xDoc.CreateElement(Element[i]);
                KatalElem.AppendChild(NameElem);

                switch (i)
                {
                    case 0:
                        {
                            for (int i1 = 0; i1 < 4; i1++)
                            {
                                XmlElement AtrElem = xDoc.CreateElement(AtribteName[i1]);
                                NameElem.AppendChild(AtrElem);
                                Write(AtribteName[i1] + "? ");
                                x = ReadLine();
                                XmlText Text = xDoc.CreateTextNode(x);
                                AtrElem.AppendChild(Text); 
                            } 
                        }
                        break;
                    case 1:
                        {
                            for (int i1 = 0; i1 < 2; i1++)
                            {
                                XmlElement AtrElem = xDoc.CreateElement(AtribteCreator[i1]);
                                NameElem.AppendChild(AtrElem);
                                Write(AtribteCreator[i1] + "? ");
                                x = ReadLine();
                                XmlText Text = xDoc.CreateTextNode(x);
                                AtrElem.AppendChild(Text); 
                            } 
                        }
                        break;
                    case 2:
                        {
                            for (int i1 = 0; i1 < 3; i1++)
                            {
                                XmlElement AtrElem = xDoc.CreateElement(AtribteHarack[i1]);
                                NameElem.AppendChild(AtrElem);
                                Write(AtribteHarack[i1] + "? ");
                                x = ReadLine();
                                XmlText Text = xDoc.CreateTextNode(x);
                                AtrElem.AppendChild(Text);
                            } 
                        }
                        break;
                    case 3:
                        {
                            for (int i1 = 0; i1 < 2; i1++)
                            {
                                XmlElement AtrElem = xDoc.CreateElement(AtribtePrice[i1]);
                                NameElem.AppendChild(AtrElem);
                                Write(AtribtePrice[i1] + "? ");
                                x = ReadLine();
                                XmlText Text = xDoc.CreateTextNode(x);
                                AtrElem.AppendChild(Text);
                            } 
                        }
                        break;
                    case 4:
                        {
                            for (int i1 = 0; i1 < 2; i1++)
                            {
                                XmlElement AtrElem = xDoc.CreateElement(AtribteInfoCredit[i1]);
                                NameElem.AppendChild(AtrElem);
                                Write(AtribteInfoCredit[i1] + "? ");
                                x = ReadLine();
                                XmlText Text = xDoc.CreateTextNode(x);
                                AtrElem.AppendChild(Text);
                            } 
                        }
                        break;
                    default:
                        break;
                }
            }
            xDoc.Save(NameFile);
            WriteLine("XML-документ изменен!");
        }
    }
}
