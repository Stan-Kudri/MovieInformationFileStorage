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


Console.WriteLine("Путь файла, ");
Console.WriteLine(pathWithTextFileName);





foreach (var itemInformation in recordingInformation)
{
    Console.Write(itemInformation.MovieLink + "   -   ");
    Console.WriteLine(itemInformation.MovieName);
}



WorkingWithElements movieInformationFileStorage = new WorkingWithElements(pathWithTextFileName);
movieInformationFileStorage.CreateFileNotExists();





var fileSerializationOrDeserialization = new Serialization();
fileSerializationOrDeserialization.Serialize(pathWithTextFileName, recordingInformation);



List<RecordingInformation> information = new List<RecordingInformation>();

information = fileSerializationOrDeserialization.Deserialize(pathWithTextFileName);

foreach (var itemInformation in information)
{
    Console.Write(itemInformation.MovieLink + "   -   ");
    Console.WriteLine(itemInformation.MovieName);
}

