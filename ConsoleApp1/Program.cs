using Newtonsoft.Json;
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            try { 
            var xmlPersonSerializer = new XmlSerializer(typeof(Person_Info));

            XmlDocument doc = new XmlDocument();
            doc.Load("clientinfo_input.xml");
            
            var Name = doc.DocumentElement.SelectSingleNode("fn").InnerText;

            var Surname = doc.DocumentElement.SelectSingleNode("ln").InnerText;

            var Middlename = doc.DocumentElement.SelectSingleNode("mn").InnerText;

            var Phone = doc.DocumentElement.SelectSingleNode("p").InnerText;

            var Email = doc.DocumentElement.SelectSingleNode("e").InnerText;

            var Day = doc.DocumentElement.SelectSingleNode("bd").InnerText;

            var Month = doc.DocumentElement.SelectSingleNode("bm").InnerText;

            var Year = doc.DocumentElement.SelectSingleNode("by").InnerText;

            var Home_Address = doc.DocumentElement.SelectSingleNode("hl1").InnerText;

            var Home_City = doc.DocumentElement.SelectSingleNode("hc").InnerText;

            var Home_State = doc.DocumentElement.SelectSingleNode("hs").InnerText;

            var Home_Zip = doc.DocumentElement.SelectSingleNode("hz").InnerText;

            var Work_Address = doc.DocumentElement.SelectSingleNode("wl1").InnerText;

            var Work_City = doc.DocumentElement.SelectSingleNode("wc").InnerText;

            var Work_State = doc.DocumentElement.SelectSingleNode("ws").InnerText;

            var Work_Zip = doc.DocumentElement.SelectSingleNode("wz").InnerText;

         
            var Client = new Person_Info
            {
                FirstName = Name,
                Surname = Surname,
                MiddleName = Middlename,
                Birth = Year +" "+ Month +" "+ Day,
                Ph_Numb = Phone,
                Home_Address = Home_Address,
                Home_City = Home_City,
                Home_State = Home_State,
                Home_Zip = Home_Zip,
                Work_Address = Work_Address,
                Work_City = Work_City,
                Work_State = Work_State,
                Work_Zip = Work_Zip,


            };
            var Client_Work_Address = new Person_Info
            {
                Work_Address = Work_Address,
                Work_City = Work_City,
                Work_State = Work_State,
                Work_Zip = Work_Zip,

            };

            var Client_Home_Address = new Person_Info
            {
                Home_Address = Home_Address,
                Home_City = Home_City,
                Home_State = Home_State,
                Home_Zip = Home_Zip,
            };


                var writer = new System.IO.StreamWriter("clientinfo_new.xml"); 
                xmlPersonSerializer.Serialize(writer, Client);

                var writer_work_address = new System.IO.StreamWriter("workaddress_output.xml"); 
                xmlPersonSerializer.Serialize(writer_work_address, Client_Work_Address);

                using (StreamWriter file = File.CreateText("homeaddress_output.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, Client_Home_Address);
                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
    }
}
