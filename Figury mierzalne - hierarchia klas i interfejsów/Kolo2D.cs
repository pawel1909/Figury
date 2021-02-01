using System;
using System.Collections.Generic;
using System.Text;

namespace Figury_mierzalne___hierarchia_klas_i_interfejsów
{
    /// <summary>
    /// Koło2D o środku O i promieniu R. Obiekty są mutable.
    /// </summary>
    public class Kolo2D : Okrag2D, IMierzalna1D, IMierzalna2D
    {
        public Kolo2D() : base() { }
        public Kolo2D(Punkt2D srodek, double promien = 0, string nazwa = "") : base(srodek, promien, nazwa)
        {
            R = promien;
            O = srodek;
        }
        public double Pole => Math.PI * R * R;
        public double Obwod => Dlugosc;
        public override string ToString() => $"Kolo2D({O}, {R})";

        public override string ToString(Format format)
            => (format is Format.Prosty) ?
                  this.ToString()
                : base.ToString(format).Replace("Długość", "Obwód") + $", Pole = {Pole:0.##}";

        public Okrag2D ToOkrag2D()
        {
            return new Okrag2D(O, R, Nazwa);
        }

        public static explicit operator Kolo2D(Kula v)
        {
            return new Kolo2D(new Punkt2D(v.O.X, v.O.Y), v.R);
        }

        
    }
}
