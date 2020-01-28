using System.Data.Common;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using timetable.Models;
using timetable.Persistence;
using timetable.Resources;
using System.Linq;
using System;
using System.Diagnostics;
namespace timetable.Controllers
{
    public class MainController : Controller
    {
        private readonly Persistence.TimeTableDbContext _context;
        private readonly IMapper _mapper;

        public MainController(Persistence.TimeTableDbContext timetableDbContext, IMapper mapper)
        {
            this._context = timetableDbContext;
            this._mapper = mapper;
        }


        [HttpGet("/api/importlendet")]
        public async Task<IEnumerable<ImportLendetResource>> TerhiqImportLendet()
        {
            var importLendet = await _context.ImportLendet.ToListAsync();

            return _mapper.Map<List<ImportLendet>, List<ImportLendetResource>>(importLendet);
        }
        [HttpGet("/api/orari")]
        public async Task<IEnumerable<OrariResource>> TerhiqOrarin()
        {
            var orari = await _context.Orari.ToListAsync();

            return _mapper.Map<List<Orari>, List<OrariResource>>(orari);
        }

        [HttpGet("/api/ditet")]
        public async Task<IEnumerable<DitetResource>> TerhiqDitet()
        {
            var ditet = await _context.Ditet.ToListAsync();

            return _mapper.Map<List<Ditet>, List<DitetResource>>(ditet);
        }

        [HttpGet("/api/lendet")]
        public async Task<IEnumerable<DegetLendetResource>> TerhiqLendet()
        {
            List<Lendet> oListLendet = await _context.Lendet.ToListAsync();
            // var results = from lenda in lendet
            //               group lenda.Dega by lenda.Id into g
            //               select new { DegaId = g.Key, Dega = g.ToList() };
            var groupedDegetLendetResource = oListLendet.GroupBy(lenda => lenda.Dega)
                                     .Select(group => new DegetLendetResource { DegaName = group.Key, Lendet = group.Select(lenda => new LendetResource { Id = lenda.Id, Lenda = lenda.Lenda }).ToList() }).ToList();
            Debug.WriteLine("\n results: ", groupedDegetLendetResource);
            // return _mapper.Map<List<Lendet>, List<LendetResource>>(lendet);
            return groupedDegetLendetResource;
        }

        // [HttpGet("/api/lendet2")]
        // public async Task<IEnumerable<DegetLendetResource>> TerhiqLendet2()
        // {
        //     List<Deget> oListDeget = await _context.Deget.ToListAsync();
        //     List<Lendet> oListLendet = await _context.Lendet.ToListAsync();

        //     var grouped = from dega in oListDeget
        //                   join lenda in oListLendet
        //                   on dega.Dega equals lenda.Dega
        //                   select new
        //                   {
        //                       DegaId = dega.Id,
        //                       DegaName = dega.Dega,
        //                       Lendet = oListLendet.Where(l => l.Dega == dega.Dega).ToList()
        //                   };

        //     var consolidateDeget = from dega in grouped
        //                            group dega by new
        //                            {
        //                                dega.DegaId,
        //                                dega.DegaName
        //                            } into gdl
        //                            select new DegetLendetResource
        //                            {
        //                                DegaId = gdl.Key.DegaId,
        //                                DegaName = gdl.Key.DegaName,
        //                                Lendet = gdl.Select(lenda => gdl.Lendet.Distinct())
        //                            };
        //     return consolidateDeget;

        // }

        [HttpGet("/api/deget")]
        public async Task<IEnumerable<DegetResource>> TerhiqDeget()
        {
            var deget = await _context.Deget.ToListAsync();

            return _mapper.Map<List<Deget>, List<DegetResource>>(deget);
        }

