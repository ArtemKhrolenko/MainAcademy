using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace ClassWork_01
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Zip_File("System.Web.Mvc.dll", "System.Web.Mvc.dll.gz");
                UnZip_File("System.Web.Mvc.dll.gz", "System.Web.Mvc.dll.tst");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void Zip_File(string in_Fl, string out_Fl)
        {
            FileStream src = File.OpenRead(in_Fl);
            FileStream dst = File.Create(out_Fl);
            GZipStream Zip_Stream = new GZipStream(dst, CompressionMode.Compress);
            int One_Byte = src.ReadByte();

            while (One_Byte != -1)
            {
                Zip_Stream.WriteByte((byte)One_Byte);
                One_Byte = src.ReadByte();
            }
            src.Close();
            Zip_Stream.Close();
            dst.Close();
            
        }

       static void UnZip_File(string in_Fl, string out_Fl)
        {
            FileStream src = File.OpenRead(in_Fl);
            FileStream dst = File.Create(out_Fl);
            // Create compressed stream
            GZipStream Zip_Stream = new GZipStream(src, CompressionMode.Decompress);
            // Write  data
            int One_Byte = Zip_Stream.ReadByte();
            while (One_Byte != -1)
            {
                dst.WriteByte((byte)One_Byte);
                One_Byte = Zip_Stream.ReadByte();
            }
            // Clear
            src.Close();
            Zip_Stream.Close();
            dst.Close();
        }


    }
}
