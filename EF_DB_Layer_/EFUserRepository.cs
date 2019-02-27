﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SportsClubModel;

namespace EF_DB_Layer
{
    public class EFUserRepository : IUserRepository
    {
        private ApplicationDbContext context;

        public EFUserRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<User> Users => context.Users;

        public void AddUser(User user)
        {
            context.Add(user);
        }

        public void RemoveUser(int userId)
        {
            var user = context.Users.Where(x => x.UserId == userId).First();
            context.Remove(user);
        }

        public async Task<User[]> GetAllUsersAsync()
        {
            return await context.Users.ToArrayAsync();
        }

        public async Task<User[]> GetAllUsersByLastNameAsync(string token)
        {
            return await context.Users.Where(r => r.LastName.Contains(token)).ToArrayAsync();
        }

        public async Task<User[]> GetBestWinner()
        {
            var max = context.Users.Max(r => r.Wins);
            return await context.Users.Where(r => r.Wins == max).ToArrayAsync();
        }

        public async Task<User[]> GetUsersByDateOfBirthRange(DateTime start, DateTime end)
        {
            start = start.Date;
            end = end.Date;

            return await context.Users.Where(r => r.BirthDate > start && r.BirthDate < end).ToArrayAsync();
        }


    }
}