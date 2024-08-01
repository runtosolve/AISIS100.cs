namespace AISIS100;

public static class ChapterFFlexure
{
    public static double EqF2_1__1(double Sfc, double Fn, double My, Output? output = null)
    {
        var Mne = Math.Min(Sfc * Fn, My);
        output?.AddResult("Mne", Mne, "Eq.F2.1-1");
        return Mne;
    }
    
    public static double EqF2_1__2(double Sf, double Fy, Output? output = null)
    {
        var My = Sf * Fy;
        output?.AddResult("My", My, "Eq.F2.1-2");
        return My;
    }

    public static double EqF2_1__3(double Fy, Output? output = null)
    {
        var Fn = Fy;
        output?.AddResult("Fn", Fn, "Eq.F2.1-3");
        return Fn;
    }
    
    public static double EqF2_1__4(double Fy, double Fcre, Output? output = null)
    {
        var Fn = 10.0 / 9.0 * Fy * (1 - (10 * Fy) / (36 * Fcre));
        output?.AddResult("Fn", Fn, "Eq.F2.1-4");
        return Fn;
    }
    
    public static double EqF2_1__5(double Fcre, Output? output = null)
    {
        var Fn = Fcre;
        output?.AddResult("Fn", Fn, "Eq.F2.1-5");
        return Fn;
    }
    
    public static double EqF3_2__1(double Mne, Output? output = null)
    {
        var Mnl = Mne;
        output?.AddResult("Mnl", Mnl, "Eq.F3.2-1");
        return Mnl;
    }

    public static double EqF3_2__2(double Mcrl, double Mne, double My, Output? output = null)
    {
        var MneBar = Math.Min(Mne, My);
        var Mnl = (1 - 0.15 * Math.Pow((Mcrl / Mne), 0.4)) * Math.Pow(Mcrl / MneBar, 0.4) * MneBar;
        output?.AddResult("Mnl", Mnl, "Eq.F3.2-2");
        return Mnl;
    }

    public static double EqF3_2__3(double Mne, double My, double Mcrl, Output? output = null)
    {
        var MneBar = Math.Min(Mne, My);
        var Lambdal = Math.Sqrt(MneBar / Mcrl);
        output?.AddResult("Lambdal", Lambdal, "Eq.F3.2-3");
        return Lambdal;
    }
    
    
    public static double EqF4__1(double My, Output? output = null)
    {
        var Mnd = My;
        output?.AddResult("Mnd", Mnd, "Eq.F4-1");
        return Mnd;
    }
    
    public static double EqF4__2(double Mcrd, double My, Output? output = null)
    {
        var Mnd = (1 - 0.22 * Math.Pow(Mcrd / My, 0.5)) * Math.Pow((Mcrd / My), 0.5) * My;
        output?.AddResult("Mnd", Mnd, "Eq.F4-2");
        return Mnd;
    }
    
    
    public static double EqF4__5(double My, double Mcrd, Output? output = null)
    {
        var Lambdad = Math.Sqrt(My / Mcrd);
        output?.AddResult("Lambdad", Lambdad, "Eq.F4-5");
        return Lambdad;
    }
    
    public static double GlobalBucklingStressFn(double Fy, double Fcre, Output? output = null)
    {

        double Fn;
        if (Fcre >= 2.78 * Fy) 
        {
            Fn = EqF2_1__3(Fy, output);
            return Fn;
        } 
        if ((Fcre < 2.78 * Fy) & (Fcre > 0.56 * Fy))
        {
            Fn = EqF2_1__4(Fy, Fcre, output);
            return Fn;
        }
        Fn = EqF2_1__5(Fcre, output);
            
        return Fn;
    }
    
    public static double GlobalBucklingStrengthMne(double Fy, double Fcre, double Sfc, double My, Output? output = null)
    {
        var Fn = GlobalBucklingStressFn(Fy, Fcre, output);

        var Mne = EqF2_1__1(Sfc, Fn, My, output);

        return Mne;
    }
    
    public static double AvailableGlobalBucklingStrengthMne(double Mne, string designMethod, Output? output = null)
    {
   
        Dictionary<string, double> SafetyResistanceFactors =  
            new Dictionary<string, double>();
        
        SafetyResistanceFactors.Add("ASD", 1.67);
        SafetyResistanceFactors.Add("LRFD", 0.90);
        SafetyResistanceFactors.Add("LSD", 0.90);

        var aMne = AISIS100.Core.CalculateAvailableStrength(Mne, designMethod, SafetyResistanceFactors, output);

        return aMne;
    }
    
    public static double LocalBucklingStrengthMnl(double Mne, double My, double Mcrl, Output? output = null)
    {
        var Lambdal = EqF3_2__3(Mne, My, Mcrl, output);

        double Mnl;
        if (Lambdal <= 0.776) 
        {
            Mnl = EqF3_2__1(Mne, output);
            return Mnl;
        }
        Mnl = EqF3_2__2(Mcrl, Mne, My, output);
        
        return Mnl;
    }

    public static double AvailableLocalBucklingStrengthMnl(double Mnl, string designMethod, Output? output = null)
    {
   
        Dictionary<string, double> SafetyResistanceFactors =  
            new Dictionary<string, double>();
        
        SafetyResistanceFactors.Add("ASD", 1.67);
        SafetyResistanceFactors.Add("LRFD", 0.90);
        SafetyResistanceFactors.Add("LSD", 0.90);

        var aMnl = AISIS100.Core.CalculateAvailableStrength(Mnl, designMethod, SafetyResistanceFactors, output);

        return aMnl;
    }
    
    public static double DistortionalBucklingStrengthMnd(double My, double Mcrd, Output? output = null)
    {
        var Lambdad = EqF4__5(My, Mcrd, output);

        double Mnd;
        if (Lambdad <= 0.561) 
        {
            Mnd = EqF4__1(My, output);
            return Mnd;
        } 
        Mnd = EqF4__2(Mcrd, My, output);

        return Mnd;
    }
    
    public static double AvailableDistortionalBucklingStrengthMnd(double Mnd, string designMethod, Output? output = null)
    {
   
        Dictionary<string, double> SafetyResistanceFactors =  
            new Dictionary<string, double>();
        
        SafetyResistanceFactors.Add("ASD", 1.67);
        SafetyResistanceFactors.Add("LRFD", 0.90);
        SafetyResistanceFactors.Add("LSD", 0.90);

        var aMnd = AISIS100.Core.CalculateAvailableStrength(Mnd, designMethod, SafetyResistanceFactors, output);

        return aMnd;
    }
    
    public static double SectionF1(double aMne, double aMnl, double aMnd, Output? output = null)
    {
        var aMn = Math.Min(Math.Min(aMne, aMnl), aMnd);
        
        output?.AddResult("aMn", aMn, "Section F1");
        
        return aMn;
    }
    
}