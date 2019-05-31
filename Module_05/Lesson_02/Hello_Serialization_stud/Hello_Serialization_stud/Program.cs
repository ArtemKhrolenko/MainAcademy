using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;

namespace Hello_Serialization_stud
{
    class Program
    {
        static void Main(string[] args)
        {
                // Create instance of Student class
                // Initialize its properties
                // Call methods for serialization and deserialization
        }

        // Impement BinaryFrm(Student p) method to serialize and deserialize p

        // Define path for file
        // Implement BinaryFormatter object creation and p serialization  in using block for FileStream object

        // Implement BinaryFormatter object creation and  deserialization  in using block for FileStream object
            // Write deserialization result to console

        // Impement SoapFrm(Student p) method to serialize and deserialize p

        // Define path for file
        // Implement SoapFormatter object creation and p serialization  in using block for FileStream object

        // Implement SoapFormatter object creation and  deserialization  in using block for FileStream object
            // Write deserialization result to console

        // Impement XmlFrm(Student p) method to serialize and deserialize p 

        // Define path for file
        // Create XmlSerializer serializer typeof Student       
        // Implement  p serialization  in using block for FileStream object

        // Create XmlSerializer deserializer typeof Student 
        // Implement   deserialization  in using block for FileStream object
            // Write deserialization result to console

    }
}

