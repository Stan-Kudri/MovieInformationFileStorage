// Программа для записи/чтения/удаления в текстовом документе, с путем для скачивания и названия фильма\сериала\мультфильма.

using MovieInformationFileStorage;

var applicationFolderPath = Directory.GetCurrentDirectory();

var pathWithTextFileName = $@"{applicationFolderPath}\MovieStorage.json";

//Информация по фильмам
List<Movie> recordingInformation = new List<Movie>()
{
    new Movie("http://fast-torrent.club/film/melochi.html","Дьявол в деталя"),
    new Movie("http://fast-torrent.club/film/cherri-1.html","По наклонной"),
    new Movie("http://fast-torrent.club/film/liga-spravedlivosti-zaka-snajdera.html","Лига справедливости"),
    new Movie("http://fast-torrent.club/film/staroe.html", "Время")
};

//Отобразить путь файла------>
Console.WriteLine("Путь файла, ");
Console.WriteLine(pathWithTextFileName);

//Создание класса для работы со списком
MovieFileSerializer movieFile = new MovieFileSerializer(pathWithTextFileName);
MovieStore movieStore = new MovieStore(movieFile);
DisplayItems(movieStore);

var films = movieStore.SelectAll()[1];
movieStore.Update(new Movie
{
    Id = films.Id,
    Name = "По наклонной 3",
    Link = films.Link,
});
//movieStore.AddRange(recordingInformation);
DisplayItems(movieStore);

//movieStore.Add(new Movie("http://fast-torrent.club/film/ozark.html", "Озарк"));
movieStore.SaveChanges();

DisplayItems(movieStore);


Console.ReadLine();




//Вывод десериализованной информации
void DisplayItems(MovieStore store)
{
    var records = store.SelectAll();
    if (records == null)
        return;
    
    foreach (var itemInformation in records)
    {
        Console.WriteLine("{0} - {1}", itemInformation.Link, itemInformation.Name);
    }
}