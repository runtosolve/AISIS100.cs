﻿using AISIS100.Entities;
using AISIS100.Reporting;

namespace AISIS100;

/// <summary>
/// AISI S100 Chapter D equations for calculating member tensile strength
/// </summary>
public static class ChapterDTension
{
    /// <summary>
    /// Safety resistance factors for tension chapter
    /// </summary>
    public static SafetyResistanceFactors SafetyResistanceFactors = new()
    {
        ASD = 1.67,
        LRFD = 0.90,
        LSD = 0.90
    };
    
    /// <summary>
    /// Calculate nominal member tensile strength considering gross cross-section.
    /// </summary>
    /// <param name="Ag">Gross cross-sectional area</param>
    /// <param name="Fy">Steel yield stress</param>
    /// <param name="output">Container for nominal strength and equation number label</param>
    /// <returns>Nominal member tensile strength considering gross cross-section</returns>
    public static double EqD2__1(double Ag, double Fy, Output? output = null)
    {
        var Tn = Ag * Fy;

        output?.AddResult("TnGross", Tn, "Eq. D2-1");
        
        return Tn;
    }
    
    /// <summary>
    /// Calculate nominal member tensile strength considering the net cross-section.
    /// </summary>
    /// <param name="Anet">Net cross-sectional area (e.g., from the presence of bolt holes)</param>
    /// <param name="Fu">Steel tensile strength</param>
    /// <param name="output">Container for nominal strength and equation number label</param>
    /// <returns>Nominal member tensile strength considering net cross-section</returns>
    public static double EqD3__1(double Anet, double Fu, Output? output = null)
    {
        var Tn = Anet * Fu;

        output?.AddResult("TnNet", Tn, "Eq. D3-1");
        
        return Tn;
    }
    
    /// <summary>
    /// Calculate available member tensile strength considering the gross cross-section.
    /// </summary>
    /// <param name="Tn">Nominal member tensile strength considering gross cross-section</param>
    /// <param name="designMethod">Select ASD, LRFD, or LSD design methodology </param>
    /// <param name="output">Available member tensile strength considering the gross cross-section</param>
    /// <returns></returns>
    public static double AvailableGrossSectionTensileStrengthTn(double Tn, string designMethod, Output? output = null)
    {

        var safetyResistanceFactorsDictionary = SafetyResistanceFactors.ToDictionary();  

        var aTn = Core.CalculateAvailableStrength(Tn, designMethod, safetyResistanceFactorsDictionary, output);

        return aTn;
    }
    
    /// <summary>
    /// Calculate available member tensile strength considering the net cross-section.
    /// </summary>
    /// <param name="Tn">Nominal member tensile strength considering net cross-section</param>
    /// <param name="designMethod">Select ASD, LRFD, or LSD design methodology</param>
    /// <param name="output">Available member tensile strength considering the net cross-section</param>
    /// <returns></returns>
    public static double AvailableNetSectionTensileStrengthTn(double Tn, string designMethod, Output? output = null)
    {
   
        var safetyResistanceFactorsDictionary = SafetyResistanceFactors.ToDictionary();  

        var aTn = Core.CalculateAvailableStrength(Tn, designMethod, safetyResistanceFactorsDictionary, output);

        return aTn;
    }
    
   /// <summary>
   /// Determine the available member tensile strength as the minimum of the available gross section tensile strength and the available net section tensile strength
   /// </summary>
   /// <param name="Ag">Gross cross-sectional area</param>
   /// <param name="Anet">Net cross-sectional area (e.g., from the presence of bolt holes)</param>
   /// <param name="Fy">Steel yield stress</param>
   /// <param name="Fu">Steel tensile strength</param>
   /// <param name="designMethod">Select ASD, LRFD, or LSD design methodology</param>
   /// <param name="output">Available member tensile strength</param>
   /// <returns></returns>
    public static double AvailableTensileStrengthTn(double Ag, double Anet, double Fy, double Fu, string designMethod, Output? output = null)
    {

        var outputGross = new Output();
        var TnGross = EqD2__1(Ag, Fy, output);
        var aTnGross = AvailableGrossSectionTensileStrengthTn(TnGross, designMethod, outputGross);
        
        var outputNet = new Output();
        var TnNet = EqD3__1(Anet, Fu, output);
        var aTnNet = AvailableNetSectionTensileStrengthTn(TnNet, designMethod, outputNet);
        
        var aTn = Math.Min(aTnGross, aTnNet);

        output?.Extend(aTnGross <= aTnNet ? outputGross : outputNet);

        output?.AddResult("aTn", aTn, "Section D1");
        
        return aTn;
    }
    
}
