namespace AISIS100;

public class ChapterECompression
{
    
    public static double EqE2__1(double ag, double fn)
    {
        var pne = ag * fn;
        return pne;
    }
    
    public static double EqE2__2(double lambdac, double fy)
    {
        var fn = (Math.Pow(0.658, Math.Pow(lambdac, 2.0))) * fy;
        return fn;
    }
    
    public static double EqE2__3(double lambdac, double fy)
    {
        var fn = (0.877 / Math.Pow(lambdac, 2.0)) * fy;
        return fn;
    }
    
    public static double EqE2__4(double fy, double fcre)
    {
        var lambda = Math.Sqrt(fy / fcre);
        return lambda;
    }

    
    public static double EqE3_2__1(double pne)
    {
        var pnl = pne;
        return pnl;
    }
    
    public static double EqE3_2__2(double pcrl, double pne)
    {
        var pnl = (1 - 0.15 * Math.Pow(pcrl/pne, 0.4))*Math.Pow((pcrl/pne), 0.4)*pne;
        return pnl;
    }
    
    
    public static double EqE3_2__3(double pne, double pcrl)
    {
        var lambdal = Math.Sqrt(pne / pcrl);
        return lambdal;
    }


    public static double EqE4__9(double ag, double fy)
    {
        var py = ag * fy;
        return py;
    }

    public static double GlobalBucklingStressFn(double fy, double fcre)
    {
        var lambdac = EqE2__4(fy, fcre);

        if (lambdac <= 1.5) 
        {
            var fn = EqE2__2(lambdac, fy);
            return fn;
        } 
        return EqE2__3(lambdac, fy);
      }
    
    
    
}