using Komentirai.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Komentirai.Models.Interfaces
{
    public interface IComment
    {
        int Id { get; set; }


        User User { get; set; }


        string Text { get; set; }

        DateTime Date { get; set; }

        Subject Subject { get; set; }
    }
}
