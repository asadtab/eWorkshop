using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.WinUI.Helper_classes
{
    public class StatusHelper
    {
        public string[] nizNaziv = { "idle", "active", "fix", "ready", "out", "parts", "task" };
        public string[] nizOpis = { "Idle", "Aktivni uređaji", "Servisirani uređaji", "Spremni uređaji", "Poslani uređaji", "Rezervni uređaji", "Radni zadatak" };

        public string[] nizNazivZadatak = { "idle", "active", "done", "invoice"};
        public string[] nizOpisZadatak = { "Neaktivan", "Aktivan", "Završen", "Fakturisan"};

        public string ProvjeraStatusa(string statusNaziv, string[] provjeraNaziv, string[] provjeraOpis)
        {
            for (int i = 0; i < provjeraNaziv.Length; i++)
            {
                if (provjeraNaziv[i] == statusNaziv)
                {
                    return provjeraOpis[i];
                }
            }
            return "Ne postoji";
        }
    }
}
