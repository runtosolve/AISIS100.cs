namespace AISIS100;

public static class ChapterFFlexure
{
    public static double EqF2_1__1(double sfc, double fn, double my)
    {
        var mne = Math.Min(sfc * fn, my);
        return mne;
    }
    
    public static double EqF2_1__2(double sf, double fy)
    {
        var my = sf * fy;
        return my;
    }

    public static double EqF2_1__3(double fy)
    {
        var fn = fy;
        return fn;
    }
    
    public static double EqF2_1__4(double fy, double fcre)
    {
        var fn = 10.0 / 9.0 * fy * (1 - (10 * fy) / (36 * fcre));
        return fn;
    }
    
    public static double EqF2_1__5(double fcre)
    {
        var fn = fcre;
        return fn;
    }
    
    public static double EqF3_2__1(double mne)
    {
        var mnl = mne;
        return mnl;
    }

    public static double EqF3_2__2(double mcrl, double mne, double my)
    {

        var mneBar = Math.Min(mne, my);
        var mnl = (1 - 0.15 * Math.Pow((mcrl / mne), 0.4)) * Math.Pow(mcrl / mneBar, 0.4) * mneBar;
        return mnl;
    }

    public static double EqF3_2__3(double mne, double my, double mcrl)
    {
        var mneBar = Math.Min(mne, my);
        var lambdal = Math.Sqrt(mneBar/mcrl);
        return lambdal;
    }
    
    
    public static double EqF4__1(double my)
    {
        var mnd = my;
        return mnd;
    }
    
    public static double EqF4__2(double mcrd, double my)
    {
        var mnd = (1 - 0.22 * Math.Pow(mcrd/my, 0.5))*Math.Pow((mcrd/my), 0.5)*my;
        return mnd;
    }
    
    
    public static double EqF4__5(double my, double mcrd)
    {
        var lambdad = Math.Sqrt(my/mcrd);
        return lambdad;
    }
    
    public static double GlobalBucklingStressFn(double fy, double fcre)
    {

        if (fcre >= 2.78 * fy) 
        {
            var fn = EqF2_1__3(fy);
            return fn;
        } 
        if ((fcre < 2.78 * fy) & (fcre > 0.56 * fy))
        {
            var fn = EqF2_1__4(fy, fcre);
            return fn;
        }
        return EqF2_1__5(fcre);
    }
    
    public static double GlobalBucklingStrengthMne(double fy, double fcre, double sfc, double my)
    {
        var fn = GlobalBucklingStressFn(fy, fcre);

        var mne = EqF2_1__1(sfc, fn, my);

        return mne;
    }
    
    public static double AvailableGlobalBucklingStrengthMne(double mne, string designMethod)
    {
   
        Dictionary<string, double> SafetyResistanceFactors =  
            new Dictionary<string, double>();
        
        SafetyResistanceFactors.Add("ASD", 1.67);
        SafetyResistanceFactors.Add("LRFD", 0.90);
        SafetyResistanceFactors.Add("LSD", 0.90);

        var aMne = AISIS100.Core.CalculateAvailableStrength(mne, designMethod, SafetyResistanceFactors);

        return aMne;
    }
    
    public static double LocalBucklingStrengthMnl(double mne, double my, double mcrl)
    {
        var lambdal = EqF3_2__3(mne, my, mcrl);

        if (lambdal <= 0.776) 
        {
            var mnl = EqF3_2__1(mne);
            return mnl;
        } 
        return EqF3_2__2(mcrl, mne, my);
    }

    public static double AvailableLocalBucklingStrengthMnl(double mnl, string designMethod)
    {
   
        Dictionary<string, double> SafetyResistanceFactors =  
            new Dictionary<string, double>();
        
        SafetyResistanceFactors.Add("ASD", 1.67);
        SafetyResistanceFactors.Add("LRFD", 0.90);
        SafetyResistanceFactors.Add("LSD", 0.90);

        var aMnl = AISIS100.Core.CalculateAvailableStrength(mnl, designMethod, SafetyResistanceFactors);

        return aMnl;
    }
    
    public static double DistortionalBucklingStrengthMnd(double my, double mcrd)
    {
        var lambdad = EqF4__5(my, mcrd);

        if (lambdad <= 0.561) 
        {
            var mnd = EqF4__1(my);
            return mnd;
        } 
        return EqF4__2(mcrd, my);
    }
    
    public static double AvailableDistortionalBucklingStrengthPne(double mnd, string designMethod)
    {
   
        Dictionary<string, double> SafetyResistanceFactors =  
            new Dictionary<string, double>();
        
        SafetyResistanceFactors.Add("ASD", 1.67);
        SafetyResistanceFactors.Add("LRFD", 0.90);
        SafetyResistanceFactors.Add("LSD", 0.90);

        var aMnd = AISIS100.Core.CalculateAvailableStrength(mnd, designMethod, SafetyResistanceFactors);

        return aMnd;
    }
    
}