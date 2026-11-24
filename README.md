# Konzolos rajzoló

Nyisd meg a Rajzolo.csproj fájlt a Visual Studióban, majd indítsd a Ctrl+F5 billentyűkkel. Parancssorból, a projekt mappájában: dotnet run. A projekthez .NET 10 SDK kell. A hangpróbához használj Windowsos gépet, Linux-on csak BIOS beep hallható. Az ablak legyen legalább 76 oszlop széles és 23 sor magas.

## Felület

A képernyő bal oldalán a menü- és állapotpanel, jobb oldalán a rajzlap látható.

- **Rajzlap:** 48 × 18 cella. A bal felső cella koordinátája (0, 0), a kezdőpozíció a középpont.
- **Állapotjelző:** az aktuális (x, y) pozíció, a kiválasztott rajzkarakter, a rajzszín és az eszköz állapota (felemelve / letéve).
- **Kurzor:** `□` ha az eszköz felemelt, `■` ha letéve
## Vezérlés

### Főmenü

|Billentyű|Funkció|
|---|---|
|`U`|Rajzkarakter választása|
|`C`|Rajzszín választása|
|`L`|Minta betöltése szövegfájlból|
|`D`|Rajzolás indítása (a rajzvezérlés ekkor aktív)|
|`X`|Kilépés|

A karakter- és a színválasztó listában a számbillentyűkkel (`1`–`7`) lehet választani.

- Karakterek: `#` `@` `:` `;` `?` `!` `█`
- Színek: fehér, piros, sárga, magenta, zöld, cián, kék

### Rajzolás közben

| Billentyű  | Funkció                       |
| ---------- | ----------------------------- |
| Nyilak     | A kurzor mozgatása cellánként |
| Szóköz     | Eszköz felemelése / letétele  |
| `F1`–`F12` | Nyomda (lásd lent)            |
| `M`        | Vissza a főmenübe             |
| `X`        | Kilépés                       |
### Nyomdák
Az alakzat középpontja mindig az aktuális rajzpozíció. Billentyűcsoportonként az első billentyű 3×3-as, a második 5×5-ös, a harmadik 7×7-es mintát helyez el. A nyomda felemelt és letett eszközzel is működik, a kurzort és az eszköz állapotát nem változtatja, és felülírhat korábbi jeleket.

|Billentyűk|Alakzat|Mely cellákat írja?|
|---|---|---|
|`F1` / `F2` / `F3`|X|A két átló|
|`F4` / `F5` / `F6`|Kereszt (+)|Középső sor és oszlop|
|`F7` / `F8` / `F9`|Négyzetkeret|A négy szélső vonal|
|`F10` / `F11` / `F12`|Rombuszkeret|A négy oldalfelező között|

Ha a teljes befoglaló négyzet nem fér rá a rajzlapra, a program nem rajzol semmit, hanem hangjelzést ad.

## Minta betöltése

A főmenüben az `L` billentyű után meg kell adni a fájl nevét. Üres bevitel (Enter) esetén a program a `minta.txt` fájlt tölti be. Relatív útvonalat a program futtatható állományának mappájához képest keres, abszolút útvonal is megadható. A `mégse` beírása visszalép a menübe.

- A betöltés lecseréli az addigi rajzot.
- A fájl első sora a rajzlap bal felső cellájától indul, a további sorok alatta jelennek meg. A szóközök megtartják a minta elrendezését.
- A betöltött karakterek egységesen az aktuális rajzszínt kapják.
- Betöltés után lehet folytatni a rajzolást.

A program a rajz módosítása előtt ellenőrzi a fájlt. Hibás fájl esetén (hiányzik, nem olvasható, üres, legfeljebb 18 sor és 48 karakter széles lehet) hangjelzés és hibaüzenet jön, a korábbi rajz marad, és újra lehet próbálkozni.

## Hibakezelés

Minden kezelt hibánál hangjelzés (Beep) szól
- A rajzlap szélén túli lépésnél a kurzor helyben marad, a rajz változatlan.
- Érvénytelen menüválasztásnál (vagy érvénytelen billentyűnél rajzolás közben) a program jelzi, hogy nincs ilyen opció, és újra lehet próbálkozni.
- Sikertelen fájlbetöltésnél lásd fent.

## Mintafájl

A teszteléshez használt mintafájl: `minta.txt` (a repóban található, a program mappájába másolódik).