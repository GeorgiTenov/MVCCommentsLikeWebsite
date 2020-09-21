using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Komentirai.Models.Interfaces
{
   public interface IUser
    {
        int Id { get; set; }

        string Username { get; set; }

        string Password { get; set; }

        string Email { get; set; }

        IFormFile ProfilePicture { get; set; }

        string ProfilePicturePath { get; set; }

        string ChangeUsername(string newUsername);
        
        string ChangePassword(string newPassword);

        bool CheckUsername();

        bool CheckPassword();

        List<Comment> GetComments();

        DateTime CreatedDate { get; set; }
    }
}
