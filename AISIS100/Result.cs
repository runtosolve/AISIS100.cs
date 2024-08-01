namespace AISIS100;

/// <summary>
/// Class to represent the result of a calculation
/// </summary>
/// <remarks>
/// Primarily used to match a calculation result with a equation reference
/// </remarks>
public class Result
{
    public double Value;
    public string? Equation;
    
    public Result(double value, string? equation = null)
    {
        Value = value;
        Equation = equation;
    }
}