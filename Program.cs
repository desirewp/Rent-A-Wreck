using static System.Console;

namespace RentAWreck
{
    public enum VehicleType //Lägger till de olika alternativen för enum
    {
        Kombi,
        Sedan,
        SUV
    }

    class Vehicle //Klass för bilar innehåller metoder för att visa och uppdatera
    {
        public Vehicle(string brand, string model, VehicleType type, string licensePlateNumber)//Constructor
        {
            this.brand = brand;
            this.model = model;
            this.type = type;
            this.licensePlateNumber = licensePlateNumber;
        }

        private string brand;
        private string model;
        private VehicleType type;
        private string licensePlateNumber;

        public string GetBrand()
        {
            return brand;
        }

        public void SetBrand(string newBrand)
        {
            brand = newBrand;
        }

        public string GetModel()
        {
            return model;
        }

        public void SetModel(string newModel)
        {
            model = newModel;
        }

        public VehicleType GetType()
        {
            return type;
        }

        public void SetType(VehicleType newType)
        {
            type = newType;
        }

        public string GetLicensePlateNumber()
        {
            return licensePlateNumber;
        }

        public void SetLicensePlateNumber(string newLicensePlateNumber)
        {
            licensePlateNumber = newLicensePlateNumber;
        }

    }

    class Program
    {
        //Skapar en tom lista att lagra foron i
        static List<Vehicle> vehicles = new List<Vehicle>();


        static void Main()
        {
            Title = "Rent a Wreck";
            InitializeExampleData(); // Skapar test data
            ShowMainMenu();
        }

        static void ShowMainMenu()//Visar huvudmenyn
        {
            bool running = true;
            do
            {
                Clear();
                WriteLine("[1] Registrera fordon \n[2] Lista fordon \n[3] Avsluta");
                ConsoleKeyInfo selected = Console.ReadKey();

                if (selected.Key == ConsoleKey.D1 || selected.Key == ConsoleKey.NumPad1)
                {
                    Clear();
                    ShowAddCarScreen();
                }
                if (selected.Key == ConsoleKey.D2 || selected.Key == ConsoleKey.NumPad2)
                {
                    Clear();
                    ShowCarsScreen();
                }
                if (selected.Key == ConsoleKey.D3 || selected.Key == ConsoleKey.NumPad3)
                {
                    running = false;

                }
            } while (running); //testar om running fortfarande är true ananrs avslutas programmet

        }

        static void ShowAddCarScreen() //Visar skärmen där användaren kan lägga till nytt fordon
        {
            WriteLine("--------------------------Registrera fordon---------------------------------");
            Write("Märke: ");
            string inputBrand = ReadLine();

            Write("Modell: ");
            string inputModel = ReadLine();

            VehicleType inputEnumType = VehicleType.Kombi; //Standard värde
            bool inCorrectEnumInput = true; //Så länge denna loop ej har fått ett giltigt enum från användaren så fortsätter den att fråga
            do
            {
                Write("Typ (Kombi, Sedan, SUV): ");
                string inputType = ReadLine();
                if (Enum.TryParse(inputType, out VehicleType selectedType))
                {
                    inputEnumType = selectedType;
                    inCorrectEnumInput = false;
                }
                else
                {
                    WriteLine("Ej giltig fordonstyp.");
                    Write("Välj någon av alternativen Kombi, Sedan eller SUV: ");
                }
            } while (inCorrectEnumInput);

            Write("Registreringsnummer: ");
            string inputLicenseplateNumber = ReadLine();

            ConsoleKeyInfo saveNewCar = ReadKey();
            if (saveNewCar.Key == ConsoleKey.Enter)
            {
                SaveNewVehicle(inputBrand, inputModel, inputEnumType, inputLicenseplateNumber);
                Clear();
                WriteLine("Fordon registrerat");
                Thread.Sleep(2000);
                Clear();
            }
            //if (saveNewCar.Key == ConsoleKey.Escape) Clear(); 
        }
        static void ShowCarsScreen() //Visar skärmen där användaren kan se alla registerade fordon
        {
            WriteLine("----------------------------Lista fordon------------------------------------");
            WriteLine(" Märke \tModell \t\t\tTyp \tRegistreringsnummer");
            WriteLine("----------------------------------------------------------------------------");
            foreach (var car in vehicles)
            {
                WriteLine($" {car.GetBrand()} \t{car.GetModel()} \t\t{car.GetType()} \t{car.GetLicensePlateNumber()}");
            }
            ReadKey();
        }

        static void SaveNewVehicle(string inputBrand, string inputModel, VehicleType inputType, string inputLicenseplateNumber)
        {
            vehicles.Add(new Vehicle(inputBrand, inputModel, inputType, inputLicenseplateNumber));
        }


        static void InitializeExampleData()
        {
            Vehicle car1 = new Vehicle("BMW", "SuperSnabb x", VehicleType.Kombi, "AAA333");
            Vehicle car2 = new Vehicle("Volvo", "Krocktestaren", VehicleType.SUV, "BBB112");
            Vehicle car3 = new Vehicle("Saab", "Meh a2007", VehicleType.Sedan, "GGGQQQ");

            vehicles.Add(car1);
            vehicles.Add(car2);
            vehicles.Add(car3);
        }
    }
}

