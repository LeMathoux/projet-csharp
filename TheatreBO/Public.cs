using System;
using System.Collections.Generic;

namespace TheatreBO
{
    public class Public
    {
        public int IdPublic { get; set; }
        public string LibPublic { get; set; }

        public Public(int idPublic, string libPublic)
        {
            IdPublic = idPublic;
            LibPublic = libPublic;
        }
    }
}