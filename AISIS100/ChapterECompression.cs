using System.ComponentModel.Design;
using System.Xml;

namespace AISIS100;


public static class ChapterECompression
{
    
    public static double EqE2__1(double Ag, double Fn, Output? output = null)
    {
        var Pne = Ag * Fn;

        output?.AddResult("Pne", Pne, "Eq.E2-1");
        
        return Pne;
    }
    
    public static double EqE2__2(double Lambdac, double Fy, Output? output = null)
    {
        var Fn = (Math.Pow(0.658, Math.Pow(Lambdac, 2.0))) * Fy;
        
        output?.AddResult("Fn", Fn, "Eq.E2-2");
        
        return Fn;
    }
    
    public static double EqE2__3(double Lambdac, double Fy, Output? output = null)
    {
        var Fn = (0.877 / Math.Pow(Lambdac, 2.0)) * Fy;
        
        output?.AddResult("Fn", Fn, "Eq.E2-3");
        
        return Fn;
    }
    
    public static double EqE2__4(double Fy, double Fcre, Output? output = null)
    {
        var Lambda = Math.Sqrt(Fy / Fcre);
        
        output?.AddResult("Lambda", Lambda, "Eq.E2-4");
        
        return Lambda;
    }

    
    public static double EqE3_2__1(double Pne, Output? output = null)
    {
        var Pnl = Pne;
        
        output?.AddResult("Pnl", Pnl, "Eq.E3.2-1");
        
        return Pnl;
    }
    
    public static double EqE3_2__2(double Pcrl, double Pne, Output? output = null)
    {
        var Pnl = (1 - 0.15 * Math.Pow(Pcrl/Pne, 0.4))*Math.Pow((Pcrl/Pne), 0.4)*Pne;
        
        output?.AddResult("Pnl", Pnl, "Eq.E3.2-2");
        
        return Pnl;
    }
    
    
    public static double EqE3_2__3(double Pne, double Pcrl, Output? output = null)
    {
        var Lambdal = Math.Sqrt(Pne / Pcrl);
        
        output?.AddResult("Lambdal", Lambdal, "Eq.E3.2-3");
        
        return Lambdal;
    }

    public static double EqE4__1(double Py, Output? output = null)
    {
        var Pnd = Py;
        
        output?.AddResult("Pnd", Pnd, "Eq.E4-1");
        
        return Pnd;
    }
    
    public static double EqE4__2(double Pcrd, double Py, Output? output = null)
    {
        var Pnd = (1 - 0.25 * Math.Pow(Pcrd/Py, 0.6))*Math.Pow((Pcrd/Py), 0.6)*Py;
        
        output?.AddResult("Pnd", Pnd, "Eq.E4-2");

        return Pnd;
    }

    
    public static double EqE4__5(double Py, double Pcrd, Output? output = null)
    {
        var Lambdad = Math.Sqrt(Py / Pcrd);
        
        output?.AddResult("Lambdad", Lambdad, "Eq.E4-5");
        
        return Lambdad;
    }
    
    
    public static double EqE4__9(double Ag, double Fy, Output? output = null)
    {
        var Py = Ag * Fy;
        
        output?.AddResult("Py", Py, "Eq.E4-9");
        
        return Py;
    }

    public static double GlobalBucklingStressFn(double Fy, double Fcre, Output? output = null)
    {
        var Lambdac = EqE2__4(Fy, Fcre, output);
       
        double Fn;
        if (Lambdac <= 1.5) 
        {
            Fn = EqE2__2(Lambdac, Fy, output);
            return Fn;
        }
        Fn = EqE2__3(Lambdac, Fy, output);
        return Fn;
    }

    public static double GlobalBucklingStrengthPne(double Fy, double Fcre, double Ag, Output? output = null)
    {
        var Fn = GlobalBucklingStressFn(Fy, Fcre, output);

        var Pne = EqE2__1(Ag, Fn, output);

        return Pne;
    }
    
    public static double AvailableGlobalBucklingStrengthPne(double Pne, string designMethod, Output? output = null)
    {
   
        Dictionary<string, double> SafetyResistanceFactors =  
            new Dictionary<string, double>();
        
            SafetyResistanceFactors.Add("ASD", 1.80);
            SafetyResistanceFactors.Add("LRFD", 0.85);
            SafetyResistanceFactors.Add("LSD", 0.80);

            var aPne = AISIS100.Core.CalculateAvailableStrength(Pne, designMethod, SafetyResistanceFactors, output);
            
            return aPne;
    }

    
    public static double LocalBucklingStrengthPnl(double Pne, double Pcrl, Output? output = null)
    {
        var Lambdal = EqE3_2__3(Pne, Pcrl, output);

        double Pnl;
        if (Lambdal <= 0.776)
        {
            Pnl = EqE3_2__1(Pne, output);
            
            return Pnl;
        } 
        Pnl = EqE3_2__2(Pcrl, Pne, output);
        return Pnl;

    }

    public static double AvailableLocalBucklingStrengthPnl(double Pnl, string designMethod, Output? output = null)
    {
   
        Dictionary<string, double> SafetyResistanceFactors =  
            new Dictionary<string, double>();
        
        SafetyResistanceFactors.Add("ASD", 1.80);
        SafetyResistanceFactors.Add("LRFD", 0.85);
        SafetyResistanceFactors.Add("LSD", 0.80);

        var aPnl = AISIS100.Core.CalculateAvailableStrength(Pnl, designMethod, SafetyResistanceFactors, output);

        return aPnl;
    }

    public static double DistortionalBucklingStrengthPnd(double Py, double Pcrd, Output? output = null)
    {
        var Lambdad = EqE4__5(Py, Pcrd, output);

        double Pnd;
        if (Lambdad <= 0.561) 
        {
            Pnd = EqE4__1(Py, output);
            return Pnd;
        } 
        Pnd = EqE4__2(Pcrd, Py, output);
        return Pnd;
    }
    
    public static double AvailableDistortionalBucklingStrengthPnd(double Pnd, string designMethod, Output? output = null)
    {
   
        Dictionary<string, double> SafetyResistanceFactors =  
            new Dictionary<string, double>();
        
        SafetyResistanceFactors.Add("ASD", 1.80);
        SafetyResistanceFactors.Add("LRFD", 0.85);
        SafetyResistanceFactors.Add("LSD", 0.80);

        var aPnd = AISIS100.Core.CalculateAvailableStrength(Pnd, designMethod, SafetyResistanceFactors, output);

        return aPnd;
    }
    
}