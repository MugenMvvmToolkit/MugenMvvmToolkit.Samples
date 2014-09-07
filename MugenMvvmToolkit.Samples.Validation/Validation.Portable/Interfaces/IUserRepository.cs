using System.Collections.Generic;
using Validation.Portable.Models;

namespace Validation.Portable.Interfaces
{
    public interface IUserRepository
    {
        void Add(UserModel user);

        void Remove(UserModel user);

        IList<UserModel> GetUsers();
    }
}