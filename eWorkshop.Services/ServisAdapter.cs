using eWorkshop.Model;
using eWorkshop.Model.SearchObject;
using eWorkshop.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services
{
    public class ServisAdapter : IServisAdapter
    {
        IReparacijaService Reparacija { get; }
        IServisIzvrsenService IzvrseniServis { get; }

        public ServisAdapter(IReparacijaService reparacija, IServisIzvrsenService izvrseniServis)
        {
            Reparacija = reparacija;
            IzvrseniServis = izvrseniServis;
        }

        public List<ServisIzvrsenFlutterVM> Servis(int id)
        {
            ReparacijaSearchObject searchReparacija = new ReparacijaSearchObject();
            searchReparacija.UredjajId = id;

            ServisIzvrsenSearchObject searchServisIzvrsen = new ServisIzvrsenSearchObject();
            searchServisIzvrsen.UredjajId = id;

            var reparacija = Reparacija.Get(searchReparacija).ToList();

            var servisIzvrsen = IzvrseniServis.Get(searchServisIzvrsen).ToList();

            List<ServisIzvrsenFlutterVM> servisKomponente = new List<ServisIzvrsenFlutterVM>();

            foreach (var item in reparacija)
            {
                for (int i = 0; i < servisIzvrsen.Count; i++)
                {
                    if (item.ServisId == servisIzvrsen[i].ServisId)
                    {
                        servisKomponente.Add(new ServisIzvrsenFlutterVM()
                        {
                            Datum = DatumHelper.DatumFormat(item.Datum) == null ? "Nepoznato" : DatumHelper.DatumFormat(item.Datum),
                            ServisId = item.ServisId,
                            Servisirao = "Asad Tabak",
                            UredjajId = id,
                            Naziv = servisIzvrsen[i].Komponenta?.Naziv,
                            Tip = servisIzvrsen[i].Komponenta?.Tip,
                            Vrijednost = servisIzvrsen[i].Komponenta?.Vrijednost,
                            KomponentaId = servisIzvrsen[i].KomponentaId
                        });
                    }
                }
            }

            return servisKomponente;
        }
    }
}
