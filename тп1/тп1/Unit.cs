using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUT
{
    /// <summary>
    /// Установка
    /// </summary>
    public class Unit
    {
        /// <summary>
        /// Уникальный идентификатор установки
        /// </summary>
        public Guid ID { get; }

        /// <summary>
        /// Название установки
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание установки
        /// </summary>
        public string Description { get; set; }


        /// <summary>
        /// Уникальный идентификатор завода
        /// </summary>
        public Guid FactoryID { get; }
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        public Unit(Guid id, string name, string description, Guid factoryID)
        {

            ID = id;
            Name = name;
            Description = description;
            FactoryID = factoryID;
        }
        /// <summary>
        /// Заполнение таблицы
        /// </summary>
        public static List<Unit> GetUnits(List<Factory> factories)
        {
            var units = new List<Unit>
            {
                new Unit(Guid.NewGuid(), "ГФУ-2", "Газофракционирующая установка", factories[0].ID),
                new Unit(Guid.NewGuid(), "АВТ-6", "Атмосферно-вакуумная трубчатка", factories[0].ID),
                new Unit(Guid.NewGuid(), "АВТ-10", "Атмосферно-вакуумная трубчатка", factories[1].ID)
            };

            return units;
        }

        /// <summary>
        /// Вывод информации об установке
        /// </summary>
        public void DisplayInfo()
        {
            Console.WriteLine($"ID: {ID} Name: {Name} Description: {Description} FactoryID: {FactoryID}");
        }

        /// <summary>
        /// Поиск установки по имени резервуара
        /// </summary>
        public static Unit FindUnit(Unit[] units, Tank[] tanks, string unitName)
        {
            foreach (var tank in tanks)
            {
                if (string.Equals(tank.Name, unitName))
                {
                    foreach (var unit in units)
                    {
                        if (unit.ID == tank.UnitID)
                        {
                            return unit;
                        }
                    }
                }
            }
            // Если установка не найдена, возвращаем null
            return null;
        }
    }
}