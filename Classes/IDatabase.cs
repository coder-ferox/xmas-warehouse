using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneLetterine.Classes
{
    public interface IDatabase
    {
        IEnumerable<Toy> GetAllToys();

        IEnumerable<Toy> GetAllOrderedToys(Request order);

        IEnumerable<Request> GetAllRequests();

        User GetUser(User user);

        Request GetRequest(string id);

        bool UpdateRequest(string id, RequestStatus status);
    }
}
