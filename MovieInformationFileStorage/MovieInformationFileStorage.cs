using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Linq;

namespace MovieInformationFileStorage
{
        //Проверку по пути добавлю, поздно подумал о ней....................
        internal class MovieStore
    {
        private string _path;
        //Путь файла
        public string Path
        {
            get { return _path; }
            set
            {
                _path = value;
                if ( !File.Exists(Path) )
                {
                    File.Create(Path);
                }
                Records = new List<Movie>();
            }
        }

        //Список элементов
        private List<Movie> Records { get; set; }

        private bool CheckingForMatches(Movie item)
        {
            if (Records.Contains(item))
            {
                return true;
            }
            else
                return false;
        }
        //Конструктор принимаемый путь файла
        public MovieStore(string path)
        {
            this.Path = path;            
        }        
        //Прочитать элементы файла по переданному пути
        public void ReadItemsToFile()
        {
            var fileDeserialization = new MovieFileSerializer();
            Records = fileDeserialization.Deserialize(Path);
            
        }
        //Сохранение сериализованного списка в файл по пути
        public void SaveChanges()
        {
            var fileSerialization = new MovieFileSerializer();
            fileSerialization.Serialize(Path, Records);
        }
        //Откат к изначальному варианту списка
        public void RollbackChanges()
        {
            Records.Clear();
            ReadItemsToFile();
        }
        //Добавить элемент в список
        public void AddElementToList(Movie itemInformation)
        {
            if( (itemInformation != null) && (!CheckingForMatches(itemInformation)) )
            {
                Records.Add(itemInformation);
            }
        }
        //Удалить элемент списка по индексу
        public void DeliteItemInList(Movie recordInformation)
        {
            if (Records.Count > 0)
            {
                Records.Remove(recordInformation);
            }
        }
        //Изменить элемент списка на переданный 
        public void ChangeItemInList(Movie itemInformatio, Movie recordInformation)
        {
            if(itemInformatio != null)
            {
                Records.Insert(Records.IndexOf(recordInformation), itemInformatio);
            }
        }       
        //Вывод десериализованной информации
        public void WriteItemsToFile()
        {
            Records = new List<Movie>();
            var fileDeserialization = new MovieFileSerializer();
            Records = fileDeserialization.Deserialize(Path);
            foreach(var itemInformation in Records)
            {
                Console.Write(itemInformation.Link + "   -   ");
                Console.WriteLine(itemInformation.Name);
            }            
        }
    }
}
