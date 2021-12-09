using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace MovieInformationFileStorage
{
        internal class WorkingWithElements
    {
        string path { get; set; }

        private bool FileConnection { get; set; }
        public WorkingWithElements()
        {

        }
        List<RecordingInformation> records { get; set; }
        public WorkingWithElements(string path) => this.path = path;

        public void CreateFileNotExists()
        {
            if (!File.Exists(path)) File.Create(path);
            FileConnection = true;
        }
        
        public void ReadItemsToFile()
        {
            records = new List<RecordingInformation>();
            var date = File.ReadAllText(path);

        }

        public void AddElementToList(RecordingInformation itemInformation)
        {
            if( (FileConnection == true) && (itemInformation != null) )
            {
                records.Add(itemInformation);
            }
        }

        public void ChangeItemInList(RecordingInformation itemInformatio)
        {
            if(FileConnection == true)
            {

            }
        }

        public void WriteItemsToFile(List <RecordingInformation> recordings)
        {
            /*using(BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                foreach(RecordingInformation recordingInformation in records )
                {
                    writer.Write(recordingInformation.MovieLink);
                    writer.Write(recordingInformation.MovieName);
                }
            }*/
            var informationJson = JsonSerializer.Serialize(recordings, typeof(List<RecordingInformation>));
            
            
        }



    }
}
