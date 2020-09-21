using Komentirai.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Komentirai.Models.Interfaces
{
    public interface ISubject
    {
        int Id { get; set; }

        string Title { get; set; }

        DateTime Date { get; set; }

        Category Category { get; set; }

        List<Comment> GetComments();

        string Description { get; set; }

        User User { get; set; }

    }
}
