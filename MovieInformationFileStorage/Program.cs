// Программа для записи/чтения/удаления в текстовом документе, с путем для скачивания и названия фильма\сериала\мультфильма.

using MovieInformationFileStorage;
using System.Text.Json;

var applicationFolderPath = System.IO.Directory.GetCurrentDirectory();

var pathWithTextFileName = $@"{applicationFolderPath}\MovieStorage.json";

//Информация по фильмам
List<RecordingInformation> recordingInformation = new List<RecordingInformation>()
{
    new RecordingInformation("http://fast-torrent.club/film/melochi.html","Дьявол в деталя"),
    new RecordingInformation("http://fast-torrent.club/film/cherri-1.html","По наклонной"),
    new RecordingInformation("http://fast-torrent.club/film/liga-spravedlivosti-zaka-snajdera.html","Лига справедливости")
};
recordingInformation.Add(new RecordingInformation("http://fast-torrent.club/film/staroe.html", "Время"));

foreach(var itemInformation in recordingInformation)
{
    Console.Write(itemInformation.MovieLink + "   -   ");
    Console.WriteLine(itemInformation.MovieName);
}



WorkingWithElements movieInformationFileStorage = new WorkingWithElements(pathWithTextFileName);
movieInformationFileStorage.CreateFileNotExists();



/*string personJson = JsonSerializer.Serialize(recordingInformation, typeof(List<RecordingInformation>));
StreamWriter file = File.CreateText(pathWithTextFileName);
file.WriteLine(personJson);
file.Close();
Console.WriteLine(personJson);*/

var fileSerializationOrDeserialization = new Serialization();
fileSerializationOrDeserialization.Serialize(pathWithTextFileName, recordingInformation);



List<RecordingInformation> information = new List<RecordingInformation>();

information = fileSerializationOrDeserialization.Deserialize(pathWithTextFileName);

foreach (var itemInformation in information)
{
    Console.Write(itemInformation.MovieLink + "   -   ");
    Console.WriteLine(itemInformation.MovieName);
}

/*var serializat = new Serialization();
serializat.Serialize(pathWithTextFileName, recordingInformation);


//information = FileSt
string str = File.ReadAllText(pathWithTextFileName);
Console.WriteLine(str);
information = JsonSerializer.Deserialize<List<RecordingInformation>>(str);

*/

Console.WriteLine("Путь файла, ");
Console.WriteLine(pathWithTextFileName);