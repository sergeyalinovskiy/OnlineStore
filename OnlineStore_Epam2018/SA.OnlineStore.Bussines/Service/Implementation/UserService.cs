﻿namespace SA.OnlineStore.Bussines.Service.Implementation
{
    #region Usings 
    using System.Collections.Generic;
    using SA.OnlineStore.Common.Entity;
    using SA.OnlineStore.DataAccess.Repositorys;
    #endregion
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void DeleteUserByUserId(int id)
        {
            if (id > 0)
            {
                _userRepository.Delete(id);
            }
        }

        public User GetUserById(int id)
        {
            if (id < 1)
            {
                return null;
            }
            return _userRepository.GetById(id);
        }

        public User GetUserByLogin(string login)
        {
           return  _userRepository.GetByLogin(login);
        }

        public IEnumerable<User> GetUsersList()
        {
             return _userRepository.GetAll();
        }

        public void SaveUser(User model)
        {
            if (model != null)
            {
                _userRepository.Create(model);
            }
        }
    }
}