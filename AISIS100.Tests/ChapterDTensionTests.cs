namespace AISIS100.Tests;

public class ChapterDTensionTests
{
    [TestCase(1.0, 1.0)]
    [TestCase(1.0, 1.25)]
    [TestCase(0.75, 1.0)]
    [TestCase(0.75, 1.25)]
    public void AvailableTensileStrengthTn_DoesNotThrowException(double AnetToAg, double FuToFy)
    {
        var Ag = 1.0;
        var Anet = AnetToAg * Ag;
        
        var Fy = 50.0;
        var Fu = FuToFy * Fy;
        
        var designMethod = "ASD";
        var output = new Output();
        
        Assert.DoesNotThrow(() => ChapterDTension.AvailableTensileStrengthTn(Ag, Anet, Fy, Fu, designMethod, output));
    }
}