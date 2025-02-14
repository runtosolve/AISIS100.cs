using System.ComponentModel.Design;

namespace AISIS100;

/// <summary>
/// AISI S100 Chapter A equations related to specification general provisions
/// </summary>
public class ChapterAGeneralProvisions
{
 
    /// <summary>
    /// Calculate available strength for members and connections evaluated using rational engineering analysis
    /// </summary>
    /// <param name="Rn">Nominal strength</param>
    /// <param name="componentType">member or connection</param>
    /// <param name="designMethod">LRFD, ASD, or LSD</param>
    /// <param name="output">Container for nominal strength and equation number label</param>
    /// <returns>aRn - available strength</returns>
    /// <exception cref="ArgumentOutOfRangeException">Enforces member or connection designation for componentType</exception>
    public static double SectionA1_2_6__c(double Rn, string componentType, string designMethod, Output? output = null)
    {
        
        if (componentType == "member")
        {
            Dictionary<string, double> safetyResistanceFactors =  
                new Dictionary<string, double>();
            
            safetyResistanceFactors.Add("ASD", 2.0);
            safetyResistanceFactors.Add("LRFD", 0.80);
            safetyResistanceFactors.Add("LSD", 0.75);
            
            var aRn = AISIS100.Core.CalculateAvailableStrength(Rn, designMethod, safetyResistanceFactors, output);
            return aRn;

        }

        if (componentType != "connection")
            throw new ArgumentOutOfRangeException(nameof(componentType),
                "componentType should be member or connection");
        {
            Dictionary<string, double> safetyResistanceFactors =  
                new Dictionary<string, double>();
                
            safetyResistanceFactors.Add("ASD", 3.0);
            safetyResistanceFactors.Add("LRFD", 0.55);
            safetyResistanceFactors.Add("LSD", 0.50);
            
            var aRn = Core.CalculateAvailableStrength(Rn, designMethod, safetyResistanceFactors, output);
            return aRn;
        }
        
    }
    
}
