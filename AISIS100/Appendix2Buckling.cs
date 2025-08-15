using System.Security.Cryptography;
using AISIS100.Reporting;

namespace AISIS100;

public static class Appendix2Buckling
{

    public static double Eq2_3_1_1__1(double Pcre, double Ag, Output? output = null)
    {
        var Fcre = Pcre / Ag;
        output?.AddResult("Fcre", Fcre, "Eq.2.3.1.1-1");
        return Fcre;
    }
    
    public static double Eq2_3_1__1(double E, double Ix, double kx, double Lx, Output? output = null)
    {
        var Pex = Math.Pow(Math.PI, 2.0) * E * Ix / Math.Pow((kx * Lx), 2.0);
        output?.AddResult("Pex", Pex, "Eq.2.3.1-1");
        return Pex;
    }
    
    public static double Eq2_3_1__2(double E, double Iy, double ky, double Ly, Output? output = null)
    {
        var Pey = Math.Pow(Math.PI, 2.0) * E * Iy / Math.Pow((ky * Ly), 2.0);
        output?.AddResult("Pey", Pey, "Eq.2.3.1-2");
        return Pey;
    }
    
    public static double Eq2_3_1__3(double ro, double G, double J, double E, double Cw, double kt, double Lt, Output? output = null)
    {
        var Pt = 1 / Math.Pow(ro, 2.0) * (G * J + (Math.Pow(Math.PI, 2.0) * E * Cw) / Math.Pow(kt * Lt, 2.0));
        output?.AddResult("Pt", Pt, "Eq.2.3.1-3");
        return Pt;
    }
    
    public static double Eq2_3_1__4(double xo, double ro, double kt, double Lt, double kx, double Lx, Output? output = null)
    {
        var beta = 1 - Math.Pow((xo / ro), 2.0) * Math.Pow((kt * Lt)/(kx * Lx), 2.0);
        output?.AddResult("beta", beta, "Eq.2.3.1-4");
        return beta;
    }

    public static double Eq2_3_1_1_1__1(double E, double I, double k, double L, Output? output = null)
    {
        var Pcre = (Math.Pow(Math.PI, 2.0) * E * I) / Math.Pow((k * L), 2.0);
        output?.AddResult("Pcre", Pcre, "Eq.2.3.1.1.1-1");
        return Pcre;
    }

    public static double Eq2_3_1_1_2__1(double beta, double Pex, double Pt, Output? output = null)
    {
        var Pcre = 1.0 / (2.0 * beta) * ((Pex + Pt) - Math.Sqrt(Math.Pow((Pex + Pt), 2.0) - 4 * beta * Pex * Pt));
        output?.AddResult("Pcre", Pcre, "Eq.2.3.1.1.2-1");
        return Pcre;
    }

    public static double Section2_3_1_1_2(double E, double G, double Ix, double Iy, double J, double Cw, double xo, double ro, double kx, double Lx, double ky, double Ly, double kt, double Lt, Output? output = null)
    {
        var Pex = Eq2_3_1__1(E, Ix, kx, Lx, output);
        var Pey = Eq2_3_1__2(E, Iy, ky, Ly, output);
        var Pt = Eq2_3_1__3(ro, G, J, E, Cw, kt, Lt, output);

        var beta = Eq2_3_1__4(xo, ro, kt, Lt, kx, Lx, output);

        var Pcreft = Eq2_3_1_1_2__1(beta, Pex, Pt, output);  

        var Pcre = Math.Min(Math.Min(Pex, Pey), Pcreft);
        output?.AddResult("Pcre", Pcre, "Section2.3.1.1-2"); 

        return Pcre;

    }
    
    
    public static double Eq2_3_1_2__1(double Mcre, double Sfc, Output? output = null)
    {
        var Fcre = Mcre / Sfc;
        output?.AddResult("Fcre", Fcre, "Eq.2.3.1.2-1");
        return Fcre;
    }
    
    public static double Eq2_3_1_2_1__1(double Cb, double ro, double Pey, double Pt, Output? output = null)
    {
        var Mcre = Cb * ro * Math.Sqrt(Pey * Pt);
        output?.AddResult("Mcre", Mcre, "Eq.2.3.1.2.1-1");
        return Mcre;
    }

    public static double Eq2_3_1_2_2__1(double Cb, double Cs, double j, double ro, double Pt, double Pex, Output? output = null)
    {
        var Mcre = Cb * Pex * (Cs * Math.Abs(j) + Math.Sqrt(j * j + ro * ro * Pt / Pex));
        output?.AddResult("Mcre", Mcre, "Eq.2.3.1.2.2-1");
        
        return Mcre;
    }
}
