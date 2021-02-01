using System;
using System.Collections.Generic;
using System.Text;

namespace Figury_mierzalne___hierarchia_klas_i_interfejsów
{
    public class Sfera : Figura3D, IMierzalna2D
    {
        public Punkt3D O;
        public double R;

        public Sfera()
        {
            O = Punkt3D.ZERO;
            R = 0;
        }

        public Sfera(Punkt3D srodek, double promien) : base()
        {
            O = srodek;
            R = promien;
        }
        public double Pole => 4 * Math.PI * R * R;

        public override void Przesun(double dx, double dy, double dz)
        {
            O = new Punkt3D(O.X + dx, O.Y + dy, O.Z + dz);
        }

        public override void Przesun(Wektor3D kierunek)
        {
            O = new Punkt3D(O.X + kierunek.X, O.Y + kierunek.Y, O.Z + kierunek.Z);
        }
        public Kula ToKula() => new Kula(this.O, this.R);

        public void Skaluj(double wspSkalowania)
        {
            if (wspSkalowania < 0) throw new ArgumentOutOfRangeException("Nie można skalować przez ujemną liczbę");
            R *= wspSkalowania;
        }
        public override string ToString() => $"Sfera({O}, {R})";
        public virtual string ToString(Format format) => (format is Format.Prosty) ? this.ToString() : $"{base.ToString()}, {this.ToString()}, Pole = {Pole}";
    }
}
