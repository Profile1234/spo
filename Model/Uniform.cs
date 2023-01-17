using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// равномерное движение
    /// </summary>
    [Serializable]
    public class Uniform : IMovement
    {
        /// <summary>
        /// Координата в начальный момент времени t = 0
        /// </summary>
        private double _y0;

        /// <summary>
        /// Свойство для работы с у
        /// </summary>
        public double StartTimeCoordinate
        {
            get => _y0;
            set => _y0 = value;
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
        /// Скорость тела
        /// </summary>
        private double _v;

        /// <summary>
        /// Свойство для работы со скоростью тела
        /// </summary>
        public double Speed
        {
            get => _v;
            set => _v = value;
        }

		/// <summary>
		/// Наименование
		/// </summary>
		public string Name => "Равномерное движение";

        /// <summary>
        /// Координата
        /// </summary>
        public double Coordinate => _y0 + _v * _t;

        /// <summary>
        /// Представление в виде строки
        /// </summary>
        /// <returns>Строковое представление движения</returns>
        public override string ToString()
        {
            return $"{Name} с начальной координатой {_y0}, скоростью {_v} и временем {_t}, координата = {Coordinate}";
        }
	}
}
