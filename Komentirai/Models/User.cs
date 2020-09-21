using Komentirai.Models.Data;
using Komentirai.Models.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Komentirai.Models
{
    public class User : IUser
    {
        private  Context _context;

        public Context Context
        {
            get { 
                    return this._context;
                }
            set
            {
                this._context = value;
            }
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Username { get; set; }

        [Required]
        [MaxLength(200)]
        public string Password { get; set; }

        [Required]
        [MaxLength(200)]
        public string Email { get; set; }

        [NotMapped]
        public IFormFile ProfilePicture { get; set; }

        public string ProfilePicturePath { get; set; }

        public bool IsLogged { get; set; }

        public DateTime CreatedDate { get; set; }

        public User() { this.CreatedDate = DateTime.Now; }

        public User(string username,
                    string password,
                    string email,
                    Context context)
                    
        {
            this.Username = username;

            this.Password = password;

            this.Email = email;

            this.CreatedDate = DateTime.Now;

            this._context = context;

        }

        public string ChangePassword(string newPassword)
        {
            this.Password = newPassword;
            return this.Password;
        }

        public string ChangeUsername(string newUsername)
        {
            this.Username = newUsername;
            return this.Username;
        }

        public bool CheckPassword()
        {
            if(Password != null)
            {
                if (this.Password.Length < 4)
                {
                    return false;
                }
               
            }
            return true;

        }

       

        public bool CheckUsername()
        {
            if(Username != null)
            {
                if (this.Username.Length < 4)
                {
                    return false;
                }
            }
           
            return true;
        }

        public void SaveProfilePicture(IFormFile picture,IWebHostEnvironment host)
        {
            if(picture != null)
            {
                //Get the rooth path
                string root = host.WebRootPath;

                //Get file name without extension
                string fileName = Path.GetFileNameWithoutExtension(picture.FileName);

                //Get file extension only
                string extension = Path.GetExtension(picture.FileName);

                //Genrate random number for unique name
                Random rand = new Random();
                fileName += "" + rand.Next(1,1000);

                //Combine paths
                string fullPath = Path.Combine(root + "/Pictures/", fileName + extension);

                //Save to path
                using (var fileStream = new FileStream(fullPath, FileMode.Create))
                {
                    picture.CopyToAsync(fileStream);
                }

                //Initializing PicturePath
                this.ProfilePicturePath = fileName + extension;
            }
           

        }

        public List<Comment> GetComments()
        {
            return _context.GetCommentsByUser(this);
        }

        public void LogIn()
        {
            this.IsLogged = true;
            _context.SaveChanges();
        }

        public void LogOut()
        {
            this.IsLogged = false;
            _context.SaveChanges();
        }

        public async Task<List<Subject>> GetSubjects()
        {
            var users = _context.GetUsers();
            return _context.GetSubjects()
                .Where(s => s.User.Id == this.Id).ToList();
        }
    }
}
