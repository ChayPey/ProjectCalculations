using System;

namespace PressureLossCalculation
{
    public class Calculation
    {
        private readonly double[] Resistances = { 0.095, 0.152, 0.19, 0.228, 0.247, 0.266 };
        private readonly InputModel inputModel;
        private ResultModel resultModel;
        private readonly double vr = 112.1/1000000.0; //Кинематическая вязкость
        private readonly double pv = 1.293; //Плотность воздуха

        public Calculation(InputModel newInputModel)
        {
            inputModel = newInputModel;
            resultModel = new ResultModel();
        }

        /// <summary>
        /// Возвращает результаты вычислений
        /// </summary>
        /// <returns>resultModel</returns>
        public ResultModel Result()
        {
            return resultModel;
        }

        /// <summary>
        /// Вычисляет заданные данные
        /// </summary>
        public void Count()
        {
            EquivalentDiameter();
            FlueGasDensity();
            FlueGasFlowRate();
            FlueGasSpeed();
            ReynoldsNumber();
            FrictionPressureLoss();
            LocalGasosses();
            GeometricLoss();
        }

        /// <summary>
        /// 1)Расчет эквивалентного диаметра
        /// </summary>
        private void EquivalentDiameter()
        {
            resultModel.D = 4.0 * inputModel.F / inputModel.P;
        }


        /// <summary>
        /// 2)Плотность дымовых газов
        /// </summary>
        private void FlueGasDensity()
        {
            resultModel.Pg = (273.0 / (273.0 + inputModel.T0)) * inputModel.P0;
        }

        /// <summary>
        /// 3)Объемный расход дымовых газов
        /// </summary>
        private void FlueGasFlowRate()
        {
            resultModel.V0 = inputModel.V0 * (inputModel.T0 + 273.0) / 273.0;
        }

        /// <summary>
        /// 4)Скорость дымовых газов
        /// </summary>
        private void FlueGasSpeed()
        {
            resultModel.W = resultModel.V0 / inputModel.F;
        }

        /// <summary>
        /// 5)Число Рейнольдса для участка
        /// </summary>
        private void ReynoldsNumber()
        {
            resultModel.Re = resultModel.W * resultModel.D / vr;
        }

        /// <summary>
        /// 6)Потери давления на трение
        /// </summary>
        private void FrictionPressureLoss()
        {
            resultModel.Lm = 0.11 * Math.Pow(0.7 / 1000.0 / resultModel.D + 68.0 / resultModel.Re, 0.25);
            resultModel.Pt = resultModel.Lm * (inputModel.L / resultModel.D) * (resultModel.W * resultModel.W * resultModel.Pg / 2.0);
        }

        /// <summary>
        /// 7)Местные потери давления по газовому тракту 
        /// </summary>
        private void LocalGasosses()
        {
            resultModel.Pm = Resistances[inputModel.Type] * (resultModel.Pg * resultModel.W * resultModel.W / 2);
        }

        /// <summary>
        /// 8)Геометрические потери давления
        /// </summary>
        private void GeometricLoss()
        {
            resultModel.Pgem = (pv - resultModel.Pg) * 9.81 * inputModel.H;
        }
    }
}
