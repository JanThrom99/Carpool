using System;
using System.IO;
using System.Text.RegularExpressions;

namespace CarPool
{
    internal class Program
    {
        #region Constants, Paths, Counters and Stuff
        public const string personDataPath = "C:/010Projects/016Carpool/driverData.csv";
        public const string locationDataPath = "C:/010Projects/016Carpool/locationData.csv";
        public const string carPoolDataPath = "C:/010Projects/016Carpool/carPoolData.csv";

        public static int pCounter = File.ReadAllLines(personDataPath).Length;
        public static int lCounter = File.ReadAllLines(locationDataPath).Length;
        public static int cCounter = File.ReadAllLines(carPoolDataPath).Length;

        public static bool repeat = true;
        public static Regex regex = new Regex("^\\d+$");
        #endregion

        public static void Main(string[] args)
        {
            Console.WriteLine("         _ ______                               __       _ " +
                          "\r\n _    __(_) / / /_____  __ _  __ _  ___ ___    / /  ___ (_)" +
                          "\r\n| |/|/ / / / /  '_/ _ \\/  ' \\/  ' \\/ -_) _ \\  / _ \\/ -_) / " +
                          "\r\n|__,__/_/_/_/_/\\_\\\\___/_/_/_/_/_/_/\\__/_//_/ /_.__/\\__/_/  ");
            Console.WriteLine("   _________    ____  ____  ____  ____  __ " +
                          "\r\n  / ____/   |  / __ \\/ __ \\/ __ \\/ __ \\/ / " +
                          "\r\n / /   / /| | / /_/ / /_/ / / / / / / / /  " +
                          "\r\n/ /___/ ___ |/ _, _/ ____/ /_/ / /_/ / /___" +
                         "\r\n\\____/_/  |_/_/ |_/_/    \\____/\\____/_____/" +
                           "\r\n                                           ");
            Console.ReadKey();

            do
            {
                Console.Clear();
                Console.WriteLine("was willst du machen?");
                Console.WriteLine("[1] - AddPerson" +
                                "\n[2] - GetPerson" +
                                "\n[3] - GetPersonById" +
                                "\n[4] - AddLocation" +
                                "\n[5] - GetLocation" +
                                "\n[6] - GetLocationById" +
                                "\n[7] - AddCarpool" +
                                "\n[8] - GetCarpool" +
                                "\n[9] - GetCarpoolById" +
                                "\n[10] - DeleteCarpool" +
                                "\n[11] - DeleteLocation" +
                                "\n[12] - DeletePerson" +
                                "\n[13] - End");

                var userInput = Console.ReadLine();
                if (regex.IsMatch(userInput))
                {
                    //switch case that checks what the user wants to do 
                    switch (userInput)
                    {
                        case ("1"):
                            AddPerson();
                            break;
                        case ("2"):
                            GetPerson();
                            break;
                        case ("3"):
                            GetPersonById();
                            break;
                        case ("4"):
                            AddLocation();
                            break;
                        case ("5"):
                            GetLocation();
                            break;
                        case ("6"):
                            GetLocationById();
                            break;
                        case ("7"):
                            AddCarpool();
                            break;
                        case ("8"):
                            GetCarpool();
                            break;
                        case ("9"):
                            GetCarpoolById();
                            break;
                        case ("10"):
                            DeleteCarpool();
                            break;
                        case ("11"):
                            DeleteLocation();
                            break;
                        case ("12"):
                            DeletePerson();
                            break;
                        case ("13"):
                            Console.WriteLine("Das Programm wird jetzt beendet");
                            repeat = false;
                            break;
                        default:
                            Console.WriteLine("valider Input aber leider gibt es keine Option mit dieser Nummer");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Falscher input! bitte erneut eingeben! ");
                }
                Console.ReadKey();
            } while (repeat);
        }

        #region Person Stuff
        /// <summary>
        /// Method for adding a Person Dataset to the driverData.csv
        /// </summary>
        public static void AddPerson()
        {
            if (File.Exists(personDataPath))
            {
                Console.WriteLine("bitte gib den Vornamen ein ");
                var name = CheckUserInputforNullOrWhitespaces(Console.ReadLine());
                Console.WriteLine("bitte gib den Nachnamen ein ");
                var familyName = CheckUserInputforNullOrWhitespaces(Console.ReadLine());
                Console.WriteLine("bitte wähle eine Ortschaft aus");
                var locationName = ChooseLocation();

                if (File.ReadAllLines(personDataPath).Length > 0)
                {
                    var newLine = $"\n{name};{familyName};{locationName};ID#{pCounter}";
                    File.AppendAllText(personDataPath, newLine);
                    Console.WriteLine("Added new Dataset (person)");
                    pCounter++;
                }
                else
                {
                    var newLine = $"{name};{familyName};{locationName};ID#{pCounter}";
                    File.AppendAllText(personDataPath, newLine);
                    Console.WriteLine("Added first Dataset (person)");
                    pCounter++;
                }
            }
        }

        /// <summary>
        /// Method for showing all Person Datasets in the driverData.csv
        /// </summary>
        public static void GetPerson()
        {
            var lines = File.ReadAllLines(personDataPath);
            foreach (var line in lines)
            {
                if (line != String.Empty)
                {
                    var splitted = line.Split(';');
                    Console.WriteLine($"Vorname: {splitted[0]}");
                    Console.WriteLine($"Nachname: {splitted[1]}");
                    Console.WriteLine($"Ortsname: {splitted[2]}");
                    Console.WriteLine($"ID: {splitted[3]}");
                    Console.WriteLine("--------------------------------");
                }
            }
        }

        /// <summary>
        /// Method for showing a single Person Dataset with a specific ID in the driverData.csv
        /// </summary>
        public static void GetPersonById()
        {
            Console.WriteLine("Choose ID:");
            showPersonIds();
            var userInput = Console.ReadLine();
            Console.WriteLine("\n");
            Console.WriteLine("Person Info: ");

            var lines = File.ReadAllLines(personDataPath);
            foreach (var line in lines)
            {
                var splitted = line.Split(';');
                if (line != String.Empty && splitted[3].Trim() == userInput.Trim())
                {

                    Console.WriteLine($"Vorname: {splitted[0]}");
                    Console.WriteLine($"Nachname: {splitted[1]}");
                    Console.WriteLine($"Ortsname: {splitted[2]}");
                    Console.WriteLine($"ID: {splitted[3]}");
                    Console.WriteLine("--------------------------------");
                }
            }
        }

        /// <summary>
        /// Method for deleting all the Person Datasets in the driverData.csv
        /// </summary>
        public static void DeletePerson()
        {
            File.WriteAllText(personDataPath, String.Empty);
            pCounter = 0;
            Console.WriteLine("Daten wurden gelöscht");
        }
        #endregion

        #region Location Stuff
        /// <summary>
        /// Method for adding a specific Location datasets to the locationData.csv
        /// </summary>
        public static void AddLocation()
        {

            Console.WriteLine("bitte gib den Ortsnamen ein ");
            var locationName = CheckUserInputforNullOrWhitespaces(Console.ReadLine());

            if (File.ReadAllLines(locationDataPath).Length > 0)
            {
                var newLine = $"\n{locationName};LID#{lCounter}";
                File.AppendAllText(locationDataPath, newLine);
                Console.WriteLine("Added new Dataset (location)");
            }
            else
            {
                var newLine = $"{locationName};LID#{lCounter}";
                File.AppendAllText(locationDataPath, newLine);
                Console.WriteLine("Added first Dataset (location)");
            }
            lCounter++;
        }

        /// <summary>
        /// Method for showing all Location datasets in the locationData.csv
        /// </summary>
        public static void GetLocation()
        {
            var lines = File.ReadAllLines(locationDataPath);
            foreach (var line in lines)
            {
                if (line != String.Empty)
                {
                    var splitted = line.Split(';');
                    Console.WriteLine($"Ortsname: {splitted[0]}");
                    Console.WriteLine($"ID: {splitted[1]}");
                    Console.WriteLine("--------------------------------");
                }
            }
        }

        /// <summary>
        /// Method for showing a single Location dataset with a specific ID in the locationData.csv
        /// </summary>
        public static void GetLocationById()
        {
            Console.WriteLine("Choose Carpool ID?");
            showLocationIds();

            var userInput = Console.ReadLine();

            var lines = File.ReadAllLines(locationDataPath);
            foreach (var line in lines)
            {
                var splitted = line.Split(';');
                if (line != String.Empty && splitted[1].Trim() == userInput.Trim())
                {

                    Console.WriteLine($"Ortsname: {splitted[0]}");
                    Console.WriteLine($"ID: {splitted[1]}");
                    Console.WriteLine("--------------------------------");
                }
            }
        }

        /// <summary>
        /// Method for deleting all Location datasets in the locationData.csv
        /// </summary>
        public static void DeleteLocation()
        {
            File.WriteAllText(locationDataPath, String.Empty);
            lCounter = 0;
            Console.WriteLine("Daten wurden gelöscht");
        }
        #endregion

        #region Carpool Stuff
        /// <summary>
        /// Method for adding a specific CarPool to the carPoolData.csv
        /// </summary>
        public static void AddCarpool()
        {
            Console.WriteLine("bitte gib den Carpool Namen ein ");
            var carpoolName = CheckUserInputforNullOrWhitespaces(Console.ReadLine());
            var driver = ChooseDriver();


            if (!String.IsNullOrEmpty(driver))
            {
                var passenger = ChoosePassenger();
                var carPoolData = ChooseCarPoolData();

                if (File.ReadAllLines(carPoolDataPath).Length > 0)
                {
                    var newLine = $"\n{carpoolName};{driver};{passenger};CPID#{cCounter};{carPoolData}";
                    File.AppendAllText(carPoolDataPath, newLine);
                    Console.WriteLine("Added new Dataset (carPool)");
                }
                else
                {
                    var newLine = $"{carpoolName};{driver};{passenger};CPID#{cCounter};{carPoolData}";
                    File.AppendAllText(carPoolDataPath, newLine);
                    Console.WriteLine("Added first Dataset (carPool)");
                }
                cCounter++;
            }
            else
            {
                Console.WriteLine("Carpool wurde nicht hinzugefügt! Ohne Fahrer fährt sichs schwer!");
            }
        }

        /// <summary>
        /// Method for showing all CarPool datasets in the carPoolData.csv
        /// </summary>
        public static void GetCarpool()
        {
            var lines = File.ReadAllLines(carPoolDataPath);
            var driverlines = File.ReadAllLines(personDataPath);
            foreach (var line in lines)
            {
                var splitted = line.Split(';');
                if (line != String.Empty)
                {
                    Console.WriteLine($"CarPool Name: {splitted[0]} ({splitted[3]})");

                    foreach (var entry in driverlines)
                    {
                        var splittedEntry = entry.Split(';');
                        if (splittedEntry[3].Trim() == splitted[1].Trim())
                        {
                            Console.WriteLine($"Driver: {splittedEntry[0]} {splittedEntry[1]} ({splitted[1]})");
                        }
                    }

                    foreach (var entry in driverlines) //TODO make it work // return passenger as well 
                    {
                        var splittedEntry = entry.Split(';');
                        if (splittedEntry[3].Trim() == splitted[2].Trim())
                        {
                            Console.WriteLine($"Passenger: {splittedEntry[0]} {splittedEntry[1]} ({splitted[2]})");
                        }
                    }
                    Console.WriteLine($"Start: {splitted[4]}");
                    Console.WriteLine($"Ziel: {splitted[5]}");
                    Console.WriteLine($"Abfahrtszeit: {splitted[6]}");
                    Console.WriteLine($"Ankunftszeit: {splitted[7]}");
                    Console.WriteLine("--------------------------------");
                }
            }
        }

        /// <summary>
        /// Method for showing all CarPool datasets in the carPoolData.csv
        /// </summary>
        public static void GetCarpoolById()
        {
            Console.WriteLine("welcher Carpool soll angezeigt werden? (Bitte ID eingeben)");
            showCarpoolIds();

            var userInput = Console.ReadLine();
            var lines = File.ReadAllLines(carPoolDataPath);
            var driverlines = File.ReadAllLines(personDataPath);
            foreach (var line in lines)
            {
                var splitted = line.Split(';');
                if (line != String.Empty && splitted[3] == userInput)
                {
                    Console.WriteLine($"CarPool Name: {splitted[0]} ({splitted[3]})");

                    foreach (var entry in driverlines)
                    {
                        var splittedEntry = entry.Split(';');
                        if (splittedEntry[3].Trim() == splitted[1].Trim())
                        {
                            Console.WriteLine($"Driver: {splittedEntry[0]} {splittedEntry[1]} ({splitted[1]})");
                        }
                    }

                    foreach (var entry in driverlines) //TODO make it work
                    {
                        var splittedEntry = entry.Split(';');
                        if (splittedEntry[3].Trim() == splitted[2].Trim())
                        {
                            Console.WriteLine($"Passenger: {splittedEntry[0]} {splittedEntry[1]} ({splitted[2]})");
                        }
                    }
                    Console.WriteLine($"Start: {splitted[4]}");
                    Console.WriteLine($"Ziel: {splitted[5]}");
                    Console.WriteLine($"Abfahrtszeit: {splitted[6]}");
                    Console.WriteLine($"Ankunftszeit: {splitted[7]}");
                    Console.WriteLine("--------------------------------");
                }
            }
        }

        /// <summary>
        /// Method for deleting all CarPool datasets in the carPoolData.csv
        /// </summary>
        public static void DeleteCarpool()
        {
            File.WriteAllText(carPoolDataPath, String.Empty);
            cCounter = 0;
            Console.WriteLine("Daten wurden gelöscht");
        }
        #endregion

        #region Helper methods
        /// <summary>
        /// Helper Method which will check a user input string on whether its empty or null and if not trims the ends
        /// </summary>
        /// <param name="userInput">The string which the user typed into the console which needs to be checked.</param>
        /// <returns>a string output which contains the trimmed user Input that is not null or only white spaces.</returns>
        public static string CheckUserInputforNullOrWhitespaces(string userInput)
        {
            var repeat = true;
            var output = "";
            do
            {
                if (!String.IsNullOrWhiteSpace(userInput))
                {
                    repeat = false;
                    output = userInput.Trim(' ');
                }
                else
                {
                    Console.WriteLine("non valid input! try again");
                    userInput = Console.ReadLine();
                }
            } while (repeat);
            return output;
        }

        /// <summary>
        /// Method that lets you choose the driver of a CarPool when creating a new CarPool dataset
        /// </summary>
        /// <returns></returns>
        public static string ChooseDriver()
        {
            var output = "";
            var repeat = true;
            while (repeat)
            {
                var lines = File.ReadAllLines(personDataPath);

                Console.WriteLine("\n");
                Console.WriteLine("Wer ist der Fahrer der Fahrgemeinschaft? (bitte ID eingeben)");
                Console.WriteLine("\n");

                foreach (var line in lines)
                {
                    var splitted = line.Split(';');
                    if (line != String.Empty)
                    {
                        Console.WriteLine($"Vorname: {splitted[0]}");
                        Console.WriteLine($"Nachname: {splitted[1]}");
                        Console.WriteLine($"Ortsname: {splitted[2]}");
                        Console.WriteLine($"ID: {splitted[3]}");
                        Console.WriteLine("--------------------------------");
                    }
                }
                var userInput = CheckUserInputforNullOrWhitespaces(Console.ReadLine());

                foreach (var line in lines)
                {
                    if (line != String.Empty)
                    {
                        var splitted = line.Split(';');
                        if (splitted[3] == userInput)
                        {
                            repeat = false;
                            output = splitted[3];
                            break;
                        }
                    }
                }
                if (output == "")
                {
                    Console.WriteLine("der Fahrer existiert leider nicht! Bitte such dir einen aus der existiert oder lege einen neuen an!");
                    Console.WriteLine("zurück zum Menü? (y/n)");
                    if (CheckUserInputforNullOrWhitespaces(Console.ReadLine()) == "y")
                    {
                        repeat = false;
                        break;
                    }
                }
                lCounter++;
            }
            return output;
        }

        /// <summary>
        /// Method that lets you choose the passenger of a CarPool when creating a new CarPool dataset
        /// </summary>
        /// <returns></returns>
        public static string ChoosePassenger()
        {
            var output = "";
            var repeat = true;
            while (repeat)
            {
                var lines = File.ReadAllLines(personDataPath);

                Console.WriteLine("\n");
                Console.WriteLine("Wer fährt bei dir mit? (bitte ID eingeben)");
                Console.WriteLine("\n");

                foreach (var line in lines)
                {
                    var splitted = line.Split(';');
                    if (line != String.Empty)
                    {
                        Console.WriteLine($"Vorname: {splitted[0]}");
                        Console.WriteLine($"Nachname: {splitted[1]}");
                        Console.WriteLine($"Ortsname: {splitted[2]}");
                        Console.WriteLine($"ID: {splitted[3]}");
                        Console.WriteLine("--------------------------------");
                    }
                }

                var userInput = CheckUserInputforNullOrWhitespaces(Console.ReadLine());
                foreach (var line in lines)
                {
                    if (line != String.Empty)
                    {
                        var splitted = line.Split(';');
                        if (splitted[3] == userInput)
                        {
                            repeat = false;
                            output = $"{splitted[3]} ";
                            break;
                        }
                    }
                }

                if (output == "")
                {
                    Console.WriteLine("der Beifahrer existiert leider nicht! Bitte such dir einen aus der existiert oder lege einen neuen an!");
                    Console.WriteLine("zurück zum Menü? (y/n)");
                    if (CheckUserInputforNullOrWhitespaces(Console.ReadLine()) == "y")
                    {
                        Console.WriteLine("Carpool wurde ohne Beifahrer erstellt!");
                        repeat = false;
                        break;
                    }
                }
                lCounter++;
            }
            return output;
        }

        /// <summary>
        /// Method that lets you choose some additional CarPool data when creating a new CarPool dataset
        /// </summary>
        /// <returns></returns>
        public static string ChooseCarPoolData()
        {
            Console.WriteLine("Bitte gib einen Abfahrtsort ein");
            var startingLocation = Console.ReadLine();
            Console.WriteLine("Bitte gib einen Zielort ein");
            var destination = Console.ReadLine();
            Console.WriteLine("Bitte gib eine Abfahrtszeit ein");
            var startingTime = Console.ReadLine();
            Console.WriteLine("Bitte gib eine Ankunftszeit ein");
            var arrivalTime = Console.ReadLine();

            return $"{startingLocation};{destination};{startingTime};{arrivalTime}";
        }

        /// <summary>
        /// Method which shows the Carpool Id's
        /// </summary>
        public static void showCarpoolIds()
        {
            Console.WriteLine("Choose your Carpool ID:");
            var lines = File.ReadAllLines(carPoolDataPath);
            Console.WriteLine("\n");

            foreach (var line in lines)
            {
                var splitted = line.Split(';');
                if (line != String.Empty)
                {

                    Console.WriteLine($"ID: {splitted[3]} - {splitted[0]}");
                    Console.WriteLine("--------------------------------");
                }
            }

        }

        /// <summary>
        /// Method which shows the Location Id's
        /// </summary>
        public static void showLocationIds()
        {
            Console.WriteLine("Choose your Location ID:");
            var lines = File.ReadAllLines(locationDataPath);
            Console.WriteLine("\n");

            foreach (var line in lines)
            {
                var splitted = line.Split(';');
                if (line != String.Empty)
                {

                    Console.WriteLine($"ID: {splitted[1]} - {splitted[0]}");
                    Console.WriteLine("--------------------------------");
                }
            }
        }

        /// <summary>
        /// Method which shows the Person Id's
        /// </summary>
        public static void showPersonIds()
        {
            Console.WriteLine("Choose your Person ID:");
            var lines = File.ReadAllLines(personDataPath);
            Console.WriteLine("\n");

            foreach (var line in lines)
            {
                var splitted = line.Split(';');
                if (line != String.Empty)
                {
                    Console.WriteLine($"ID: {splitted[3]} - {splitted[1]}, {splitted[0]}");
                    Console.WriteLine("--------------------------------");
                }
            }
        }

        /// <summary>
        /// Method which lets you choose a Location when creating a new Person Dataset
        /// </summary>
        public static string ChooseLocation()
        {
            var output = "";
            var repeat = true;
            while (repeat)
            {
                var lines = File.ReadAllLines(locationDataPath);
                Console.WriteLine("in welchem Ort wohnst du? (bitte ID eingeben)");
                foreach (var line in lines)
                {
                    if (line != String.Empty)
                    {
                        var splitted = line.Split(';');
                        Console.WriteLine($"Ortsname: {splitted[0]} \nID: {splitted[1]}");
                        Console.WriteLine("--------------------------------");
                    }
                }
                var userInput = Console.ReadLine();

                foreach (var line in lines)
                {
                    if (line != String.Empty)
                    {
                        var splitted = line.Split(';');
                        if (splitted[1] == userInput)
                        {
                            repeat = false;
                            output = splitted[0];
                            break;
                        }
                    }
                }
                if (output == "")
                {
                    Console.WriteLine("der Ort existiert nicht! Bitte fügen sie ihn jetzt hinzu indem du unten den Namen eingiebst!");
                    var locationName = CheckUserInputforNullOrWhitespaces(Console.ReadLine());

                    if (File.ReadAllLines(locationDataPath).Length > 0)
                    {
                        var newLine = $"\n{locationName};LID#{lCounter}";
                        File.AppendAllText(locationDataPath, newLine);
                        Console.WriteLine("Added new Dataset (location)");
                        output = $"{locationName}";
                        repeat = false;
                        break;
                    }
                    else
                    {
                        var newLine = $"{locationName};LID#{lCounter}";
                        File.AppendAllText(locationDataPath, newLine);
                        Console.WriteLine("Added first Dataset (location)");
                        output = $"{locationName}";
                        repeat = false;
                        break;
                    }
                }
                lCounter++;
            }
            return output;
        }
        #endregion
    }
}