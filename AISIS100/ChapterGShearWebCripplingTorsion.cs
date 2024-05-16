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
    
    public static double ShearStrengthVn(double vcr, double vy)
    {
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
        var fcr = (Math.Pow(Math.PI, 2) * e * kv) / (12 * (1 - Math.Pow(mu, 2)) * Math.Pow(h / t, 2));
        return fcr;
    }
    
}