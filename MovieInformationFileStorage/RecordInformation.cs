using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieInformationFileStorage
{
    internal class RecordInformation
    {
        public string MovieLink { get; set; }

        public string MovieName { get; set; }

        public RecordInformation()
        {
        }

        public RecordInformation(string movieLink, string movieName)
        {
            MovieLink = movieLink;  
            MovieName = movieName;
        }
    }
}
