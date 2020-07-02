using System;

namespace MavlinkTester.Function
{
    public static class Formula
    {
        public static readonly double e9 = Math.Pow(10, -9);

        public static readonly double RadE9ToDegree = ((180 / Math.PI) * e9 * 2);
        public static readonly double DegreeToRadianE9 = ((Math.PI / 180) / e9 / 2);

        public static readonly double RadToDegree = (180 / Math.PI);
        public static readonly double DegreeToRadian = (Math.PI / 180);
    }
}
