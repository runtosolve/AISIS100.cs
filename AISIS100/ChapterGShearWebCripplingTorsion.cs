using System.Collections.Immutable;

namespace AISIS100;

public class ChapterGShearWebCripplingTorsion
{
    public static double EqG2_1__1(double vy)
    {
        var vn = vy;
        return vn;
    }
    
    
    public static double EqG2_1__2(double vcr, double vy)
    {
        var vn = (1 - 0.25 * Math.Pow(vcr/vy, 0.65))*Math.Pow((vcr/vy), 0.65)*vy;
        return vn;
    }
    
    
    public static double EqG2_1__3(double vy, double vcr)
    {
        var lambdav = Math.Sqrt(vy / vcr);
        return lambdav;
    }

    public static double EqG2_1__4(double aw, double fy)
    {
        var vy = 0.6 * aw * fy;
        return vy;
    }
    
    public static double EqG2_1__5(double h, double t)
    {
        var aw = h * t;
        return aw;
    }
    
    public static double ShearStrengthVn(double aw, double fy, double e, double kv, double mu, double h, double t)
    {

        var vy = EqG2_1__4(aw, fy);

        var fcr = EqG2_3__2(e, kv, mu, h, t);

        var vcr = EqG2_3__1(aw, fcr);
        
        var lambdav = EqG2_1__3(vy, vcr);

        if (lambdav <= 0.587) 
        {
            var vn = EqG2_1__1(vy);
            return vn;
        } 
        return EqG2_1__2(vcr, vy);
    }

    public static double AvailableShearStrengthVn(double vn, string designMethod)
    {
   
        Dictionary<string, double> SafetyResistanceFactors =  
            new Dictionary<string, double>();
        
        SafetyResistanceFactors.Add("ASD", 1.67);
        SafetyResistanceFactors.Add("LRFD", 0.90);
        SafetyResistanceFactors.Add("LSD", 0.75);

        var aVn = AISIS100.Core.CalculateAvailableStrength(vn, designMethod, SafetyResistanceFactors);

        return aVn;
    }
    
    public static double EqG2_3__1(double aw, double fcr)
    {
        var vcr = aw * fcr;
        return vcr;
    }
    
    public static double EqG2_3__2(double e, double kv, double mu, double h, double t)
    {
        var fcr = (Math.Pow(Math.PI, 2.0) * e * kv) / (12 * (1 - Math.Pow(mu, 2.0)) * Math.Pow(h / t, 2.0));
        return fcr;
    }
    
    public static double EqG5__1(double c, double t, double fy, double theta, double cr, double r, double cn, double n, double ch,
        double h)

    {
        var pn = c * Math.Pow(t, 2.0) * fy * Math.Sin(theta * (2 * Math.PI) / 360.0) * (1 - cr * Math.Sqrt(r / t)) *
                 (1 + cn * Math.Sqrt(n / t)) * (1 - ch * Math.Sqrt(h / t));

        return pn;
    }

    public static (double c, double cr, double cn, double ch) TableG5__2(string supportAndFlangeConditions, string loadCases, double r, double t)

    {

        if (supportAndFlangeConditions == "Fastened to Support")
        {
            if (loadCases == "One-Flange Loading or Reaction, End")
            {

                if ((r / t) <= 9)

                {
                    var c = 4.0;
                    var cr = 0.14;
                    var cn = 0.35;
                    var ch = 0.02;

                    return (c, cr, cn, ch);
                }
                
            }
        }

        return (Double.NaN, Double.NaN, Double.NaN, Double.NaN);
    }
    
    
    public static double AvailableWebCripplingStrengthPn(double t, double fy, double theta, double r, double n, double h, string supportAndFlangeConditions, string loadCases, string designMethod)
    {

        (var c, var cr, var cn, var ch) = TableG5__2(supportAndFlangeConditions, loadCases, r, t);

        var pn = EqG5__1(c, t, fy, theta, cr, r, cn, n, ch, h);
        
        if (supportAndFlangeConditions == "Fastened to Support")
        {
            if (loadCases == "One-Flange Loading or Reaction, End")
            {

                Dictionary<string, double> safetyResistanceFactors =  
                    new Dictionary<string, double>();
        
                safetyResistanceFactors.Add("ASD", 1.75);
                safetyResistanceFactors.Add("LRFD", 0.85);
                safetyResistanceFactors.Add("LSD", 0.75);
                
                var aPn = AISIS100.Core.CalculateAvailableStrength(pn, designMethod, safetyResistanceFactors);

                return aPn;
                
            }
        }

        return Double.NaN;
    }
    
}