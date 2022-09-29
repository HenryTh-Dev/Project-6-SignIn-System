using Application.Interfaces.IServices;
using SignIn.Domain.Models;
using SignIn.Infra.Repositories;
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;

namespace Application.Services
{
    public class UserServices : IUserServices
    {
        public bool AlreadyRegistredEmail(string email)
        {
            UserRepository repo = new UserRepository();
            var emailRegistred = repo.GetUserEmail(email);
            return emailRegistred;
        }
        public bool IsValidEmail(string email)
        {
            if (email == null)
            {
                return false;
            }
            return new EmailAddressAttribute().IsValid(email);
        }
        public bool ValidatePassword(string password)
        {
            int validConditions = 0;
            foreach (char c in password)
            {
                if (c >= 'a' && c <= 'z')
                {
                    validConditions++;
                    break;
                }
            }
            foreach (char c in password)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    validConditions++;
                    break;
                }
            }
            if (validConditions == 0) return false;
            foreach (char c in password)
            {
                if (c >= '0' && c <= '9')
                {
                    validConditions++;
                    break;
                }
            }
            if (validConditions == 1) return false;
            if (validConditions == 2)
            {
                char[] special = { '@', '#', '$', '%', '^', '&', '+', '=' }; // or whatever    
                if (password.IndexOfAny(special) == -1) return false;
            }
            if (password.Length > 8)
            {
                return true;
            }
            return false;
        }
        public string GetFirstLetterUpper(string Upper)
        {
            var UpperCase = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Upper);
            return UpperCase;
        }
        public bool birthDateValidation(int birthday, int birthyear, int birthmonth)
        {

            if (birthyear < 1900 || birthyear > DateTime.Now.Year - 13)
            {
                return false;
            }
            if (birthmonth <= 0 || birthmonth > 12)
            {
                return false;
            }
            if (birthday <= 0 || birthday > 31)
            {
                return false;
            }
            return true;

        }
        public User GetUserAccountInfo(string email)
        {
            UserRepository repo = new UserRepository();
            var user = repo.GetUser(email);
            return user;
        }
        public bool ValidateSsn(string password)
        {
            int validConditions = 0;
            foreach (char c in password)
            {
                if (c >= 'a' && c <= 'z')
                {
                    validConditions++;
                    break;
                }
            }
            foreach (char c in password)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    validConditions++;
                    break;
                }
            }
            if (validConditions > 0) return false;
            if (validConditions > 0)
            {
                char[] special = { '@', '#', '$', '%', '^', '&', '+', '=', '.', '-', ',' };
                if (password.IndexOfAny(special) == -1) return false;
            }
            if (password.Length < 8)
            {
                return false;
            }
            return true;
        }
        public bool ValidatePerson(string ssn, string firstName, string lastName, User user)
        {
            if (user.Snn == ssn && user.Firstname.ToUpper() == firstName.ToUpper() && user.Lastname.ToUpper() == lastName.ToUpper())
            {
                return true;
            }
            return false;
        }
        public string EncodePassword(string password)
        {
            byte[] encData_byte = new byte[password.Length];
            encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
            string encodedData = Convert.ToBase64String(encData_byte);
            return encodedData;
        }
        public bool UserRegistry(string FirstName, string LastName, string ssn, string birthDate, string encryptPass, string email)
        {

            User user = new User() { Birthdate = birthDate, Email = email, Firstname = FirstName, Lastname = LastName, Password = encryptPass, Snn = ssn };
            UserRepository repo = new UserRepository();
            bool registred = repo.UserRegistry(user);
            return registred;
        }

        public string RandomPassword()
        {
            int length = 8;
            Random random = new Random();
            const string chars = "abcefghijklmnopqrstuvxwyz@!@#%%$&&¨*ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public bool NewRandomPassword(string password, User user)
        {
            UserRepository repo = new UserRepository();
            repo.RandomPasswordChangedMarkTrue(user);
            password = EncodePassword(password);
            repo.ChangePassword(password, user);
            return true;
        }
        public bool ChangePassword(string password, User user)
        {
            UserRepository repo = new UserRepository();
            password = EncodePassword(password);
            repo.ChangePassword(password, user);
            return true;
        }
        public User UserLogin (string email)
        {
            UserRepository repo = new UserRepository();
            User user = repo.GetUser(email);
            

            return user;
        }
        public bool RandomPasswordChangedMarkFalse(User user)
        {
            UserRepository repo = new UserRepository();
            repo.RandomPasswordChangedMarkFalse(user);
            return true;
        }
        public bool DataValidation(string FirstName, string LastName, string ssn)
        {
            if (FirstName == "" || LastName == "" || ssn == "")
            {
                return false;
            }
            if (ssn.Length > 8 || ssn.Length <8)
            {
                return false;
            }
            char[] special = { '@', '#', '$', '%', '^', '&', '+', '=', '.', '-', ',','1','2','3','4','5','6','7','8','9','0' };
            char[] specialAndChar = { '@', '#', '$', '%', '^', '&', '+', '=', '.', '-', ',','A','B','C','D','F','G','H','I','J','K','L','M','O','P','Q','R','S','T','U','V','X','Y','W','Z'};
            if (ssn.ToUpper().IndexOfAny(special) > 0)
            {
                return false;
            }
            if (FirstName.ToUpper().IndexOfAny(special) > 0)
            {
                return false;
            }
            if (LastName.ToUpper().IndexOfAny(special) > 0)
            {
                return false;
            }
            return true;
        }
    }
}
