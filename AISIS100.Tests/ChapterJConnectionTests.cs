namespace AISIS100.Tests;

public class ChapterJConnectionTests
{
    [Test]
    public void EqJ4_3_1__1_IsCorrect()
    {
        var output = new Output();
        var Pnv = AISIS100.ChapterJConnections.EqJ4_3_1__1(0.0451, 0.190, 45000.0, output);
        
        var expected = 789.0;  // AISI D110-16, p1-31
        var actual = Pnv;
        Assert.That(actual, Is.EqualTo(expected).Within(1.0).Percent);
        Assert.That(output.GetResult("Pnv").Equation, Is.EqualTo("Eq.J4.3.1-1"));
    }
    
}