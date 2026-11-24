// Konzolos próbaprogram. Windows Terminalban vagy konzolablakban futtasd.
Console.OutputEncoding = System.Text.Encoding.UTF8;

// letéve kurzor ■
// felemelt kurzor □

Console.CursorVisible = false;


const int RajzlapSzelesseg = 48;
const int RajzlapMagassag = 18;

string drawColor = "fehér";
ConsoleColor drawConsoleColor = ConsoleColor.White;
string drawPickupState = "felemelve";
char drawChar = '#';
int positionX = RajzlapSzelesseg / 2;
int positionY = RajzlapMagassag / 2;
string uzenet = "";

string[] drawBoard = new string[RajzlapMagassag];

ConsoleColor[] drawColors = new ConsoleColor[RajzlapSzelesseg * RajzlapMagassag];
TorolRajzlapot(drawBoard, drawColors);

bool fut = true;

void MainMenu()
{
    Console.Clear();
    Console.WriteLine($"KONZOLOS RAJZOLÓ {"|".PadLeft(8)} RAJZLAP");
    Console.WriteLine("|".PadLeft(25));
    Console.WriteLine($" Karakter választás {{U}} |");
    Console.WriteLine($" Szín választása {{C}} {"|".PadLeft(4)}");
    Console.WriteLine($" Minta betöltése {{L}} {"|".PadLeft(4)}");
    Console.WriteLine($" Rajzolás {{D}} {"|".PadLeft(11)}");
    Console.WriteLine($" 2 saját funkció {"|".PadLeft(8)}");
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
    string positionText = $" Pozíció ({positionX}, {positionY})";
    Console.WriteLine(positionText + "|".PadLeft(25 - positionText.Length));
    Console.WriteLine($" Karakter {drawChar} {"|".PadLeft(13)}");
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
                drawConsoleColor = ConsoleColor.White;
                drawColor = "fehér";
                pickingColor = false;
                break;
            case ConsoleKey.D2:
                drawConsoleColor = ConsoleColor.Red;
                drawColor = "piros";
                pickingColor = false;
                break;
            case ConsoleKey.D3:
                drawConsoleColor = ConsoleColor.Yellow;
                drawColor = "sárga";
                pickingColor = false;
                break;
            case ConsoleKey.D4:
                drawConsoleColor = ConsoleColor.Magenta;
                drawColor = "magenta";
                pickingColor = false;
                break;
            case ConsoleKey.D5:
                drawConsoleColor = ConsoleColor.Green;
                drawColor = "zöld";
                pickingColor = false;
                break;
            case ConsoleKey.D6:
                drawConsoleColor = ConsoleColor.Cyan;
                drawColor = "cián";
                pickingColor = false;
                break;
            case ConsoleKey.D7:
                drawConsoleColor = ConsoleColor.Blue;
                drawColor = "kék";
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

void CharacterMenu()
{
    Console.Clear();
    Console.WriteLine("# {1}");
    Console.WriteLine("@ {2}");
    Console.WriteLine(": {3}");
    Console.WriteLine("; {4}");
    Console.WriteLine("? {5}");
    Console.WriteLine("! {6}");
    Console.WriteLine("█ {7}");
    bool pickingChar = true;
    while (pickingChar)
    {
        ConsoleKey colorKey = Console.ReadKey(true).Key;
        switch (colorKey)
        {
            case ConsoleKey.D1:
                drawChar = '#';
                pickingChar = false;
                break;
            case ConsoleKey.D2:
                drawChar = '@';
                pickingChar = false;
                break;
            case ConsoleKey.D3:
                drawChar = ':';
                pickingChar = false;
                break;
            case ConsoleKey.D4:
                drawChar = ';';
                pickingChar = false;
                break;
            case ConsoleKey.D5:
                drawChar = '?';
                pickingChar = false;
                break;
            case ConsoleKey.D6:
                drawChar = '!';
                pickingChar = false;
                break;
            case ConsoleKey.D7:
                drawChar = '█';
                pickingChar = false;
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

void PlaceChar(string[] boardToChange, ConsoleColor[] colorsToChange, int placeX, int placeY, char drawingChar, ConsoleColor drawingColor)
{
    boardToChange[placeY] = boardToChange[placeY].Substring(0, placeX) + drawingChar + boardToChange[placeY].Substring(placeX + 1);
    colorsToChange[placeY * RajzlapSzelesseg + placeX] = drawingColor;
}

void ShowBoard(string[] boardToShow, ConsoleColor[] colorsToShow, int startX, int startY)
{
    for (int row = 0; row < RajzlapMagassag; row++)
    {
        Console.SetCursorPosition(startX, startY + row);
        for (int col = 0; col < RajzlapSzelesseg; col++)
        {
            Console.ForegroundColor = colorsToShow[row * RajzlapSzelesseg + col];
            Console.Write(boardToShow[row][col]);
        }
    }
    Console.ResetColor();
}

void TorolRajzlapot(string[] boardToClear, ConsoleColor[] colorsToClear)
{
    for (int y = 0; y < RajzlapMagassag; y++)
    {
        boardToClear[y] = new string(' ', RajzlapSzelesseg);
        for (int x = 0; x < RajzlapSzelesseg; x++)
        {
            colorsToClear[y * RajzlapSzelesseg + x] = ConsoleColor.Gray;
        }
    }
}

void Hiba(string szoveg)
{
    if (OperatingSystem.IsWindows())
        Console.Beep(800, 120);
    else
        Console.Write("\a");

    uzenet = "Hiba: " + szoveg;
}

void Nyomda(string[] boardToChange, int centerX, int centerY, char drawingChar, string bilentyu)
{
    if (bilentyu == "f1" || bilentyu == "f2" || bilentyu == "f3")
    {
        int r = 1;
        if (bilentyu == "f2") r = 2;
        if (bilentyu == "f3") r = 3;

        if (centerX < r || centerX > boardToChange[0].Length - 1 - r || centerY < r || centerY > boardToChange.Length - 1 - r)
        {
            if (OperatingSystem.IsWindows())
            {
                Console.Beep(800, 120);
                return;
            }
            Console.Write("\\a");
            return;
        }

        for (int d = -r; d <= r; d++)
        {
            PlaceChar(boardToChange, drawColors, centerX + d, centerY + d, drawingChar, drawConsoleColor); // főátló (\)
            PlaceChar(boardToChange, drawColors, centerX + d, centerY - d, drawingChar, drawConsoleColor); // mellékátló (/)
        }
    }
    if (bilentyu == "f4" || bilentyu == "f5" || bilentyu == "f6")
    {
        int r = 1;
        if (bilentyu == "f5") r = 2;
        if (bilentyu == "f6") r = 3;

        if (centerX < r || centerX > boardToChange[0].Length - 1 - r || centerY < r || centerY > boardToChange.Length - 1 - r)
        {
            if (OperatingSystem.IsWindows())
            {
                Console.Beep(800, 120);
                return;
            }
            Console.Write("\\a");
            return;
        }

        for (int d = -r; d <= r; d++)
        {
            PlaceChar(boardToChange, drawColors, centerX + d, centerY, drawingChar, drawConsoleColor); // középső sor (-)
            PlaceChar(boardToChange, drawColors, centerX, centerY + d, drawingChar, drawConsoleColor); // középső oszlop (|)
        }
    }
    if (bilentyu == "f7" || bilentyu == "f8" || bilentyu == "f9")
    {
        int r = 1;
        if (bilentyu == "f8") r = 2;
        if (bilentyu == "f9") r = 3;

        if (centerX < r || centerX > boardToChange[0].Length - 1 - r || centerY < r || centerY > boardToChange.Length - 1 - r)
        {
            if (OperatingSystem.IsWindows())
            {
                Console.Beep(800, 120);
                return;
            }
            Console.Write("\\a");
            return;
        }

        for (int d = -r; d <= r; d++)
        {
            PlaceChar(boardToChange, drawColors, centerX + d, centerY - r, drawingChar, drawConsoleColor); // felső oldal
            PlaceChar(boardToChange, drawColors, centerX + d, centerY + r, drawingChar, drawConsoleColor); // alsó oldal
            PlaceChar(boardToChange, drawColors, centerX - r, centerY + d, drawingChar, drawConsoleColor); // bal oldal
            PlaceChar(boardToChange, drawColors, centerX + r, centerY + d, drawingChar, drawConsoleColor); // jobb oldal
        }
    }
    if (bilentyu == "f10" || bilentyu == "f11" || bilentyu == "f12")
    {
        int r = 1;
        if (bilentyu == "f11") r = 2;
        if (bilentyu == "f12") r = 3;

        if (centerX < r || centerX > boardToChange[0].Length - 1 - r || centerY < r || centerY > boardToChange.Length - 1 - r)
        {
            if (OperatingSystem.IsWindows())
            {
                Console.Beep(800, 120);
                return;
            }
            Console.Write("\\a");
            return;
        }

        for (int d = 0; d <= r; d++)
        {
            PlaceChar(boardToChange, drawColors, centerX + d, centerY - (r - d), drawingChar, drawConsoleColor); // jobb felső oldal
            PlaceChar(boardToChange, drawColors, centerX + d, centerY + (r - d), drawingChar, drawConsoleColor); // jobb alsó oldal
            PlaceChar(boardToChange, drawColors, centerX - d, centerY - (r - d), drawingChar, drawConsoleColor); // bal felső oldal
            PlaceChar(boardToChange, drawColors, centerX - d, centerY + (r - d), drawingChar, drawConsoleColor); // bal alsó oldal
        }
    }
}

void LoadFile()
{
    Console.Clear();
    Console.CursorVisible = true; // a gépeléshez látszódjon a kurzor
    uzenet = "";

    while (true)
    {
        if (uzenet != "")
            Console.WriteLine(uzenet); // az előző próbálkozás hibája

        Console.Write("\nFájlnév (Enter: minta.txt, 'mégse'): ");
        string? nev = Console.ReadLine()?.Trim();
        if (string.Equals(nev, "mégse", StringComparison.OrdinalIgnoreCase))
            break;

        string fajlNev = string.IsNullOrEmpty(nev) ? "minta.txt" : nev;
        string path = Path.IsPathRooted(fajlNev)
            ? fajlNev
            : Path.Combine(AppContext.BaseDirectory, fajlNev);

        if (!File.Exists(path))
        {
            Hiba($"Nincs ilyen fájl ({path})");
            continue;
        }

        string[] sorok;
        try
        {
            sorok = File.ReadAllLines(path, System.Text.Encoding.UTF8);
        }
        catch (Exception ex)
        {
            Hiba($"Nem olvasható: {ex.Message}");
            continue;
        }

        if (sorok.Length == 0)
        {
            Hiba("A fájl üres");
            continue;
        }

        if (sorok.Length > RajzlapMagassag)
        {
            Hiba("Nem fér el (túl sok sor)");
            continue;
        }

        bool tulSzeles = false;
        foreach (string sor in sorok)
        {
            if (sor.Length > RajzlapSzelesseg)
            {
                tulSzeles = true;
                break;
            }
        }

        if (tulSzeles)
        {
            Hiba("Nem fér el (túl hosszú sor)");
            continue;
        }

        // Idáig csak ellenőriztünk, a rajzlap még változatlan. Innen jön a tényleges csere.
        TorolRajzlapot(drawBoard, drawColors);

        for (int y = 0; y < sorok.Length; y++)
        {
            for (int x = 0; x < sorok[y].Length; x++)
            {
                char c = sorok[y][x];
                if (c != ' ')
                {
                    // minden betöltött karakter ugyanazt az aktuális színt kapja
                    PlaceChar(drawBoard, drawColors, x, y, c, drawConsoleColor);
                }
            }
        }

        break;
    }

    uzenet = "";
    Console.CursorVisible = false;
}

void DrawMode(string[] boardInput, ConsoleColor[] colorsInput, char inputDrawingChar, ConsoleColor inputDrawingColor)
{
    string billentyu = "";
    int startX = 26;
    int startY = 2;
    int x = RajzlapSzelesseg / 2;
    int y = RajzlapMagassag / 2;
    bool penDown = false;
    bool drawing = true;

    positionX = x;
    positionY = y;
    drawPickupState = "felemelve";
    uzenet = "";

    while (drawing)
    {
        StatusMenu();
        ShowBoard(boardInput, colorsInput, startX, startY);

        Console.SetCursorPosition(0, 20);
        Console.Write("Nyilak: mozgás  Szóköz: eszköz  F1-F12: nyomda");
        Console.SetCursorPosition(0, 21);
        Console.Write(uzenet);

        Console.SetCursorPosition(startX + x, startY + y);
        if (penDown)
        {
            Console.Write('■');
        }
        else
        {
            Console.Write('□');
        }

        ConsoleKey key = Console.ReadKey(true).Key;
        uzenet = "";

        int newX = x;
        int newY = y;
        bool wantsToMove = false;

        switch (key)
        {
            case ConsoleKey.UpArrow:
                newY = y - 1;
                wantsToMove = true;
                break;
            case ConsoleKey.DownArrow:
                newY = y + 1;
                wantsToMove = true;
                break;
            case ConsoleKey.LeftArrow:
                newX = x - 1;
                wantsToMove = true;
                break;
            case ConsoleKey.RightArrow:
                newX = x + 1;
                wantsToMove = true;
                break;
            case ConsoleKey.Spacebar:
                if (penDown)
                {
                    penDown = false;
                    drawPickupState = "felemelve";
                }
                else
                {
                    penDown = true;
                    drawPickupState = "letéve";
                    PlaceChar(boardInput, colorsInput, x, y, inputDrawingChar, inputDrawingColor);
                }
                break;
            //nyomda
            case ConsoleKey.F1:
                billentyu = "f1";
                Nyomda(boardInput, x, y, inputDrawingChar, billentyu);
                break;
            case ConsoleKey.F2:
                billentyu = "f2";
                Nyomda(boardInput, x, y, inputDrawingChar, billentyu);
                break;
            case ConsoleKey.F3:
                billentyu = "f3";
                Nyomda(boardInput, x, y, inputDrawingChar, billentyu);
                break;
            case ConsoleKey.F4:
                billentyu = "f4";
                Nyomda(boardInput, x, y, inputDrawingChar, billentyu);
                break;
            case ConsoleKey.F5:
                billentyu = "f5";
                Nyomda(boardInput, x, y, inputDrawingChar, billentyu);
                break;
            case ConsoleKey.F6:
                billentyu = "f6";
                Nyomda(boardInput, x, y, inputDrawingChar, billentyu);
                break;
            case ConsoleKey.F7:
                billentyu = "f7";
                Nyomda(boardInput, x, y, inputDrawingChar, billentyu);
                break;
            case ConsoleKey.F8:
                billentyu = "f8";
                Nyomda(boardInput, x, y, inputDrawingChar, billentyu);
                break;
            case ConsoleKey.F9:
                billentyu = "f9";
                Nyomda(boardInput, x, y, inputDrawingChar, billentyu);
                break;
            case ConsoleKey.F10:
                billentyu = "f10";
                Nyomda(boardInput, x, y, inputDrawingChar, billentyu);
                break;
            case ConsoleKey.F11:
                billentyu = "f11";
                Nyomda(boardInput, x, y, inputDrawingChar, billentyu);
                break;
            case ConsoleKey.F12:
                billentyu = "f12";
                Nyomda(boardInput, x, y, inputDrawingChar, billentyu);
                break;

            case ConsoleKey.M:
                drawing = false;
                MainMenu();
                ShowBoard(drawBoard, drawColors, 26, 2);
                break;
            case ConsoleKey.X:
                drawing = false;
                fut = false;
                break;
            default:
                Hiba("Csak nyilak, szóköz, F1-F12, M vagy X");
                break;
        }

        if (wantsToMove)
        {
            if (newX < 0 || newX >= RajzlapSzelesseg || newY < 0 || newY >= RajzlapMagassag)
            {
                Hiba("Szélen túl"); // Beep + üzenet, a kurzor és a rajz változatlan marad
            }
            else
            {
                positionX = x = newX;
                positionY = y = newY;
                if (penDown)
                {
                    PlaceChar(boardInput, colorsInput, x, y, inputDrawingChar, inputDrawingColor);
                }
            }
        }
    }

    ShowBoard(boardInput, colorsInput, startX, startY);
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


while (fut)
{
    ConsoleKey billentyu = Console.ReadKey(true).Key;
    // Console.SetCursorPosition(0, 20);
    // Console.Write(("Billentyű: " + billentyu).PadRight(75));

    switch (billentyu)
    {
        case ConsoleKey.U:
            CharacterMenu();
            MainMenu();
            ShowBoard(drawBoard, drawColors, 26, 2);
            break;
        case ConsoleKey.C:
            ColorMenu();
            MainMenu();
            ShowBoard(drawBoard, drawColors, 26, 2);
            break;
        case ConsoleKey.D:
            DrawMode(drawBoard, drawColors, drawChar, drawConsoleColor);
            break;
        case ConsoleKey.B:
            if (OperatingSystem.IsWindows())
                Console.Beep(800, 120);
            else
                Console.Write("\a");
            break;
        case ConsoleKey.L:
            LoadFile();
            MainMenu();
            ShowBoard(drawBoard, drawColors, 26, 2);
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