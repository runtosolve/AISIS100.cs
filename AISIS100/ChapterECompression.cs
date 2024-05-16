using System.ComponentModel.Design;
using System.Xml;

namespace AISIS100;


public static class ChapterECompression
{
    
    public static double EqE2__1(double ag, double fn)
    {
        var pne = ag * fn;
        return pne;
    }
    
    public static double EqE2__2(double lambdac, double fy)
    {
        var fn = (Math.Pow(0.658, Math.Pow(lambdac, 2.0))) * fy;
        return fn;
    }
    
    public static double EqE2__3(double lambdac, double fy)
    {
        var fn = (0.877 / Math.Pow(lambdac, 2.0)) * fy;
        return fn;
    }
    
    public static double EqE2__4(double fy, double fcre)
    {
        var lambda = Math.Sqrt(fy / fcre);
        return lambda;
    }

    
    public static double EqE3_2__1(double pne)
    {
        var pnl = pne;
        return pnl;
    }
    
    public static double EqE3_2__2(double pcrl, double pne)
    {
        var pnl = (1 - 0.15 * Math.Pow(pcrl/pne, 0.4))*Math.Pow((pcrl/pne), 0.4)*pne;
        return pnl;
    }
    
    
    public static double EqE3_2__3(double pne, double pcrl)
    {
        var lambdal = Math.Sqrt(pne / pcrl);
        return lambdal;
    }

    public static double EqE4__1(double py)
    {
        var pnd = py;
        return pnd;
    }
    
    public static double EqE4__2(double pcrd, double py)
    {
        var pnd = (1 - 0.25 * Math.Pow(pcrd/py, 0.6))*Math.Pow((pcrd/py), 0.6)*py;
        return pnd;
    }

    
    public static double EqE4__5(double py, double pcrd)
    {
        var lambdad = Math.Sqrt(py / pcrd);
        return lambdad;
    }
    
 

    public static double EqE4__9(double ag, double fy)
    {
        var py = ag * fy;
        return py;
    }

    public static double GlobalBucklingStressFn(double fy, double fcre)
    {
        var lambdac = EqE2__4(fy, fcre);

        if (lambdac <= 1.5) 
        {
            var fn = EqE2__2(lambdac, fy);
            return fn;
        } 
        return EqE2__3(lambdac, fy);
      }

    public static double GlobalBucklingStrengthPne(double fy, double fcre, double ag)
    {
        var fn = GlobalBucklingStressFn(fy, fcre);

        var pne = EqE2__1(ag, fn);

        return pne;
    }
    
    public static double AvailableGlobalBucklingStrengthPne(double pne, string designMethod)
    {
   
        Dictionary<string, double> SafetyResistanceFactors =  
            new Dictionary<string, double>();
        
            SafetyResistanceFactors.Add("ASD", 1.80);
            SafetyResistanceFactors.Add("LRFD", 0.85);
            SafetyResistanceFactors.Add("LSD", 0.80);

            var aPne = AISIS100.Core.CalculateAvailableStrength(pne, designMethod, SafetyResistanceFactors);

            return aPne;
    }

    
    public static double LocalBucklingStrengthPnl(double pne, double pcrl)
    {
        var lambdal = EqE3_2__3(pne, pcrl);

        if (lambdal <= 0.776) 
        {
            var pnl = EqE3_2__1(pne);
            return pnl;
        } 
        return EqE3_2__2(pcrl, pne);
    }

    public static double AvailableLocalBucklingStrengthPnl(double pnl, string designMethod)
    {
   
        Dictionary<string, double> SafetyResistanceFactors =  
            new Dictionary<string, double>();
        
        SafetyResistanceFactors.Add("ASD", 1.80);
        SafetyResistanceFactors.Add("LRFD", 0.85);
        SafetyResistanceFactors.Add("LSD", 0.80);

        var aPnl = AISIS100.Core.CalculateAvailableStrength(pnl, designMethod, SafetyResistanceFactors);

        return aPnl;
    }

    public static double DistortionalBucklingStrengthPnd(double py, double pcrd)
    {
        var lambdad = EqE4__5(py, pcrd);

        if (lambdad <= 0.561) 
        {
            var pnd = EqE4__1(py);
            return pnd;
        } 
        return EqE4__2(pcrd, py);
    }
    
    public static double AvailableDistortionalBucklingStrengthPnd(double pnd, string designMethod)
    {
   
        Dictionary<string, double> SafetyResistanceFactors =  
            new Dictionary<string, double>();
        
        SafetyResistanceFactors.Add("ASD", 1.80);
        SafetyResistanceFactors.Add("LRFD", 0.85);
        SafetyResistanceFactors.Add("LSD", 0.80);

        var aPnd = AISIS100.Core.CalculateAvailableStrength(pnd, designMethod, SafetyResistanceFactors);

        return aPnd;
    }



}