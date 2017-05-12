using System.Collections.Generic;
using MugenMvvmToolkit;
using Validation.Portable.Interfaces;
using Validation.Portable.Models;

namespace Validation.Portable.Infrastructure
{
    public class CollectionUserRepository : IUserRepository
    {
        #region Fields

        private readonly List<UserModel> _users = new List<UserModel>();

        #endregion

        #region Implementation of IUserRepository

        public void Add(UserModel user)
        {
            Should.NotBeNull(user, nameof(user));
            _users.Add(user);
        }

        public void Remove(UserModel user)
        {
            Should.NotBeNull(user, nameof(user));
            _users.Remove(user);
        }

        public IList<UserModel> GetUsers()
        {
            return _users;
        }

        #endregion
    }
}