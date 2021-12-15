using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieInformationFileStorage
{
    internal class ImpactCheckWithPath
    {
        private string Path {get;set;}
        private bool fileExistence;
        public bool GetFileExistence()
        {
            return fileExistence;
        }
        public void SetFileExistence(bool value)
        {
            fileExistence = value;
        }
        public ImpactCheckWithPath(string path)
        {
            Path = path;
            FileInfo fileInfo = new FileInfo(Path);
            if(fileInfo.Exists)
                SetFileExistence(true);
        }


        

    }
}
