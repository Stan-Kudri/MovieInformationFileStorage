using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace MovieInformationFileStorage
{
        //Проверку по пути добавлю, поздно подумал о ней....................
        internal class WorkingWithElements
    {
        //Путь файла
        public string Path{get;set;}
        //Существует ли файл в переданном пути
        private bool FileConnection { get; set; }
        //Список элементов
        List<RecordingInformation> records { get; set; }
        
        //Конструктор принимаемый путь файла
        public WorkingWithElements(string path) => this.Path = path;

        //Проверка наличия файла, по выбранному пути
        public void CreateFileNotExists()
        {
            if (!File.Exists(Path)) File.Create(Path);
            FileConnection = true;
        }
        //Прочитать элементы файла по переданному пути
        public void ReadItemsToFile()
        {
            if((FileConnection == true) && (records == null))
            {
                records = new List<RecordingInformation>();
                var fileDeserialization = new Serialization();
                records = fileDeserialization.Deserialize(Path);
            }

        }
        //Добавить элемент в список
        public void AddElementToList(RecordingInformation itemInformation)
        {
            if( (FileConnection == true) && (itemInformation != null) )
            {
                records.Add(itemInformation);
            }
        }
        //Удалить элемент списка по индексу
        public void DeliteItemInList(int index) => records.RemoveAt(index);
        //Изменить элемент списка по индексу (далее будут формы, и его пользователю не нужно будет знать)
        public void ChangeItemInList(RecordingInformation itemInformatio, int index)
        {
            if( (FileConnection == true) && (itemInformatio != null) )
            {
                records.Insert(index, itemInformatio);
            }
        }
        //Сохранение сериализованного списка в файл по пути
        public void SaveSerializeList()
        {
            var fileSerialization = new Serialization();
            fileSerialization.Serialize(Path, records);
        }
        //Вывод десериализованной информации
        public void WriteItemsToFile()
        {
            if(FileConnection == true)
            {
                records = new List<RecordingInformation>();
                var fileDeserialization = new Serialization();
                records = fileDeserialization.Deserialize(Path);
                foreach(var itemInformation in records)
                {
                    Console.Write(itemInformation.MovieLink + "   -   ");
                    Console.WriteLine(itemInformation.MovieName);
                }
            }
        }



    }
}
