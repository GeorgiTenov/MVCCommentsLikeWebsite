using Komentirai.Models.Enums;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Komentirai.Models.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Subject> Subjects { get; set; }


        //Users methods

        public void AddUser(User user)
        {
            this.Users.Add(user);
            this.SaveChanges();
        }

        public void RemoveUser(User user)
        {
            this.Users.Remove(user);
        }

        public void RemoveAllUsers()
        {
            this.Users.RemoveRange(this.Users);
            this.SaveChanges();
        }

        public List<User> GetUsers()
        {
            return this.Users.ToList();
        }


        public User GetUserById(int id)
        {
            return this.Users.FirstOrDefault(u => u.Id == id);
        }

        public User GetUserByUsername(string username)
        {
            return this.Users.FirstOrDefault(u => u.Username.Equals(username));
        }

        public User GetUserByEmail(string email)
        {
            return this.Users.FirstOrDefault(u => u.Email.Equals(email));
        }

        public User GetUserByUsernameAndPassword(string username,string password)
        {
            return this.Users.FirstOrDefault( u => u.Username.Equals(username)
            && u.Password.Equals(password));
        }

        //Comments methods

        public void AddComment(Comment comment)
        {
            this.Comments.Add(comment);
            this.SaveChanges();
        }

        public void RemoveComment(Comment comment)
        {
            this.Comments.Remove(comment);
            this.SaveChanges();
        }

        public void RemoveAllComments()
        {
            this.Comments.RemoveRange(this.Comments);
            this.SaveChanges();
        }
        public List<Comment> GetComments()
        {
            return this.Comments.ToList();
        }

        public Comment GetCommentById(int id)
        {
            return this.Comments.FirstOrDefault(c => c.Id == id);
        }

        public List<Comment> GetCommentsByUser(User user)
        {
           return this.Comments.Where(c => c.User == user).ToList();
        }


        public List<Comment> GetCommentsBySubjectId(int id)
        {
            return this.Comments.Where(c => c.Subject.Id == id).ToList();
        }

        //Subject Methods

        public void AddSubject(Subject subject)
        {
            this.Subjects.Add(subject);
            this.SaveChanges();
        }

        public void RemoveSubject(Subject subject)
        {
            this.Subjects.Remove(subject);
            this.SaveChanges();
        }

        public void RemoveAllSubjects()
        {
            this.Subjects.RemoveRange(this.Subjects);
            this.SaveChanges();
        }

        public Subject GetSubjectById(int id)
        {
            return this.Subjects.FirstOrDefault(s => s.Id == id);
        }

        public  List<Subject> GetSubjects()
        {
            return this.Subjects.ToList();
        }

        public List<Subject> GetSubjectsByTitle(string title)
        {
            return this.Subjects.Where(s => s.Title.ToLower()
            .Contains(title.ToLower())).ToList();
        }

        public List<Subject> GetSubjectsByDate(DateTime date)
        {
            return this.Subjects.Where(s => s.Date == date).ToList();
        }

        public List<Subject> GetSubjectsByCategoryName(string name)
        {
           return this.GetSubjects().Where(s => Enum
                .GetName(typeof(Category), s.Category) == name)
                .ToList();
        }

        public int SubjectCount(string categoryName)
        {
            return this.GetSubjects().Where(s => Enum
                .GetName(typeof(Category), s.Category) == categoryName)
                .ToList()
                .Count();
        }
       

      
        //Empty database
        public void EmptyDatabase()
        {
            this.RemoveAllUsers();

            this.RemoveAllComments();

            this.RemoveAllSubjects();
        }


    }
}
