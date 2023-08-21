﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDataAccess.Models
{
    public class Song
    {
        public int songID { get; set; }
        public int artistID { get; set; }
        public int albumID { get; set; }
        public string title { get; set; }   
        public  decimal bpm { get; set; }
        public string timeSignature { get; set; }
        public bool multitracks { get; set; }
        public bool customMix { get; set; } 
        public bool chart { get; set; }
        public bool reheasalMix { get; set; }   
        public bool pathces { get; set; }
        public bool songSpecificPatches { get; set; }
        public bool proPresenter { get; set; }
    }
}
