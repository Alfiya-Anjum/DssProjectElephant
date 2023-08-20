using DssProjectElephant.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DssProjectElephant.Interfaces
{
    public interface INewsRepository
    {
        Task<IEnumerable<TheNews>> GetAll();
        Task<TheNews> GetByIdAsync(int id);
        Task<IEnumerable<TheNews>> GetNewsByCity(string city);
        bool Add(TheNews news);
        bool Update(TheNews news);
        bool Delete(TheNews news);
        bool Save();
    }
}
