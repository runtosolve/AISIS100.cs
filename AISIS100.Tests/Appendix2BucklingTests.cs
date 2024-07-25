namespace AISIS100.Tests;

public class Appendix2BucklingTests
{
    [Test]
    public void Eq2_3_1__1_IsCorrect()
    {
        var output = new Output();
        var Pex = AISIS100.Appendix2Buckling.Eq2_3_1__1(29500.0, 1.734611938, 1.0, 96.0, output);

        var expected = 54.80013475;
        var actual = Pex;
        
        Assert.That(actual, Is.EqualTo(expected).Within(1.0).Percent);
        Assert.That(output.GetResult("Pex").Equation, Is.EqualTo("Eq.2.3.1-1"));
    }
    
    
}