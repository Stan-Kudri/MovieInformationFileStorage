using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieInformationFileStorage
{
    internal class Movie
    {
        public Guid Id { get; set; }
        public string Link { get; set; }

        public string Name { get; set; }

        public Movie()
        {

        }
        public Movie(string movieLink, string movieName)
        {
            Id = Guid.NewGuid();
            Link = movieLink;  
            Name = movieName;
        }
    }
}
