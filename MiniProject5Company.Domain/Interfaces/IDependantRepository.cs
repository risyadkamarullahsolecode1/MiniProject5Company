using MiniProject5Company.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject5Company.Domain.Interfaces
{
    public interface IDependantRepository
    {
        Task<IEnumerable<Dependant>> GetAllDependant();
        Task<Dependant> GetDependantById(int dependantno);
        Task<Dependant> AddDependant(Dependant dependant);
        Task<Dependant> UpdateDependant(Dependant dependant);
        Task<bool> DeleteDependant(int dependantno);
    }
}
