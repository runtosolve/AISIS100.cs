namespace AISIS100;

public class ChapterJConnections
{
    public static double EqJ4_4_1__1(double tc, double d, double Fu2, string units, Output? output = null)
    {

        if (units == "inches")
        {
            var alpha = 1.0;
            var Pnot = 0.85 * tc * d * Fu2 * (1.63 * Math.Pow(alpha * tc, 0.18));
            output?.AddResult("Pnot", Pnot, "Eq.J4.4.1-1");
            return Pnot;
        }
        else
        {
            var alpha = 0.0394;
            var Pnot = 0.85 * tc * d * Fu2 * (1.63 * Math.Pow(alpha * tc, 0.18));
            output?.AddResult("Pnot", Pnot, "Eq.J4.4.1-1");
            return Pnot;
        }
        
    }

    
    public static double EqJ4_4_2__1(double t1, double dPrimew, double Fu1, Output? output = null)
    {

        var Pnov = 0.90 * t1 * dPrimew * Fu1;
        output?.AddResult("Pnov", Pnov, "Eq.J4.4.2-1");

        return Pnov;
        
    }
    
    public static double EqJ4_4_2__3(double dh, double tw, double t1, double dw, Output? output = null)
    {

        var dPrimew = Math.Min(dh + 2 * tw + t1, dw);
        output?.AddResult("dPrimew", dPrimew, "Eq.J4.4.2-3");

        return dPrimew;
        
    }
    
    
    public static double AvailablePulloutStrength(double Pnot, string designMethod, Output? output = null)

    {
        
        Dictionary<string, double> safetyResistanceFactors =  
            new Dictionary<string, double>();
            
        safetyResistanceFactors.Add("ASD", 2.80);
        safetyResistanceFactors.Add("LRFD", 0.55);
        safetyResistanceFactors.Add("LSD", 0.45);
        
        var aPnot = AISIS100.Core.CalculateAvailableStrength(Pnot, designMethod, safetyResistanceFactors, output);

        return aPnot;

    }
    
 


    public static double AvailablePulloverStrength(double Pnov, string designMethod, Output? output = null)

    {
        
        Dictionary<string, double> safetyResistanceFactors =  
            new Dictionary<string, double>();
            
        safetyResistanceFactors.Add("ASD", 2.90);
        safetyResistanceFactors.Add("LRFD", 0.55);
        safetyResistanceFactors.Add("LSD", 0.40);
        
        var aPnov = AISIS100.Core.CalculateAvailableStrength(Pnov, designMethod, safetyResistanceFactors, output);

        return aPnov;

    }
    
    
}