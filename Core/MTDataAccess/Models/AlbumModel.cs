using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDataAccess.Models
{
    public class Album
    {
        public int albumID { get; set; }
        public DateTime DateCreation { get; set; }
        public int artistID { get; set; }
        public string title { get; set; }
        public string imageURL { get; set; }
        public int year { get; set; }
    }
}
