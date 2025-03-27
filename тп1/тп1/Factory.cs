using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUT
{
    /// <summary>
    /// Заводы
    /// </summary>
    public class Factory
    {
        /// <summary>
        /// Уникальный идентификатор завода
        /// </summary>
        public Guid ID { get; }

        /// <summary>
        /// Название завода
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание завода
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Конструктор с параметрами Factory
        /// </summary>
        public Factory(Guid id, string name, string description)
        {
            ID = id;
            Name = name;
            Description = description;
        }
        /// <summary>
        /// Заполнение таблицы
        /// </summary>
        public static List<Factory> GetFactories()
        {
            var factories = new List<Factory>
            {
                new Factory(Guid.NewGuid(), "НПЗ№1", "Первый нефтеперерабатывающий завод"),
                new Factory(Guid.NewGuid(), "НПЗ№2", "Второй нефтеперерабатывающий завод")
            };

            return factories;
        }
        /// <summary>
        /// Вывод информации о заводе
        /// </summary>
        public void DisplayInfo()
        {
            
            Console.WriteLine($"Id: {ID}\tName: {Name}\tDescription: {Description}");
        }
        /// <summary>
        /// Поиск названия завода по id unit
        /// </summary>
        public static Factory FindFactory(Factory[] factories, Unit unit)
        {
            foreach (var factory in factories)
            {
                if (factory.ID == unit.FactoryID)
                {
                    return factory;
                }
            }
            return null;
        }
    }
}
