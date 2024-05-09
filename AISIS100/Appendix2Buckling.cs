using System.Security.Cryptography;

namespace AISIS100;

public static class Appendix2Buckling
{
    public static double Eq2_3_1__1(double e, double ix, double kx, double lx)
    {
        var pex = Math.Pow(Math.PI, 2.0) * e * ix / Math.Pow((kx * lx), 2.0);
        return pex;
    }
    
    public static double Eq2_3_1__2(double e, double iy, double ky, double ly)
    {
        var pey = Math.Pow(Math.PI, 2.0) * e * iy / Math.Pow((ky * ly), 2.0);
        return pey;
    }
    
    public static double Eq2_3_1__3(double ro, double g, double j, double e, double cw, double kt, double lt)
    {
        var pt = 1 / Math.Pow(ro, 2.0) * (g * j + (Math.Pow(Math.PI, 2.0) * e * cw) / Math.Pow(kt * lt, 2.0));
        return pt;
    }
    
    public static double Eq2_3_1__4(double xo, double ro, double kt, double lt, double kx, double lx)
    {
        var beta = 1 - Math.Pow((xo / ro), 2.0) * Math.Pow((kt*lt)/(kx*lx), 2.0);
        return beta;
    }

    public static double Eq2_3_1_1_1__1(double e, double i, double k, double l)
    {
        var pcre = (Math.Pow(Math.PI, 2.0) * e * i) / Math.Pow((k * l), 2.0);
        return pcre;
    }
    
    public static double Eq2_3_1_1_2__1(double beta, double pex, double pt)
    {
        var pcre = (1 / (2 * beta)) * ((pex + pt) - Math.Sqrt(Math.Pow(pex + pt, 2.0) - 4 * beta * pex * pt));
        return pcre;
    }
    
}