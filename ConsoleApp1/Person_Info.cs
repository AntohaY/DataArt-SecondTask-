using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp1
{
  public  class Person_Info
    {
        [XmlElement("Firstname")]
        public string FirstName { get; set; }

        [XmlElement("Surname")]
        public string Surname { get; set; }

        [XmlElement("Middlename")]
        public string MiddleName { get; set; }

        [XmlElement("Phone_number")]
        public string Ph_Numb { get; set; }

        [XmlElement("E-mail")]
        public string Email { get; set; }

        [XmlElement("Home_Address")]
        public string Home_Address { get; set; }

        [XmlElement("Home_City")]
        public string Home_City { get; set; }

        [XmlElement("Home_State")]
        public string Home_State { get; set; }

        [XmlElement("Home_Zip")]
        public string Home_Zip { get; set; }

        [XmlElement("Work_Address")]
        public string Work_Address { get; set; }

        [XmlElement("Work_City")]
        public string Work_City { get; set; }

        [XmlElement("Work_State")]
        public string Work_State { get; set; }

        [XmlElement("Work_Zip")]
        public string Work_Zip { get; set; }


        [XmlElement("Birthdate")]
        public string Birth { get; set; }

        [XmlIgnore]
        public string FullName
        {
            get { return FirstName + " " + Surname + " " + MiddleName; }
        }






    }
}
