using System;
using System.Collections.Generic;
using System.Text;

namespace Figury_mierzalne___hierarchia_klas_i_interfejsów
{
    public class Okrag2D : Figura2D, IMierzalna1D
    {
        public Punkt2D O;
        public double R;
        
        public Okrag2D() : base()
        {
            O = new Punkt2D();
            R = 0;
            Nazwa = Nazwa;
        }
        public Okrag2D(Punkt2D srodek, double promien, string nazwa) : base()
        {
            this.O = srodek;
            this.R = promien;
        }

        public double Dlugosc => Math.Round(2 * Math.PI * R, 2);

        public void Skaluj(double wspSkalowania)
        {
            if (wspSkalowania < 0) throw new ArgumentOutOfRangeException("Wspolrzedna skalowania nie moze byc ujemna!");
            R = R * 2 * wspSkalowania;
        }

        public override string ToString() => $"Okrag2D({O}, {R})";
        public virtual string ToString(Format format) => (format is Format.Prosty) ? this.ToString() : $"{base.ToString()}, {ToString()}, Długość = {Dlugosc}";

        public static explicit operator Okrag2D(Kula v)
        {
            return new Kolo2D(new Punkt2D(v.O.X, v.O.Y), v.R);
        }

        public static explicit operator Okrag2D(Sfera v)
        {
            return new Kolo2D(new Punkt2D(v.O.X, v.O.Y), v.R);
        }

        public Kolo2D ToKolo2D()
        {
            return new Kolo2D(O, R, Nazwa);
        }

        public override void Przesun(double dx, double dy)
        {
            O = new Punkt2D(O.X + dx, O.Y + dy);
        }

        public override void Przesun(Wektor2D kierunek)
        {
            O = new Punkt2D(O.X + kierunek.X, O.Y + kierunek.Y);
        }
    }
}
