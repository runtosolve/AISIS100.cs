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
    
    [Test]
    public void Eq2_3_1__2_IsCorrect()
    {
        var output = new Output();
        var Pey = AISIS100.Appendix2Buckling.Eq2_3_1__2(29500.0, 0.08788380153, 0.5, 96.0, output);

        var expected = 11.10575584;
        var actual = Pey;
        
        Assert.That(actual, Is.EqualTo(expected).Within(1.0).Percent);
        Assert.That(output.GetResult("Pey").Equation, Is.EqualTo("Eq.2.3.1-2"));
    }
    
    [Test]
    public void Eq2_3_1__3_IsCorrect()
    {
        var output = new Output();
        var Pt = AISIS100.Appendix2Buckling.Eq2_3_1__3(2.260629921, 11300.0, 0.0002731653427, 29500.0, 0.5325173201, 0.5, 96.0, output);

        var expected = 13.77183741;
        var actual = Pt;
        
        Assert.That(actual, Is.EqualTo(expected).Within(1.0).Percent);
        Assert.That(output.GetResult("Pt").Equation, Is.EqualTo("Eq.2.3.1-3"));
    }
    
    
    [Test]
    public void Eq2_3_1__4_IsCorrect()
    {
        var output = new Output();
        var beta = AISIS100.Appendix2Buckling.Eq2_3_1__4(0.7720472441, 2.260629921, 0.5, 96.0, 1.0, 96.0, output);
        var expected = 0.9708412556;
        var actual = beta;
        
        Assert.That(actual, Is.EqualTo(expected).Within(1.0).Percent);
        Assert.That(output.GetResult("beta").Equation, Is.EqualTo("Eq.2.3.1-4"));
    }

    [Test]
    public void Eq2_3_1_1_2__1_IsCorrect()
    {
        var output = new Output();
        var Pcre = AISIS100.Appendix2Buckling.Eq2_3_1_1_2__1(0.9708412556, 54.80013475, 13.77183741, output);
        var expected = 13.640035;
        var actual = Pcre;
        
        Assert.That(actual, Is.EqualTo(expected).Within(1.0).Percent);
        Assert.That(output.GetResult("Pcre").Equation, Is.EqualTo("Eq.2.3.1.1.2-1"));
    }

    [Test]
    public void Eq2_3_1_2_1__1_IsCorrect()
    {
        var output = new Output();
        var Mcre = AISIS100.Appendix2Buckling.Eq2_3_1_2_1__1(1.0, 2.260629921, 11.10575584, 13.77183741, output);
        var expected = 27.95757352;
        var actual = Mcre;
        
        Assert.That(actual, Is.EqualTo(expected).Within(1.0).Percent);
        Assert.That(output.GetResult("Mcre").Equation, Is.EqualTo("Eq.2.3.1.2.1-1"));
    }

    
    
}