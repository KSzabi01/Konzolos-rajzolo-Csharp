// Konzolos próbaprogram. Windows Terminalban vagy konzolablakban futtasd.
Console.OutputEncoding = System.Text.Encoding.UTF8;

string drawColor = "Fehér";
string drawPickupState = "felemelve";

void MainMenu()
{
    Console.Clear();
    Console.WriteLine($"KONZOLOS RAJZOLÓ {"|".PadLeft(8)} RAJZLAP");
    Console.WriteLine("|".PadLeft(25));
    Console.WriteLine($" Karakter választás {{U}} |");
    Console.WriteLine($" Szín választása {{C}} {"|".PadLeft(4)}");
    Console.WriteLine($" Minta betöltése {{L}} {"|".PadLeft(4)}");
    Console.WriteLine($" Ugrás középre {{D}} {"|".PadLeft(6)}");
    Console.WriteLine($" 2. saját funkció {"|".PadLeft(7)}");
    Console.WriteLine("|".PadLeft(25));
    Console.WriteLine($" Kilépés {{X}} {"|".PadLeft(12)}");
    Console.WriteLine("|".PadLeft(25));
    // Console.WriteLine($"Fel/Le: választás {"|".PadLeft(7)}");
}

void StatusMenu()
{
    Console.Clear();
    Console.WriteLine($"KONZOLOS RAJZOLÓ {"|".PadLeft(8)} RAJZLAP");
    Console.WriteLine("|".PadLeft(25));
    Console.WriteLine($" Menü {{M}} {"|".PadLeft(15)}");
    Console.WriteLine($" Kilépés {{X}} {"|".PadLeft(12)}");
    Console.WriteLine("|".PadLeft(25));
    Console.WriteLine($" Pozíció ({"00"}, {"00"}) {"|".PadLeft(7)}");
    Console.WriteLine($" Karakter {"#"} {"|".PadLeft(13)}");
    Console.WriteLine($" Szín {drawColor} {"|".PadLeft(18 - drawColor.Length)}");
    Console.WriteLine($" Eszköz {drawPickupState}{"|".PadLeft(17-drawPickupState.Length)}");
    Console.WriteLine("|".PadLeft(25));
}

void ColorMenu()
{
    Console.Clear();
    Console.WriteLine("Fehér {1}");
    Console.WriteLine("Piros {2}");
    Console.WriteLine("Sárga {3}");
    Console.WriteLine("Magenta {4}");
    Console.WriteLine("Zöld {5}");
    Console.WriteLine("Cián {6}");
    Console.WriteLine("Kék {7}");
    bool pickingColor = true;
    while (pickingColor)
    {
        ConsoleKey colorKey = Console.ReadKey(true).Key;
        switch (colorKey)
        {
            case ConsoleKey.D1:
                Console.ForegroundColor = ConsoleColor.White;
                drawColor = "Fehér";
                pickingColor = false;
                break;
            case ConsoleKey.D2:
                Console.ForegroundColor = ConsoleColor.Red;
                drawColor = "Piros";
                pickingColor = false;
                break;
            case ConsoleKey.D3:
                Console.ForegroundColor = ConsoleColor.Yellow;
                drawColor = "Sárga";
                pickingColor = false;
                break;
            case ConsoleKey.D4:
                Console.ForegroundColor = ConsoleColor.Magenta;
                drawColor = "Magenta";
                pickingColor = false;
                break;
            case ConsoleKey.D5:
                Console.ForegroundColor = ConsoleColor.Green;
                drawColor = "Zöld";
                pickingColor = false;
                break;
            case ConsoleKey.D6:
                Console.ForegroundColor = ConsoleColor.Cyan;
                drawColor = "Cián";
                pickingColor = false;
                break;
            case ConsoleKey.D7:
                Console.ForegroundColor = ConsoleColor.Blue;
                drawColor = "Kék";
                pickingColor = false;
                break;
            default:
                Console.SetCursorPosition(0, 11);
                Console.WriteLine("Nincs ilyen opció");
                if (OperatingSystem.IsWindows())
                    Console.Beep(800, 120);
                else
                    Console.Write("\a");
                break;
        }
    }
}

if (Console.IsInputRedirected || Console.IsOutputRedirected)
{
    Console.WriteLine("A próbához nyiss interaktív konzolablakot.");
    return;
}

if (Console.WindowWidth < 76 || Console.WindowHeight < 23)
{
    Console.WriteLine("Nagyítsd a konzolablakot legalább 76 oszloposra és 23 sorosra.");
    return;
}
MainMenu();
// StatusMenu();
// Console.WriteLine("Konzolpróba | F1: színes jel | B: hang | L: fájl | Esc: kilépés");
// Console.WriteLine("Az alsó sor az utolsó leütött billentyűt mutatja.");
bool fut = true;
while (fut)
{
    ConsoleKey billentyu = Console.ReadKey(true).Key;
    // Console.SetCursorPosition(0, 20);
    // Console.Write(("Billentyű: " + billentyu).PadRight(75));

    switch (billentyu)
    {
        case ConsoleKey.U:
            break;
        case ConsoleKey.C:
            ColorMenu();
            MainMenu();
            break;
        case ConsoleKey.K:
            Console.SetCursorPosition(26, 4); // oszlop, majd sor
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write('#');
            Console.ResetColor();
            break;
        case ConsoleKey.B:
            if (OperatingSystem.IsWindows())
                Console.Beep(800, 120);
            else
                Console.Write("\a");
            break;
        case ConsoleKey.L:
            string utvonal = Path.Combine(AppContext.BaseDirectory, "minta.txt");
            if (File.Exists(utvonal))
            {
                string[] sorok = File.ReadAllLines(utvonal);
                for (int i = 0; i < sorok.Length && i < 5; i++)
                {
                    Console.SetCursorPosition(27, 3 + i);
                    Console.Write(sorok[i]);
                }
            }
            else
            {
                Console.SetCursorPosition(26, 7);
                Console.Write("A mintafájl nem található.");
            }
            break;
        case ConsoleKey.X:
            fut = false;
            break;
        default:
            Console.SetCursorPosition(0, 11);
            Console.WriteLine("Nincs ilyen opció");
            if (OperatingSystem.IsWindows())
                Console.Beep(800, 120);
            else
                Console.Write("\a");
            break;
    }
}

Console.SetCursorPosition(0, 11);
Console.WriteLine("A próba véget ért.");
