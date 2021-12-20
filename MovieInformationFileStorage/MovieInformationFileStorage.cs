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
        private MovieFileSerializer _classSerializerOrDeserializer { get; set; }       
        //Список элементов
        private List<Movie> Records { get; set; }
        private bool Exists(Movie item)
        { 
            return FindPosition(item) >= 0;
        }
        //Конструктор принимаемый путь файла
        public MovieStore(MovieFileSerializer classSerializer)
        {            
            _classSerializerOrDeserializer = classSerializer;            
        }        
        //Прочитать элементы файла по переданному пути
        public List<Movie> SelectAll()
        {
            Records = _classSerializerOrDeserializer.Deserialize();
            return Records;
        }
        //Записать список фильмов, принятых методом
        public void AddRange(List<Movie> movies)
        {
            Records.AddRange(movies);
            _classSerializerOrDeserializer.Serialize(Records);
        }
        //Сохранение сериализованного списка в файл по пути
        public void SaveChanges()
        {            
            _classSerializerOrDeserializer.Serialize(Records);
        }
        //Откат к изначальному варианту списка
        public void RollbackChanges()
        {
            Records.Clear();
            SelectAll();
        }
        //Добавить элемент в список
        public void Add(Movie itemInformation)
        {
            if(itemInformation == null)
                throw new ArgumentNullException(nameof(itemInformation));
            if (Exists(itemInformation))
                throw new InvalidOperationException("Этот элемент уже добавлен");

            Records.Add(itemInformation);
            _classSerializerOrDeserializer.Serialize(Records);
        }
        //Удалить элемент списка
        public void Delite(Movie recordInformation)
        {
            Records.Remove(recordInformation);
            _classSerializerOrDeserializer.Serialize(Records);
        }

        //Изменить элемент списка на переданный 
        public void Update(Movie updateItem)
        {
            var index = FindPosition(updateItem);
            if (index < 0)
                return;

            Records[index] = updateItem;
            _classSerializerOrDeserializer.Serialize(Records);
        }  

        private int FindPosition(Movie item)
        {
            for (int i = 0; i < Records.Count; i++)
            {
                Movie? record = Records[i];
                if (record.Id == item.Id)
                    return i;
            }
            return -1;
        }
    }
}
