namespace AISIS100;

public static class ChapterFFlexure
{
    public static double EqF2_1__1(double Sfc, double Fn, double My)
    {
        var Mne = Math.Min(Sfc * Fn, My);
        return Mne;
    }
    
    public static double EqF2_1__2(double Sf, double Fy)
    {
        var My = Sf * Fy;
        return My;
    }

    public static double EqF2_1__3(double Fy)
    {
        var Fn = Fy;
        return Fn;
    }
    
    public static double EqF2_1__4(double Fy, double Fcre)
    {
        var Fn = 10.0 / 9.0 * Fy * (1 - (10 * Fy) / (36 * Fcre));
        return Fn;
    }
    
    public static double EqF2_1__5(double Fcre)
    {
        var Fn = Fcre;
        return Fn;
    }
    
    public static double EqF3_2__1(double Mne)
    {
        var Mnl = Mne;
        return Mnl;
    }

    public static double EqF3_2__2(double Mcrl, double Mne, double My)
    {
        var MneBar = Math.Min(Mne, My);
        var Mnl = (1 - 0.15 * Math.Pow((Mcrl / Mne), 0.4)) * Math.Pow(Mcrl / MneBar, 0.4) * MneBar;
        return Mnl;
    }

    public static double EqF3_2__3(double Mne, double My, double Mcrl)
    {
        var MneBar = Math.Min(Mne, My);
        var Lambdal = Math.Sqrt(MneBar / Mcrl);
        return Lambdal;
    }
    
    
    public static double EqF4__1(double My)
    {
        var Mnd = My;
        return Mnd;
    }
    
    public static double EqF4__2(double Mcrd, double My)
    {
        var Mnd = (1 - 0.22 * Math.Pow(Mcrd / My, 0.5)) * Math.Pow((Mcrd / My), 0.5) * My;
        return Mnd;
    }
    
    
    public static double EqF4__5(double My, double Mcrd)
    {
        var Lambdad = Math.Sqrt(My / Mcrd);
        return Lambdad;
    }
    
    public static double GlobalBucklingStressFn(double Fy, double Fcre)
    {

        if (Fcre >= 2.78 * Fy) 
        {
            var Fn = EqF2_1__3(Fy);
            return Fn;
        } 
        if ((Fcre < 2.78 * Fy) & (Fcre > 0.56 * Fy))
        {
            var Fn = EqF2_1__4(Fy, Fcre);
            return Fn;
        }
        return EqF2_1__5(Fcre);
    }
    
    public static double GlobalBucklingStrengthMne(double Fy, double Fcre, double Sfc, double My)
    {
        var Fn = GlobalBucklingStressFn(Fy, Fcre);

        var Mne = EqF2_1__1(Sfc, Fn, My);

        return Mne;
    }
    
    public static double AvailableGlobalBucklingStrengthMne(double Mne, string designMethod)
    {
   
        Dictionary<string, double> SafetyResistanceFactors =  
            new Dictionary<string, double>();
        
        SafetyResistanceFactors.Add("ASD", 1.67);
        SafetyResistanceFactors.Add("LRFD", 0.90);
        SafetyResistanceFactors.Add("LSD", 0.90);

        var aMne = AISIS100.Core.CalculateAvailableStrength(Mne, designMethod, SafetyResistanceFactors);

        return aMne;
    }
    
    public static double LocalBucklingStrengthMnl(double Mne, double My, double Mcrl)
    {
        var Lambdal = EqF3_2__3(Mne, My, Mcrl);

        if (Lambdal <= 0.776) 
        {
            var Mnl = EqF3_2__1(Mne);
            return Mnl;
        } 
        return EqF3_2__2(Mcrl, Mne, My);
    }

    public static double AvailableLocalBucklingStrengthMnl(double Mnl, string designMethod)
    {
   
        Dictionary<string, double> SafetyResistanceFactors =  
            new Dictionary<string, double>();
        
        SafetyResistanceFactors.Add("ASD", 1.67);
        SafetyResistanceFactors.Add("LRFD", 0.90);
        SafetyResistanceFactors.Add("LSD", 0.90);

        var aMnl = AISIS100.Core.CalculateAvailableStrength(Mnl, designMethod, SafetyResistanceFactors);

        return aMnl;
    }
    
    public static double DistortionalBucklingStrengthMnd(double My, double Mcrd)
    {
        var lambdad = EqF4__5(My, Mcrd);

        if (lambdad <= 0.561) 
        {
            var mnd = EqF4__1(My);
            return mnd;
        } 
        return EqF4__2(Mcrd, My);
    }
    
    public static double AvailableDistortionalBucklingStrengthMnd(double Mnd, string designMethod)
    {
   
        Dictionary<string, double> SafetyResistanceFactors =  
            new Dictionary<string, double>();
        
        SafetyResistanceFactors.Add("ASD", 1.67);
        SafetyResistanceFactors.Add("LRFD", 0.90);
        SafetyResistanceFactors.Add("LSD", 0.90);

        var aMnd = AISIS100.Core.CalculateAvailableStrength(Mnd, designMethod, SafetyResistanceFactors);

        return aMnd;
    }
    
}