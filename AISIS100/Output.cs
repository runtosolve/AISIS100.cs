namespace AISIS100;

using System.Collections.Generic;

public class Output
{
    private Dictionary<string, Result> _data = new();
    
    /// <summary>
    /// Add a result to the output
    /// </summary>
    /// <param name="key">Variable name (matching AISI S100)</param>
    /// <param name="value">Value of the variable</param>
    /// <param name="equation">Equation number for the calculating the variable</param>
    public void AddResult(string key, double value, string equation)
    {
        _data.Add(key, new Result(value, equation));
    }
    
    /// <summary>
    /// Extend the output with another Output object
    /// </summary>
    /// <param name="other">The other Output object</param>
    public void Extend(Output other)
    {
        foreach (var kvp in other._data)
        {
            // We should raise exception if the key already exists
            _data.Add(kvp.Key, kvp.Value);
        }
    }
    
    /// <summary>
    /// Remove a result from the output
    /// </summary>
    /// <param name="key">Variable name (matching AISI S100)</param>
    public void RemoveResult(string key)
    {
        _data.Remove(key);
    }
    
    /// <summary>
    /// Get a result from the output
    /// </summary>
    /// <param name="key">Variable name (matching AISI S100)</param>
    /// <returns></returns>
    public Result GetResult(string key)
    {
        return _data[key];
    }
    
    /// <summary>
    /// Get the value of a result from the output
    /// </summary>
    /// <param name="key">Variable name (matching AISI S100)</param>
    /// <returns></returns>
    public double GetResultValue(string key)
    {
        return _data[key].Value;
    }
    
    /// <summary>
    /// Get the equation number for a result from the output
    /// </summary>
    /// <param name="key">Variable name (matching AISI S100)</param>
    /// <returns></returns>
    public string? GetResultEquation(string key)
    {
        return _data[key].Equation;
    }
}