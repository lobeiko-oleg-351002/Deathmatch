using BLL.Exceptions;
using BLL.Services.Interface;
using System;
using System.Net.Mail;
using ViewModels.Create;

namespace BLL.Services
{
    public class UserValidationService : IUserValidationService
    {
        private const int MinFieldLength = 3;

        public void ValidateNewUser(UserCreateModel user)
        {
            if (user == null)
            {
                throw new UserValidationExceptionUserIsNull();
            }
            ValidateNameAndPassword(user.Name, user.Password);
            if (user.Role == null)
            {
                throw new UserValidationExceptionRoleIsNull();
            }

            if (!IsEmailValid(user.Email))
            {
                throw new UserValidationExceptionInvalidEmail();
            }
        }

        public void ValidateNameAndPassword(string name, string password)
        {
            if (string.IsNullOrEmpty(name) || (name.Length < MinFieldLength))
            {
                throw new UserValidationExceptionInvalidName($"Name must contain at least {MinFieldLength} letters");
            }
            if (string.IsNullOrEmpty(password) || (password.Length < MinFieldLength))
            {
                throw new UserValidationExceptionInvalidPassword($"Password must contain at least {MinFieldLength} letters");
            }
        }

        private bool IsEmailValid(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}
