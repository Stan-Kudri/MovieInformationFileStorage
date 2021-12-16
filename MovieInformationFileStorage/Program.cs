// Программа для записи/чтения/удаления в текстовом документе, с путем для скачивания и названия фильма\сериала\мультфильма.

using MovieInformationFileStorage;
using System.Text.Json;

var applicationFolderPath = System.IO.Directory.GetCurrentDirectory();

var pathWithTextFileName = $@"{applicationFolderPath}\MovieStorage.json";

//Информация по фильмам
List<Movie> recordingInformation = new List<Movie>()
{
    new Movie("http://fast-torrent.club/film/melochi.html","Дьявол в деталя"),
    new Movie("http://fast-torrent.club/film/cherri-1.html","По наклонной"),
    new Movie("http://fast-torrent.club/film/liga-spravedlivosti-zaka-snajdera.html","Лига справедливости")
};
recordingInformation.Add(new Movie("http://fast-torrent.club/film/staroe.html", "Время"));
//Отобразить путь файла------>
Console.WriteLine("Путь файла, ");
Console.WriteLine(pathWithTextFileName);
//Вывести все элементы списка
//Создание класса для работы со списком
MovieStore movieInformationFileStorage = new MovieStore(pathWithTextFileName);
movieInformationFileStorage.WriteItemsToFile();
movieInformationFileStorage.AddElementToList(new Movie("http://fast-torrent.club/film/ozark.html", "Озарк"));
movieInformationFileStorage.SaveChanges();
movieInformationFileStorage.WriteItemsToFile();
Console.ReadLine();


