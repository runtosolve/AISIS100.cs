// ReSharper disable InconsistentNaming
using System.Collections.Immutable;

namespace AISIS100;

public class ChapterGShearWebCripplingTorsion
{
    public static double EqG2_1__1(double Vy, Output? output = null)
    {
        var Vn = Vy;
        output?.AddResult("Vn", Vn, "Eq.G2.1-1");
        return Vn;
    }
    
    
    public static double EqG2_1__2(double Vcr, double Vy, Output? output = null)
    {
        var Vn = (1 - 0.25 * Math.Pow(Vcr / Vy, 0.65))*Math.Pow((Vcr / Vy), 0.65) * Vy;
        output?.AddResult("Vn", Vn, "Eq.G2.1-2");
        return Vn;
    }
    
    
    public static double EqG2_1__3(double Vy, double Vcr, Output? output = null)
    {
        var Lambdav = Math.Sqrt(Vy / Vcr);
        output?.AddResult("Lambdav", Lambdav, "Eq.G2.1-3");
        return Lambdav;
    }

    public static double EqG2_1__4(double Aw, double Fy, Output? output = null)
    {
        var Vy = 0.6 * Aw * Fy;
        output?.AddResult("Vy", Vy, "Eq.G2.1-4");
        return Vy;
    }
    
    public static double EqG2_1__5(double h, double t, Output? output = null)
    {
        var Aw = h * t;
        output?.AddResult("Aw", Aw, "Eq.G2.1-5");
        return Aw;
    }
    
    public static double ShearStrengthVn(double Aw, double Fy, double E, double kv, double mu, double h, double t, Output? output = null)
    {

        var Vy = EqG2_1__4(Aw, Fy);
        output?.AddResult("Vy", Vy, "Eq.G2.1-4");
        
        var Fcr = EqG2_3__2(E, kv, mu, h, t);
        output?.AddResult("Fcr", Fcr, "Eq.G2.3-2");

        var Vcr = EqG2_3__1(Aw, Fcr);
        output?.AddResult("Vcr", Vcr, "Eq.G2.3-1");
        
        var Lambdav = EqG2_1__3(Vy, Vcr);
        output?.AddResult("Lambdav", Lambdav, "Eq.G2.1-3");

        double Vn;
        if (Lambdav <= 0.587) 
        {
            Vn = EqG2_1__1(Vy);
            output?.AddResult("Vn", Vn, "Eq.G2.1-1");
            return Vn;
        } 
        Vn = EqG2_1__2(Vcr, Vy);
        output?.AddResult("Vn", Vn, "Eq.G2.1-2");
        return Vn;
    }

    public static double AvailableShearStrengthVn(double Vn, string designMethod, Output? output = null)
    {
   
        Dictionary<string, double> SafetyResistanceFactors =  
            new Dictionary<string, double>();
        
        SafetyResistanceFactors.Add("ASD", 1.67);
        SafetyResistanceFactors.Add("LRFD", 0.90);
        SafetyResistanceFactors.Add("LSD", 0.75);

        var aVn = AISIS100.Core.CalculateAvailableStrength(Vn, designMethod, SafetyResistanceFactors, output);

        return aVn;
    }
    
    public static double EqG2_3__1(double Aw, double Fcr, Output? output = null)
    {
        var Vcr = Aw * Fcr;
        output?.AddResult("Vcr", Vcr, "Eq.G2.3-1");
        return Vcr;
    }
    
    public static double EqG2_3__2(double E, double kv, double mu, double h, double t, Output? output = null)
    {
        var Fcr = (Math.Pow(Math.PI, 2.0) * E * kv) / (12 * (1 - Math.Pow(mu, 2.0)) * Math.Pow(h / t, 2.0));
        output?.AddResult("Fcr", Fcr, "Eq.G2.3-2");
        return Fcr;
    }
    
    public static double EqG5__1(double C, double t, double Fy, double theta, double Cr, double R, double Cn, double N, double Ch,
        double h, Output? output = null)

    {
        var Pn = C * Math.Pow(t, 2.0) * Fy * Math.Sin(theta * (2 * Math.PI) / 360.0) * (1 - Cr * Math.Sqrt(R / t)) *
                 (1 + Cn * Math.Sqrt(N / t)) * (1 - Ch * Math.Sqrt(h / t));
        output?.AddResult("Pn", Pn, "Eq.G5-1");
        return Pn;
    }

    public static (double C, double Cr, double Cn, double Ch) TableG5__2(SupportAndFlangeConditions supportAndFlangeConditions, LoadCases loadCases, double R, double t, Output? output = null)

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
                    
                    output?.AddResult("C", C, "TABLE G5-2");
                    output?.AddResult("Cr", Cr, "TABLE G5-2");
                    output?.AddResult("Cn", Cn, "TABLE G5-2");
                    output?.AddResult("Ch", Ch, "TABLE G5-2");

                    return (C, Cr, Cn, Ch);
                }
                
            }
        }

        return (Double.NaN, Double.NaN, Double.NaN, Double.NaN);
    }
    
    
    public static double AvailableWebCripplingStrengthPn(double t, double Fy, double theta, double R, double N, double h, SupportAndFlangeConditions supportAndFlangeConditions, LoadCases loadCases, string designMethod, Output? output = null)
    {

        (var C, var Cr, var Cn, var Ch) = TableG5__2(supportAndFlangeConditions, loadCases, R, t);

        output?.AddResult("C", C, "TABLE G5-2");
        output?.AddResult("Cr", Cr, "TABLE G5-2");
        output?.AddResult("Cn", Cn, "TABLE G5-2");
        output?.AddResult("Ch", Ch, "TABLE G5-2");   
        
        var Pn = EqG5__1(C, t, Fy, theta, Cr, R, Cn, N, Ch, h);
        output?.AddResult("Pn", Pn, "Eq.G5-1");
        
        if (supportAndFlangeConditions == SupportAndFlangeConditions.FastenedToSupport)
        {
            if (loadCases == LoadCases.OneFlangeLoadingOrReactionEnd)
            {

                Dictionary<string, double> safetyResistanceFactors =  
                    new Dictionary<string, double>();
        
                safetyResistanceFactors.Add("ASD", 1.75);
                safetyResistanceFactors.Add("LRFD", 0.85);
                safetyResistanceFactors.Add("LSD", 0.75);
                
                var aPn = AISIS100.Core.CalculateAvailableStrength(Pn, designMethod, safetyResistanceFactors, output);

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