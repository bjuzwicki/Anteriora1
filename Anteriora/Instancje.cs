using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Anteriora
{
    public class Instancje
    {
        public string nazwa { get; set; }
        public int czasRuchuWrogow { get; set; }
        public int czasWroga { get; set; }
        public int czasRuchuZwiadowcy { get; set; }
        public int czasZwiadowcy { get; set; }
        public int licznikZwiadowca { get; set; }
        public bool akcjaWrog { get; set; }
        public bool akcjaZwiadowca { get; set; }
        public string obrazekLewo { get; set; }
        public string obrazekGora { get; set; }
        public string obrazekDol { get; set; }
        public bool enablePoziom1 { get; set; }
        public bool enablePoziom2 { get; set; }
        public bool enablePoziom3 { get; set; }
        public bool enablePoziom4 { get; set; }
        public bool enablePoziom5 { get; set; }
        public int postep { get; set; }
        public bool czyBlokadaIstnieje1 { get; set; }
        public bool czyBlokadaIstnieje2 { get; set; }
        public bool czyBudowlaIstnieje1 { get; set; }
        public bool czyBudowlaIstnieje2 { get; set; }
        public bool czyBudowlaIstnieje3 { get; set; }
        public Timer timerMapa { get; set; }

        public Instancje(string nazwa, int czasRuchuWrogow, int czasRuchuZwiadowcy, string obrazekLewo, string obrazekGora, string obrazekDol, bool czyBlokadaIstnieje1 = true, bool czyBlokadaIstnieje2 = true,
                          bool czyBudowlaIstnieje1 = false, bool czyBudowlaIstnieje2 = false, bool czyBudowlaIstnieje3 = false, int czasWroga = 0, int czasZwiadowcy = 0, int licznikZwiadowca = 1, bool akcjaWrog = false,
                          int postep = 0, bool akcjaZwiadowca = false, bool enablePoziom1 = true, bool enablePoziom2 = true, bool enablePoziom3 = true, bool enablePoziom4 = true, bool enablePoziom5 = true)
        {
            this.nazwa = nazwa;
            this.czasRuchuWrogow = czasRuchuWrogow;
            this.czasRuchuZwiadowcy = czasRuchuZwiadowcy;
            this.obrazekLewo = obrazekLewo;
            this.obrazekGora = obrazekGora;
            this.obrazekDol = obrazekDol;

            this.czyBlokadaIstnieje1 = czyBlokadaIstnieje1;
            this.czyBlokadaIstnieje2 = czyBlokadaIstnieje2;
            this.czyBudowlaIstnieje1 = czyBudowlaIstnieje1;
            this.czyBudowlaIstnieje2 = czyBudowlaIstnieje2;
            this.czyBudowlaIstnieje3 = czyBudowlaIstnieje3;

            this.czasWroga = czasWroga;
            this.czasZwiadowcy = czasZwiadowcy;
            this.licznikZwiadowca = licznikZwiadowca;
            this.akcjaWrog = akcjaWrog;
            this.postep = postep;
            this.akcjaZwiadowca = akcjaZwiadowca;
            this.enablePoziom1 = enablePoziom1;
            this.enablePoziom2 = enablePoziom2;
            this.enablePoziom3 = enablePoziom3;
            this.enablePoziom4 = enablePoziom4;
            this.enablePoziom5 = enablePoziom5;
        }
    }
}
