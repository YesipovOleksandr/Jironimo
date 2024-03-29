﻿using AutoMapper;
using Jironimo.Common.Abstract;
using Jironimo.Common.Abstract.Repository;
using Jironimo.Common.Models.Aplications;
using Jironimo.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;

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

        public Guid Create(Application application)
        {
            var newApplication = _mapper.Map<Entities.Application>(application);
            _context.Add(newApplication);
            _context.SaveChanges();
            return newApplication.Id;
        }

        public List<Application> GetAll()
        {
            var applicationsEntity = _context.Applications.Include(a => a.Category).ToList();
            var applicationsList = _mapper.Map<List<Application>>(applicationsEntity);
            return applicationsList;
        }

        public Application GetById(Guid applicationId)
        {
            var applicationsEntity = _context.Applications.FirstOrDefault(x => x.Id == applicationId);
            var application = _mapper.Map<Application>(applicationsEntity);
            return application;
        }

        public Application GetByName(string nameProject)
        {
            var applicationsEntity = _context.Applications.FirstOrDefault(x => x.Title == nameProject);
            var application = _mapper.Map<Application>(applicationsEntity);
            return application;
        }

        public List<Application> GetAplicationsWithDetails()
        {
            var applicationsEntity = _context.Applications.Include(a => a.ApplicationDetails).ToList();
            var applicationsList = _mapper.Map<List<Application>>(applicationsEntity);
            return applicationsList;
        }


        public List<Application> GetByCategoryId(Guid categoryId)
        {
            var applicationsEntity = _context.Applications.Where(x => x.CategoryId == categoryId);
            var applicationsList = _mapper.Map<List<Application>>(applicationsEntity);
            return applicationsList;
        }

        public void Update(Application model)
        {
            var application = _mapper.Map<Entities.Application>(model);
            _context.Update(application);
        }

        public void DeleteById(Guid id)
        {
            var application = _context.Applications.Find(id);
            if (application != null)
                _context.Applications.Remove(application);
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