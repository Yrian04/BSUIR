namespace PPOIS_lab1
{
    public class Vector
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public Vector() : this(0, 0, 0) { }
        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public Vector((double x, double y, double z) p1, (double x, double y, double z) p2)
        {
            X = p2.x - p1.x;
            Y = p2.y - p1.y;
            Z = p2.z - p1.z;
        }

        public static implicit operator Vector((double, double, double) v) => new Vector(v.Item1, v.Item2, v.Item3);
        public static implicit operator (double, double, double)(Vector v) => (v.X, v.Y, v.Z);

        public double Module()
        {
            double x2 = Math.Pow(X, 2);
            double y2 = Math.Pow(Y, 2);
            double z2 = Math.Pow(Z, 2);

            return Math.Sqrt(x2 + y2 + z2);
        }

        public static Vector operator +(Vector a, Vector b) => new Vector(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        public static Vector operator -(Vector a, Vector b) => new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        public static double operator *(Vector a, Vector b) => a.X * b.X + a.Y * b.Y + a.Z * b.Z;
        public static Vector operator *(double n, Vector v) => new Vector(v.X * n, v.Y * n, v.Z * n);
        public static Vector operator *(Vector v, double n) => n * v;
        public static double operator ^(Vector a, Vector b)
        {
            if (a == (0, 0, 0) || b == (0, 0, 0))
                throw new ArgumentNullException();
            return a * b / (a.Module() * b.Module());
        }

        public static bool operator >(Vector a, Vector b) => a.Module() > b.Module();
        public static bool operator >=(Vector a, Vector b) => a.Module() >= b.Module();
        public static bool operator <(Vector a, Vector b) => a.Module() < b.Module();
        public static bool operator <=(Vector a, Vector b) => a.Module() <= b.Module();
        public static bool operator ==(Vector a, Vector b) => a.Equals(b);
        public static bool operator !=(Vector a, Vector b) => !a.Equals(b);

        public override bool Equals(object? obj) => obj is Vector v && X == v.X && Y == v.Y && Z == v.Z;
        public override string ToString() => $"({X}, {Y}, {Z})";
    }
}
