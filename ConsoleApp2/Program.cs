using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Operation_Info Op_Info = new Operation_Info();
            Operation_Info Op_Info_Json = new Operation_Info();

            CheckXml(@"operations",Op_Info);
            CheckJson(@"operations",Op_Info_Json);
            Max(Op_Info,Op_Info_Json);
             void CheckXml(string path_string,Operation_Info obj) {
                    string path = path_string; 
                    string fullPath;
                    fullPath = Path.GetFullPath(path);
                    /* Console.WriteLine("GetFullPath('{0}') returns '{1}'",path, fullPath); */
                XmlDocument doc = new XmlDocument();

                

                try
                {
                    int amount;
                    DateTime Date;
                    foreach (String Filename in Directory.GetFiles(fullPath, "*.xml"))
                    {
                     //   Console.WriteLine(Filename);
                        doc.Load(Filename);
                        var string_amount = doc.DocumentElement.SelectSingleNode("Amount").InnerText;
                        Int32.TryParse(string_amount, out amount);
                        var string_Date = doc.DocumentElement.SelectSingleNode("Date").InnerText;
                        DateTime.TryParse(string_Date, out Date);
                        var type = doc.DocumentElement.Attributes[2].InnerText;
                        if (amount > obj.Amount)
                        {
                            obj.Type = type;
                            obj.Date = Date;
                            obj.Amount = amount;
                        }

                    }
                }
                catch (Exception e)
                {
                    // Console.WriteLine(e.Message);
                }

                Console.WriteLine("Max among XML : ");

                Console.WriteLine($"Type : {obj.Type} , Date: {obj.Date} , Amount: {obj.Amount}");
                
            }
             
             void CheckJson(string path_string,Operation_Info obj)
             {
                string path = path_string; 
                string fullPath;
                fullPath = Path.GetFullPath(path);

                
                try
                {
                    foreach (String Filename in Directory.GetFiles(fullPath, "*.json"))
                    {
                        JObject jobject = JObject.Parse(File.ReadAllText(Filename));
                        var type = (string)jobject["OperationType"];
                        var Date = (DateTime)jobject["Date"];
                        var Amount = (int)jobject["Amount"];
                        if (Amount > obj.Amount)
                        {
                            obj.Type = type;
                            obj.Date = Date;
                            obj.Amount = Amount;
                        }
                    }

                }
                catch(Exception e)
                {
                   // Console.WriteLine(e.Message);
                }
                Console.WriteLine("Max among JSon : ");
                Console.WriteLine($"Type : {obj.Type} , Date: {obj.Date} , Amount: {obj.Amount}");
                Console.ReadLine();

            }
             
             void Max(Operation_Info xml_info,Operation_Info json_info)
             {
               if(xml_info.Amount > json_info.Amount)
                {
                    Console.WriteLine("And the winner is...");
                    Console.WriteLine($"Type : {xml_info.Type} , Date: {xml_info.Date} , Amount: {xml_info.Amount}");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("And the winner is...");
                    Console.WriteLine($"Type : {json_info.Type} , Date: {json_info.Date} , Amount: {json_info.Amount}");
                    Console.ReadLine();
                }
             }
        }
    }
}
