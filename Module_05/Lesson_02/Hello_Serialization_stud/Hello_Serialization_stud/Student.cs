using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Serialization_stud
{

    [Serializable] //Required by BinaryFormatter and SoapFormatter  
    public class Student  //XMLSerializer needs the public class
    {

        //Public fields are serialize by the three formatters          

        //These fields will not be serialized by XmlSerialization
        [System.Xml.Serialization.XmlIgnore]   //Ignore in Xml Serialization
        public string firstName;
        
        public string lastName;
        
        [NonSerialized] //Thield will not be serialized
        public string nationality;

        private string address;
        private string code;


        // Create SetAddress(string address, string code) method
        public void SetAddress(string address, string code)
        {
            this.address = address;
            this.code = code;
        }

        // Override ToString() method
        public override string ToString()
        {
            return string.Concat(firstName, " ", lastName, " ", nationality, " ", address, " ", code);
        }


    }

}
