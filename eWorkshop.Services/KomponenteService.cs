using AutoMapper;
using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Model.SearchObject;
using eWorkshop.Services.Database;
using eWorkshop.Services.MLService;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services
{
    public class KomponenteService : BaseCRUDService<KomponenteVM, KomponenteSearchObject, Komponente, KomponenteUpsertRequest, KomponenteUpsertRequest>, IKomponenteService
    {
        public IServisIzvrsenService ServisIzvrsen { get; set; }
        public IUredjajService UredjajService { get; set; }
        public KomponenteService(_190128Context context, IMapper mapper, IServisIzvrsenService servisIzvrsen, IUredjajService uredjajService) : base(context, mapper)
        {
            ServisIzvrsen = servisIzvrsen;
            UredjajService = uredjajService;
        }

        public override IQueryable<Komponente> AddFilter(IQueryable<Komponente> query, KomponenteSearchObject search = null)
        {
            var filter = base.AddFilter(query, search);

            if(!string.IsNullOrEmpty(search.Tip))
            {
                filter = filter.Where(x => x.Tip.ToLower() == search.Tip.ToLower());
            }

            if (!string.IsNullOrEmpty(search.Naziv))
            {
                filter = filter.Where(x => x.Naziv.ToLower() == search.Naziv.ToLower());
            }

            if (!string.IsNullOrEmpty(search.Opis))
            {
                filter = filter.Where(x => x.Opis.ToLower() == search.Opis.ToLower());
            }

            if (!string.IsNullOrEmpty(search.Vrijednost))
            {
                filter = filter.Where(x => x.Vrijednost.ToLower() == search.Vrijednost.ToLower());
            }

           

            return filter;
        }

        public List<IzvrseniServisEntry> test ()
        {
            var tempData = Context.Servis.Include("IzvrseniServis").Where(x => x.IzvrseniServis.Count > 1).ToList();

            var data = new List<IzvrseniServisEntry>();

            foreach (var item in tempData)
            {
                if (item.IzvrseniServis.Count > 1)
                {
                    var distinct = item.IzvrseniServis.Select(x => x.KomponentaId).ToList();

                    distinct.ForEach(x =>
                    {
                        var relatedParts = item.IzvrseniServis.Where(y => y.KomponentaId != x);

                        foreach (var z in relatedParts)
                        {
                            data.Add(new IzvrseniServisEntry()
                            {
                                KomponentaID = (uint)x,
                                WithThisKomponentaID = (uint)z.KomponentaId,
                            });
                        }
                    });
                }
            }

            return data;
        }


        public List<KomponenteVM> Recommend(int id)
        {
            MLContext mlContext = new MLContext();

            var tempData = Context.Servis.Include("IzvrseniServis").Where(x => x.IzvrseniServis.Count > 1).ToList();

            var data = new List<IzvrseniServisEntry>();

            foreach (var x in tempData)
            {
                if(x.IzvrseniServis.Count > 1)  
                {
                    var distinct = x.IzvrseniServis.Select(y => y.KomponentaId).ToList();

                    distinct.ForEach(y =>
                    {
                        var relatedParts = x.IzvrseniServis.Where(z => z.KomponentaId != y);

                        foreach (var z in relatedParts)
                        {
                            data.Add(new IzvrseniServisEntry()
                            {
                                KomponentaID = (uint)y,
                                WithThisKomponentaID = (uint)z.KomponentaId,
                            });
                        }
                    });
                }
            }

            
            var traindata = mlContext.Data.LoadFromEnumerable(data);

            var traindata2 = mlContext.Data.LoadFromEnumerable(data);


            MatrixFactorizationTrainer.Options options = new MatrixFactorizationTrainer.Options();
            options.MatrixColumnIndexColumnName = nameof(IzvrseniServisEntry.WithThisKomponentaID);
            options.MatrixRowIndexColumnName = nameof(IzvrseniServisEntry.KomponentaID);
            options.LabelColumnName = nameof(IzvrseniServisEntry.Label);
            options.LossFunction = MatrixFactorizationTrainer.LossFunctionType.SquareLossOneClass;
            options.Alpha = 0.01;
            options.Lambda = 0.025;
            // For better results use the following parameters
            options.NumberOfIterations = 5000000;
            options.C = options.C = 0.00001;
           
            var est = mlContext.Recommendation().Trainers.MatrixFactorization(options);

            var preview = traindata.Preview(maxRows: 10); // Get the first 10 rows of data
            var schema = preview.Schema;
            var numRows = preview.RowView.Length;

            Console.WriteLine($"Number of rows in preview: {numRows}");
            Console.WriteLine("Column names and types:");
            foreach (var column in schema)
            {
                Console.WriteLine($"{column.Name}: {column.Type}");
            }

            foreach (var row in preview.RowView)
            {
                Console.WriteLine("Row:");
                foreach (var column in row.Values)
                {
                    Console.WriteLine($"  {column.Key}: {column.Value}");
                }
            }

            ITransformer model = est.Fit(traindata);

            var allItems = Context.Komponentes.Where(x => x.KomponentaId != id);

            var predictionResult = new List<Tuple<Komponente, float>>();

            foreach (var item in allItems)
            {
                var predictionEngine = mlContext.Model.CreatePredictionEngine<IzvrseniServisEntry, IzvrseniServisPrediction>(model);
                var prediction = predictionEngine.Predict(new IzvrseniServisEntry()
                {
                    WithThisKomponentaID = (uint)id,
                    KomponentaID = (uint)item.KomponentaId
                });

                predictionResult.Add(new Tuple<Komponente, float>(item, prediction.Score));
            }

            var finalResult = predictionResult.OrderByDescending(x => x.Item2).Select(x => x.Item1).Take(10).ToList();

            return Mapper.Map<List<KomponenteVM>>(finalResult);
        }
    }
}
