# Amőba
## Játékmenet
A két játékos hagyományosan X és O alakú jelekkel (bábúkkal) játszik. A tábla mérete változatos, a mi esetünkben 4 x 4 mezőből álló tábára felváltva teszik le a jeleiket, bármelyik még szabad mezőre. Az nyer, akinek sikerül egy vonalban 4 jelet elhelyeznie, vízsintes, függőleges vagy átlós irányban. Ha elfogynak az üres mezők és senki nyert az előbbi feltétel szerint, akkor a játék döntetlen. Mindig az X-kezd.
## Bemeneti fájlok
-	Minden fájl egy játék állását tárolja mátrix-szerűen. (kivéve a gameStates.txt, mert ez a bemeneti fájlok neveit tartalmazza soronként.
-	Az értékek pontosvesszővel vannak elválasztva.
-	Játékos 1 lépéseit az állapotban ’X’-el jelöljük. A másodikét ’O’-val.
-	Az első sor mindig a játékosok neveit tárolja. (Játékos1;Játékos2)
-	A további sorok a játék állását tartalmazza mátrix-szerűen, az üres cellákat ’_’ karakterrel jelöljük.
-	Minta

```
Józsi;Karesz
X;O;_;_
O;O;X;_
X;_;_;_
_;_;_;_
```

## Feladatmegoldásra vonatkozó információk
-	Megoldását elkészítheti saját osztály definiálása és alkalmazása nélkül is, de úgy az nem lesz teljes értékű.
-	A képernyőre írást igénylő feladatok eredményének megjelenítése előtt írja a képernyőre a feladat sorszámát (például: 4. feladat)!
-	Az egyes feladatokban a kiírásokat a minta szerint készítse el!
-	Az ékezetmentes kiírások is elfogadottak.
-	Tartsa be a nyelv névelnevezési konvencióit!
-	A program megírásakor az állományokban lévő adatok helyes szerkezetét nem kell ellenőriznie, feltételezheti, hogy a rendelkezésre álló adatok a leírtaknak megfelelnek.
-	A megoldást úgy készítse el, hogy az azonos szerkezetű, de tetszőleges bemeneti adatok mellett is helyes eredményt adjon.
-	A feladat forrás mappájában megtalálható txt kiterjeszésű szöveges állományok.
## Konzolos feladatrész
1.	Készítsen konzolos alkalmazást a következő feladatok megoldására, melynek projektjét Amoba néven mentse el!
2.	Készítsen saját osztályt GameState azonosítóval, melynek adattagjai legyenek alkalmasak egy játék állapotának tárolására (két játékos neve és a játék állása) és a további feladatmegoldásra.
3.	Olvassa be és tárolja a forrásállományokban kódolt játékosok neveit és játékaik állását és tárolja el egy olyan adatszerkezetben, ami a további feladatok megoldására alkalmas! A választott adatszerkezet feltöltésekor használja a GameState osztály példányait! Legfeljebb 100 játékos (forrásállomány) lehet. Megoldáshoz felhasználhatja a gameStates.txt szöveges állományt, melyben soronként a feldolgozandó forrásállományok neveit gyűjtöttük ki. Ha csak egy állomány tud beolvasni és tárolni, akkor a minta.txt állománnyal folytassa a feladatok megoldását.
4.	Készítsen StepSigning azonosítóval metódust (függvényt) a GameState osztályba, melynek segítségével a paraméterben átadott pozíciót „megjelöli” a játék állapotát reprezentáló adatszerkezetben.
5.	Készítsen CheckState azonosítóval jellemzőt vagy metódust (függvényt), melynek segítségével ellenőrizheti, játék állapotát a bevezetőben ismertetett módon. A kódtag egész számmal térjen vissza a következőképpen:
-	1:Játékos1 nyert
-	2:Játékos2 nyert
-	0:döntetlen (elfogytak a mezők és nincs nyertes)
6.	Határozza meg és írja ki, hogy a forrásokban szereplő állapotok közül hányszor nyert az első játékos, hányszor a második, hány állapot van, ami döntetlen és hány nincs még teljesen lejátszva.

-Kiíratás példa:
```6. feladat:
    Első játékos 4 esetben nyert.
    Második játékos 3 esetben nyert.
    3 esetben döntetlen eredmény született.
    1 esetben még nincs teljesen lejátszva.
```
# Grafikus feladatrész
7. Készítsen grafikus alkalmazást AmobaGUI néven, melynek segítségével olyan fájlokat tudunk generálni, mint amit a konzolos feladatrészben feldolgozott! A grafikus alkalmazásban a következő feladatokat végezze el:
8. Alakítsa ki a felhasználói felületet a következő minta szerint! Állítsa be az alkalmazás címsorában megjelenő „Amőba” feliratot és a beviteli mező alapértelmezett értékét (minta.txt)! A beviteli mezőben az állomány nevét tudja megadni a mentéshez!
9. Ha a „Mentés” parancsgombra kattintunk akkor mentse el a megadott néven a nézetben szereplő adatokat, állapotot és törölje a korábbi lépéseket. (a fájl és a játékosok neveit nem kell) Ügyeljen rá, hogy a mentés után is mindig az X kezdjen.
10.	A mentés gombra csak akkor legyen engedélyezve, ha már megadtuk a két játékos és a kimeneti fájl nevét.
11.	Mátrix-szerűen jelenítse meg a játékteret.
12. Ha egy üres mezőre kattintunk a játéktáblát szimbolizáló részen, jelenítsük meg a soron következő játékos szimbólumát, mindig az első játékos kezd az ’X’ karakterrel. Ha a második játékos lép akkor legyen a vezérlő tartalma ’O’. Az üres mezők esetén a vezérlő tartalma is legyen üres.

-Ablak minta:

```
Ablak fejléc Amőba, kicsinyítő gomb, teljes ablak gomb, bezárás gomb
label1: 1.Játékos (x)	BeviteliMező1Játékos: Józsi
label2: 2.Játékos (O)	BeviteliMező2Játékos: Karesz
4x4-es kattintható mátrix tábla
1_sor:	 X;O;_;_
2_sor:	O;O;X;_
3_sor:	X;_;_;_
4_sor:	_;_;_;_
label: Fájlnév	BeviteliMezőFájlnév: minta.txt
Button: Mentés
```
