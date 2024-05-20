namespace AISIS100;

public class ChapterJConnections
{
    public static double EqJ4_4_1__1(double tc, double d, double fu2, string units)
    {

        if (units == "inches")
        {
            var alpha = 1.0;
            return 0.85 * tc * d * fu2 * (1.63 * Math.Pow(alpha * tc, 0.18));
        }
        else
        {
            var alpha = 0.0394;
            return 0.85 * tc * d * fu2 * (1.63 * Math.Pow(alpha * tc, 0.18));
        }
        
    }

    
    public static double EqJ4_4_2__1(double t1, double dprimew, double fu1)
    {

        var pnov = 0.90 * t1 * dprimew * fu1;

        return pnov;
        
    }
    
    public static double EqJ4_4_2__3(double dh, double tw, double t1, double dw)
    {

        var dprimew = Math.Min(dh + 2 * tw + t1, dw);

        return dprimew;
        
    }
    
    
    public static double AvailablePulloutStrength(double pnot, string designMethod)

    {
        
        Dictionary<string, double> safetyResistanceFactors =  
            new Dictionary<string, double>();
            
        safetyResistanceFactors.Add("ASD", 2.80);
        safetyResistanceFactors.Add("LRFD", 0.55);
        safetyResistanceFactors.Add("LSD", 0.45);
        
        var aPnot = AISIS100.Core.CalculateAvailableStrength(pnot, designMethod, safetyResistanceFactors);

        return aPnot;

    }
    
 


    public static double AvailablePulloverStrength(double pnov, string designMethod)

    {
        
        Dictionary<string, double> safetyResistanceFactors =  
            new Dictionary<string, double>();
            
        safetyResistanceFactors.Add("ASD", 2.90);
        safetyResistanceFactors.Add("LRFD", 0.55);
        safetyResistanceFactors.Add("LSD", 0.40);
        
        var aPnov = AISIS100.Core.CalculateAvailableStrength(pnov, designMethod, safetyResistanceFactors);

        return aPnov;

    }
    
    
}