        [HttpGet("/api/deget/{id}")]
        public DegetResource TerhiqDegenById(Int32 id)
        {
            var deget = _context.Deget.Where(dega => dega.Id == id).SingleOrDefault();

            return _mapper.Map<Deget, DegetResource>(deget);
        }
        [HttpGet("/api/klasat")]
        public async Task<IEnumerable<KlasatResource>> TerhiqKlasat()
        {
            var klasat = await _context.Klasat.ToListAsync();

            return _mapper.Map<List<Klasat>, List<KlasatResource>>(klasat);
        }

        [HttpGet("/api/oret")]
        public async Task<IEnumerable<OretResource>> TerhiqOret()
        {
            var oret = await _context.Oret.ToListAsync();

            return _mapper.Map<List<Oret>, List<OretResource>>(oret);
        }

        [HttpGet("/api/tipet")]
        public async Task<IEnumerable<TipetResource>> TerhiqTipet()
        {
            var tipet = await _context.Tipet.ToListAsync();

            return _mapper.Map<List<Tipet>, List<TipetResource>>(tipet);
        }

        [HttpGet("/api/events")]
        public IList<EventResource> TerhiqEventet()
        {
            IList<EventResource> oListEvents = new List<EventResource>();


            EventResource event1 = new EventResource();
            event1.id = 1;
            event1.allDay = false;
            event1.title = "event 1";
            event1.description = "test description 1";
            event1.start = new System.DateTime(2020, 01, 25, 17, 20, 30); ;
            event1.end = new System.DateTime(2020, 01, 25, 17, 40, 30);
            oListEvents.Add(event1);

            EventResource event2 = new EventResource();
            event2.id = 2;
            event2.allDay = false;
            event2.title = "event 2";
            event2.description = "test description 2";
            event2.start = new System.DateTime(2020, 01, 28, 17, 00, 30);
            event2.end = new System.DateTime(2020, 01, 28, 17, 20, 30);
            oListEvents.Add(event2);

            EventResource event3 = new EventResource();
            event3.id = 3;
            event3.allDay = false;
            event3.title = "event 3";
            event3.description = "test description 3";
            event3.start = new System.DateTime(2020, 01, 30, 13, 00, 30);
            event3.end = new System.DateTime(2020, 01, 30, 14, 20, 30);
            oListEvents.Add(event3);

            EventResource event4 = new EventResource();
            event4.id = 4;
            event4.allDay = false;
            event4.title = "event 4";
            event4.description = "test description 4";
            event4.start = new System.DateTime(2020, 01, 31, 14, 00, 30);
            event4.end = new System.DateTime(2020, 01, 31, 15, 20, 30);
            oListEvents.Add(event4);
            return oListEvents;
        }

        [HttpGet("/api/subjects/{degreeId}")]
        public IList<EventResource> FetchSubjectsByDegreeId(string degreeId)
        {
            Deget dega = _context.Deget.Where(degree => degree.Id == Convert.ToInt32(degreeId)).FirstOrDefault();
            List<Lendet> allSubjectsOfCurrentDegree = _context.Lendet.Where(lenda => lenda.Dega == dega.Dega).ToList();

            DegetLendetResource degetLendetResource = new DegetLendetResource();


            degetLendetResource.DegaId = dega.Id;
            degetLendetResource.DegaName = dega.Dega;
            degetLendetResource.Lendet = _mapper.Map<List<Lendet>, List<LendetResource>>(allSubjectsOfCurrentDegree);

            List<EventResource> oListEvents = convertSubjectsToEvents(degetLendetResource);

            // return groupedDegetLendetResource;
            return oListEvents;

        }


        private List<EventResource> convertSubjectsToEvents(DegetLendetResource degetLendetResource)
        {
            List<EventResource> oListEvents = new List<EventResource>();

            foreach (var lenda in degetLendetResource.Lendet)
            {
                EventResource eventResource = new EventResource();
                eventResource.id = lenda.Id;
                eventResource.title = lenda.Lenda;
                eventResource.description = degetLendetResource.DegaName;
            }

            return oListEvents;
        }
    }
}