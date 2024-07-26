namespace AISIS100;

public class ChapterJConnections
{
    public static double EqJ4_4_1__1(double tc, double d, double Fu2, string units)
    {

        if (units == "inches")
        {
            var alpha = 1.0;
            var Pnot = 0.85 * tc * d * Fu2 * (1.63 * Math.Pow(alpha * tc, 0.18));
            return Pnot;
        }
        else
        {
            var alpha = 0.0394;
            var Pnot = 0.85 * tc * d * Fu2 * (1.63 * Math.Pow(alpha * tc, 0.18));
            return Pnot;
        }
        
    }

    
    public static double EqJ4_4_2__1(double t1, double dPrimew, double fu1)
    {

        var Pnov = 0.90 * t1 * dPrimew * fu1;

        return Pnov;
        
    }
    
    public static double EqJ4_4_2__3(double dh, double tw, double t1, double dw)
    {

        var dPrimew = Math.Min(dh + 2 * tw + t1, dw);

        return dPrimew;
        
    }
    
    
    public static double AvailablePulloutStrength(double Pnot, string designMethod)

    {
        
        Dictionary<string, double> safetyResistanceFactors =  
            new Dictionary<string, double>();
            
        safetyResistanceFactors.Add("ASD", 2.80);
        safetyResistanceFactors.Add("LRFD", 0.55);
        safetyResistanceFactors.Add("LSD", 0.45);
        
        var aPnot = AISIS100.Core.CalculateAvailableStrength(Pnot, designMethod, safetyResistanceFactors);

        return aPnot;

    }
    
 


    public static double AvailablePulloverStrength(double Pnov, string designMethod)

    {
        
        Dictionary<string, double> safetyResistanceFactors =  
            new Dictionary<string, double>();
            
        safetyResistanceFactors.Add("ASD", 2.90);
        safetyResistanceFactors.Add("LRFD", 0.55);
        safetyResistanceFactors.Add("LSD", 0.40);
        
        var aPnov = AISIS100.Core.CalculateAvailableStrength(Pnov, designMethod, safetyResistanceFactors);

        return aPnov;

    }
    
    
}