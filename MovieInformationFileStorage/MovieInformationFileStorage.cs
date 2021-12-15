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
        internal class WorkInElement
    {
        //Путь файла
        public string Path{get;set;}
        //Список элементов
        private List<RecordInformation> Records { get; set; }
        //Конструктор принимаемый путь файла
        public WorkInElement(string path)
        {
            this.Path = path;
            if (!File.Exists(Path))
            {
                File.Create(Path);
                
            }
            Records = new List<RecordInformation>();
        }        
        //Прочитать элементы файла по переданному пути
        private void ReadItemsToFile()
        {
            if(Records == null)
            {
                var fileDeserialization = new MovieFileSerializer();
                Records = fileDeserialization.Deserialize(Path);
            }
        }
        //Сохранение сериализованного списка в файл по пути
        public void SaveSerializeList()
        {
            var fileSerialization = new MovieFileSerializer();
            foreach (var itemInformation in Records)
            {
                Console.Write(itemInformation.MovieLink + "   -   ");
                Console.WriteLine(itemInformation.MovieName);
            }
            fileSerialization.Serialize(Path, Records);
        }
        //Откат к изначальному варианту списка
        public void RollbackChanges()
        {
            Records.Clear();
            ReadItemsToFile();
        }
        //Добавить элемент в список
        public void AddElementToList(RecordInformation itemInformation)
        {
            if(itemInformation != null)
            {
                Records.Add(itemInformation);
            }
        }
        //Удалить элемент списка по индексу
        public void DeliteItemInList(RecordInformation recordInformation)
        {
            if (Records.Count > 0)
            {
                Records.Remove(recordInformation);
            }

        }
        //Изменить элемент списка на переданный 
        public void ChangeItemInList(RecordInformation itemInformatio, RecordInformation recordInformation)
        {
            if(itemInformatio != null)
            {
                Records.Insert(Records.IndexOf(recordInformation), itemInformatio);
            }
        }       
        //Вывод десериализованной информации
        public void WriteItemsToFile()
        {
            Records = new List<RecordInformation>();
            var fileDeserialization = new MovieFileSerializer();
            Records = fileDeserialization.Deserialize(Path);
            foreach(var itemInformation in Records)
            {
                Console.Write(itemInformation.MovieLink + "   -   ");
                Console.WriteLine(itemInformation.MovieName);
            }            
        }
    }
}
