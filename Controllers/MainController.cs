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

        [HttpGet("/api/lendet")]
        public async Task<IEnumerable<LendetResource>> TerhiqLendet()
        {
            var features = await _context.Lendet.ToListAsync();

            return _mapper.Map<List<Lendet>, List<LendetResource>>(features);
        }
    }
}