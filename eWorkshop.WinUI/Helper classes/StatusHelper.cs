using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.WinUI.Helper_classes
{
    public class StatusHelper
    {
        public string[] nizNaziv = { "idle", "active", "fix", "ready", "out", "parts" };
        public string[] nizOpis = { "Idle", "Aktivni uređaji", "Servisirani uređaji", "Spremni uređaji", "Poslani uređaji", "Rezervni uređaji" };

        public string ProvjeraStatusa(string statusNaziv)
        {
            for (int i = 0; i < nizNaziv.Length; i++)
            {
                if (nizNaziv[i] == statusNaziv)
                {
                    return nizOpis[i];
                }
            }
            return "Ne postoji";
        }
    }
}
