using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proiect_CSharp_MPP.TouristAgency.Domain;

namespace Persistence
{
    public interface ICRUDRepository<ID, E> where E : Entity<ID>
    {
        E FindOne(ID id);
        IEnumerable<E> FindAll();
        void Add(E entity);
        void Delete(E entity);
        void Update(E entity, int id);
    }
}
