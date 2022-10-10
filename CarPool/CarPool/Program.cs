using System;
using System.IO;
using System.Text.RegularExpressions;

namespace CarPool
{
    internal class Program
    {
        #region Constants, Paths and Stuff
        public static string personDataPath = "C:/010Projects/016Carpool/driverData.csv";
        public static string locationDataPath = "C:/010Projects/016Carpool/locationData.csv";
        public static string carPoolDataPath = "C:/010Projects/016Carpool/carPoolData.csv";
        public static int pCounter = File.ReadAllLines(personDataPath).Length;
        public static int lCounter = File.ReadAllLines(locationDataPath).Length;
        public static int cpCounter = File.ReadAllLines(carPoolDataPath).Length;
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

            var repeat = true;
            Regex regex = new Regex("^\\d+$");

            do
            {
                Console.Clear();
                Console.WriteLine("was willst du machen?");
                Console.WriteLine("[1] - Personen Daten hinzufügen" +
                                "\n[2] - Personen Daten anzeigen" +
                                "\n[3] - Ort hinzufügen" +
                                "\n[4] - Orte anzeigen" +
                                "\n[5] - Carpool hinzufügen" +
                                "\n[6] - Carpools anzeigen" +
                                "\n[7] - Alle Carpool Daten löschen" +
                                "\n[8] - Alle Orts Daten löschen" +
                                "\n[9] - Alle Personen Daten löschen" +
                                "\n[10] - Beenden");

                var userInput = Console.ReadLine();
                if (regex.IsMatch(userInput))
                {
                    switch (userInput)
                    {
                        case ("1"):
                            AddPerson(pCounter);
                            break;
                        case ("2"):
                            ShowPersonData();
                            break;
                        case ("3"):
                            AddLocation();
                            break;
                        case ("4"):
                            ShowLocationData();
                            break;
                        case ("5"):
                            AddCarPool();
                            break;
                        case ("6"):
                            ShowCarPoolData();
                            break;
                        case ("7"):
                            DeleteCarPoolData();
                            break;
                        case ("8"):
                            DeleteLocationData();
                            break;
                        case ("9"):
                            DeletePersonData();
                            break;
                        case ("10"):
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
        public static void AddPerson(int i)
        {
            if (File.Exists(personDataPath))
            {
                Console.WriteLine("bitte gib den Vornamen ein ");
                var name = CheckUserInput(Console.ReadLine());
                Console.WriteLine("bitte gib den Nachnamen ein ");
                var familyName = CheckUserInput(Console.ReadLine());
                Console.WriteLine("bitte wähle eine Ortschaft aus");
                var locationName = ChoseLocation();

                if (File.ReadAllLines(personDataPath).Length > 0)
                {
                    var newLine = $"\n{name};{familyName};{locationName};PID{i}";
                    File.AppendAllText(personDataPath, newLine);
                    Console.WriteLine("Added new Dataset (person)");
                    pCounter++;
                }
                else
                {
                    var newLine = $"{name};{familyName};{locationName};PID{i}";
                    File.AppendAllText(personDataPath, newLine);
                    Console.WriteLine("Added first Dataset (person)");
                    pCounter++;
                }
            }
        }
        public static void ShowPersonData()
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
        public static void DeletePersonData()
        {
            File.WriteAllText(personDataPath, "");
            pCounter = 0;
            Console.WriteLine("Daten wurden gelöscht");
        }
        #endregion

        #region Location Stuff
        public static void AddLocation()
        {

            Console.WriteLine("bitte gib den Ortsnamen ein ");
            var locationName = CheckUserInput(Console.ReadLine());

            if (File.ReadAllLines(locationDataPath).Length > 0)
            {
                var newLine = $"\n{locationName};LID{lCounter}";
                File.AppendAllText(locationDataPath, newLine);
                Console.WriteLine("Added new Dataset (location)");
            }
            else
            {
                var newLine = $"{locationName};LID{lCounter}";
                File.AppendAllText(locationDataPath, newLine);
                Console.WriteLine("Added first Dataset (location)");
            }
            lCounter++;
        }
        public static void ShowLocationData()
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
        public static void DeleteLocationData()
        {
            File.WriteAllText(locationDataPath, "");
            lCounter = 0;
            Console.WriteLine("Daten wurden gelöscht");
        }
        public static string ChoseLocation()
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
                    var locationName = CheckUserInput(Console.ReadLine());

                    if (File.ReadAllLines(locationDataPath).Length > 0)
                    {
                        var newLine = $"\n{locationName};LID{lCounter}";
                        File.AppendAllText(locationDataPath, newLine);
                        Console.WriteLine("Added new Dataset (location)");
                        output = $"{locationName}";
                        repeat = false;
                        break;
                    }
                    else
                    {
                        var newLine = $"{locationName};LID{lCounter}";
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

        #region Carpool Stuff
        public static void AddCarPool() 
        {
            Console.WriteLine("bitte gib den Carpool Namen ein ");
            var carpoolName = CheckUserInput(Console.ReadLine());
            var driver = ChoseDriver();
            

            if (!String.IsNullOrEmpty(driver))
            {
                var passenger = ChosePassenger();

                if (File.ReadAllLines(carPoolDataPath).Length > 0)
                {
                    var newLine = $"\n{carpoolName};{driver};{passenger};CPID{cpCounter}";
                    File.AppendAllText(carPoolDataPath, newLine);
                    Console.WriteLine("Added new Dataset (carPool)");
                }
                else
                {
                    var newLine = $"{carpoolName};{driver};{passenger};CPID{cpCounter}";
                    File.AppendAllText(carPoolDataPath, newLine);
                    Console.WriteLine("Added first Dataset (carPool)");
                }
                cpCounter++;
            }
            else
            {
                Console.WriteLine("Carpool wurde nicht hinzugefügt! Ohne Fahrer fährt sichs schwer!");
            }
        }
        public static void ShowCarPoolData()
        {
            var lines = File.ReadAllLines(carPoolDataPath);
            var driverlines = File.ReadAllLines(personDataPath);
            foreach (var line in lines)
            {
                var splitted = line.Split(';');
                if (line != String.Empty)
                {
                    Console.WriteLine($"CarPool Name: {splitted[0]}");

                    foreach (var entry in driverlines)
                    {
                        var splittedEntry = entry.Split(';');
                        if (splittedEntry[3] == splitted[1])
                        {
                            Console.WriteLine($"Driver: {splittedEntry[0]} {splittedEntry[1]}");
                        }
                    }
                    Console.WriteLine($"Driver ID: {splitted[1]}");

                    foreach (var entry in driverlines) //TODO make it work
                    {
                        var splittedEntry = entry.Split(';');
                        if (splittedEntry[3] == splitted[2])
                        {
                            Console.WriteLine($"Passenger: {splittedEntry[0]} {splittedEntry[1]}");
                        }
                    }
                    Console.WriteLine($"Passenger ID: {splitted[2]}");

                    Console.WriteLine($"Carpool ID: {splitted[3]}");
                    Console.WriteLine("--------------------------------");
                }
            }
        }
        public static void DeleteCarPoolData()
        {
            File.WriteAllText(carPoolDataPath, "");
            cpCounter = 0;
            Console.WriteLine("Daten wurden gelöscht");
        }
        public static string ChoseDriver()
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
                var userInput = CheckUserInput(Console.ReadLine());

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
                    if (CheckUserInput(Console.ReadLine()) == "y")
                    {
                        repeat = false;
                        break;
                    }
                }
                lCounter++;
            }
            return output;
        }
        public static string ChosePassenger()
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

                var userInput = CheckUserInput(Console.ReadLine());
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
                    if (CheckUserInput(Console.ReadLine()) == "y")
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
        #endregion

        #region Helper methods
        public static string CheckUserInput(string userInput)
        {

            if (String.IsNullOrWhiteSpace(userInput))
            {
                return userInput;
            }
            else
            {
                return userInput.Trim(' ');
            }
        }
        #endregion
    }
}