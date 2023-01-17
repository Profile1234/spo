using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// колебательное движение
    /// </summary>
    [Serializable]
    public class Oscillatory : IMovement
    {
        /// <summary>
        /// Амплитуда колебания (в метрах)
        /// </summary>
        private double _a;

        /// <summary>
        /// Свойство для работы с амплитудой
        /// </summary>
        public double Amplitude
        {
            get => _a;
            set => _a = value;
        }

        /// <summary>
        /// Циклическая частота
        /// </summary>
        private double _w;

        /// <summary>
        /// Свойство для работы с циклической частотой
        /// </summary>
        public double CyclicFrequency
        {
            get => _w;
            set => _w = value;
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
        /// Начальная фаза
        /// </summary>
        private double _fi0;

        /// <summary>
        /// Свойство для работы с начальной фазой
        /// </summary>
        public double InitialPhase
        {
            get => _fi0;
            set => _fi0 = value;
        }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name => "Колебательное движение";

        /// <summary>
        /// Координата
        /// </summary>
        public double Coordinate => _a * Math.Cos(_w * _t + _fi0);

        /// <summary>
        /// Представление в виде строки
        /// </summary>
        /// <returns>Строковое представление движения</returns>
        public override string ToString()
        {
            return $"{Name} с амплитудой колебания {_a}, циклической частотой {_w}, временем {_t} и начальной фазой {_fi0}, координата = {Coordinate} ";
        }
	}
}
