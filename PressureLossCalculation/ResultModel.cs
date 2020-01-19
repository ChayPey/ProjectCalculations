using System;
using System.Collections.Generic;
using System.Text;

namespace PressureLossCalculation
{
    public class ResultModel
    {
        /// <summary>
        /// Ид пользователя
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Эквивалентный диаметр
        /// </summary>
        public double D { get; set; }

        /// <summary>
        /// Плотность газа
        /// </summary>
        public double Pg { get; set; }

        /// <summary>
        /// Объемный расход дымовых газов
        /// </summary>
        public double V0 { get; set; }

        /// <summary>
        /// Скорость дымовых газов
        /// </summary>
        public double W { get; set; }

        /// <summary>
        /// Число Рейнольдса для участка
        /// </summary>
        public double Re { get; set; }

        /// <summary>
        /// Лямда
        /// </summary>
        public double Lm { get; set; }

        /// <summary>
        /// Потери давления на трение
        /// </summary>
        public double Pt { get; set; }

        /// <summary>
        /// Местные потери по газовому тракту 
        /// </summary>
        public double Pm { get; set; }

        /// <summary>
        /// Геометрические потери
        /// </summary>
        public double Pgem { get; set; }
    }
}
