using static System.Console;
Title = "Rent a Wreck";

/*--------Start data---------*/
//Skapar en tom lista att lagra foron i
List<Vehichle> vehichles = new List<Vehichle>();

//Skapar upp flera bilar av typen Vehichle
Vehichle car1 = new Vehichle("BMW", "SuperSnabb x", VehicleType.Kombi, "AAA333");
Vehichle car2 = new Vehichle("Volvo", "Krocktestaren", VehicleType.SUV, "BBB112");
Vehichle car3 = new Vehichle("Saab", "Meh a2007", VehicleType.Sedan, "GGGQQQ");

//Lägger till alla bilar i listan
vehichles.Add(car1);
vehichles.Add(car2);
vehichles.Add(car3);
/*-------------------------*/

bool running = true;
ShowMainMenu();

void ShowMainMenu()//Visar huvudmenyn
{
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

void ShowAddCarScreen() //Visar skärmen där användaren kan lägga till nytt fordon
{
    WriteLine("--------------------------Registrera fordon---------------------------------");
    Write("Märke: ");
    string inputBrand = ReadLine();

    Write("Modell: ");
    string inputModel = ReadLine();

    VehicleType inputEnumType;
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
        Clear();
        WriteLine("Fordon registrerat");
        Thread.Sleep(2000);
        Clear();
    }
}
void ShowCarsScreen() //Visar skärmen där användaren kan se alla registerade fordon
{
    WriteLine("----------------------------Lista fordon------------------------------------");
    WriteLine(" Märke \tModell \t\t\tTyp \tRegistreringsnummer");
    WriteLine("----------------------------------------------------------------------------");
    foreach (var car in vehichles)
    {
        WriteLine($" {car.GetBrand()} \t{car.GetModel()} \t\t{car.GetType()} \t{car.GetLicensePlateNumber()}");
    }
    ReadKey();
}

public enum VehicleType //Lägger till de olika alternativen för enum
{
    Kombi,
    Sedan,
    SUV
}

class Vehichle //Klass för bilar innehåller metoder för att visa och uppdatera
{
    public Vehichle(string brand, string model, VehicleType type, string licensePlateNumber)//Constructor
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

