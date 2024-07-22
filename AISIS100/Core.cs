namespace AISIS100;
public static class Core
{

    public static double CalculateAvailableStrength(double rn, string designMethod, Dictionary<string,double> safetyResistanceFactors, Output? output = null)
    {
        
        if (designMethod == "ASD")
        {
            var aRn = rn / safetyResistanceFactors[designMethod];
            output?.AddResult("aRn", aRn, "Eq.B3.2.1-2");
            
            return aRn;
        }
        
        if (designMethod == "LRFD")
        {
            var aRn = safetyResistanceFactors[designMethod] * rn;
            output?.AddResult("aRn", aRn, "Eq.B3.2.2-2");
            
            return aRn;
        }

        if (designMethod == "LSD")
        {
            var aRn = safetyResistanceFactors[designMethod] * rn;
            output?.AddResult("aRn", aRn, "Eq.B3.2.3-2");
            
            return aRn;
            
        }
        
        return Double.NaN;

    }

}