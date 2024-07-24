using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Model.Helpers
{
    public class StatusHelper
    {
    
            public  static string[] nizNaziv = { "idle", "active", "fix", "ready", "out", "parts", "task" };
            public static string[] nizOpis = { "Idle", "Aktivni uređaji", "Servisirani uređaji", "Spremni uređaji", "Poslani uređaji", "Rezervni uređaji", "Radni zadatak" };

            public static string[] nizNazivZadatak = { "idle", "active", "done", "invoice" };
            public static string[] nizOpisZadatak = { "Neaktivan", "Aktivan", "Završen", "Fakturisan" };

            public static string ProvjeraStatusa(string statusNaziv, string[] provjeraNaziv, string[] provjeraOpis)
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

