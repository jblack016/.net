using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultiTracksAPI.Models
{
    public class Song
    {
        public int songID { get; set; }
        public int artistID { get; set; }
        public int albumID { get; set; }
        public string title { get; set; }
        public decimal bpm { get; set; }
        public string timeSignature { get; set; }
    }
}