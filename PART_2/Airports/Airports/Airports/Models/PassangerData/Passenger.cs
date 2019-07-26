using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Airports.Models.FlightData;
using System.Globalization;
using System.ComponentModel;


namespace Airports.Models.PassengerData
{
    class Passenger: IPrintable
    {
        #region Static Members        
        private static string[] countryArray;       //List Of Countries. Filled from Passenger static constructor
        #endregion

        #region Properties
      //  [Description("Flight")]
        public Flight PassFlight { get; set; }

        [Description("First Name")]
        public string FirstName { get; set; }

        [Description("Second Name")]
        public string SecondName { get; set; }

        [Description("Nationality")]
        public string Nationality { get; set; }

        [Description("Passport Info")]
        public string Passport { get; set; }

        
        internal DateTime DateOfBirth { get; set; }

        [Description("Date of Birth")]
        public string StrDateOfBirth
        {
            get
            {
                return DateOfBirth.ToString("dd.MM.yyyy");
            }
        }

        [Description("Sex")]
        public PassengerSex Sex { get; set; }

        [Description("Class")]
        public PassengerClass PassClass { get; set; }

        #endregion

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

        
    }
}
