using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieInformationFileStorage
{
    internal class RecordingInformation
    {
        public string MovieLink { get; set; }

        public string MovieName { get; set; }

        public RecordingInformation()
        {

        }

        public RecordingInformation(string movieLink, string movieName)
        {
            MovieLink = movieLink;  
            MovieName = movieName;
        }
    }
}
