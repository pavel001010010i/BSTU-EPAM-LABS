using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle
{
    public class Triangle
    {
        public static bool IsTriangle(double a, double b, double c, string str)
        {
            return a > 0 && b > 0 && a + b > c && b + c > a && a + c > b;
        }
        public static bool IsIsoscelesTriangle(double a, double b, double c, string str)
        {
            return IsTriangle(a, b, c, str) && (a == b || b == c || a == c);
        }
        public static bool IsRightTriangle(double a, double b, double c, string str)
        {
            return IsTriangle(a, b, c, str) &&
                ((Math.Pow(a, 2) + Math.Pow(b, 2)) == Math.Pow(c, 2) ||
                (Math.Pow(a, 2) + Math.Pow(c, 2)) == Math.Pow(b, 2) ||
                (Math.Pow(b, 2) + Math.Pow(c, 2)) == Math.Pow(a, 2));
        }
    }
    
}
