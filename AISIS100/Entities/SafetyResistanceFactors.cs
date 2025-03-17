namespace AISIS100.Entities;

/// <summary>
/// Represent a set of resistance factors for design methods
/// </summary>
public record SafetyResistanceFactors
{
    /// <summary>
    /// Factor for ASD
    /// </summary>
    public double ASD { get; set; } = 1.0;

    /// <summary>
    /// Factor for LRD
    /// </summary>
    public double LRFD { get; set; } = 1.0;

    /// <summary>
    /// Factor for LSD
    /// </summary>
    public double LSD { get; set; } = 1.0;

    /// <summary>
    /// Get a dictionary representation of the safety resistance factors
    /// </summary>
    /// <returns></returns>
    public Dictionary<string, double> ToDictionary()
    {
        return new Dictionary<string, double>
        {
            { "ASD", ASD },
            { "LRFD", LRFD },
            { "LSD", LSD }
        };
    }
}