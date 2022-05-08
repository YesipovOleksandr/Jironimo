﻿using AutoMapper;
using Jironimo.Common.Abstract.Repository;
using Jironimo.Common.Models.User;
using Jironimo.DAL.Context;

namespace Jironimo.DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        protected readonly ApplicationDbContext _context;
        protected readonly IMapper _mapper;

        public UserRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool Create(User user)
        {
            var newUser = _mapper.Map<Entities.User>(user);
            _context.Add(newUser);
            _context.SaveChanges();

            return true;
        }

        public User Get(string login)
        {
            var user = _mapper.Map<User>(_context.Users.FirstOrDefault(x => x.Login == login));

            return user;
        }
    }
}
