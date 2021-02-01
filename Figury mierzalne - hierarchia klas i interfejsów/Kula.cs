using System;
using System.Collections.Generic;
using System.Text;

namespace Figury_mierzalne___hierarchia_klas_i_interfejsów
{
    public class Kula : Sfera, IMierzalna2D, IMierzalna3D
    {
        public Kula() : base() { }
        public Kula(Punkt3D srodek, double promien) : base(srodek, promien)
        {
            O = srodek;
            R = promien;
        }
        public double Objetosc => (4 / 3) * Math.PI * R * R;

        public Sfera ToSfera() => new Sfera(this.O, this.R);

        public override string ToString() => $"Kula({O}, {R})";
        public override string ToString(Format format) => (format is Format.Prosty) ? this.ToString() : $"{base.ToString(format)}, Objetosc = {Objetosc}";
    }
}
