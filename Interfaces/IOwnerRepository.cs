using DogGo.Models;
using Microsoft.Data.SqlClient;

namespace DogGo.Interfaces
{
    public interface IOwnerRepository
    {
        SqlConnection Connection { get; }

        void AddOwner(Owner owner);
        void DeleteOwner(int ownerId);
        List<Owner> GetAllOwners();
        Owner GetOwnerByEmail(string email);
        Owner GetOwnerById(int id);
        void UpdateOwner(Owner owner);
    }
}