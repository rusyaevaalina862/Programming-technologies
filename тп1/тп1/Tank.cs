using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUT
{
    /// <summary>
    /// Резервуар
    /// </summary>

    public class Tank
    {
        /// <summary>
        /// Уникальный идентификатор резервуара
        /// </summary>
        public Guid ID { get; }

        /// <summary>
        /// Название резервуара
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание резервуара
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Текущий объем резервуара
        /// </summary>
        public int Volume { get; set; }

        /// <summary>
        /// Максимальный объем резервуара
        /// </summary>
        public int MaxVolume { get; set; }

        /// <summary>
        /// Уникальный идентификатор установки
        /// </summary>
        public Guid UnitID { get; }
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        public Tank(Guid id, string name, string description, int volume, int maxVolume, Guid unitID)
        {
            ID = id;
            Name = name;
            Description = description;
            Volume = volume;
            MaxVolume = maxVolume;
            UnitID = unitID;
        }
        /// <summary>
        /// Заполнение таблицы
        /// </summary>
        public static List<Tank> GetTanks(List<Unit> units)
        {

            var tanks = new List<Tank>
            {
                new Tank(Guid.NewGuid(), "Резервуар 1", "Надземный-вертикальный",                   1500,   2000, units[0].ID),
                new Tank(Guid.NewGuid(), "Резервуар 2", "Надземный-горизонтальный",                 2500,   3000, units[0].ID),
                new Tank(Guid.NewGuid(), "Дополнительный резервуар 24", "Надземный-горизонтальный", 3000,   3000, units[1].ID),
                new Tank(Guid.NewGuid(), "Резервуар 35", "Надземный-вертикальный",                  3000,   3000, units[1].ID),
                new Tank(Guid.NewGuid(), "Резервуар 47", "Подземный-двустенный",                    4000,   5000, units[1].ID),
                new Tank(Guid.NewGuid(), "Резервуар 256", "Подводный",                              500,    500,  units[2].ID)
            };

            return tanks;
        }
        /// <summary>
        /// Вывод информации о резервуаре
        /// </summary>
        public void DisplayInfo()
        {
            Console.WriteLine($"ID: {ID}\tName: {Name}\tDescription: {Description}\tVolume: {Volume}\t" +
                $"MaxVolume: {MaxVolume}\tUnitID: {UnitID} ");
        }

        /// <summary>
        /// Максимальный объем всех резервуаров
        /// </summary>
        public static int GetTotalVolume(Tank[] tanks)
        {
            int totalVolume = 0;
            foreach (var tank in tanks)
            {
                totalVolume += tank.Volume;
            }
            return totalVolume;
        }

        
    }
}
