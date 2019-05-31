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
            [System.Xml.Serialization.XmlIgnore]   //Ignore in Xml Serialization          
            //Public fields are serialize by the three formatters  

            [NonSerialized] //Thield will not be serialized
            
            //These fields will not be serialized by XmlSerialization
            

        // Create SetAddress(string address, string code) method

        // Override ToString() method

        }  
    
}
