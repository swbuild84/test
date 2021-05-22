using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LepFoundation
{
    public class Rigel
    {
        /// <summary>
        /// Длина ригеля, м
        /// </summary>       
        public double L { get => L; set => L = value; }

        /// <summary>
        /// Ширина ригеля, м
        /// </summary>       
        public double B { get => B; set => B = value; }

        /// <summary>
        /// Толщина ригеля, м
        /// </summary>       
        public double A { get => A; set => A = value; }

        /// <summary>
        /// Привязка ригеля от уровня планировки, м
        /// </summary>       
        public double Yr { get => Yr; set => Yr = value; }

        /// <summary>
        /// Объем, м3
        /// </summary>       
        public double Volume { get => Volume; set => Volume = value; }

        /// <summary>
        /// Масса, т
        /// </summary>       
        public double Weight { get => Weight; set => Weight = value; }

    }
}
