namespace AISIS100;


public class DirectStrengthMethod
{

    static double AxialCompressiveStrength(double ag, double fy)
    {
        var py = ChapterECompression.EqE4__9(ag, fy);
        return py;
    }
        
    
        
    
    
}