using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Xml;
using System.Text.Unicode;
using System.Text.Encodings.Web;

namespace MovieInformationFileStorage
{
    internal class MovieFileSerializer
    {
        private string _path { get; set; }
        public MovieFileSerializer()
        {           
        }
        public MovieFileSerializer(string path)
        {
            _path = path;
        }

        public void Serialize(List<Movie> listMovie)
        {
            if(File.Exists(_path))
                File.Delete(_path);

            using (var file = File.Open(_path, FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize(file, listMovie, new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
                });
            }
        }
        public List<Movie> Deserialize ()
        {
            if (File.Exists(_path))
            {
                using (var file = File.OpenRead(_path))
                {
                    var result = JsonSerializer.Deserialize(file, typeof(List<Movie>), new JsonSerializerOptions
                    {
                        WriteIndented = true,
                        Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
                    });
                    return (List<Movie>)result;
                }
            }
            else return new List<Movie>();    
            




            /*if(File.Exists(_path))
            {
                string strSerializeList = File.ReadAllText(_path);
                if (strSerializeList.Length > 0)
                {
                    return JsonSerializer.Deserialize<List<Movie>>(strSerializeList);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                File.Create(_path).Close();
                return null;
            }*/



            /*using(FileStream stream = new FileStream(_path,FileMode.OpenOrCreate))
            {
                string strSerializeMovie = new StreamReader(stream).ReadToEnd();
                if (strSerializeMovie.Length > 0)
                {
                    return JsonSerializer.Deserialize<List<Movie>>(strSerializeMovie);
                }
                return null;
            }*/

        }

    }
}
