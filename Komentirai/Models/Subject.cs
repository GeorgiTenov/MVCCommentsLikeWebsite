using Komentirai.Models.Data;
using Komentirai.Models.Enums;
using Komentirai.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Komentirai.Models
{
    public class Subject : ISubject
    {
        private Context _context;

        public Context Context
        {
            get
            {
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
        public string Title { get; set; }

        [Required]
        [MaxLength(400)]
        public string Description { get; set; }

        public DateTime Date { get; set; }

        public Category Category { get; set; }

        public User User { get; set; }

        public Subject() { this.Date = DateTime.Now; }

        public Subject(string title,Category category,string description,User user)
        {
            this.Title = title;

            this.Category = category;

            this.Description = description;

            this.User = user;

            this.Date = DateTime.Now;
        }

        public List<Comment> GetComments()
        {
            return this._context.GetCommentsBySubjectId(this.Id);
        }

        
    }
}
