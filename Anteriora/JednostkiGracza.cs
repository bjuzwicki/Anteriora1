﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anteriora
{
    public class JednostkiGracza : JednostkiMilitarne
    {
        public int liczebnoscWojsk { get; set; }

        readonly Poczatek o;

        public JednostkiGracza(string nazwa, int atakDomyslny, int obronaDomyslna, int PZDomyslne, int ilosc, int odlegloscAtaku, bool czyAtakNaBliskiDystans,
                                Bitmap obrazekPrawo, Bitmap obrazekLewo, Bitmap obrazekGora, Bitmap obrazekDol)
        {
            this.nazwa = nazwa;
            this.poziomUlepszenia = 1;
            this.atakDomyslny = atakDomyslny;
            this.obronaDomyslna = obronaDomyslna;
            this.PZDomyslne = PZDomyslne;
            this.ilosc = ilosc;
            this.odlegloscAtaku = odlegloscAtaku;
            this.czyAtakNaBliskiDystans = czyAtakNaBliskiDystans;
            this.obrazekPrawo = obrazekPrawo;
            this.obrazekLewo = obrazekLewo;
            this.obrazekGora = obrazekGora;
            this.obrazekDol = obrazekDol;
        }

        //zwiadowca
        public JednostkiGracza()
        {
            this.atakDomyslny = 30;
            this.poziomUlepszenia = 1;
        }

        public int ObliczLiczebnoscWojsk()
        {
            return liczebnoscWojsk = o.zwiadowca.ilosc + o.piechur.ilosc + o.lucznik.ilosc + o.rycerz.ilosc + o.czarnyRycerz.ilosc + o.czarnyLucznik.ilosc;
        }
    }
}
