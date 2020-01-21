using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using timetable.Models;
using timetable.Persistence;
using timetable.Resources;

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
            var lendet = await _context.Lendet.ToListAsync();

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
    }
}