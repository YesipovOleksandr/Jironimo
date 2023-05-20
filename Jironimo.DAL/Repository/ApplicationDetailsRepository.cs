using AutoMapper;
using Jironimo.Common.Abstract.Repository;
using Jironimo.Common.Models.Aplications;
using Jironimo.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;

namespace Jironimo.DAL.Repository
{
    public class ApplicationDetailsRepository : IApplicationDetailsRepository
    {
        protected readonly ApplicationDbContext _context;
        protected readonly IMapper _mapper;

        public ApplicationDetailsRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Create(ApplicationDetails applicationDetails)
        {
            var newApplicationDetails = _mapper.Map<Entities.ApplicationDetails>(applicationDetails);
            _context.Add(newApplicationDetails);
        }

        public List<ApplicationDetails> GetByIdByApplication(Guid applicationId)
        {
            var applicationsDetailsEntity = _context.ApplicationDetails.Where(x => x.ApplicationId == applicationId);
            var applicationsDetails = _mapper.Map<List<ApplicationDetails>>(applicationsDetailsEntity);
            return applicationsDetails;
        }

        public List<ApplicationDetails> GetAplicationsDetailsByName(string nameProject)
        {
            var applicationsDetailsEntity = _context.ApplicationDetails.Include(x=>x.Application).Where(x => x.Application.Title == nameProject);
            var applicationsDetails = _mapper.Map<List<ApplicationDetails>>(applicationsDetailsEntity);
            return applicationsDetails;
        }

        public ApplicationDetails GetById(Guid id)
        {
            var applicationsDetailsEntity = _context.ApplicationDetails.FirstOrDefault(x => x.Id == id);
            var applicationsDetails = _mapper.Map<ApplicationDetails>(applicationsDetailsEntity);
            return applicationsDetails;
        }

        public void Delete(Guid id)
        {
            var applicationDetails = _context.ApplicationDetails.Find(id);
            if (applicationDetails != null)
                _context.ApplicationDetails.Remove(applicationDetails);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}