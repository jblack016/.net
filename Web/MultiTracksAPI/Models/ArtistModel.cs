using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultiTracksAPI.Models
{
    public class Artist
    {
        public int artistID { get; set; }
        public string title { get; set; }
        public string biography { get; set; }
        public string imageURL { get; set; }
        public string heroURL { get; set; }
    }
}