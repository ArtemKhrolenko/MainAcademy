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
            Student student = new Student();

            // Initialize its properties
            student.firstName = "Artem";
            student.lastName = "Khrolenko";
            student.nationality = "Ukraine";
            student.SetAddress("Kyiv", "0000");

            // Call methods for serialization and deserialization

            //Binary
            BinaryFrm(student);            

            //SOAP
            SoapFrm(student);

            //XML
            XmlFrm(student);

        }

        // Impement BinaryFrm(Student p) method to serialize and deserialize p
        // Define path for file
        // Implement BinaryFormatter object creation and p serialization  in using block for FileStream object

        // Implement BinaryFormatter object creation and  deserialization  in using block for FileStream object
        // Write deserialization result to console

        static void BinaryFrm(Student p)
        {
            //Serialization
            Console.WriteLine("Serialization BinaryFormatter...");
            using (var stream = new FileStream("binarySerFile.txt", FileMode.OpenOrCreate))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, p);
            }
            Console.WriteLine("Ok");

            //Deserialization
            Console.WriteLine("Deserialization BinaryFormatter...");
            using (var stream = new FileStream("binarySerFile.txt", FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Student student = (Student)formatter.Deserialize(stream);
                Console.WriteLine($"Deserialized object: {student}");
            }
            Console.WriteLine("Ok\n----------------------");
        }


        // Impement SoapFrm(Student p) method to serialize and deserialize p

        // Define path for file
        // Implement SoapFormatter object creation and p serialization  in using block for FileStream object

        // Implement SoapFormatter object creation and  deserialization  in using block for FileStream object
        // Write deserialization result to console

        static void SoapFrm(Student p)
        {
            //Serialization
            Console.WriteLine("Serialization SoapFormatter...");
            using (var stream = new FileStream("soapSerFile.txt", FileMode.OpenOrCreate))
            {
                SoapFormatter formatter = new SoapFormatter();
                formatter.Serialize(stream, p);
            }
            Console.WriteLine("Ok");

            //Deserialization
            Console.WriteLine("Deserialization SoapFormatter...");
            using (var stream = new FileStream("soapSerFile.txt", FileMode.Open))
            {
                SoapFormatter formatter = new SoapFormatter();
                Student student = (Student)formatter.Deserialize(stream);
                Console.WriteLine($"Deserialized object: {student}");
            }
            Console.WriteLine("Ok\n----------------------");
        }


        // Impement XmlFrm(Student p) method to serialize and deserialize p 

        // Define path for file
        // Create XmlSerializer serializer typeof Student       
        // Implement  p serialization  in using block for FileStream object

        // Create XmlSerializer deserializer typeof Student 
        // Implement   deserialization  in using block for FileStream object
        // Write deserialization result to console
        static void XmlFrm(Student p)
        {
             //Serialization
            Console.WriteLine("Serialization XmlFormatter...");
            using (var stream = new FileStream("xmlSerFile.txt", FileMode.OpenOrCreate))
            {
                XmlSerializer serialiser = new XmlSerializer(typeof(Student));
                serialiser.Serialize(stream, p);
            }
            Console.WriteLine("Ok");

            //Deserialization
            Console.WriteLine("Deserialization XmlFormatter...");
            using (var stream = new FileStream("xmlSerFile.txt", FileMode.Open))
            {
                XmlSerializer deSerialiser = new XmlSerializer(typeof(Student));;
                Student student = (Student)deSerialiser.Deserialize(stream);
                Console.WriteLine($"Deserialized object: {student}");
            }
            Console.WriteLine("Ok\n----------------------");

        }

    }
}

