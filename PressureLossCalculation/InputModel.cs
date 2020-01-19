using System;
using System.Collections.Generic;
using System.Text;

namespace PressureLossCalculation
{
    public class InputModel
    {
        /// <summary>
        /// Ид пользователя
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Площадь
        /// </summary>
        public double F { get; set; }

        /// <summary>
        /// Периметр
        /// </summary>
        public double P { get; set; }

        /// <summary>
        /// Плотность газов
        /// </summary>
        public double P0 { get; set; }

        /// <summary>
        /// Температура
        /// </summary>
        public double T0 { get; set; }

        /// <summary>
        /// Рассход газа
        /// </summary>
        public double V0 { get; set; }

        /// <summary>
        /// Длина
        /// </summary>
        public double L { get; set; }

        /// <summary>
        /// Высота
        /// </summary>
        public double H { get; set; }

        /// <summary>
        /// Тип участка
        /// </summary>
        public int Type { get; set; }
    }
}
