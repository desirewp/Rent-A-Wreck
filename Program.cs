using static System.Console;
//Console.CursorVisible = false;
Title = "Rent a Wreck";
//BackgroundColor = ConsoleColor.DarkGray;

bool running = true;

List<Vehichle> vehichles = new List<Vehichle>();
vehichles.Add(new Vehichle("BMW", "SuperSnabb x500", "SUV", "AAA333"));

while (running)
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
}

void ShowAddCarScreen()
{
    WriteLine("---- Registrera fordon ----");
    ReadKey();
}
void ShowCarsScreen()
{
    WriteLine("---- Lista fordon ----");
    // Table header
    WriteLine("| Märke \tModell \t\t\tTyp \tRegistreringsnummer");
    WriteLine("|----------------------------------------------------------------------------|");
    foreach (var car in vehichles)
    {
        WriteLine($"  {car.brand} \t\t{car.model} \t{car.type} \t{car.licensePlateNumber}");
    }
    ReadKey();
}

class Vehichle
{
    public Vehichle(string brand, string model, string type, string licensePlateNumber)
    {
        this.brand = brand;
        this.model = model;
        this.type = type;
        this.licensePlateNumber = licensePlateNumber;
    }

    public string brand;
    public string model;
    public string type;
    public string licensePlateNumber;
}

