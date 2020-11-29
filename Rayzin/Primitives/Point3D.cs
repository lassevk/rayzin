using System;

namespace Rayzin.Primitives
{
    public struct Point3D : IEquatable<Point3D>
    {
        public struct Presets
        {
            public static readonly Point3D Zero = new Point3D(0, 0, 0);
            public static readonly Point3D Origo = new Point3D(0, 0, 0);
        }

        public Point3D(double x, double y, double z) => (X, Y, Z) = (x, y, z);
        public void Deconstruct(out double x, out double y, out double z) => (x, y, z) = (X, Y, Z);

        public double X { get; }
        public double Y { get; }
        public double Z { get; }

        public bool Equals(Point3D other) => Epsilon.Equals(X, other.X) && Epsilon.Equals(Y, other.Y) && Epsilon.Equals(Z, other.Z);

        public override bool Equals(object obj) => obj is Point3D other && Equals(other);

        public override int GetHashCode() => throw new NotSupportedException();

        public static bool operator ==(Point3D left, Point3D right) => left.Equals(right);

        public static bool operator !=(Point3D left, Point3D right) => !left.Equals(right);

        public override string ToString() => $"Point3D ({X}, {Y}, {Z})";

        public static Vector3D operator -(Point3D p1, Point3D p2) => new Vector3D(p1.X - p2.X, p1.Y - p2.Y, p1.Z - p2.Z);
        public static Point3D operator +(Point3D p, Vector3D v) => new Point3D(p.X + v.X, p.Y + v.Y, p.Z + v.Z);
    }
}