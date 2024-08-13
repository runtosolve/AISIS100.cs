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
    public void EqE2__2_IsCorrect()
    {
        var output = new Output();
        var Fn = AISIS100.ChapterECompression.EqE2__2(1.35, 50.0, output);

        var expected = 23.36;
        var actual = Fn;
        Assert.That(actual, Is.EqualTo(expected).Within(1.0).Percent);
        Assert.That(output.GetResult("Fn").Equation, Is.EqualTo("Eq.E2-2"));
    }    
    
    [Test]
    public void EqE2__3_IsCorrect()
    {
        var output = new Output();
        var Fn = AISIS100.ChapterECompression.EqE2__3(1.35, 50.0, output);

        var expected = 24.12;
        var actual = Fn;
        Assert.That(actual, Is.EqualTo(expected).Within(1.0).Percent);
        Assert.That(output.GetResult("Fn").Equation, Is.EqualTo("Eq.E2-3"));
    } 
        
    
    [Test]
    public void EqE2__4_IsCorrect()
    {
        var output = new Output();
        var Lambdac = AISIS100.ChapterECompression.EqE2__4(50.0, 27.50, output);

        var expected = 1.35;
        var actual = Lambdac;
        Assert.That(actual, Is.EqualTo(expected).Within(1.0).Percent);
        Assert.That(output.GetResult("Lambdac").Equation, Is.EqualTo("Eq.E2-4"));
    }
  
        
    [Test]
    public void  EqE3_2__1_IsCorrect()
    {
        var output = new Output();
        var Pnl = AISIS100.ChapterECompression. EqE3_2__1(9.43, output);

        var expected = 9.43;
        var actual = Pnl;
        Assert.That(actual, Is.EqualTo(expected).Within(1.0).Percent);
        Assert.That(output.GetResult("Pnl").Equation, Is.EqualTo("Eq.E3.2-1"));
    }      
    
    [Test]
    public void  EqE3_2__2_IsCorrect()
    {
        var output = new Output();
        var Pnl = AISIS100.ChapterECompression. EqE3_2__2(6.41, 9.43, output);

        var expected = 7.04;
        var actual = Pnl;
        Assert.That(actual, Is.EqualTo(expected).Within(1.0).Percent);
        Assert.That(output.GetResult("Pnl").Equation, Is.EqualTo("Eq.E3.2-2"));
    }        

        
        
    [Test]
    public void  EqE3_2__3_IsCorrect()
    {
        var output = new Output();
        var Lambdal = AISIS100.ChapterECompression. EqE3_2__3(9.43, 6.41, output);

        var expected = 1.21;
        var actual = Lambdal;
        Assert.That(actual, Is.EqualTo(expected).Within(1.0).Percent);
        Assert.That(output.GetResult("Lambdal").Equation, Is.EqualTo("Eq.E3.2-3"));
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
        var Fn = AISIS100.ChapterECompression.GlobalBucklingStressFn(50, 27.50, output);
        
        var expectedFn = 23.36;
        var actualFn = Fn;

        var expectedLambdac = 1.35;
        Assert.That(output.GetResult("Lambdac").Value, Is.EqualTo(expectedLambdac).Within(1.0).Percent);    
        
        Assert.That(actualFn, Is.EqualTo(expectedFn).Within(1.0).Percent);
        
    }

    [Test]
    public void GlobalBucklingStrengthPne_IsCorrect()
    {
        var output = new Output();
        var Pne = AISIS100.ChapterECompression.GlobalBucklingStrengthPne(50.0, 27.5, 0.4037758076, output);

        var expectedPne = 9.43;
        Assert.That(Pne, Is.EqualTo(expectedPne).Within(1.0).Percent);
        
        var expectedLambdac = 1.35;
        Assert.That(output.GetResult("Lambdac").Value, Is.EqualTo(expectedLambdac).Within(1.0).Percent);    

        var expectedFn = 23.36;
        Assert.That(output.GetResult("Fn").Value, Is.EqualTo(expectedFn).Within(1.0).Percent);
        
    }
    
    [Test]
    public void LocalBucklingStrengthPnl_IsCorrect()
    {
        var output = new Output();
        var Pnl = AISIS100.ChapterECompression.LocalBucklingStrengthPnl(9.43, 6.41, output);

        var expectedPnl = 7.04;
        Assert.That(Pnl, Is.EqualTo(expectedPnl).Within(1.0).Percent);
        
        var expectedLambdal = 1.21;
        Assert.That(output.GetResult("Lambdal").Value, Is.EqualTo(expectedLambdal).Within(1.0).Percent);    
        
    }
    
    
    
    
}


