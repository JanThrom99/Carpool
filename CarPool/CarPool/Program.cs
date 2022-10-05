using System;
using System.IO;
using System.Text.RegularExpressions;

namespace CarPool
{
    internal class Program
    {
        public static string driverDataPath = "C:/010Projects/016Carpool/driverData.csv";
        public static string locationDataPath = "C:/010Projects/016Carpool/locationData.csv";
        public static int dCounter = 0;
        public static int pCounter = 0;
        public static int lCounter = 0;
        public static void Main(string[] args)
        {
            Console.WriteLine(" _____  ___ ____________ _____ _____ _     \r\n/  __ \\/ _ \\| ___ | ___ |  _  |  _  | |    \r\n| /  \\/ /_\\ | |_/ | |_/ | | | | | | | |    \r\n| |   |  _  |    /|  __/| | | | | | | |    \r\n| \\__/| | | | |\\ \\| |   \\ \\_/ \\ \\_/ | |____\r\n \\____\\_| |_\\_| \\_\\_|    \\___/ \\___/\\_____/");
            Console.ReadKey();
            var repeat = true;
            Regex regex = new Regex(@"^\d$");
            do
            {
                Console.Clear();
                Console.WriteLine("was willst du machen?");
                Console.WriteLine("[1] - Fahrer hinzufügen " +
                    "\n[2] - Mitfahrer hinzufügen " +
                    "\n[3] - Daten anzeigen " +
                    "\n[4] - Orte hinzufügen " +
                    "\n[5] - Orte anzeigen lassen" +
                    "\n[6] - Alle Ortsdaten löschen " +
                    "\n[7] - Alle Personen Daten löschen " +
                    "\n[8] - Beenden");

                var userInput = Console.ReadLine();
                if (regex.IsMatch(userInput))
                {
                    switch (userInput)
                    {
                        case ("1"):
                            AddDriver(dCounter);
                            break;
                        case ("2"):
                            AddPassenger(pCounter);
                            break;
                        case ("3"):
                            ShowPersonData();
                            break;
                        case ("4"):
                            AddLocation(lCounter);
                            break;
                        case ("5"):
                            ShowLocationData();
                            break;
                        case ("6"):
                            DeleteLocationData();
                            break;
                        case ("7"):
                            DeletePersonData();
                            break;
                        case ("8"):
                            Console.WriteLine("Das Programm wird jetzt beendet");
                            repeat = false;
                            break;
                        default:
                            Console.WriteLine("valider Input aber keine valide Option");
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

        public static void AddDriver(int i)
        {
            if (File.Exists(driverDataPath))
            {
                Console.WriteLine("bitte gib den Vornamen ein ");
                var name = Console.ReadLine();
                Console.WriteLine("bitte gib den Nachnamen ein ");
                var familyName = Console.ReadLine();
                Console.WriteLine("bitte wähle eine Ortschaft aus");
                var locationName = ChoseLocation();

                if (File.ReadAllLines(driverDataPath).Length > 0)
                {
                    var newLine = $"\n{name};{familyName};{locationName};DID{i}";
                    File.AppendAllText(driverDataPath, newLine);
                    Console.WriteLine("Added new Dataset (driver)");
                    dCounter++;
                }
                else
                {
                    var newLine = $"{name};{familyName};{locationName};DID{i}";
                    File.AppendAllText(driverDataPath, newLine);
                    Console.WriteLine("Added first Dataset (driver)");
                    dCounter++;
                }
            }
        }
        public static void AddPassenger(int i)
        {
            if (File.Exists(driverDataPath))
            {
                Console.WriteLine("bitte gib den Vornamen ein ");
                var name = Console.ReadLine();
                Console.WriteLine("bitte gib den Nachnamen ein ");
                var familyName = Console.ReadLine();
                Console.WriteLine("bitte gib den Ortsnamen ein ");
                var locationName = Console.ReadLine();

                if (File.ReadAllLines(driverDataPath).Length > 0)
                {
                    var newLine = $"\n{name};{familyName};{locationName};PID{i}";
                    File.AppendAllText(driverDataPath, newLine);
                    Console.WriteLine("Added new Dataset (passenger)");
                    pCounter++;
                }
                else
                {
                    var newLine = $"{name};{familyName};{locationName};PID{i}";
                    File.AppendAllText(driverDataPath, newLine);
                    Console.WriteLine("Added first Dataset (passenger)");
                    pCounter++;
                }
            }
        }
        public static void ShowPersonData()
        {
            var lines = File.ReadAllLines(driverDataPath);
            foreach (var line in lines)
            {
                var splitted = line.Split(';');
                Console.WriteLine($"Vorname: {splitted[0]}");
                Console.WriteLine($"Nachname: {splitted[1]}");
                Console.WriteLine($"Ortsname: {splitted[2]}");
                Console.WriteLine($"ID: {splitted[3]}");
                Console.WriteLine("--------------------------------");
            }
        }
        public static void DeletePersonData()
        {
            File.WriteAllText(driverDataPath, "");
            Console.WriteLine("Daten wurden gelöscht");
        }


        public static void AddLocation(int i)
        {

            Console.WriteLine("bitte gib den Ortsnamen ein ");
            var locationName = Console.ReadLine();

            if (File.ReadAllLines(locationDataPath).Length > 0)
            {
                var newLine = $"\n{locationName};LID{i}";
                File.AppendAllText(locationDataPath, newLine);
                Console.WriteLine("Added new Dataset (location)");
                lCounter++;
            }
            else
            {
                var newLine = $"{locationName};LID{i}";
                File.AppendAllText(locationDataPath, newLine);
                Console.WriteLine("Added first Dataset (location)");
                lCounter++;
            }

        }
        public static void ShowLocationData()
        {
            var lines = File.ReadAllLines(locationDataPath);
            foreach (var line in lines)
            {
                var splitted = line.Split(';');
                Console.WriteLine($"Ortsname: {splitted[0]}");
                Console.WriteLine($"ID: {splitted[1]}");
                Console.WriteLine("--------------------------------");
            }
        }
        public static void DeleteLocationData()
        {
            File.WriteAllText(locationDataPath, "");
            Console.WriteLine("Daten wurden gelöscht");
        }

        public static string ChoseLocation()
        {
            var lines = File.ReadAllLines(locationDataPath);
            Console.WriteLine("in welchem Ort wohnst du? (bitte ID eingeben)");
            foreach (var line in lines)
            {
                var splitted = line.Split(';');
                Console.WriteLine($"Ortsname: {splitted[0]} -  ID: {splitted[1]}");
                Console.WriteLine("--------------------------------");
            }
            var userInput = Console.ReadLine();


            var repeat = true;
            while (repeat)
            {
                if (userInput != null)
                {
                    foreach (var line in lines)
                    {
                        var splitted = line.Split(';');
                        if (splitted[1] == userInput)
                        {
                            repeat = false;
                            return splitted[1];
                        }
                        else
                        {
                            Console.WriteLine("der Ort existiert nicht! Bitte fügen sie ihn jetzt hinzu!");
                            var locationName = Console.ReadLine();

                            if (File.ReadAllLines(locationDataPath).Length > 0)
                            {
                                var newLine = $"\n{locationName};LID{lCounter}";
                                File.AppendAllText(locationDataPath, newLine);
                                Console.WriteLine("Added new Dataset (location)");
                                return $"LID{lCounter}"; // 
                                lCounter++;
                            }
                            else
                            {
                                var newLine = $"{locationName};LID{lCounter}";
                                File.AppendAllText(locationDataPath, newLine);
                                Console.WriteLine("Added first Dataset (location)");
                                lCounter++;
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("kein valider input!");
                }
            }

        }
    }
}