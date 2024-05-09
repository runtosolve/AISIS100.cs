namespace AISIS100;
public static class Core
{

    public static double CalculateAvailableStrength(double rn, string designMethod, Dictionary<string,double> safetyResistanceFactors)
    {
        if ((designMethod == "LRFD") | (designMethod == "LSD"))
        {
            var aRn = safetyResistanceFactors[designMethod] * rn;
            return aRn;
        }

        if (designMethod == "ASD")

        {
            var aRn = rn / safetyResistanceFactors[designMethod];
            return aRn;
        }

        return Double.NaN;

    }

}