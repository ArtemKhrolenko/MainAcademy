using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Airport_Project.Flight_Data;
using System.Globalization;
using System.ComponentModel;


namespace Airport_Project.Passenger_Data
{
    class Passenger: IPrintable
    {
        #region Static Members
        internal static PropertyInfo[] listOffields; //List of Properies with Description attribute
        private static string[] countryArray;       //List Of Countries. Filled from Passenger static constructor
        #endregion

        [Description("Flight")]
        public Flight PassFlight { get; private set; }

        [Description("First Name")]
        public string FirstName { get; private set; }

        [Description("Second Name")]
        public string SecondName { get; private set; }

        [Description("Nationality")]
        public string Nationality { get; private set; }

        [Description("Passport Info")]
        public string Passport { get; private set; }

        
        internal DateTime DateOfBirth { get; private set; }

        [Description("Date of Birth")]
        public string StrDateOfBirth
        {
            get
            {
                return DateOfBirth.ToString("dd-mm-yyyy");
            }
        }

        [Description("Sex")]
        public PassengerSex Sex { get; private set; }

        [Description("Class")]
        public PassengerClass PassClass { get; private set; }

        private Random rnd;

        //For random implicit fields initalization
        internal Passenger(Random _rnd, Flight _flight)
        {
            rnd = _rnd;
            PassFlight = _flight;
            RandomInitalizePassenger(_rnd);

        }

        //For explicit fields initalization
        internal Passenger(Flight passFlight, string firstName, string secondName, string nationality, string passport, DateTime dateOfBirth, PassengerSex sex, PassengerClass passClass)
        {
            PassFlight = passFlight;
            FirstName = firstName;
            SecondName = secondName;
            Nationality = nationality;
            Passport = passport;
            DateOfBirth = dateOfBirth;
            Sex = sex;
            PassClass = passClass;
        }

        #region Static initialization
        //In a static constructor fill list of Countries in Airport_Data static class
        static Passenger()
        {
            //Get list of Countries
            countryArray = GetCountryList();
            //Get list of Properties
            listOffields = InitProps();
        }

        //Method for getting array of Countries for Random initialization
        private static string[] GetCountryList()
        {
            List<string> _countryList = new List<string>(); //AirportData.CountryList = new List<string>();

            //getting the specific CultureInfo from CultureInfo class
            CultureInfo[] getCultureInfo = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            foreach (CultureInfo getCulture in getCultureInfo)
            {
                //creating the object of RegionInfo class
                RegionInfo regionInfo = new RegionInfo(getCulture.LCID);
                //adding each country Name into the List
                if (!(_countryList.Contains(regionInfo.EnglishName)))
                {
                    _countryList.Add(regionInfo.EnglishName);
                }
            }
            //sorting array
            _countryList.Sort();
            return _countryList.ToArray();
        }

        //Method for getting a list of Propeerties with Description attribute
        private static PropertyInfo[] InitProps()
        {
            PropertyInfo[] props = typeof(Passenger).GetProperties();
            var propList = new List<PropertyInfo>();
            foreach (var item in props)
            {
                if (Attribute.IsDefined(item, typeof(DescriptionAttribute)))
                {
                    propList.Add(item);
                }
            }
            return propList.ToArray();

        }
        #endregion

        #region Random Initialization

        private void RandomInitalizePassenger(Random rnd)
        {
            //First Name
            FirstName = NameInit();

            //Second Name
            SecondName = NameInit();

            //Nationality
            Nationality = countryArray[rnd.Next(0, countryArray.Length)];

            //PassPort
            char[] charArray = new char[8];
            for (int i = 0; i < 2; i++)
                charArray[i] = (char)rnd.Next(65, 91);

            for (int i = 2; i < charArray.Length; i++)
            {
                charArray[i] = (char)rnd.Next(48, 58);
            }
            Passport = new string(charArray);

            //Date of Birth            
            //DateOfBirth = new DateTime(rnd.Next(1900, DateTime.Now.Year - 10), rnd.Next(1, 12), rnd.Next(1, 28));
            DateTime start = new DateTime(1990, 1, 1);
            DateOfBirth = start.AddDays(rnd.Next((DateTime.Today - start).Days));

            //Sex
            Array passSexItems = Enum.GetValues(typeof(PassengerSex));
            Sex = (PassengerSex)passSexItems.GetValue(rnd.Next(passSexItems.Length));

            //PassClass
            Array passClassItems = Enum.GetValues(typeof(PassengerClass));
            PassClass = (PassengerClass)passClassItems.GetValue(rnd.Next(passClassItems.Length));

        }


        private string NameInit()
        {
            char[] charArray = new char[rnd.Next(3, 10)];
            charArray[0] = (char)rnd.Next(65, 91); //First later in First Name
            for (int i = 1; i < charArray.Length; i++)
            {
                charArray[i] = (char)rnd.Next(97, 123);
            }
            return new string(charArray);
        }

        #endregion

        #region Printing Passenger's info
        //Method for printing Passenger's info
        internal void GetPassengerFieldsDescription()
        {
            foreach (var item in listOffields)
            {
                printPassangerInfoLine(item, this);
                //Console.Write($"{(Attribute.GetCustomAttribute(item, typeof(DescriptionAttribute)) as DescriptionAttribute).Description}  ");
            }
        }

        //Method for printing one passengar's info line
        private void printPassangerInfoLine(PropertyInfo propertyInfo, Passenger passanger)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            string desc = (Attribute.GetCustomAttribute(propertyInfo, typeof(DescriptionAttribute)) as DescriptionAttribute).Description;
            Console.Write($"{desc,-20}");
            Console.ResetColor();
            object objVal = propertyInfo.GetValue(passanger);
            string value = objVal.ToString();
            Console.WriteLine(value.Substring(0, Math.Min(10, value.Length)));
            Console.ResetColor();            
        }

        #endregion



    }
}
