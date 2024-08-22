using Microsoft.EntityFrameworkCore;
using MiniProject5Company.Domain.Entities;
using MiniProject5Company.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject5Company.Infrastructure.Data.Repository
{
    public class DependantRepository:IDependantRepository
    {
        private readonly CompanyFinancialContext _context;

        public DependantRepository(CompanyFinancialContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Dependant>> GetAllDependant()
        {
            return await _context.Dependants.ToListAsync();
        }
        public async Task<Dependant> GetDependantById(int dependantno)
        {
            return await _context.Dependants.FindAsync(dependantno);
        }
        public async Task<Dependant> AddDependant(Dependant dependant)
        {
            _context.Dependants.Add(dependant);
            await _context.SaveChangesAsync();
            return dependant;
        }
        public async Task<Dependant> UpdateDependant(Dependant dependant)
        {
            _context.Dependants.Update(dependant);
            await _context.SaveChangesAsync();
            return dependant;
        }
        public async Task<bool> DeleteDependant(int dependantno)
        {
            var dependant = await _context.Dependants.FindAsync(dependantno);
            if (dependant == null)
            {
                return false;
            }
            _context.Dependants.Remove(dependant);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
