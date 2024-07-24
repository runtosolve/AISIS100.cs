// ReSharper disable InconsistentNaming
using System.Collections.Immutable;

namespace AISIS100;

public class ChapterGShearWebCripplingTorsion
{
    public static double EqG2_1__1(double Vy)
    {
        var Vn = Vy;
        return Vn;
    }
    
    
    public static double EqG2_1__2(double Vcr, double Vy)
    {
        var Vn = (1 - 0.25 * Math.Pow(Vcr / Vy, 0.65))*Math.Pow((Vcr / Vy), 0.65) * Vy;
        return Vn;
    }
    
    
    public static double EqG2_1__3(double Vy, double Vcr)
    {
        var Lambdav = Math.Sqrt(Vy / Vcr);
        return Lambdav;
    }

    public static double EqG2_1__4(double Aw, double Fy)
    {
        var Vy = 0.6 * Aw * Fy;
        return Vy;
    }
    
    public static double EqG2_1__5(double h, double t)
    {
        var Aw = h * t;
        return Aw;
    }
    
    public static double ShearStrengthVn(double Aw, double Fy, double E, double kv, double mu, double h, double t)
    {

        var Vy = EqG2_1__4(Aw, Fy);

        var Fcr = EqG2_3__2(E, kv, mu, h, t);

        var Vcr = EqG2_3__1(Aw, Fcr);
        
        var Lambdav = EqG2_1__3(Vy, Vcr);

        if (Lambdav <= 0.587) 
        {
            var Vn = EqG2_1__1(Vy);
            return Vn;
        } 
        return EqG2_1__2(Vcr, Vy);
    }

    public static double AvailableShearStrengthVn(double Vn, string designMethod)
    {
   
        Dictionary<string, double> SafetyResistanceFactors =  
            new Dictionary<string, double>();
        
        SafetyResistanceFactors.Add("ASD", 1.67);
        SafetyResistanceFactors.Add("LRFD", 0.90);
        SafetyResistanceFactors.Add("LSD", 0.75);

        var aVn = AISIS100.Core.CalculateAvailableStrength(Vn, designMethod, SafetyResistanceFactors);

        return aVn;
    }
    
    public static double EqG2_3__1(double Aw, double Fcr)
    {
        var Vcr = Aw * Fcr;
        return Vcr;
    }
    
    public static double EqG2_3__2(double E, double kv, double mu, double h, double t)
    {
        var Fcr = (Math.Pow(Math.PI, 2.0) * E * kv) / (12 * (1 - Math.Pow(mu, 2.0)) * Math.Pow(h / t, 2.0));
        return Fcr;
    }
    
    public static double EqG5__1(double C, double t, double Fy, double theta, double Cr, double R, double Cn, double N, double Ch,
        double h)

    {
        var Pn = C * Math.Pow(t, 2.0) * Fy * Math.Sin(theta * (2 * Math.PI) / 360.0) * (1 - Cr * Math.Sqrt(R / t)) *
                 (1 + Cn * Math.Sqrt(N / t)) * (1 - Ch * Math.Sqrt(h / t));

        return Pn;
    }

    public static (double C, double Cr, double Cn, double Ch) TableG5__2(SupportAndFlangeConditions supportAndFlangeConditions, LoadCases loadCases, double R, double t)

    {

        if (supportAndFlangeConditions == SupportAndFlangeConditions.FastenedToSupport)
        {
            if (loadCases == LoadCases.OneFlangeLoadingOrReactionEnd)
            {

                if ((R / t) <= 9)

                {
                    var C = 4.0;
                    var Cr = 0.14;
                    var Cn = 0.35;
                    var Ch = 0.02;

                    return (C, Cr, Cn, Ch);
                }
                
            }
        }

        return (Double.NaN, Double.NaN, Double.NaN, Double.NaN);
    }
    
    
    public static double AvailableWebCripplingStrengthPn(double t, double Fy, double theta, double R, double N, double h, SupportAndFlangeConditions supportAndFlangeConditions, LoadCases loadCases, string designMethod)
    {

        (var C, var Cr, var Cn, var Ch) = TableG5__2(supportAndFlangeConditions, loadCases, R, t);

        var Pn = EqG5__1(C, t, Fy, theta, Cr, R, Cn, N, Ch, h);
        
        if (supportAndFlangeConditions == SupportAndFlangeConditions.FastenedToSupport)
        {
            if (loadCases == LoadCases.OneFlangeLoadingOrReactionEnd)
            {

                Dictionary<string, double> safetyResistanceFactors =  
                    new Dictionary<string, double>();
        
                safetyResistanceFactors.Add("ASD", 1.75);
                safetyResistanceFactors.Add("LRFD", 0.85);
                safetyResistanceFactors.Add("LSD", 0.75);
                
                var aPn = AISIS100.Core.CalculateAvailableStrength(Pn, designMethod, safetyResistanceFactors);

                return aPn;
                
            }
        }

        return Double.NaN;
    }

    public enum SupportAndFlangeConditions
    {
        FastenedToSupport,
        UnfastenedStiffenedOrPartiallyStiffenedFlanges,
        UnfastenedUnstiffenedFlanges,
    }
    
    public enum LoadCases
    {
        OneFlangeLoadingOrReactionEnd,
        OneFlangeLoadingOrReactionInterior,
        TwoFlangeLoadingOrReactionEnd,
        TwoFlangeLoadingOrReactionInterior,
    }
}