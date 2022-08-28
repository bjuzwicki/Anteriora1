using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Anteriora
{
    public partial class Osada : Form
    {
        public Poczatek o;

        //budynki w osadzie

        public Budowle tartak1;
        public Budowle tartak2;
        public Budowle kamieniolom1;
        public Budowle kamieniolom2;
        public Budowle kwateraRybacka;
        public Budowle chataMaga;
        public Budowle chatkaRolnika;
        public Budowle hodowla;
        public Budowle studnia;
        
        public Budowle targowisko;
        public Budowle most;
        public Budowle mur;
        public Budowle koszary;
        public Budowle budynekMieszkalny;
        public Budowle kuznia;

        //budynki w lodowej krainie

        public Budowle warsztatLK;
        public Budowle kwateraRybackaLK1;
        public Budowle kwateraRybackaLK2;
        public Budowle studniaLK1;
        public Budowle studniaLK2;
        public Budowle budynekMieszkalnyLK;

        //budynki w osadzie goblinów

        public Budowle kopalniaKamienia;
        public Budowle kopalniaRudyZelaza1;
        public Budowle kopalniaRudyZelaza2;

        public List<Budowle> budynki = new List<Budowle>();
        public List<Materialy> surowce = new List<Materialy>();

        public Przeciwnicy goblin;
        public Przeciwnicy goblin2;
        public Przeciwnicy goblin3;
        public Przeciwnicy goblin4;
        public Przeciwnicy goblin5;
        public Przeciwnicy goblin6;
        public Przeciwnicy goblin7;
        public Przeciwnicy ork;
        public Przeciwnicy nietoperzDuzy;
        public Przeciwnicy nietoperzMaly;
        public Przeciwnicy robak;
        public Przeciwnicy wazOgnisty;
        public Przeciwnicy wazJadowity;
        public Przeciwnicy brak;

        public ObszaryInstancji osadaGoblinow1;
        public ObszaryInstancji osadaGoblinow2;
        public ObszaryInstancji osadaGoblinow3;
        public ObszaryInstancji osadaGoblinow4;
        public ObszaryInstancji osadaGoblinow5;
        public ObszaryInstancji osadaGoblinow6;
        public ObszaryInstancji osadaGoblinow7;
        public ObszaryInstancji osadaGoblinow8;

        public Instancje osadaGoblinow;
        public Instancje jaskiniaWezy;
        public Instancje lodowaKraina;
        //public Instancje zagadka = new Instancje();

        public Mieszkancy mieszkancy = new Mieszkancy();

        public Materialy wood;
        public Materialy hay;
        public Materialy stone;
        public Materialy food;
        public Materialy water;
        public Materialy skin;
        public Materialy gold;
        public Materialy ironOre;
        public Materialy obsidianOre;
        public Materialy wool;
        public Materialy iron;
        public Materialy obsidian;
        public Materialy leatherBelt;
        public Materialy pieceOfWood;

        public Uzbrojenie skorzanaZbroja;
        public Uzbrojenie skorzaneSpodnie;
        public Uzbrojenie skorzanyHelm;
        public Uzbrojenie skorzaneButy;
        public Uzbrojenie zelaznaZbroja;
        public Uzbrojenie zelazneSpodnie;
        public Uzbrojenie zelaznyHelm;
        public Uzbrojenie zelazneButy;
        public Uzbrojenie obsydianowaZbroja;
        public Uzbrojenie obsydianoweSpodnie;
        public Uzbrojenie obsydianowyHelm;
        public Uzbrojenie obsydianoweButy;
        public Uzbrojenie zelaznaTarcza;
        public Uzbrojenie obsydianowaTarcza;

        public Bronie kamiennyMiecz;                // kawalekDrewna 0, skora 1, kamien 2, drewno 3, zelazo 4, obsydian 5
        public Bronie zelaznyMiecz;                   // rudaZelaza 6, rudaObsydianu 7, welna 8, skorzanyPasek 9
        public Bronie obsydianowyMiecz;
        public Bronie luk;

        public Inne ubraniaMieszkancow;
        public Inne lozko;

        public JednostkiGracza zwiadowca;
        public JednostkiGracza piechur;
        public JednostkiGracza lucznik;
        public JednostkiGracza rycerz;
        public JednostkiGracza czarnyRycerz;
        public JednostkiGracza czarnyLucznik;

        public Budowle magazyn;

        public int i, j; // zmienne związane ze sprawdzaniem przepełnienia magazynu
        public int czasBudowy;
        public string notatkaZwiadowcy;
        public string zapisDoDziennika;
        public int zwiadowcaCzas;
        public int czasDoZjedzenia;
        public int czasDoPobraniaPodatkow;
        public string nazwaBudowliBudowa;
        public string nazwaBudowliUlepszenie;

        public Random losowa = new Random();

        public Osada(Poczatek c)
        {
            o = c;
            InitializeComponent();

            pictureBoxGraczPart5.BackgroundImage = Character.pictureUp;

            mieszkancy = new Mieszkancy();

            wood = new Materialy(2000 + o.woodQuantity);
            hay = new Materialy(2000 + o.hayQuantity);
            stone = new Materialy(2000 + o.stoneQuantiy);
            food = new Materialy(2000 + o.foodQuantity);
            water = new Materialy(2000);
            skin = new Materialy(0);
            gold = new Materialy(100);
            ironOre = new Materialy(100);
            obsidianOre = new Materialy(100);
            wool = new Materialy(24);
            iron = new Materialy(24);
            obsidian = new Materialy(24);
            leatherBelt = new Materialy(24);
            pieceOfWood = new Materialy(24);

            tartak1 = new Budowle("pierwszy tartak", 1);
            tartak2 = new Budowle("drugi tartak", 1);
            kamieniolom1 = new Budowle("pierwszy kamieniołom", 2);
            kamieniolom2 = new Budowle("drugi kamieniołom", 2);
            kwateraRybacka = new Budowle("kwatera rybacka", 2);
            chataMaga = new Budowle("chata maga", 1);
            chatkaRolnika = new Budowle("chatka rolnika", 3);
            hodowla = new Budowle("hodowla", 4);
            studnia = new Budowle("studnia", 2);
            targowisko = new Budowle("targowisko", 1);
            most = new Budowle("most", 4);
            mur = new Budowle("mur", 10);
            koszary = new Budowle("koszary", 6);
            budynekMieszkalny = new Budowle("budynek mieszkalny", 4);
            kuznia = new Budowle("kuznia", 2);
            magazyn = new Budowle("magazyn", 1);

            //budynki w lodowej krainie

            warsztatLK = new Budowle("lodowy warsztat", 1);
            kwateraRybackaLK1 = new Budowle("pierwsza lodowa kwatera rybacka", 1);
            kwateraRybackaLK2 = new Budowle("druga lodowa kwatera rybacka", 1);
            studniaLK1 = new Budowle("pierwsza lodowa studnia", 1);
            studniaLK2 = new Budowle("druga lodowa studnia", 1);
            budynekMieszkalnyLK = new Budowle("lodowy budynek mieszkalny", 1);

            //budynki w osadzie goblinów

            kopalniaKamienia = new Budowle("kopalnia kamienia", 2);
            kopalniaRudyZelaza1 = new Budowle("pierwsza kopalnia rudy zelaza", 2);
            kopalniaRudyZelaza2 = new Budowle("druga kopalnia rudy zelaza", 2);

            goblin = new Przeciwnicy("Goblin", 10, 5, 20, 100, Properties.Resources.goblinprawo, Properties.Resources.goblinlewo, Properties.Resources.goblingora, Properties.Resources.goblindol);
            goblin2 = new Przeciwnicy("Goblin", 10, 5, 20, 100, Properties.Resources.goblinprawo, Properties.Resources.goblinlewo, Properties.Resources.goblingora, Properties.Resources.goblindol);
            goblin3 = new Przeciwnicy("Goblin", 10, 5, 20, 100, Properties.Resources.goblinprawo, Properties.Resources.goblinlewo, Properties.Resources.goblingora, Properties.Resources.goblindol);
            goblin4 = new Przeciwnicy("Goblin", 10, 5, 20, 100, Properties.Resources.goblinprawo, Properties.Resources.goblinlewo, Properties.Resources.goblingora, Properties.Resources.goblindol);
            goblin5 = new Przeciwnicy("Goblin", 10, 5, 20, 100, Properties.Resources.goblinprawo, Properties.Resources.goblinlewo, Properties.Resources.goblingora, Properties.Resources.goblindol);
            goblin6 = new Przeciwnicy("Goblin", 10, 5, 20, 100, Properties.Resources.goblinprawo, Properties.Resources.goblinlewo, Properties.Resources.goblingora, Properties.Resources.goblindol);
            goblin7 = new Przeciwnicy("Goblin", 10, 5, 20, 100, Properties.Resources.goblinprawo, Properties.Resources.goblinlewo, Properties.Resources.goblingora, Properties.Resources.goblindol);
            ork = new Przeciwnicy("Ork", 400, 50, 400, 100, Properties.Resources.orkprawo, Properties.Resources.orklewo, Properties.Resources.orkgora, Properties.Resources.orkdol);
            nietoperzDuzy = new Przeciwnicy("Duży nietoperz", 10, 5, 20, 100, Properties.Resources.nietoperzduzyprawo, Properties.Resources.nietoperzduzylewo, Properties.Resources.nietoperzduzygora, Properties.Resources.nietoperzduzydol);
            nietoperzMaly = new Przeciwnicy("Mały nietoperz", 5, 1, 5, 100, Properties.Resources.nietoperzmalyprawo, Properties.Resources.nietoperzmalylewo, Properties.Resources.nietoperzmalygora, Properties.Resources.nietoperzmalydol);
            robak = new Przeciwnicy("Robak", 30, 10, 50, 100, Properties.Resources.robakprawo, Properties.Resources.robaklewo, Properties.Resources.robakgora, Properties.Resources.robakdol);
            wazOgnisty = new Przeciwnicy("Ognisty wąż", 10, 10, 100, 100, Properties.Resources.waz3lewo, Properties.Resources.waz3lewo, Properties.Resources.waz3lewo, Properties.Resources.waz3lewo);
            wazJadowity = new Przeciwnicy("Jadowity wąż", 10, 10, 100, 100, Properties.Resources.waz1lewo, Properties.Resources.waz1lewo, Properties.Resources.waz1lewo, Properties.Resources.waz1lewo);
            brak = new Przeciwnicy();

            osadaGoblinow1 = new ObszaryInstancji();
            osadaGoblinow2 = new ObszaryInstancji();
            osadaGoblinow3 = new ObszaryInstancji();
            osadaGoblinow4 = new ObszaryInstancji();
            osadaGoblinow5 = new ObszaryInstancji();
            osadaGoblinow6 = new ObszaryInstancji();
            osadaGoblinow7 = new ObszaryInstancji();
            osadaGoblinow8 = new ObszaryInstancji();

            osadaGoblinow = new Instancje("Osada Goblinów", 120, 5, "orklewo", "orkgora", "orkdol");
            jaskiniaWezy = new Instancje("Jaskinia Węży", 180, 10, "waz2lewo", "waz2lewo", "waz2lewo");
            lodowaKraina = new Instancje("Lodowa kraina", 180, 10, "orklewo", "orkgora", "orkdol");
            //public Instancje zagadka = new Instancje();

            skorzanaZbroja = new Uzbrojenie("Skórzana Zbroja", 8, 0, 0, "1X1111111", Properties.Resources.skorzana_zbroja);
            skorzaneSpodnie = new Uzbrojenie("Skórzane Spodnie", 7, 0, 0, "1111X11X1", Properties.Resources.skorzane_spodnie);
            skorzanyHelm = new Uzbrojenie("Skórzany Hełm", 5, 0, 0, "1111X1XXX", "XXX1111X1", Properties.Resources.skorzany_helm);
            skorzaneButy = new Uzbrojenie("Skórzane Buty", 4, 0, 0, "XXX1X11X1", "1X11X1XXX", Properties.Resources.skorzane_buty);
            zelaznaZbroja = new Uzbrojenie("Żelazna Zbroja", 0, 8, 0, "4X4444444", Properties.Resources.zelazna_zbroja);
            zelazneSpodnie = new Uzbrojenie("Żelazne Spodnie", 0, 7, 0, "4444X44X4", Properties.Resources.zelazne_spodnie);
            zelaznyHelm = new Uzbrojenie("Żelazny Hełm", 0, 5, 0, "4444X4XXX", "XXX4444X4", Properties.Resources.zelazny_helm);
            zelazneButy = new Uzbrojenie("Żelazne Buty", 0, 4, 0, "XXX4X44X4", "4X44X4XXX", Properties.Resources.zelazne_buty);
            obsydianowaZbroja = new Uzbrojenie("Obsydianowa Zbroja", 0, 0, 8, "5X5555555", Properties.Resources.obsydianowa_zbroja);
            obsydianoweSpodnie = new Uzbrojenie("Obsydianowe Spodnie", 0, 0, 7, "5555X55X5", Properties.Resources.obsydianowe_spodnie);
            obsydianowyHelm = new Uzbrojenie("Obsydianowy Helm", 0, 0, 5, "5555X5XXX", "XXX5555X5", Properties.Resources.obsydianowy_helm);
            obsydianoweButy = new Uzbrojenie("Obsydianowe Buty", 0, 0, 4, "XXX5X55X5", "5X55X5XXX", Properties.Resources.obsydianowe_buty);
            zelaznaTarcza = new Uzbrojenie("Żelazna tarcza", "434343434", Properties.Resources.zelazna_tarcza);
            obsydianowaTarcza = new Uzbrojenie("Obsydianowa tarcza", "535353535", Properties.Resources.obsydianowa_tarcza);

            kamiennyMiecz = new Bronie("Kamienny Miecz", 1, 2, 0, 0, "2XX2XX0XX", "X2XX2XX0X", "XX2XX2XX0", Properties.Resources.kamienny_miecz);                // kawalekDrewna 0, skora 1, kamien 2, drewno 3, zelazo 4, obsydian 5
            zelaznyMiecz = new Bronie("Żelazny Miecz", 1, 0, 2, 0, "4XX4XX0XX", "X4XX4XX0X", "XX4XX4XX0", Properties.Resources.zelazny_miecz);                   // rudaZelaza 6, rudaObsydianu 7, welna 8, skorzanyPasek 9
            obsydianowyMiecz = new Bronie("Obsydianowy Miecz", 1, 0, 0, 2, "5XX5XX0XX", "X5XX5XX0X", "XX5XX5XX0", Properties.Resources.obsydianowy_miecz);
            luk = new Bronie("Łuk", 3, 3, "09X0X909X", "X909X0X90", Properties.Resources.luk);

            ubraniaMieszkancow = new Inne("Ubrania mieszkańców", "888888888", Properties.Resources.ubrania_mieszkanców, 9);
            lozko = new Inne("Łóżko", "888999333", Properties.Resources.łóżko, 3);

            zwiadowca = new JednostkiGracza();
            piechur = new JednostkiGracza("Piechur", 10, 10, 100, 1, 100, true, Properties.Resources.wojownikprawo, Properties.Resources.wojowniklewo, Properties.Resources.wojownikgora, Properties.Resources.wojownikdol);
            lucznik = new JednostkiGracza("Łucznik", 20, 5, 50, 1, 300, false, Properties.Resources.lucznikprawo, Properties.Resources.luczniklewo, Properties.Resources.lucznikgora, Properties.Resources.lucznikdol);
            rycerz = new JednostkiGracza("Rycerz", 40, 20, 200, 1, 100, true, Properties.Resources.rycerzprawo, Properties.Resources.rycerzlewo, Properties.Resources.rycerzgora, Properties.Resources.rycerzdol);
            czarnyRycerz = new JednostkiGracza("Czarny rycerz", 10, 10, 100, 1, 100, true, Properties.Resources.czarnyrycerzprawo, Properties.Resources.czarnyrycerzlewo, Properties.Resources.czarnyrycerzgora, Properties.Resources.czarnyrycerzdol);
            czarnyLucznik = new JednostkiGracza("Czarny łucznik", 20, 5, 50, 1, 300, false, Properties.Resources.czarnylucznikprawo, Properties.Resources.czarnyluczniklewo, Properties.Resources.czarnylucznikgora, Properties.Resources.czarnylucznikdol);

            budynki.AddRange(new Budowle[] { tartak1, tartak2, kamieniolom1, kamieniolom2, kwateraRybacka, chataMaga, chatkaRolnika, hodowla, studnia, magazyn, targowisko, most, mur, koszary, budynekMieszkalny, kuznia });
            surowce.AddRange(new Materialy[] { wood, stone, hay, skin, wool, food, water, ironOre, obsidianOre, iron, obsidian, leatherBelt, pieceOfWood });

            timerCzasGry.Start();
            //zagadka.obrazekLewo = "dinozaurmacius";
            //zagadka.obrazekDol = "dinozaurmacius";

            #region Przypisanie budowli do pictureBoxów

            // nie mogłem wrzucić tego do konstruktora?

            tartak1.pictureBox = pictureBoxTartak1;
            tartak2.pictureBox = pictureBoxTartak2;
            kamieniolom1.pictureBox = pictureBoxKamieniolom1;
            kamieniolom2.pictureBox = pictureBoxKamieniolom2;
            chatkaRolnika.pictureBox = pictureBoxChatkaRolnika;
            kwateraRybacka.pictureBox = pictureBoxKwateraRybacka;
            most.pictureBox = pictureBoxMost;
            studnia.pictureBox = pictureBoxStudnia;
            koszary.pictureBox = pictureBoxKoszary;
            budynekMieszkalny.pictureBox = pictureBoxBudynekMieszkalny;
            targowisko.pictureBox = pictureBoxTargowisko;
            hodowla.pictureBox = pictureBoxHodowla;
            chataMaga.pictureBox = pictureBoxChataMaga;
            kuznia.pictureBox = pictureBoxKuznia;
            magazyn.pictureBox = pictureBoxMagazyn;
            mur.pictureBox = pictureBoxMur;

            #endregion

            #region Przypisanie pozycji budowlom

            Budowle.PrzypiszPozycjeBudowli(budynki);

            #endregion
        }

        public Osada()
        {
            SQLConnection sql = new SQLConnection();
            InitializeComponent();

            pictureBoxMiejsceNaNamiot.Visible = false;
            pictureBoxNamiot.Visible = true;
            pictureBoxGraczPart6.Visible = false;
            pictureBoxGraczPart5.Visible = false;

            mieszkancy = new Mieszkancy();

            DataTable loadData = sql.LoadGame(Character.REF);

            new Panel(this,(int)loadData.Rows[0][2]).Show();

            wood = new Materialy((int)loadData.Rows[0][3],(int)loadData.Rows[0][4]);
            hay = new Materialy((int)loadData.Rows[0][5], (int)loadData.Rows[0][6]);
            stone = new Materialy((int)loadData.Rows[0][7], (int)loadData.Rows[0][8]);
            food = new Materialy((int)loadData.Rows[0][9], (int)loadData.Rows[0][10]);
            water = new Materialy((int)loadData.Rows[0][11], (int)loadData.Rows[0][12]);
            skin = new Materialy((int)loadData.Rows[0][13], (int)loadData.Rows[0][14]);
            gold = new Materialy((int)loadData.Rows[0][15], (int)loadData.Rows[0][16]);
            ironOre = new Materialy((int)loadData.Rows[0][17], (int)loadData.Rows[0][18]);
            obsidianOre = new Materialy((int)loadData.Rows[0][19], (int)loadData.Rows[0][20]);
            wool = new Materialy((int)loadData.Rows[0][21], (int)loadData.Rows[0][22]);
            iron = new Materialy((int)loadData.Rows[0][23], (int)loadData.Rows[0][24]);
            obsidian = new Materialy((int)loadData.Rows[0][25], (int)loadData.Rows[0][26]);
            leatherBelt = new Materialy((int)loadData.Rows[0][27], (int)loadData.Rows[0][28]);
            pieceOfWood = new Materialy((int)loadData.Rows[0][29], (int)loadData.Rows[0][30]);

            tartak1 = new Budowle("pierwszy tartak", 1);
            tartak2 = new Budowle("drugi tartak", 1);
            kamieniolom1 = new Budowle("pierwszy kamieniołom", 2);
            kamieniolom2 = new Budowle("drugi kamieniołom", 2);
            kwateraRybacka = new Budowle("kwatera rybacka", 2);
            chataMaga = new Budowle("chata maga", 1);
            chatkaRolnika = new Budowle("chatka rolnika", 3);
            hodowla = new Budowle("hodowla", 4);
            studnia = new Budowle("studnia", 2);
            targowisko = new Budowle("targowisko", 1);
            most = new Budowle("most", 4);
            mur = new Budowle("mur", 10);
            koszary = new Budowle("koszary", 6);
            budynekMieszkalny = new Budowle("budynek mieszkalny", 4);
            kuznia = new Budowle("kuznia", 2);
            magazyn = new Budowle("magazyn", 1);

            //budynki w lodowej krainie

            warsztatLK = new Budowle("lodowy warsztat", 1);
            kwateraRybackaLK1 = new Budowle("pierwsza lodowa kwatera rybacka", 1);
            kwateraRybackaLK2 = new Budowle("druga lodowa kwatera rybacka", 1);
            studniaLK1 = new Budowle("pierwsza lodowa studnia", 1);
            studniaLK2 = new Budowle("druga lodowa studnia", 1);
            budynekMieszkalnyLK = new Budowle("lodowy budynek mieszkalny", 1);

            //budynki w osadzie goblinów

            kopalniaKamienia = new Budowle("kopalnia kamienia", 2);
            kopalniaRudyZelaza1 = new Budowle("pierwsza kopalnia rudy zelaza", 2);
            kopalniaRudyZelaza2 = new Budowle("druga kopalnia rudy zelaza", 2);

            goblin = new Przeciwnicy("Goblin", 10, 5, 20, 100, Properties.Resources.goblinprawo, Properties.Resources.goblinlewo, Properties.Resources.goblingora, Properties.Resources.goblindol);
            goblin2 = new Przeciwnicy("Goblin", 10, 5, 20, 100, Properties.Resources.goblinprawo, Properties.Resources.goblinlewo, Properties.Resources.goblingora, Properties.Resources.goblindol);
            goblin3 = new Przeciwnicy("Goblin", 10, 5, 20, 100, Properties.Resources.goblinprawo, Properties.Resources.goblinlewo, Properties.Resources.goblingora, Properties.Resources.goblindol);
            goblin4 = new Przeciwnicy("Goblin", 10, 5, 20, 100, Properties.Resources.goblinprawo, Properties.Resources.goblinlewo, Properties.Resources.goblingora, Properties.Resources.goblindol);
            goblin5 = new Przeciwnicy("Goblin", 10, 5, 20, 100, Properties.Resources.goblinprawo, Properties.Resources.goblinlewo, Properties.Resources.goblingora, Properties.Resources.goblindol);
            goblin6 = new Przeciwnicy("Goblin", 10, 5, 20, 100, Properties.Resources.goblinprawo, Properties.Resources.goblinlewo, Properties.Resources.goblingora, Properties.Resources.goblindol);
            goblin7 = new Przeciwnicy("Goblin", 10, 5, 20, 100, Properties.Resources.goblinprawo, Properties.Resources.goblinlewo, Properties.Resources.goblingora, Properties.Resources.goblindol);
            ork = new Przeciwnicy("Ork", 400, 50, 400, 100, Properties.Resources.orkprawo, Properties.Resources.orklewo, Properties.Resources.orkgora, Properties.Resources.orkdol);
            nietoperzDuzy = new Przeciwnicy("Duży nietoperz", 10, 5, 20, 100, Properties.Resources.nietoperzduzyprawo, Properties.Resources.nietoperzduzylewo, Properties.Resources.nietoperzduzygora, Properties.Resources.nietoperzduzydol);
            nietoperzMaly = new Przeciwnicy("Mały nietoperz", 5, 1, 5, 100, Properties.Resources.nietoperzmalyprawo, Properties.Resources.nietoperzmalylewo, Properties.Resources.nietoperzmalygora, Properties.Resources.nietoperzmalydol);
            robak = new Przeciwnicy("Robak", 30, 10, 50, 100, Properties.Resources.robakprawo, Properties.Resources.robaklewo, Properties.Resources.robakgora, Properties.Resources.robakdol);
            wazOgnisty = new Przeciwnicy("Ognisty wąż", 10, 10, 100, 100, Properties.Resources.waz3lewo, Properties.Resources.waz3lewo, Properties.Resources.waz3lewo, Properties.Resources.waz3lewo);
            wazJadowity = new Przeciwnicy("Jadowity wąż", 10, 10, 100, 100, Properties.Resources.waz1lewo, Properties.Resources.waz1lewo, Properties.Resources.waz1lewo, Properties.Resources.waz1lewo);
            brak = new Przeciwnicy();

            osadaGoblinow1 = new ObszaryInstancji();
            osadaGoblinow2 = new ObszaryInstancji();
            osadaGoblinow3 = new ObszaryInstancji();
            osadaGoblinow4 = new ObszaryInstancji();
            osadaGoblinow5 = new ObszaryInstancji();
            osadaGoblinow6 = new ObszaryInstancji();
            osadaGoblinow7 = new ObszaryInstancji();
            osadaGoblinow8 = new ObszaryInstancji();

            osadaGoblinow = new Instancje("Osada Goblinów", 120, 5, "orklewo", "orkgora", "orkdol");
            jaskiniaWezy = new Instancje("Jaskinia Węży", 180, 10, "waz2lewo", "waz2lewo", "waz2lewo");
            lodowaKraina = new Instancje("Lodowa kraina", 180, 10, "orklewo", "orkgora", "orkdol");
            //public Instancje zagadka = new Instancje();

            skorzanaZbroja = new Uzbrojenie("Skórzana Zbroja", 8, 0, 0, "1X1111111", Properties.Resources.skorzana_zbroja);
            skorzaneSpodnie = new Uzbrojenie("Skórzane Spodnie", 7, 0, 0, "1111X11X1", Properties.Resources.skorzane_spodnie);
            skorzanyHelm = new Uzbrojenie("Skórzany Hełm", 5, 0, 0, "1111X1XXX", "XXX1111X1", Properties.Resources.skorzany_helm);
            skorzaneButy = new Uzbrojenie("Skórzane Buty", 4, 0, 0, "XXX1X11X1", "1X11X1XXX", Properties.Resources.skorzane_buty);
            zelaznaZbroja = new Uzbrojenie("Żelazna Zbroja", 0, 8, 0, "4X4444444", Properties.Resources.zelazna_zbroja);
            zelazneSpodnie = new Uzbrojenie("Żelazne Spodnie", 0, 7, 0, "4444X44X4", Properties.Resources.zelazne_spodnie);
            zelaznyHelm = new Uzbrojenie("Żelazny Hełm", 0, 5, 0, "4444X4XXX", "XXX4444X4", Properties.Resources.zelazny_helm);
            zelazneButy = new Uzbrojenie("Żelazne Buty", 0, 4, 0, "XXX4X44X4", "4X44X4XXX", Properties.Resources.zelazne_buty);
            obsydianowaZbroja = new Uzbrojenie("Obsydianowa Zbroja", 0, 0, 8, "5X5555555", Properties.Resources.obsydianowa_zbroja);
            obsydianoweSpodnie = new Uzbrojenie("Obsydianowe Spodnie", 0, 0, 7, "5555X55X5", Properties.Resources.obsydianowe_spodnie);
            obsydianowyHelm = new Uzbrojenie("Obsydianowy Helm", 0, 0, 5, "5555X5XXX", "XXX5555X5", Properties.Resources.obsydianowy_helm);
            obsydianoweButy = new Uzbrojenie("Obsydianowe Buty", 0, 0, 4, "XXX5X55X5", "5X55X5XXX", Properties.Resources.obsydianowe_buty);
            zelaznaTarcza = new Uzbrojenie("Żelazna tarcza", "434343434", Properties.Resources.zelazna_tarcza);
            obsydianowaTarcza = new Uzbrojenie("Obsydianowa tarcza", "535353535", Properties.Resources.obsydianowa_tarcza);

            kamiennyMiecz = new Bronie("Kamienny Miecz", 1, 2, 0, 0, "2XX2XX0XX", "X2XX2XX0X", "XX2XX2XX0", Properties.Resources.kamienny_miecz);                // kawalekDrewna 0, skora 1, kamien 2, drewno 3, zelazo 4, obsydian 5
            zelaznyMiecz = new Bronie("Żelazny Miecz", 1, 0, 2, 0, "4XX4XX0XX", "X4XX4XX0X", "XX4XX4XX0", Properties.Resources.zelazny_miecz);                   // rudaZelaza 6, rudaObsydianu 7, welna 8, skorzanyPasek 9
            obsydianowyMiecz = new Bronie("Obsydianowy Miecz", 1, 0, 0, 2, "5XX5XX0XX", "X5XX5XX0X", "XX5XX5XX0", Properties.Resources.obsydianowy_miecz);
            luk = new Bronie("Łuk", 3, 3, "09X0X909X", "X909X0X90", Properties.Resources.luk);

            ubraniaMieszkancow = new Inne("Ubrania mieszkańców", "888888888", Properties.Resources.ubrania_mieszkanców, 9);
            lozko = new Inne("Łóżko", "888999333", Properties.Resources.łóżko, 3);

            zwiadowca = new JednostkiGracza();
            piechur = new JednostkiGracza("Piechur", 10, 10, 100, 1, 100, true, Properties.Resources.wojownikprawo, Properties.Resources.wojowniklewo, Properties.Resources.wojownikgora, Properties.Resources.wojownikdol);
            lucznik = new JednostkiGracza("Łucznik", 20, 5, 50, 1, 300, false, Properties.Resources.lucznikprawo, Properties.Resources.luczniklewo, Properties.Resources.lucznikgora, Properties.Resources.lucznikdol);
            rycerz = new JednostkiGracza("Rycerz", 40, 20, 200, 1, 100, true, Properties.Resources.rycerzprawo, Properties.Resources.rycerzlewo, Properties.Resources.rycerzgora, Properties.Resources.rycerzdol);
            czarnyRycerz = new JednostkiGracza("Czarny rycerz", 10, 10, 100, 1, 100, true, Properties.Resources.czarnyrycerzprawo, Properties.Resources.czarnyrycerzlewo, Properties.Resources.czarnyrycerzgora, Properties.Resources.czarnyrycerzdol);
            czarnyLucznik = new JednostkiGracza("Czarny łucznik", 20, 5, 50, 1, 300, false, Properties.Resources.czarnylucznikprawo, Properties.Resources.czarnyluczniklewo, Properties.Resources.czarnylucznikgora, Properties.Resources.czarnylucznikdol);

            budynki.AddRange(new Budowle[] { tartak1, tartak2, kamieniolom1, kamieniolom2, kwateraRybacka, chataMaga, chatkaRolnika, hodowla, studnia, magazyn, targowisko, most, mur, koszary, budynekMieszkalny, kuznia });
            surowce.AddRange(new Materialy[] { wood, stone, hay, skin, wool, food, water, ironOre, obsidianOre, iron, obsidian, leatherBelt, pieceOfWood });

            timerCzasGry.Start();
            //zagadka.obrazekLewo = "dinozaurmacius";
            //zagadka.obrazekDol = "dinozaurmacius";

            #region Przypisanie budowli do pictureBoxów

            // nie mogłem wrzucić tego do konstruktora?

            tartak1.pictureBox = pictureBoxTartak1;
            tartak2.pictureBox = pictureBoxTartak2;
            kamieniolom1.pictureBox = pictureBoxKamieniolom1;
            kamieniolom2.pictureBox = pictureBoxKamieniolom2;
            chatkaRolnika.pictureBox = pictureBoxChatkaRolnika;
            kwateraRybacka.pictureBox = pictureBoxKwateraRybacka;
            most.pictureBox = pictureBoxMost;
            studnia.pictureBox = pictureBoxStudnia;
            koszary.pictureBox = pictureBoxKoszary;
            budynekMieszkalny.pictureBox = pictureBoxBudynekMieszkalny;
            targowisko.pictureBox = pictureBoxTargowisko;
            hodowla.pictureBox = pictureBoxHodowla;
            chataMaga.pictureBox = pictureBoxChataMaga;
            kuznia.pictureBox = pictureBoxKuznia;
            magazyn.pictureBox = pictureBoxMagazyn;
            mur.pictureBox = pictureBoxMur;

            #endregion

            #region Przypisanie pozycji budowlom

            Budowle.PrzypiszPozycjeBudowli(budynki);

            #endregion
        }

        private void timerCzasGry_Tick(object sender, EventArgs e)
        {
            PojemnośćMagazynu();

            mieszkancy.liczebnoscWojsk = (zwiadowca.liczebnoscAtakujacych + piechur.liczebnoscAtakujacych + lucznik.liczebnoscAtakujacych + rycerz.liczebnoscAtakujacych + czarnyRycerz.liczebnoscAtakujacych + czarnyLucznik.liczebnoscAtakujacych + piechur.liczebnoscBroniacych + lucznik.liczebnoscBroniacych + rycerz.liczebnoscBroniacych + czarnyRycerz.liczebnoscBroniacych + czarnyLucznik.liczebnoscBroniacych);

            if (budynekMieszkalny.pictureBox.Visible == true)
            {
                if (mieszkancy.czyPrzyrostMieszkancow == true)
                {
                    timerMieszkancy.Start();
                }
                else if (mieszkancy.czyPrzyrostMieszkancow == false)
                {
                    timerMieszkancy.Stop();
                }
            }

            WojnaAkcja(osadaGoblinow);
            WojnaAkcja(jaskiniaWezy);

            Zjedz();
            PobierzPodatek();
        }

        private void timerMieszkancy_Tick(object sender, EventArgs e)
        {
            if (ubraniaMieszkancow.ilosc >= 1 && lozko.ilosc >= 1)
            {
                ubraniaMieszkancow.ilosc--;
                lozko.ilosc--;
                mieszkancy.liczbaMieszkancow++;
            }
            else
            {
                new Wiadomosc("Brakuje ubrań lub łóżek dla mieszkańców.").ShowDialog();
                mieszkancy.czyPrzyrostMieszkancow = false;
                timerMieszkancy.Stop();
            }
        }

        private void Osada_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Osada_Shown(object sender, EventArgs e)
        {
            /* DialogResult dialogResult = MessageBox.Show("Czuję, że to już niedaleko!", "", MessageBoxButtons.OK);
             if (dialogResult == DialogResult.OK)
             {
                 pictureBoxGraczPart5.Visible = false;
                 pictureBoxGraczPart6.Visible = true;
                 MessageBox.Show("Tak! Właśnie tu rozbiję swój namiot.");

             }
              */
        }
        
        private void pictureBoxMiejsceNaNamiot_Click(object sender, EventArgs e)
        {
            pictureBoxMiejsceNaNamiot.Visible = false;
            pictureBoxNamiot.Visible = true;
            pictureBoxGraczPart6.Visible = false;
            pictureBoxGraczPart5.Visible = false;
            //MessageBox.Show("Czas rozbudować osadę!");

            new Panel(this).Show();

            new Wiadomosc("To idealne miejsce na zbudowanie osady.\n\nZarządzaj ją mądrze, każdy twój ruch ma swoje konsekwencje.").Show();
        }
     
        private void pictureBoxNamiotPoziom1_Click(object sender, EventArgs e)
        {
            new Namiot(this).ShowDialog();
        }
        
        private void pictureBoxKoszary_Click(object sender, EventArgs e)
        {
            new Koszary(this).ShowDialog();
        }

        /// <summary>
        /// po kliknieciu na targowisko przechodzimy do okna Targowisk
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxTargowisko_Click(object sender, EventArgs e)
        {
            new Targowisko(this).ShowDialog();
        }

        private void pictureBoxWarsztat_Click(object sender, EventArgs e)
        {
            new Kuznia(this).ShowDialog();
        }

        private void buttonCzyszczenie_Click(object sender, EventArgs e)
        {
            textBoxInformacja.Clear();
        }

        #region Sprawdzenie czy magazyn przepełniony

        public void PojemnośćMagazynu()
        {
            if (magazyn.poziomUlepszenia == 0)
            {
                foreach (var item in surowce)
                {
                    if (item.quantity > 999)
                    {
                        i++;
                        item.quantity = 1000;
                    }
                    else if (item.quantity <= 999)
                    {
                        i = i + 0;
                    }
                }

                if (j == 0 && i > 0)
                {

                    textBoxInformacja.AppendText("Magazyn przepełniony!");
                    textBoxInformacja.AppendText(Environment.NewLine);
                    j = 1;
                }
                else if (j == 1 && i == 0)
                {
                    j = 0;
                }

                i = 0;

            }
            else if (magazyn.poziomUlepszenia == 1)
            {
                foreach (var item in surowce)
                {
                    if (item.quantity > 999)
                    {
                        i++;
                        item.quantity = 1000;
                    }
                    else if (item.quantity <= 999)
                    {
                        i = i + 0;
                    }
                }

                if (j == 0 && i > 0)
                {
                    textBoxInformacja.AppendText("Magazyn przepełniony!");
                    textBoxInformacja.AppendText(Environment.NewLine);
                    j = 1;
                }
                else if (j == 1 && i == 0)
                {
                    j = 0;
                }

                i = 0;
            }
            else if (magazyn.poziomUlepszenia == 2)
            {
                foreach (var item in surowce)
                {
                    if (item.quantity > 1999)
                    {
                        i++;
                        item.quantity = 2000;
                    }
                    else if (item.quantity <= 1999)
                    {
                        i = i + 0;
                    }
                }

                if (j == 0 && i > 0)
                {
                    textBoxInformacja.AppendText("Magazyn przepełniony!");
                    textBoxInformacja.AppendText(Environment.NewLine);
                    j = 1;
                }
                else if (j == 1 && i == 0)
                {
                    j = 0;
                }

                i = 0;
            }
            else if (magazyn.poziomUlepszenia == 3)
            {
                foreach (var item in surowce)
                {
                    if (item.quantity > 2999)
                    {
                        i++;
                        item.quantity = 3000;
                    }
                    else if (item.quantity <= 2999)
                    {
                        i = i + 0;
                    }
                }

                if (j == 0 && i > 0)
                {

                    textBoxInformacja.AppendText("Magazyn przepełniony!");
                    textBoxInformacja.AppendText(Environment.NewLine);

                    j = 1;
                }
                else if (j == 1 && i == 0)
                {
                    j = 0;
                }

                i = 0;
            }
        }
        #endregion

        private void pictureBoxMapa_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Visible = false;
            new EkranLadowania(o, this, new Size(1920,1080),2).Show();                        
        }

        private void buttonELO_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public string InformacjaNaTematInstancji(Instancje instancja, Przeciwnicy wrog1, Przeciwnicy wrog2, Przeciwnicy wrog3, Przeciwnicy wrog4, Przeciwnicy wrog5)
        {
            return "W instancji " + instancja.nazwa + " znajdziesz przeciwników takich jak: " + wrog1.nazwa + ", " + wrog2.nazwa + ", " + wrog3.nazwa + ", " + wrog4.nazwa + ", "
                    + wrog5.nazwa + "." + Environment.NewLine + Environment.NewLine;

        }

        public string InformacjaNaTematPrzeciwnika(Instancje instancja, int poziom, Przeciwnicy wrog, int ilosc, string styl)
        {
            return "W " + instancja.nazwa + " na poziomie " + poziom + " znajdziesz: " + Environment.NewLine + Environment.NewLine + wrog.nazwa + ":" + Environment.NewLine + "Sztuk: " + ilosc + Environment.NewLine +
                   "Atak jednostkowy: " + wrog.atak + Environment.NewLine + "Obrona jednostkowa: " + wrog.obronaDomyslna + Environment.NewLine + "PZ jednostkowe: " + wrog.PZ + Environment.NewLine +
                   "Styl walki: " + styl + Environment.NewLine + Environment.NewLine;

        }

        private void timerZwiadowca_Tick(object sender, EventArgs e)
        {
            #region informacje zdobyte przez zwiadowce
            if (osadaGoblinow.akcjaZwiadowca == true)
            {
                osadaGoblinow.czasZwiadowcy++;

                if (osadaGoblinow.czasZwiadowcy == osadaGoblinow.czasRuchuZwiadowcy)
                {
                    int wylosowana;
                    wylosowana = losowa.Next(0, 101);

                    if (wylosowana <= zwiadowca.atak)
                    {
                        MessageBox.Show("udalo sie" + wylosowana.ToString() + " " + zwiadowca.atak.ToString());

                        if (osadaGoblinow.licznikZwiadowca == 1)
                        {
                            notatkaZwiadowcy += InformacjaNaTematInstancji(osadaGoblinow, nietoperzMaly, nietoperzDuzy, goblin, goblin, ork) + InformacjaNaTematPrzeciwnika(osadaGoblinow, 1, nietoperzMaly, 10, "zwarcie")
                                                + InformacjaNaTematPrzeciwnika(osadaGoblinow, 1, nietoperzDuzy, 5,"zwarcie");
                        }
                        else if (osadaGoblinow.licznikZwiadowca == 2)
                        {
                            notatkaZwiadowcy += InformacjaNaTematPrzeciwnika(osadaGoblinow, 2, goblin, 10, "zwarcie") + InformacjaNaTematPrzeciwnika(osadaGoblinow, 2, goblin, 5, "zwarcie");
                        }
                        else if (osadaGoblinow.licznikZwiadowca == 3)
                        {
                            notatkaZwiadowcy += InformacjaNaTematPrzeciwnika(osadaGoblinow, 3, goblin, 15, "zwarcie") + InformacjaNaTematPrzeciwnika(osadaGoblinow, 3, ork, 1, "zwarcie");
                        }

                        osadaGoblinow.licznikZwiadowca++;
                        osadaGoblinow.czasZwiadowcy = 0;
                        osadaGoblinow.akcjaZwiadowca = false;
                        timerZwiadowca.Stop();
                    }
                    else
                    {
                        MessageBox.Show("nie udalo sie" + wylosowana.ToString() + " " + zwiadowca.atak.ToString());
                        osadaGoblinow.czasZwiadowcy = 0;
                        osadaGoblinow.akcjaZwiadowca = false;
                        timerZwiadowca.Stop();
                    }
                }
            }
            else if (jaskiniaWezy.akcjaZwiadowca == true)
            {
                jaskiniaWezy.czasZwiadowcy++;

                if (jaskiniaWezy.czasZwiadowcy == jaskiniaWezy.czasRuchuZwiadowcy)
                {
                    int wylosowana;
                    wylosowana = losowa.Next(0, 101);

                    if (wylosowana <= zwiadowca.atak)
                    {
                        MessageBox.Show("udalo sie" + wylosowana.ToString() + " " + zwiadowca.atak.ToString());

                        if (jaskiniaWezy.licznikZwiadowca == 1)
                        {
                            notatkaZwiadowcy += InformacjaNaTematInstancji(jaskiniaWezy, nietoperzMaly, nietoperzDuzy, robak, wazJadowity, wazOgnisty) + InformacjaNaTematPrzeciwnika(jaskiniaWezy, 1, robak, 10, "zwarcie");
                        }
                        else if (jaskiniaWezy.licznikZwiadowca == 2)
                        {
                            notatkaZwiadowcy += InformacjaNaTematPrzeciwnika(jaskiniaWezy, 2, wazOgnisty, 1, "dystans") + InformacjaNaTematPrzeciwnika(jaskiniaWezy, 2, wazJadowity, 1, "dystans");
                        }

                        jaskiniaWezy.licznikZwiadowca++;
                        jaskiniaWezy.czasZwiadowcy = 0;
                        jaskiniaWezy.akcjaZwiadowca = false;
                        timerZwiadowca.Stop();
                    }
                    else
                    {
                        MessageBox.Show("nie udalo sie" + wylosowana.ToString() + " " + zwiadowca.atak.ToString());
                        jaskiniaWezy.czasZwiadowcy = 0;
                        jaskiniaWezy.akcjaZwiadowca = false;
                        timerZwiadowca.Stop();
                    }
                }


            }
            #endregion
        }

        public void WojnaAkcja(Instancje instancja)
        {
            if (instancja.akcjaWrog)
            {
                instancja.czasWroga++;

                if (instancja.czasWroga == 1)
                {
                    textBoxInformacja.AppendText("Armia z " + instancja.nazwa + " zmierza w kierunku osady!");
                    textBoxInformacja.AppendText(Environment.NewLine);
                }
                else if (instancja.czasWroga == instancja.czasRuchuWrogow)
                {
                    instancja.akcjaWrog = false;
                    instancja.czasWroga = 0;
                    var o = Properties.Resources.ResourceManager.GetObject(instancja.obrazekDol);
                    pictureBoxWrog.Image = (Image)o;
                    pictureBoxWrog.Visible = true;
                    MessageBox.Show("Zostałeś zaatakowany przez " + instancja.nazwa + "!");

                }
            }
        }

        #region Konsumpcja jedzenia i wody

        // metoda Zjedz() określa czynności związane z konsumpcją jedzenia i wody przez mieszkańców
        public void Zjedz()
        {
            if(czasDoZjedzenia == 10)
            {
                int iloscDoSpozycia = (mieszkancy.liczbaPracujacychMieszkancow * mieszkancy.poziomPodatkow) + (mieszkancy.liczbaBezrobotnychMieszkancow * mieszkancy.poziomPodatkow / 2);
                

                if (food.quantity < iloscDoSpozycia || water.quantity < iloscDoSpozycia)
                {
                    mieszkancy.poziomZadowolenia = 1;
                    mieszkancy.poziomPodatkow = 1;
                    ZmienNaGlod();
                }
                else
                {
                    if (Materialy.glod == 2)
                    {
                        ZmienNaDostatek();
                    }
                }

                food.quantity -= iloscDoSpozycia;
                water.quantity -= iloscDoSpozycia;
                czasDoZjedzenia = 0;
            }
            else
            {
                czasDoZjedzenia++;
            }
        }

        #endregion

        public static void ZmienNaGlod()
        {
            Materialy.glod = 2;
        }

        public static void ZmienNaDostatek()
        {
            Materialy.glod = 1;
        }
               
        private void pictureBoxBudynekMieszkalny_Click(object sender, EventArgs e)
        {
            new BudynekMieszkalny(this,o).ShowDialog();
        }

        private void timerPrzyrostDrewna_Tick(object sender, EventArgs e)
        {
            wood.ObliczPoziomUlepszenia(tartak1.poziomUlepszenia, tartak2.poziomUlepszenia);
            wood.ZwiekszPrzyrostMaterialu();
        }

        private void timerPrzyrostKamienia_Tick(object sender, EventArgs e)
        {
            stone.ObliczPoziomUlepszenia(kamieniolom1.poziomUlepszenia, kamieniolom2.poziomUlepszenia, kopalniaKamienia.poziomUlepszenia);
            stone.ZwiekszPrzyrostMaterialu();
        }

        private void timerPrzyrostSiana_Tick(object sender, EventArgs e)
        {
            hay.ObliczPoziomUlepszenia(chatkaRolnika.poziomUlepszenia, 0);
            hay.ZwiekszPrzyrostMaterialu();
        }

        private void timerPrzyrostSkory_Tick(object sender, EventArgs e)
        {
            skin.ObliczPoziomUlepszenia(hodowla.poziomUlepszenia, 0);
            skin.ZwiekszPrzyrostMaterialu();
        }

        private void TimerPrzyrostWelny_Tick(object sender, EventArgs e)
        {
            wool.ObliczPoziomUlepszenia(hodowla.poziomUlepszenia, 0);
            wool.ZwiekszPrzyrostMaterialu();
        }

        private void timerPrzyrostJedzenia_Tick(object sender, EventArgs e)
        {
            food.ObliczPoziomUlepszenia(hodowla.poziomUlepszenia, kwateraRybacka.poziomUlepszenia);
            food.ZwiekszPrzyrostMaterialu();
        }

        private void timerPrzyrostWody_Tick(object sender, EventArgs e)
        {
            water.ObliczPoziomUlepszenia(studnia.poziomUlepszenia, 0);
            water.ZwiekszPrzyrostMaterialu();
        }

        private void TimerPrzyrostRudyZelaza_Tick(object sender, EventArgs e)
        {
            ironOre.ObliczPoziomUlepszenia(kopalniaRudyZelaza1.poziomUlepszenia, kopalniaRudyZelaza2.poziomUlepszenia);
            ironOre.ZwiekszPrzyrostMaterialu();
        }

        public void PobierzPodatek()
        {
            if(czasDoPobraniaPodatkow == 10)
            {
                if(Materialy.glod == 1)
                {
                    gold.quantity += (mieszkancy.liczbaMieszkancow * mieszkancy.poziomPodatkow);
                }
                else if(Materialy.glod == 2)
                {
                    gold.quantity += 0;
                }
                
                czasDoPobraniaPodatkow = 0;
            }
            else
            {
                czasDoPobraniaPodatkow++;
            }
        }

        public void Budowa2(Budowle budowle, Timer timerSurowiec)
        {
            if (progressBar.Value == progressBar.Maximum)
            {
                timerCzasBudowy.Stop();
                progressBar.Visible = false;
                budowle.pictureBox.Visible = true;
                budowle.poziomUlepszenia = 1;
                progressBar.Value = 0;
                textBoxInformacja.AppendText("Wybudowano " + budowle.nazwa + "!");
                textBoxInformacja.AppendText(Environment.NewLine);
                timerSurowiec.Start();
            }
            else
            {
                progressBar.Increment(5);
            }
        }

        public void Budowa2(Budowle budowle)
        {
            if (progressBar.Value == progressBar.Maximum)
            {
                timerCzasBudowy.Stop();
                progressBar.Visible = false;
                budowle.pictureBox.Visible = true;
                budowle.poziomUlepszenia = 1;
                progressBar.Value = 0;
                textBoxInformacja.AppendText("Wybudowano " + budowle.nazwa + "!");
                textBoxInformacja.AppendText(Environment.NewLine);
            }
            else
            {
                progressBar.Increment(5);

            }
        }

        //public void Budowa2(Budowle budowle, Timer timerSurowiec1, Timer timerSurowiec2)
        //{
        //    if (progressBar.Value == progressBar.Maximum)
        //    {
        //        timerCzasBudowy.Stop();
        //        progressBar.Visible = false;
        //        budowle.pictureBox.Visible = true;
        //        budowle.poziomUlepszenia = 1;
        //        progressBar.Value = 0;
        //        textBoxInformacja.AppendText("Wybudowano " + budowle.name + "!");
        //        textBoxInformacja.AppendText(Environment.NewLine);
        //        timerSurowiec1.Start();
        //        timerSurowiec2.Start();
        //    }
        //    else
        //    {
        //        progressBar.Increment(5);
        //    }
        //}

        public void Budowa2(Budowle budowle, Timer timerSurowiec1, Timer timerSurowiec2, Timer timerSurowiec3)
        {
            if (progressBar.Value == progressBar.Maximum)
            {
                timerCzasBudowy.Stop();
                progressBar.Visible = false;
                budowle.pictureBox.Visible = true;
                budowle.poziomUlepszenia = 1;
                progressBar.Value = 0;
                textBoxInformacja.AppendText("Wybudowano " + budowle.nazwa + "!");
                textBoxInformacja.AppendText(Environment.NewLine);
                timerSurowiec1.Start();
                timerSurowiec2.Start();
                timerSurowiec3.Start();
            }
            else
            {
                progressBar.Increment(5);
            }
        }



        public void BudowaInstancje(Budowle budowla, Timer timerSurowiec)
        {
            if(budowla.progressBarBudowa.Value == budowla.progressBarBudowa.Maximum)
            {
                timerCzasBudowy.Stop();
                budowla.progressBarBudowa.Visible = false;
                budowla.pictureBox.Visible = true;
                budowla.czyBudowlaIstnieje = true;
                budowla.pictureBox.BackgroundImage = budowla.bitmap;
                budowla.poziomUlepszenia = 1;
                budowla.progressBarBudowa.Value = 0;
                textBoxInformacja.AppendText("Wybudowano " + budowla.nazwa + "!");
                textBoxInformacja.AppendText(Environment.NewLine);
                timerSurowiec.Start();
            }
            else
            {
                budowla.progressBarBudowa.Increment(5);
            }
        }

        private void TimerCzasBudowy_Tick(object sender, EventArgs e)
        {
            switch (nazwaBudowliBudowa)
            {
                case "pierwszy tartak":
                    Budowa2(tartak1, timerPrzyrostDrewna);
                    break;
                case "drugi tartak":
                    Budowa2(tartak2, timerPrzyrostDrewna);
                    break;
                case "pierwszy kamieniołom":
                    Budowa2(kamieniolom1, timerPrzyrostKamienia);
                    break;
                case "drugi kamieniołom":
                    Budowa2(kamieniolom2, timerPrzyrostKamienia);
                    break;
                case "chatka rolnika":
                    Budowa2(chatkaRolnika, timerPrzyrostSiana);
                    break;
                case "magazyn":
                    Budowa2(magazyn);
                    break;
                case "budynek mieszkalny":
                    Budowa2(budynekMieszkalny);
                    break;
                case "koszary":
                    Budowa2(koszary);
                    break;
                case "targowisko":
                    Budowa2(targowisko);
                    break;
                case "kuznia":
                    Budowa2(kuznia);
                    break;
                case "chata maga":
                    Budowa2(chataMaga);
                    break;
                case "kwatera rybacka":
                    Budowa2(kwateraRybacka, timerPrzyrostJedzenia);
                    break;
                case "most":
                    Budowa2(most);
                    break;
                case "mur":
                    Budowa2(mur);
                    break;
                case "hodowla":
                    Budowa2(hodowla, timerPrzyrostJedzenia, timerPrzyrostSkory, timerPrzyrostWelny);
                    break;
                case "studnia":
                    Budowa2(studnia, timerPrzyrostWody);
                    break;
                case "kopalnia kamienia":
                    BudowaInstancje(kopalniaKamienia, timerPrzyrostKamienia);
                    break;
                case "pierwsza kopalnia rudy zelaza":
                    BudowaInstancje(kopalniaRudyZelaza1, timerPrzyrostRudyZelaza);
                    break;
                case "druga kopalnia rudy zelaza":
                    BudowaInstancje(kopalniaRudyZelaza2, timerPrzyrostRudyZelaza);
                    break;
            }

        }

        public void KosztBudowyOsada(Materialy material, int ilosc, Materialy material2, int ilosc2, Budowle budowle)
        {
            if (budowle.pictureBox.Visible == false)
            {
                if (budowle.liczbaPracownikowPotrzebnychDoBudowy <= mieszkancy.liczbaBezrobotnychMieszkancow)
                {
                    if (material.quantity >= ilosc && material2.quantity >= ilosc2)
                    {
                        if (progressBar.Visible == false)
                        {
                            material.quantity -= ilosc;
                            material2.quantity -= ilosc2;
                            mieszkancy.liczbaPracujacychMieszkancow += budowle.liczbaPracownikowPotrzebnychDoBudowy;
                            progressBar.Location = budowle.punkt;
                            progressBar.Visible = true;
                            progressBar.Maximum = budowle.ZwrocCzasTrwaniaBudowy();
                            nazwaBudowliBudowa = budowle.nazwa;
                            timerCzasBudowy.Start();
                        }
                        else
                        {
                            MessageBox.Show("W jednym momencie możesz budować tylko jeden obiekt!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Brak odpowiednich surowców!");
                    }
                }
                else
                {
                    MessageBox.Show("Brak pracowników!");
                }
            }
            else if (budowle.pictureBox.Visible == true)
            {
                MessageBox.Show("Budynek został już wybudowany!");
            }

        }

        public void KosztBudowyInstancje(Materialy material, int ilosc, Materialy material2, int ilosc2, Budowle budowla)
        {
            if (budowla.liczbaPracownikowPotrzebnychDoBudowy <= mieszkancy.liczbaBezrobotnychMieszkancow)
            {
                if (material.quantity >= ilosc && material2.quantity >= ilosc2)
                {
                    // gdy czas jest równy 0, czyli na początku
                    if (budowla.progressBarBudowa.Visible == false)
                    {
                        material.quantity -= ilosc;
                        material2.quantity -= ilosc2;
                        mieszkancy.liczbaPracujacychMieszkancow += budowla.liczbaPracownikowPotrzebnychDoBudowy;
                        budowla.progressBarBudowa.Location = budowla.punkt;
                        budowla.progressBarBudowa.Visible = true;
                        budowla.progressBarBudowa.Maximum = budowla.ZwrocCzasTrwaniaBudowy();
                        budowla.pictureBox.Visible = false;
                        nazwaBudowliBudowa = budowla.nazwa;
                        timerCzasBudowy.Start();
                    }
                    else
                    {
                        MessageBox.Show("W jednym momencie możesz budować tylko jeden obiekt!");
                    }
                }
                else
                {
                    MessageBox.Show("Brak odpowiednich surowców!");
                }
            }
            else
            {
                MessageBox.Show("Brak pracowników!");
            }
        }

        public void UlepszanieBudynkuOsada1(Materialy material, int ilosc, Materialy material2, int ilosc2, Budowle budowle)
        {
            if (progressBar2.Visible == false)
            {
                if (budowle.pictureBox.Visible == true)
                {
                    if (material.quantity >= (ilosc * budowle.poziomUlepszenia^2) && material2.quantity >= (ilosc2 * budowle.poziomUlepszenia^2))
                    {
                        if (budowle.poziomUlepszenia < 3)
                        {
                            material.quantity -= ilosc;
                            material2.quantity -= ilosc2;
                            progressBar2.Location = budowle.punkt;
                            progressBar2.Visible = true;
                            progressBar2.Maximum = budowle.ZwrocCzasTrwaniaUlepszania();
                            nazwaBudowliUlepszenie = budowle.nazwa;
                            timerCzasUlepszenia.Start();
                        }
                        else
                        {
                            MessageBox.Show("Maksymalny poziom ulepszenia!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Brak określonych surowców!");
                    }
                }
                else
                {
                    MessageBox.Show("Budynek nie jest wybudowany!");
                }
            }
            else
            {
                MessageBox.Show("W jednym momencie możesz ulepszać tylko jeden budynek!");
            }
        }

        public void UlepszanieBudynkuInstancja1(Materialy material, int ilosc, Materialy material2, int ilosc2, Budowle budowla)
        {
            if (budowla.progressBarUlepszanie.Visible == false)
            {
                if (material.quantity >= (ilosc * budowla.poziomUlepszenia ^ 2) && material2.quantity >= (ilosc2 * budowla.poziomUlepszenia ^ 2))
                {
                    material.quantity -= ilosc;
                    material2.quantity -= ilosc2;
                    budowla.progressBarUlepszanie.Location = budowla.punkt;
                    budowla.pictureBox.Visible = false;
                    budowla.progressBarUlepszanie.Visible = true;
                    budowla.progressBarUlepszanie.Maximum = budowla.ZwrocCzasTrwaniaUlepszania();
                    nazwaBudowliUlepszenie = budowla.nazwa;
                    timerCzasUlepszenia.Start();
                }
                else
                {
                    MessageBox.Show("Brak określonych surowców");
                }
            }
            else
            {
                MessageBox.Show("W jednym momencie możesz ulepszać tylko jeden budynek");
            }
        }

        public void UlepszanieBudynkuOsada2(Budowle budowle)
        {
            if (progressBar2.Value == progressBar2.Maximum)
            {
                timerCzasUlepszenia.Stop();
                budowle.poziomUlepszenia++;
                progressBar2.Visible = false;
                progressBar2.Value = 0;
                textBoxInformacja.AppendText("Ulepszono " + budowle.nazwa + " do poziomu " + budowle.poziomUlepszenia + "!");
                textBoxInformacja.AppendText(Environment.NewLine);
            }
            else
            {
                progressBar2.Increment(10);
            }
        }

        public void UlepszanieBudynkuInstancja2(Budowle budowla)
        {
            if(budowla.progressBarUlepszanie.Value == budowla.progressBarUlepszanie.Maximum)
            {
                timerCzasUlepszenia.Stop();
                budowla.poziomUlepszenia++;
                budowla.pictureBox.Visible = true;
                budowla.progressBarUlepszanie.Visible = false;
                budowla.progressBarUlepszanie.Value = 0;
                textBoxInformacja.AppendText("Ulepszono " + budowla.nazwa + " do poziomu " + budowla.poziomUlepszenia + "!");
                textBoxInformacja.AppendText(Environment.NewLine);
            }
            else
            {
                budowla.progressBarUlepszanie.Increment(10);
            }
        }

        private void PictureBoxMur_Click(object sender, EventArgs e)
        {
            new EkranLadowania(o, this, new Size(820, 539), 4).Show();
        }

        private void TimerCzasUlepszenia_Tick(object sender, EventArgs e)
        {
            switch (nazwaBudowliUlepszenie)
            {
                case "pierwszy tartak":
                    UlepszanieBudynkuOsada2(tartak1);
                    break;
                case "drugi tartak":
                    UlepszanieBudynkuOsada2(tartak2);
                    break;
                case "pierwszy kamieniołom":
                    UlepszanieBudynkuOsada2(kamieniolom1);
                    break;
                case "drugi kamieniołom":
                    UlepszanieBudynkuOsada2(kamieniolom2);
                    break;
                case "chatka rolnika":
                    UlepszanieBudynkuOsada2(chatkaRolnika);
                    break;
                case "magazyn":
                    UlepszanieBudynkuOsada2(magazyn);
                    break;
                case "budynek mieszkalny":
                    UlepszanieBudynkuOsada2(budynekMieszkalny);
                    break;
                case "koszary":
                    UlepszanieBudynkuOsada2(koszary);
                    break;
                case "targowisko":
                    UlepszanieBudynkuOsada2(targowisko);
                    break;
                case "kuznia":
                    UlepszanieBudynkuOsada2(kuznia);
                    break;
                case "chata maga":
                    UlepszanieBudynkuOsada2(chataMaga);
                    break;
                case "kwatera rybacka":
                    UlepszanieBudynkuOsada2(kwateraRybacka);
                    break;
                case "most":
                    UlepszanieBudynkuOsada2(most);
                    break;
                case "mur":
                    UlepszanieBudynkuOsada2(mur);
                    break;
                case "hodowla":
                    UlepszanieBudynkuOsada2(hodowla);
                    break;
                case "studnia":
                    UlepszanieBudynkuOsada2(studnia);
                    break;
                case "kopalnia kamienia":
                    UlepszanieBudynkuInstancja2(kopalniaKamienia);
                    break;
                case "pierwsza kopalnia rudy zelaza":
                    UlepszanieBudynkuInstancja2(kopalniaRudyZelaza1);
                    break;
                case "druga kopalnia rudy zelaza":
                    UlepszanieBudynkuInstancja2(kopalniaRudyZelaza2);
                    break;
            }
        }
    }
}