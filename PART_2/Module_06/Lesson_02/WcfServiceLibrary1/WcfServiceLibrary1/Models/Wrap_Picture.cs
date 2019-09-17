using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using WcfServiceLibrary1.Models;

namespace WcfServiceLibrary1.Models
{
    [DataContract]
    public partial class Wrap_Picture
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public String Url { get; set; }
        [DataMember]
        public String Description { get; set; }
        public byte[] foo { get; set; }

        public static explicit operator Wrap_Picture(Models.Picture pict)
        {
            Wrap_Picture temp = new Wrap_Picture();
            // code to convert 
            temp.Id = pict.Id;
            temp.Description = pict.Description;
            temp.Url = pict.Url;
            temp.foo = pict.foo;
            return temp;
        }

    }

    public partial class Picture
    {
        public static explicit operator Picture(Models.Wrap_Picture pict)
        {
            Picture temp = new Picture();
            // code to convert 
            temp.Id = pict.Id;
            temp.Description = pict.Description;
            temp.Url = pict.Url;
            temp.foo = pict.foo;
            return temp;
        }
    }

    public partial class Picture
    {
        public int Id {get; set;}
        public string Description { get; set; }
        public string Url { get; set; }
        public byte[] foo { get; set; }
    }
}
