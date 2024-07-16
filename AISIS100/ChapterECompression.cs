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
    
    public static double EqE2__2(double Lambdac, double Fy)
    {
        var Fn = (Math.Pow(0.658, Math.Pow(Lambdac, 2.0))) * Fy;
        return Fn;
    }
    
    public static double EqE2__3(double Lambdac, double Fy)
    {
        var Fn = (0.877 / Math.Pow(Lambdac, 2.0)) * Fy;
        return Fn;
    }
    
    public static double EqE2__4(double Fy, double Fcre)
    {
        var Lambda = Math.Sqrt(Fy / Fcre);
        return Lambda;
    }

    
    public static double EqE3_2__1(double Pne)
    {
        var Pnl = Pne;
        return Pnl;
    }
    
    public static double EqE3_2__2(double Pcrl, double Pne)
    {
        var Pnl = (1 - 0.15 * Math.Pow(Pcrl/Pne, 0.4))*Math.Pow((Pcrl/Pne), 0.4)*Pne;
        return Pnl;
    }
    
    
    public static double EqE3_2__3(double Pne, double Pcrl)
    {
        var Lambdal = Math.Sqrt(Pne / Pcrl);
        return Lambdal;
    }

    public static double EqE4__1(double Py)
    {
        var Pnd = Py;
        return Pnd;
    }
    
    public static double EqE4__2(double Pcrd, double Py)
    {
        var Pnd = (1 - 0.25 * Math.Pow(Pcrd/Py, 0.6))*Math.Pow((Pcrd/Py), 0.6)*Py;
        return Pnd;
    }

    
    public static double EqE4__5(double Py, double Pcrd)
    {
        var Lambdad = Math.Sqrt(Py / Pcrd);
        return Lambdad;
    }
    
    
    public static double EqE4__9(double Ag, double Fy)
    {
        var Py = Ag * Fy;
        return Py;
    }

    public static double GlobalBucklingStressFn(double Fy, double Fcre, Output? output = null)
    {
        var Lambdac = EqE2__4(Fy, Fcre);
        output?.AddResult("Lambdac", Lambdac, "Eq.E2-4");

        double Fn;
        if (Lambdac <= 1.5) 
        {
            Fn = EqE2__2(Lambdac, Fy);
            output?.AddResult("Fn", Fn, "Eq.E2-2");
            return Fn;
        }
        Fn = EqE2__3(Lambdac, Fy);
        output?.AddResult("Fn", 0, "Eq.E2-3");
        return Fn;
    }

    public static double GlobalBucklingStrengthPne(double Fy, double Fcre, double Ag, Output? output = null)
    {
        var Fn = GlobalBucklingStressFn(Fy, Fcre, output);

        var Pne = EqE2__1(Ag, Fn);
        output?.AddResult("Pne", Pne, "Eq.E2-1");

        return Pne;
    }
    
    public static double AvailableGlobalBucklingStrengthPne(double Pne, string designMethod)
    {
   
        Dictionary<string, double> SafetyResistanceFactors =  
            new Dictionary<string, double>();
        
            SafetyResistanceFactors.Add("ASD", 1.80);
            SafetyResistanceFactors.Add("LRFD", 0.85);
            SafetyResistanceFactors.Add("LSD", 0.80);

            var aPne = AISIS100.Core.CalculateAvailableStrength(Pne, designMethod, SafetyResistanceFactors);

            return aPne;
    }

    
    public static double LocalBucklingStrengthPnl(double Pne, double Pcrl)
    {
        var Lambdal = EqE3_2__3(Pne, Pcrl);

        if (Lambdal <= 0.776) 
        {
            var Pnl = EqE3_2__1(Pne);
            return Pnl;
        } 
        return EqE3_2__2(Pcrl, Pne);
    }

    public static double AvailableLocalBucklingStrengthPnl(double Pnl, string designMethod)
    {
   
        Dictionary<string, double> SafetyResistanceFactors =  
            new Dictionary<string, double>();
        
        SafetyResistanceFactors.Add("ASD", 1.80);
        SafetyResistanceFactors.Add("LRFD", 0.85);
        SafetyResistanceFactors.Add("LSD", 0.80);

        var aPnl = AISIS100.Core.CalculateAvailableStrength(Pnl, designMethod, SafetyResistanceFactors);

        return aPnl;
    }

    public static double DistortionalBucklingStrengthPnd(double Py, double Pcrd)
    {
        var Lambdad = EqE4__5(Py, Pcrd);

        if (Lambdad <= 0.561) 
        {
            var Pnd = EqE4__1(Py);
            return Pnd;
        } 
        return EqE4__2(Pcrd, Py);
    }
    
    public static double AvailableDistortionalBucklingStrengthPnd(double Pnd, string designMethod)
    {
   
        Dictionary<string, double> SafetyResistanceFactors =  
            new Dictionary<string, double>();
        
        SafetyResistanceFactors.Add("ASD", 1.80);
        SafetyResistanceFactors.Add("LRFD", 0.85);
        SafetyResistanceFactors.Add("LSD", 0.80);

        var aPnd = AISIS100.Core.CalculateAvailableStrength(Pnd, designMethod, SafetyResistanceFactors);

        return aPnd;
    }



}