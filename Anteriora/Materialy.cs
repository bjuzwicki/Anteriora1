using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anteriora
{
    /// <summary>
    /// klasa Materiały określa cechy możliwych do zdobycia surowców
    /// </summary>
    public class Materialy
    {
        public int quantity { get; set; }
        public int improvementLevel { get; set; }
        // jesli glod = 1 to brak glodu a gdy = 2 to glod
        public static int glod = 1;
        public int exploitationLevel { get; set; }
        public string code { get; set; }
        public const int oreAmountNeeded = 9;
        public Bitmap picture { get; set; }

        public Materialy(int ilosc, int poziomEksploatacji = 0)
        {
            this.quantity = ilosc;
            this.exploitationLevel = poziomEksploatacji;
        }

        // z każdym poziomem ulepszenia budowli(lub kilku tych samych) rośnie ilość zdobywanych surowców
        public int ZwiekszPrzyrostMaterialu()
        {
            quantity += (exploitationLevel * improvementLevel) / glod;
            return (exploitationLevel * improvementLevel) / glod;
        }

        public void ObliczPoziomUlepszenia(int poziomUlepszenia1, int poziomUlepszenia2)
        {
            improvementLevel = poziomUlepszenia1 + poziomUlepszenia2;
        }

        public void ObliczPoziomUlepszenia(int poziomUlepszenia1, int poziomUlepszenia2, int poziomUlepszenia3)
        {
            improvementLevel = poziomUlepszenia1 + poziomUlepszenia2 + poziomUlepszenia3;
        }

    }
}
