// Konzolos próbaprogram. Windows Terminalban vagy konzolablakban futtasd.
Console.OutputEncoding = System.Text.Encoding.UTF8;

// letéve kurzor ■
// felemelt kurzor □
string drawColor = "fehér";
string drawPickupState = "felemelve";
char drawChar = '#';
int positionX = 3;
int positionY = 3;
string[] drawBoard = new string[7];
for (int i = 0; i < 7; i++)
{
    drawBoard[i] = new string(' ', 7);
}

bool fut = true;

void MainMenu()
{
    Console.Clear();
    Console.WriteLine($"KONZOLOS RAJZOLÓ {"|".PadLeft(8)} RAJZLAP");
    Console.WriteLine("|".PadLeft(25));
    Console.WriteLine($" Karakter választás {{U}} |");
    Console.WriteLine($" Terminál szín v.{{C}} {"|".PadLeft(4)}");
    Console.WriteLine($" Szín választása {{S}} {"|".PadLeft(4)}");
    Console.WriteLine($" Minta betöltése {{L}} {"|".PadLeft(4)}");
    Console.WriteLine($" Ugrás középre {{D}} {"|".PadLeft(6)}");
    //Console.WriteLine($" Nyomtatás {{D}} {"|".PadLeft(6)}");
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
    Console.WriteLine($" Pozíció ({positionX}, {positionY}) {"|".PadLeft(9)}");
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
                drawColor = "fehér";
                pickingColor = false;
                break;
            case ConsoleKey.D2:
                Console.ForegroundColor = ConsoleColor.Red;
                drawColor = "piros";
                pickingColor = false;
                break;
            case ConsoleKey.D3:
                Console.ForegroundColor = ConsoleColor.Yellow;
                drawColor = "sárga";
                pickingColor = false;
                break;
            case ConsoleKey.D4:
                Console.ForegroundColor = ConsoleColor.Magenta;
                drawColor = "magenta";
                pickingColor = false;
                break;
            case ConsoleKey.D5:
                Console.ForegroundColor = ConsoleColor.Green;
                drawColor = "zöld";
                pickingColor = false;
                break;
            case ConsoleKey.D6:
                Console.ForegroundColor = ConsoleColor.Cyan;
                drawColor = "cián";
                pickingColor = false;
                break;
            case ConsoleKey.D7:
                Console.ForegroundColor = ConsoleColor.Blue;
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

//még nincs kész
void CharacterColor()
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
                drawColor = "fehér";
                pickingColor = false;
                break;
            case ConsoleKey.D2:
                Console.ForegroundColor = ConsoleColor.Red;
                drawColor = "piros";
                pickingColor = false;
                break;
            case ConsoleKey.D3:
                Console.ForegroundColor = ConsoleColor.Yellow;
                drawColor = "sárga";
                pickingColor = false;
                break;
            case ConsoleKey.D4:
                Console.ForegroundColor = ConsoleColor.Magenta;
                drawColor = "magenta";
                pickingColor = false;
                break;
            case ConsoleKey.D5:
                Console.ForegroundColor = ConsoleColor.Green;
                drawColor = "zöld";
                pickingColor = false;
                break;
            case ConsoleKey.D6:
                Console.ForegroundColor = ConsoleColor.Cyan;
                drawColor = "cián";
                pickingColor = false;
                break;
            case ConsoleKey.D7:
                Console.ForegroundColor = ConsoleColor.Blue;
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

void PlaceChar(string[] boardToChange, int placeX, int placeY, char drawingChar)
{
    boardToChange[placeY] = boardToChange[placeY].Substring(0, placeX) + drawingChar + boardToChange[placeY].Substring(placeX + 1);
}

void ShowBoard(string[] boardToShow, int startX, int startY)
{
    for (int row = 0; row < 7; row++)
    {
        Console.SetCursorPosition(startX, startY + row);
        Console.Write(boardToShow[row]);
    }
}


void DrawMode(string[] boardInput, char inputDrawingChar)
{
    string billentyu= "";
    int startX = 26;
    int startY = 2;
    int x = 3;
    int y = 3;
    bool penDown = false;
    bool drawing = true;

    Console.CursorVisible = false;
    while (drawing)
    {
        StatusMenu();
        ShowBoard(boardInput, startX, startY);
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
                    PlaceChar(boardInput, x, y, inputDrawingChar);
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
                ShowBoard(drawBoard, 26, 2);
                break;
            case ConsoleKey.X:
                drawing = false;
                fut = false;
                break;
        }

        if (wantsToMove)
        {
            if (newX < 0 || newX > 6 || newY < 0 || newY > 6)
            {
                if (OperatingSystem.IsWindows())
                    Console.Beep(800, 120);
                else
                    Console.Write("\a");
            }
            else
            {
                positionX = x = newX;
                positionY = y = newY;
                if (penDown)
                {
                    PlaceChar(boardInput, x, y, inputDrawingChar);
                }
            }
        }
    }

    ShowBoard(boardInput, startX, startY);
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
            ShowBoard(drawBoard, 26, 2);
            break;
        case ConsoleKey.C:
            ColorMenu();
            MainMenu();
            ShowBoard(drawBoard, 26, 2);
            break;
        case ConsoleKey.S:
            CharacterColor();
            MainMenu();
            ShowBoard(drawBoard, 26, 2);
            break;
        case ConsoleKey.D:
            DrawMode(drawBoard, drawChar);
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
void Nyomda(string[] boardToChange, int centerX, int centerY, char drawingChar, string bilentyu)
{
    if (bilentyu == "f1" || bilentyu == "f2" || bilentyu == "f3")
    {
        int r = 1;
        if (bilentyu == "f2") r = 2;
        if (bilentyu == "f3") r = 3;

        if (centerX < r || centerX > boardToChange[0].Length - 1 - r || centerY < r || centerY > boardToChange.Length - 1 - r)
        {
            Console.Beep(800, 120);
            return;
        }

        for (int d = -r; d <= r; d++)
        {
            PlaceChar(boardToChange, centerX + d, centerY + d, drawingChar); // főátló (\)
            PlaceChar(boardToChange, centerX + d, centerY - d, drawingChar); // mellékátló (/)
        }
    }
    if (bilentyu == "f4" || bilentyu == "f5" || bilentyu == "f6")
    {
        int r = 1;
        if (bilentyu == "f5") r = 2;
        if (bilentyu == "f6") r = 3;

        if (centerX < r || centerX > boardToChange[0].Length - 1 - r || centerY < r || centerY > boardToChange.Length - 1 - r)
        {
            Console.Beep(800, 120);
            return;
        }

        for (int d = -r; d <= r; d++)
        {
            PlaceChar(boardToChange, centerX + d, centerY, drawingChar); // középső sor (-)
            PlaceChar(boardToChange, centerX, centerY + d, drawingChar); // középső oszlop (|)
        }
    }
    if (bilentyu == "f7" || bilentyu == "f8" || bilentyu == "f9")
    {
        int r = 1;
        if (bilentyu == "f8") r = 2;
        if (bilentyu == "f9") r = 3;

        if (centerX < r || centerX > boardToChange[0].Length - 1 - r || centerY < r || centerY > boardToChange.Length - 1 - r)
        {
            Console.Beep(800, 120);
            return;
        }

        for (int d = -r; d <= r; d++)
        {
            PlaceChar(boardToChange, centerX + d, centerY - r, drawingChar); // felső oldal
            PlaceChar(boardToChange, centerX + d, centerY + r, drawingChar); // alsó oldal
            PlaceChar(boardToChange, centerX - r, centerY + d, drawingChar); // bal oldal
            PlaceChar(boardToChange, centerX + r, centerY + d, drawingChar); // jobb oldal
        }
    }
    if (bilentyu == "f10" || bilentyu == "f11" || bilentyu == "f12")
    {
        int r = 1;
        if (bilentyu == "f11") r = 2;
        if (bilentyu == "f12") r = 3;

        if (centerX < r || centerX > boardToChange[0].Length - 1 - r || centerY < r || centerY > boardToChange.Length - 1 - r)
        {
            Console.Beep(800, 120);
            return;
        }

        for (int d = 0; d <= r; d++)
        {
            PlaceChar(boardToChange, centerX + d, centerY - (r - d), drawingChar); // jobb felső oldal
            PlaceChar(boardToChange, centerX + d, centerY + (r - d), drawingChar); // jobb alsó oldal
            PlaceChar(boardToChange, centerX - d, centerY - (r - d), drawingChar); // bal felső oldal
            PlaceChar(boardToChange, centerX - d, centerY + (r - d), drawingChar); // bal alsó oldal
        }
    }
}

Console.SetCursorPosition(0, 11);
Console.WriteLine("A próba véget ért.");
