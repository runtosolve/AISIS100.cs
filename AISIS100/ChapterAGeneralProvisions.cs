using AISIS100.Entities;
using AISIS100.Reporting;

namespace AISIS100;

/// <summary>
/// AISI S100 Chapter A equations related to specification general provisions
/// </summary>
public class ChapterAGeneralProvisions
{
    public static SafetyResistanceFactors SafetyResistanceFactorsForMembers = new()
    {
        ASD = 2.0,
        LRFD = 0.80,
        LSD = 0.75
    };

    public static SafetyResistanceFactors SafetyResistanceFactorsForConnections = new()
    {
        ASD = 3.0,
        LRFD = 0.55,
        LSD = 0.50
    };

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
            var safetyResistanceFactors = SafetyResistanceFactorsForMembers.ToDictionary();
            var aRn = Core.CalculateAvailableStrength(Rn, designMethod, safetyResistanceFactors, output);
            return aRn;
        }

        if (componentType == "connection")
        {
            var safetyResistanceFactors = SafetyResistanceFactorsForConnections.ToDictionary();

            var aRn = Core.CalculateAvailableStrength(Rn, designMethod, safetyResistanceFactors, output);
            return aRn;
        }

        throw new ArgumentOutOfRangeException(nameof(componentType), "componentType should be member or connection");
    }
}