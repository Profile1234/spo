using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class UniformlyAccelerated : IMovement
    {
        /// <summary>
        /// Координата в начальный момент времени t = 0
        /// </summary>
        private double _y0;

        /// <summary>
        /// Свойство для работы с у0
        /// </summary>
        public double StartTimeCoordinate
        {
            get => _y0;
            set => _y0 = value;
        }

        /// <summary>
        /// Начальная скорость
        /// </summary>
        private double _v0;

        /// <summary>
        /// Свойство для работы с начальной скоростью
        /// </summary>
        public double StartSpeed
        {
            get => _v0;
            set => _v0 = value;
        }

        /// <summary>
        /// Время (в секундах)
        /// </summary>
        private double _t;

        /// <summary>
        /// Свойство для работы со временем
        /// </summary>
        public double Time
        {
            get => _t;
            set => _t = value;
        }

        /// <summary>
        /// Ускорение
        /// </summary>
        private double _a;

        /// <summary>
        /// Свойство для работы с ускорением
        /// </summary>
        public double Acceleration
        {
            get => _a;
            set => _a = value;
        }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name => "Равноускоренное движение";

        /// <summary>
        /// Координата
        /// </summary>
        public double Coordinate => _y0 + _v0 * _t + (_a * _t * _t) / 2;

        /// <summary>
        /// Представление в виде строки
        /// </summary>
        /// <returns>Строковое представление движения</returns>
        public override string ToString()
        {
            return $"{Name} с начальной координатой {_y0}, начальной скоростью {_v0}, временем {_t} и начальным ускорением {_a}, координата = {Coordinate} ";
        }
	}
}
