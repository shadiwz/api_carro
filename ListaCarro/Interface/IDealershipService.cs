using ListaCarro.Models;
using System.Collections.Generic;

namespace ListaCarro.Interface
{
    public interface IDealershipService
    {
        List<Dealership> GetAll();
        Dealership Get(string id);
        Dealership Create(Dealership dealership);
        long Updarte(string id, Dealership dealership);
        long Delete(string id);
    }
}
