using Repository.Entities;
using Repository.Repository;
using Services.Base;
using System;

namespace Services.Services
{
    public class UserService : GenericService<UserModel, User>
    {
        UserRepository _userRepository;
        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public UserModel Login(string username, string pass)
        {
            var result = _userRepository.Login(username, pass);
            var user = mapper.MapToModel<User, UserModel>(result);
            if (result == null)
            {
                throw new Exception("Ocurrió un error al iniciar sesión.");
            }
            return user;
        }

    }
}
