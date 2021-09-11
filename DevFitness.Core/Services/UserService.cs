using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DevFitness.Core.Entities;
using DevFitness.Core.Exceptions;
using DevFitness.Core.Interfaces.Repositories;
using DevFitness.Core.Interfaces.Services;
using DevFitness.Core.Interfaces.UnitOfWork;
using DevFitness.Core.Services.Base;
using DevFitness.Core.Validations.Users;

namespace DevFitness.Core.Services
{
    public class UserService : Service, IUserService
    {
        private readonly IUnitOfWork _unitOfWork = null;
        private readonly IUserRepository _userRepository = null;

        public UserService(IUnitOfWork unitOfWork,IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public async Task Add(User user)
        {
            try
            {
                if (!this.ExecuteValidation(new UserValidation(), user))
                    throw new ValidationException("Please check the fields entered.");
                
                await _userRepository.Add(user);
                
                if (!await _unitOfWork.Commit())
                    throw new Exception("Something went wrong trying to add");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task Update(User user)
        {
            try
            {
                if (!this.ExecuteValidation(new UserValidation(), user))
                    throw new ValidationException("Please check the fields entered.");
                await _userRepository.Update(user);
                if (!await _unitOfWork.Commit())
                    throw new Exception("Something went wrong while trying to update.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<IEnumerable<User>> Get()
        {
            try
            {
                return await _userRepository.Get();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<User> GetById(int id)
        {
            var user = await _userRepository.GetById(id);

            if (user == null)
                throw new NotExistsException("User not found.");

            return user;
        }

        public async Task DisableUser(int id)
        {
            try
            {
                var user = await _userRepository.GetById(id);

                if (user == null)
                    throw new NotExistsException("User not found.");

                user.Disable();
                await _userRepository.Update(user);

                if (!await _unitOfWork.Commit())
                    throw new Exception("Something went wrong while trying to update.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task EnableUser(int id)
        {
            try
            {
                var user = await _userRepository.GetById(id);

                if (user == null)
                    throw new NotExistsException("User not found.");

                user.Enable();
                await _userRepository.Update(user);

                if (!await _unitOfWork.Commit())
                    throw new Exception("Something went wrong while trying to update.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}