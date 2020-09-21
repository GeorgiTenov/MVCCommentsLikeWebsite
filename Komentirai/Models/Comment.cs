using Komentirai.Models.Enums;
using Komentirai.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Komentirai.Models
{
    public class Comment : IComment
    {
        public int Id { get; set; }

        public User User { get; set; }
        
        public string Text { get; set; }

        public DateTime Date { get; set; }

        public Subject Subject { get; set; }

        public Comment() { this.Date = DateTime.Now; }

        public Comment(Category category,
                       User user,
                       string title,
                       string text,
                       Subject subject)
        {
           
            this.User = user;

            this.Text = text;

            this.Subject = subject;

            this.Date = DateTime.Now;
        }
    }
}
