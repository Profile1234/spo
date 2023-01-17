using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Интерфейс для всех видов движения
    /// </summary>
    public interface IMovement
    {
        /// <summary>
        /// Наименование движения
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Координата движения
        /// </summary>
        double Coordinate { get; }

        /// <summary>
        /// Представление движения в виде строки
        /// </summary>
        /// <returns>Строковое представление движения</returns>
        string ToString();
    }
}
