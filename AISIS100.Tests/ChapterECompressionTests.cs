namespace AISIS100.Tests;

public class ChapterECompressionTests
{
    [Test]
    public void EqE2__1_IsCorrect()
    {
        var output = new Output();
        var Pne = AISIS100.ChapterECompression.EqE2__1(1, 50, output);
        
        Assert.That(output.GetResult("Pne").Value, Is.EqualTo(50.0));
        Assert.That(output.GetResult("Pne").Equation, Is.EqualTo("Eq.E2-1"));
    }
    
    [Test]
    public void EqE4__9_IsCorrect()
    {
        var output = new Output();
        var Py = AISIS100.ChapterECompression.EqE4__9(0.4037758076, 50.0, output);

        var expected = 20.19;
        var actual = Py;
        Assert.That(actual, Is.EqualTo(expected).Within(1.0).Percent);
        Assert.That(output.GetResult("Py").Equation, Is.EqualTo("Eq.E4-9"));
    }

    
    [Test]
    public void GlobalBucklingStressFn_IsCorrect()
    {
        var output = new Output();
        var Fn = AISIS100.ChapterECompression.GlobalBucklingStressFn(50, 25, output);
        
        var expectedLambdac = Math.Sqrt(50.0 / 25.0);
        var expectedFn = (Math.Pow(0.658, Math.Pow(expectedLambdac, 2.0))) * 50.0;
        
        Assert.That(output.GetResult("Lambdac").Value, Is.EqualTo(expectedLambdac).Within(1.0).Percent);
        Assert.That(output.GetResult("Fn").Value, Is.EqualTo(expectedFn).Within(1.0).Percent);
    }

    [Test]
    public void GlobalBucklingStrengthPne_IsCorrect()
    {
        var output = new Output();
        var Pne = AISIS100.ChapterECompression.GlobalBucklingStrengthPne(50, 25, 1.0, output);
        
        var expectedLambdac = Math.Sqrt(50.0 / 25.0);
        var expectedFn = (Math.Pow(0.658, Math.Pow(expectedLambdac, 2.0))) * 50.0;
        var expectedPne = 1.0 * expectedFn;
        
        Assert.That(output.GetResult("Lambdac").Value, Is.EqualTo(expectedLambdac).Within(1.0).Percent);
        Assert.That(output.GetResult("Fn").Value, Is.EqualTo(expectedFn).Within(1.0).Percent);
        Assert.That(output.GetResult("Pne").Value, Is.EqualTo(expectedPne).Within(1.0).Percent);
    }
}