using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_07
{
    abstract class UserInfo
    {
        protected string Usr_name;
        protected byte Usr_nmbr;

        public UserInfo(string User_Name, byte User_Number)
        {
            Usr_name = User_Name;
            Usr_nmbr = User_Number;
        }

        public abstract string User_Info();
        
    }

    class UserGroup : UserInfo
    {
        string Group;
        public UserGroup(string User_Group, string User_Name, byte User_Number) : base(User_Name, User_Number)
        {
            Group = User_Group;
        }

        public override string User_Info()
        {
            return Group + " " + Usr_name + " " + Usr_nmbr; 
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            UserGroup user_1 = new UserGroup("Albert", "Moon", 1);

            Console.WriteLine("User Information :" + user_1.User_Info());
        }
    }
}
