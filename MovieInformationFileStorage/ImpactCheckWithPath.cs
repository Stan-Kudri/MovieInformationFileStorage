using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieInformationFileStorage
{
    internal class ImpactCheckWithPath
    {
        private string _path;

        public bool FileExist { get; set; }
        
        public string Path
        {
            get { return _path; }
            set
            {
                _path = value;
                FileExist = File.Exists(value);
            }
        }
              
        public ImpactCheckWithPath(string path)
        {
            Path = path;
            FileInfo fileInfo = new FileInfo(Path);
            if(fileInfo.Exists)
                FileExist = true;
        }


        

    }
}
