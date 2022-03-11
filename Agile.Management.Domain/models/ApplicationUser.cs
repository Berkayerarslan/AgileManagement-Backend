using AgileManagement.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agile.Management.Domain.models
{
    public class ApplicationUser:Entity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; } 
        public string ProfilePictureUrl { get; private set; }
        public bool EmailVerified { get; private set; }
        public string ProfPictureUrl { get; private set; }
        public string RefreshToken { get; set; }

        public ApplicationUser(string email)
        {
          SetName(email);
          SetEmail(email);
        }
        public void SetRefreshToken(string refreshToken)
        {
            this.RefreshToken = refreshToken;
        }
        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                this.Username = this.Email;

            }
            this.Username = name;
        }

        public void SetEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new Exception("E-mail alanı boş geçilemez.");

            }
            this.Email = email.Trim();
        }
        public void SetPasswordHash(string passwordHash)
        {
            if (string.IsNullOrEmpty(passwordHash))
            {
                throw new Exception("Parola alanı boş geçilemez");
            }

            this.PasswordHash = passwordHash.Trim();
        }
        public void SetProfileInfo(string firstName, string lastName, string middleName)
        {
            if (string.IsNullOrEmpty(firstName))
            {
                throw new Exception("FirstName boş geçilemez");
            }

            if (string.IsNullOrEmpty(lastName))
            {
                throw new Exception("LastName boş geçilemez");
            }

            this.FirstName = firstName.Trim();
            this.LastName = lastName.Trim().ToUpper();
            this.MiddleName = middleName.Trim();
        }
        public void SetProfilePicture(string profilePictureUrl)
        {
            if (string.IsNullOrEmpty(profilePictureUrl))
            {
                throw new Exception("Profil Fotoğrafı boş geçilemez");
            }

            this.ProfilePictureUrl = profilePictureUrl.Trim();
        }

        public void SetVerifyEmail()
        {
            EmailVerified = true;
        }




    }
}
