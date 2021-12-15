using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Xml;

namespace MovieInformationFileStorage
{
    internal class MovieFileSerializer
    {
        public void Serialize( string path, List<RecordInformation> recordings)
        {
            string itemJson = JsonSerializer.Serialize(recordings, typeof (List<RecordInformation>));
            Console.WriteLine(itemJson);
            StreamWriter streamWriter = new StreamWriter(path);
            streamWriter.WriteLine(itemJson);
            streamWriter.Close();
        }
        public List<RecordInformation> Deserialize (string path)
        {
            string strItemInforationDeserialize = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<RecordInformation>>(strItemInforationDeserialize);           
        }
    }
}
