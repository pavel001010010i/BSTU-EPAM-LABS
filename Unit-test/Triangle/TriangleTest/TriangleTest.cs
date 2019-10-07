using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
//using Triangle;

namespace TriangleTest
{
    public class TriangleTest: IEnumerable<object>
    {
        public IEnumerator<object> GetEnumerator()
        {
            return (IEnumerator<object>)GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public static IEnumerable<object[]> IsCheckingForAnIsoscelesTriangle()
        {
            yield return new object[] { 12, 10, 10, "rectangular 12, 10, 10" };
            yield return new object[] { 6, 6, 10, "rectangular 6, 6, 10" };
            yield return new object[] { 5, 5, 5, "rectangular 5, 5, 5" };
        }
        public static IEnumerable<object[]> IsCheckingForAnRightTriangle()
        {
            yield return new object[] { 3, 4, 5, "rectangular 3, 4, 5" };
            yield return new object[] { 6, 8, 10, "rectangular 6, 8, 10" };
            yield return new object[] { 12, 16, 20, "rectangular 12, 15, 20" };
        }

        [Theory]
        [MemberData("IsCheckingForAnIsoscelesTriangle")]
        public void IsTriangleIsosceles(double x, double y, double z, string st)
        {
            Assert.True(Triangle.Triangle.IsIsoscelesTriangle(x, y, z,st));
        }
        [Theory]
        [MemberData("IsCheckingForAnRightTriangle")]
        public void IsTriangleRightTest(double x, double y, double z, string st)
        {
            Assert.True(Triangle.Triangle.IsRightTriangle(x, y, z, st));
        }
        [Theory]
        [InlineData(0,2,4,"0,2,4"), InlineData(0, 0, 0, "0,0,0"), InlineData(-1, 1, 2, "-1,1,2"), InlineData(0, 1, -1, "0,1-1")]
        public void IsZeroAndNegativeSide(double x, double y, double z, string st)
        {
            Assert.False(Triangle.Triangle.IsTriangle(x, y, z, st));
        }
    }
}
