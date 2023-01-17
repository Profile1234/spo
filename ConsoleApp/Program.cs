using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите тип движения:");
            Console.WriteLine("1 - равномерное");
            Console.WriteLine("2 - равноускоренное");
            Console.WriteLine("3 - колебательное");
            Console.WriteLine("4 - выход");

            while (true)
            {
                char movementType = Console.ReadKey(true).KeyChar;

                switch (movementType)
                {
                    case '1':
                        UniformMovement();
                        break;
                    case '2':
                        UniformlyAcceleratedMovement();
                        break;
                    case '3':
                        OscillatoryMovement();
                        break;
                    case '4':
                        return;

                    default:
                        continue;
                }

                Console.ReadLine();
                break;
            }
        }

        /// <summary>
        /// Обработка выбора равномерного движения
        /// </summary>
        private static void UniformMovement()
        {
            try
            {
                Console.WriteLine("Введите координаты начальной точки:");
                double.TryParse(Console.ReadLine(), out double y0);
                Console.WriteLine("Введите скорость тела (в метрах в секунду):");
                double.TryParse(Console.ReadLine(), out double v);
                Console.WriteLine("Введите время движения (в секундах):");
                double.TryParse(Console.ReadLine(), out double t);

                if (t > 0)
                {
                    Uniform uniform = new Uniform
                    {
                        StartTimeCoordinate = y0,
                        Time = t,
                        Speed = v
                    };

                    Console.WriteLine();
                    Console.WriteLine(uniform.ToString());
                }
                else
                {
                    new ArgumentOutOfRangeException(t.ToString(), "Недопустимое значение времени");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }




        /// <summary>
        /// Обработка выбора равноускоренного движения
        /// </summary>
        private static void UniformlyAcceleratedMovement()
        {
            try
            {
                Console.WriteLine("Введите координаты начальной точки:");
                double.TryParse(Console.ReadLine(), out double y0);
                Console.WriteLine("Введите начальную скорость (в секундах):");
                double.TryParse(Console.ReadLine(), out double v0);
                Console.WriteLine("Введите время движения (в секундах):");
                double.TryParse(Console.ReadLine(), out double t);
                Console.WriteLine("Введите ускорение тела (в метрах в секунду):");
                double.TryParse(Console.ReadLine(), out double a);

                if (Convert.ToDouble(t) > 0)
                {
                    UniformlyAccelerated uniform = new UniformlyAccelerated
                    {
                        StartTimeCoordinate = y0,
                        StartSpeed = v0,
                        Time = t,
                        Acceleration = a
                    };

                    Console.WriteLine();
                    Console.WriteLine(uniform.ToString());
                }
                else new ArgumentOutOfRangeException(t.ToString(), $"Недопустимое значение времени");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Обработка выбора колебательного движения
        /// </summary>
        private static void OscillatoryMovement()
        {
            try
            {
                Console.WriteLine("Введите амплитуду колебания:");
                double.TryParse(Console.ReadLine(), out double a);
                Console.WriteLine("Введите циклическую частоту:");
                double.TryParse(Console.ReadLine(), out double w);
                Console.WriteLine("Введите время движения (в секундах):");
                double.TryParse(Console.ReadLine(), out double t);
                Console.WriteLine("Введите начальную фазу:");
                double.TryParse(Console.ReadLine(), out double fi0);

                if (Convert.ToDouble(t) > 0)
                {
                    Oscillatory uniform = new Oscillatory
                    {
                        Amplitude = a,
                        CyclicFrequency = w,
                        Time = t,
                        InitialPhase = fi0
                    };

                    Console.WriteLine();
                    Console.WriteLine(uniform.ToString());
                }
                else new ArgumentOutOfRangeException(t.ToString(), $"Недопустимое значение времени");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
