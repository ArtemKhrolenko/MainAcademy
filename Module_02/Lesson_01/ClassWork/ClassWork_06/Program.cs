using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_06
{
    interface Inter
    {
        void SOmeMEthod();
        
    }
    public class Indexed_students
    {
        public static int stud_cnt = 8;
        private string[] stud_list = new string[stud_cnt];
        
        public Indexed_students()
        {
            for (int j = 0; j < stud_cnt; j++)
            {
                stud_list[j] = "C# student";
            }
        }        

        public string this[int index_var]
        {
            get
            {
                string temp;
                if (index_var >= 0 && index_var <= stud_cnt - 1)
                {
                    temp = stud_list[index_var];
                }
                else
                {
                    temp = "";
                }
                return temp;
            }
            set
            {
                if (index_var >= 0 && index_var <= stud_cnt - 1)
                {
                    stud_list[index_var] = value;
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Indexed_students students = new Indexed_students();
            for (int i = 0; i < Indexed_students.stud_cnt; i++)
            {
                Console.WriteLine(students[i]);
            }
            
        }
    }
}
