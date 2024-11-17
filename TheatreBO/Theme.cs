using System;
using System.Collections.Generic;

namespace TheatreBO
{
    public class Theme
    {
        public int IdTheme { get; set; }
        public string LibTheme { get; set; }

        public Theme(int idTheme, string libTheme)
        {
            IdTheme = idTheme;
            LibTheme = libTheme;
        }
    }
}
