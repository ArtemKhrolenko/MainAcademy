using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airport_Project.Passenger_Data;

namespace Airport_Project.Menu_Data
{
    class PassengerEditor: Editor
    {
        private ItemsPrinter itemsPrinter;
        public PassengerEditor(ItemsPrinter _itemsPrinter)
        {
            itemsPrinter = _itemsPrinter;
        }

        internal void EditPassenger(List<Passenger> passengers, string description)
        {
            Passenger passItem;
            int numOfPassToEdit;
            bool parseIsOk;
            string usersChoice = string.Empty;

            while (true)
            {
                Console.Clear();                
                itemsPrinter.PrintItemsList(passengers, 0, description);
                Console.Write($"Enter number of passenger you want to edit...Or press 0 to return to previous menu...");

                parseIsOk = Int32.TryParse(Console.ReadLine(), out numOfPassToEdit);

                if (numOfPassToEdit == 0 && parseIsOk)
                    return;

                if (!parseIsOk || numOfPassToEdit < 0 || numOfPassToEdit > passengers.Count)
                {
                    usersChoice = ReceiveUserChoice();
                    if (usersChoice == "1") break;
                    if (usersChoice == "2") return;
                    else continue;
                }

                passItem = passengers[numOfPassToEdit - 1];
                while (true)
                {
                    Console.Clear();
                    itemsPrinter.PrintItemsList(passengers, numOfPassToEdit, description);
                    Console.WriteLine($"...Editing user {passItem.FirstName}  {passItem.SecondName} of flight {passItem.PassFlight}");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"1. First Name;\n2. Second Name;\n3. Nationality;\n4. Passport;\n5. Date of Birth;\n6. Sex;\n7. Class;\n0. To return to previous menuu.");
                    Console.ResetColor();
                    Console.Write("Select item number to edit...");
                    parseIsOk = Int32.TryParse(Console.ReadLine(), out int numOfItemToEdit);

                    if (parseIsOk && numOfItemToEdit == 0)
                        break;

                    if (!parseIsOk || numOfItemToEdit < 0 || numOfItemToEdit > passengers.Count)
                    {
                        usersChoice = ReceiveUserChoice();
                        if (usersChoice == "1") break;
                        if (usersChoice == "2") return;
                        else continue;
                    }

                    //Handling correct input
                    switch (numOfItemToEdit)
                    {
                        case 1: //Fist Name                     
                            while (true)
                            {
                                Console.Clear();                                
                                itemsPrinter.PrintItemsList(passengers, numOfPassToEdit, description);
                                (bool succeed, string result) firstNameFromUser = ChangeItemInDesk("First Name", passItem.FirstName, @"[A-Z][a-z]+$", 8);
                                if (!firstNameFromUser.succeed)
                                {
                                    usersChoice = ReceiveUserChoice();
                                    if (usersChoice == "1") break;
                                    if (usersChoice == "2") return;
                                    else continue;
                                }
                                passengers[numOfPassToEdit - 1].FirstName = firstNameFromUser.result;
                                break;
                            }
                            break;

                        case 2: //Second Name  
                            while (true)
                            {
                                Console.Clear();
                                itemsPrinter.PrintItemsList(passengers, numOfPassToEdit, description);
                                (bool succeed, string result) secondNameFromUser = ChangeItemInDesk("Second Name", passItem.FirstName, @"[A-Z][a-z]+$", 8);
                                if (!secondNameFromUser.succeed)
                                {
                                    usersChoice = ReceiveUserChoice();
                                    if (usersChoice == "1") break;
                                    if (usersChoice == "2") return;
                                    else continue;
                                }
                                passengers[numOfPassToEdit - 1].FirstName = secondNameFromUser.result;
                                break;
                            }
                            break;

                        case 3: //Nationality                       

                            while (true)
                            {
                                Console.Clear();                                
                                itemsPrinter.PrintItemsList(passengers, numOfPassToEdit, description);
                                (bool succeed, string result) natioFromUser = ChangeItemInDesk("City", passItem.Nationality, @"^[A-Z][a-z]+$", 10);
                                if (!natioFromUser.succeed)
                                {
                                    usersChoice = ReceiveUserChoice();
                                    if (usersChoice == "1") break;
                                    if (usersChoice == "2") return;
                                    else continue;
                                }
                                passengers[numOfPassToEdit - 1].Nationality = natioFromUser.result;
                                
                                break;
                            }
                            break;

                        case 4: //Passport

                            while (true)
                            {
                                Console.Clear();                                
                                itemsPrinter.PrintItemsList(passengers, numOfPassToEdit, description);
                                (bool succeed, string result) passportFromUser = ChangeItemInDesk("Air Company", passItem.Passport, @"[A-Z]{2}[0-9]{4}$", 8);
                                if (!passportFromUser.succeed)
                                {
                                    usersChoice = ReceiveUserChoice();
                                    if (usersChoice == "1") break;
                                    if (usersChoice == "2") return;
                                    else continue;
                                }
                                passengers[numOfPassToEdit - 1].Passport = passportFromUser.result;
                                break;
                            }
                            break;

                        case 5: //Date of Birth                          

                            Console.Clear();                            
                            itemsPrinter.PrintItemsList(passengers, numOfPassToEdit, description);
                            (bool succeed, DateTime result) timeFromUser = ChangeItemInDesk("Time", passItem.DateOfBirth, "dd.MM.yyyy");
                            if (!timeFromUser.succeed)
                            {
                                usersChoice = ReceiveUserChoice();
                                if (usersChoice == "1") break;
                                if (usersChoice == "2") return;
                                else continue;
                            }
                            passengers[numOfPassToEdit - 1].DateOfBirth = timeFromUser.result;                            
                            break;
                        

                        case 6: //Sex
                            while (true)
                            {
                                Console.Clear();                                
                                itemsPrinter.PrintItemsList(passengers, numOfPassToEdit, description);
                                Console.WriteLine(passengers[numOfPassToEdit - 1].Sex.GetType());
                                Console.Read();

                                
                                //else
                                //{
                                //    usersChoice = ReceiveUserChoice();
                                //    if (usersChoice == "1") break;
                                //    if (usersChoice == "2") return;
                                //    else continue;
                                //}
                            }
                            break;

                        default:
                            //If edit info is incorrect
                            //numOfItemToEdit = -1;
                            //usersChoice = ReceiveUserChoice();
                            //if (usersChoice != "1") continue;
                            //if (usersChoice == "2") return;
                            break;

                    }
                    //if (numOfItemToEdit == -1 && usersChoice == "1") break;
                }

            }
        }

    }
}
