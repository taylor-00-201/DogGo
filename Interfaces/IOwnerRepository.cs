using DogGo.Models;
using Microsoft.Data.SqlClient;

namespace DogGo.Interfaces
{
    public interface IOwnerRepository
        // this is an interface return type for our repositroy, created by extracting an interface from the owner repository
    {
        SqlConnection Connection { get; }

        List<Owner> GetAllOwners();
        Owner GetOwnerById(int id);

        Owner GetOwnerByEmail (string email);

        void AddOwner (Owner owner);

        void UpgradeOwner (Owner owner);

        void DeleteOwner (int ownerId);

    }
}