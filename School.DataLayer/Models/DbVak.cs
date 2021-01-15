using System.Collections.Generic;

namespace School.DataLayer.Models
{
    public class DbVak
    {
        public string Naam { get; set; }
        public uint AantalLesuren { get; set; }
       public IList<DbStudent> Studenten { get; set; }
    }
}