// Программа для записи/чтения/удаления в текстовом документе, с путем для скачивания и названия фильма\сериала\мультфильма.

using MovieInformationFileStorage;
using System.Text.Json;

var applicationFolderPath = System.IO.Directory.GetCurrentDirectory();

var pathWithTextFileName = $@"{applicationFolderPath}\MovieStorage.json";

//Информация по фильмам
List<RecordInformation> recordingInformation = new List<RecordInformation>()
{
    new RecordInformation("http://fast-torrent.club/film/melochi.html","Дьявол в деталя"),
    new RecordInformation("http://fast-torrent.club/film/cherri-1.html","По наклонной"),
    new RecordInformation("http://fast-torrent.club/film/liga-spravedlivosti-zaka-snajdera.html","Лига справедливости")
};
recordingInformation.Add(new RecordInformation("http://fast-torrent.club/film/staroe.html", "Время"));


Console.WriteLine("Путь файла, ");
Console.WriteLine(pathWithTextFileName);





foreach (var itemInformation in recordingInformation)
{
    Console.Write(itemInformation.MovieLink + "   -   ");
    Console.WriteLine(itemInformation.MovieName);
}





WorkInElement movieInformationFileStorage = new WorkInElement(pathWithTextFileName);






var fileSerializationOrDeserialization = new MovieFileSerializer();
fileSerializationOrDeserialization.Serialize(pathWithTextFileName, recordingInformation);

movieInformationFileStorage.AddElementToList(new RecordInformation("http://fast-torrent.club/film/ozark.html", "Озарк"));
movieInformationFileStorage.SaveSerializeList();
movieInformationFileStorage.WriteItemsToFile();
//List<RecordInformation> information = new List<RecordInformation>();


Console.ReadLine();
/*information = fileSerializationOrDeserialization.Deserialize(pathWithTextFileName);

foreach (var itemInformation in information)
{
    Console.Write(itemInformation.MovieLink + "   -   ");
    Console.WriteLine(itemInformation.MovieName);
}
*/

