/*using DssProjectElephant.Controllers;
using DssProjectElephant.Data;
using DssProjectElephant.Interfaces;
using DssProjectElephant.Models;
using Microsoft.EntityFrameworkCore;

namespace DssProjectElephant.Repository
{
    public class ClubRepository : IClubRepository
    {
        private readonly ApplicationDbContent _content;
        public ClubRepository(ApplicationDbContent context)
        { 
            _content = context;
        }

        public bool Add(Club club)
        {
          _content.Add(club);
            return Save();

        }

        public bool Delete(Club club)
        {
           _content.Remove(club);
            return Save();
        }

        public async Task<IEnumerable<Club>> GetAll()
        {
            return await _content.Clubs.ToListAsync();
        }

        public async Task<Club> GetByIdAsync(int id)
        {
            return await _content.Clubs.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Club>> GetClubByCity(string city)
        {
            return await _content.Clubs.Where(c => c.Address.State.Contains(city)).ToListAsync();
        }

        public bool Save()
        {
            var saved = _content.SaveChanges();
            return saved > 0? true: false;
        }

        public bool Update(Club club)
        {
            _content.Update(club);
            return Save();
        }
    }
}*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DssProjectElephant.Data;
using DssProjectElephant.Interfaces;
using DssProjectElephant.Models;
using Microsoft.EntityFrameworkCore;

namespace DssProjectElephant.Repository
{
    public class ClubRepository : IClubRepository
    {
        private readonly ApplicationDbContent _context;

        public ClubRepository(ApplicationDbContent context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Club>> GetAll()
        {
            return await _context.Clubs.ToListAsync();
        }

        public async Task<Club> GetByIdAsync(int id)
        {
            return await _context.Clubs.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Club>> GetClubByCity(string city)
        {
            return await _context.Clubs.Where(c => c.Address.State.Contains(city)).ToListAsync();
        }

        public bool Add(Club club)
        {
            try
            {
                _context.Clubs.Add(club);
                return Save();
            }
            catch (Exception ex)
            {
                // Handle exception or log error
                return false;
            }
        }

        public bool Update(Club club)
        {
            try
            {
                _context.Clubs.Update(club);
                return Save();
            }
            catch (Exception ex)
            {
                // Handle exception or log error
                return false;
            }
        }

        public bool Delete(Club club)
        {
            try
            {
                _context.Clubs.Remove(club);
                return Save();
            }
            catch (Exception ex)
            {
                // Handle exception or log error
                return false;
            }
        }

        public bool Save()
        {
            try
            {
                var saved = _context.SaveChanges();
                return saved > 0;
            }
            catch (Exception ex)
            {
                // Handle exception or log error
                return false;
            }
        }
    }
}

