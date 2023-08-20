using DssProjectElephant.Data;
using DssProjectElephant.Interfaces;
using DssProjectElephant.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DssProjectElephant.Repository
{
    public class NewsRepository : INewsRepository
    {
        private readonly ApplicationDbContent _context;

        public NewsRepository(ApplicationDbContent context)
        {
            _context = context;
        }

        public bool Add(TheNews news)
        {
            _context.TheNews.Add(news);
            return Save();
        }

        public bool Delete(TheNews news)
        {
            _context.TheNews.Remove(news);
            return Save();
        }

        public async Task<IEnumerable<TheNews>> GetAll()
        {
            return await _context.TheNews.ToListAsync();
        }

        public async Task<TheNews> GetByIdAsync(int id)
        {
            return await _context.TheNews.FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task<IEnumerable<TheNews>> GetNewsByCity(string city)
        {
            return await _context.TheNews.Where(n => n.Address.State.Contains(city)).ToListAsync();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public bool Update(TheNews news)
        {
            _context.TheNews.Update(news);
            return Save();
        }
    }
}

