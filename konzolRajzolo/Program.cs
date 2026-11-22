// Konzolos próbaprogram. Windows Terminalban vagy konzolablakban futtasd.
Console.OutputEncoding = System.Text.Encoding.UTF8;

string drawColor = "cián";
string drawPickupState = "felemelve";

void FoMenu()
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

void RajzMenu()
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

FoMenu();
RajzMenu();
Console.WriteLine("Konzolpróba | F1: színes jel | B: hang | L: fájl | Esc: kilépés");
Console.WriteLine("Az alsó sor az utolsó leütött billentyűt mutatja.");
bool fut = true;
while (fut)
{
    ConsoleKey billentyu = Console.ReadKey(true).Key;
    Console.SetCursorPosition(0, 20);
    Console.Write(("Billentyű: " + billentyu).PadRight(75));

    switch (billentyu)
    {
        case ConsoleKey.F1:
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
                    Console.SetCursorPosition(26, 7 + i);
                    Console.Write(sorok[i]);
                }
            }
            else
            {
                Console.SetCursorPosition(26, 7);
                Console.Write("A mintafájl nem található.");
            }
            break;
        case ConsoleKey.Escape:
            fut = false;
            break;
    }
}

Console.SetCursorPosition(0, 21);
Console.WriteLine("A próba véget ért.");
