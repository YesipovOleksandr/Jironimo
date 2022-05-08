using AutoMapper;
using Jironimo.Common.Abstract;
using Jironimo.Common.Abstract.Repository;
using Jironimo.Common.Models.Aplications;
using Jironimo.DAL.Context;

namespace Jironimo.DAL.Repository
{
    public class ApplicationRepository : IApplicationRepository
    {
        protected readonly ApplicationDbContext _context;
        protected readonly IMapper _mapper;

        public ApplicationRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Add(Application application)
        {
            var newApplication = _mapper.Map<Entities.Application>(application);
            _context.Add(newApplication);
            _context.SaveChanges();
        }

        public List<Application> Get()
        {
            var list = _context.Applications.Select(x => new Application(x.Title, x.Description, x.ImagePath, x.PositionRight)).ToList();
            return list;
        }
    }
}
