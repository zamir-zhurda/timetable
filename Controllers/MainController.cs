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

        [HttpGet("/api/ditet")]
        public async Task<IEnumerable<DitetResource>> TerhiqDitet()
        {
            var ditet = await _context.Ditet.ToListAsync();

            return _mapper.Map<List<Ditet>, List<DitetResource>>(ditet);
        }

        [HttpGet("/api/lendet")]
        public async Task<IEnumerable<LendetResource>> TerhiqLendet()
        {
            List<Lendet> lendet = await _context.Lendet.ToListAsync();
            var results = from lenda in lendet
                          group lenda.Dega by lenda.Id into g
                          select new { DegaId = g.Key, Dega = g.ToList() };
            Debug.WriteLine("\n results: ", results);
            return _mapper.Map<List<Lendet>, List<LendetResource>>(lendet);
        }

        [HttpGet("/api/deget")]
        public async Task<IEnumerable<DegetResource>> TerhiqDeget()
        {
            var deget = await _context.Deget.ToListAsync();

            return _mapper.Map<List<Deget>, List<DegetResource>>(deget);
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
        // public async Task<IEnumerable<>> RuajEventet([FromBody] )
        // {
        //     var object = _mapper.Map <
        // }
    }
}