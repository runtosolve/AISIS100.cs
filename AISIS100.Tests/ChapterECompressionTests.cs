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
    public void  EqE4__1_IsCorrect()
    {
        var output = new Output();
        var Pnd = AISIS100.ChapterECompression. EqE4__1(20.19, output);

        var expected = 20.19;
        var actual = Pnd;
        Assert.That(actual, Is.EqualTo(expected).Within(1.0).Percent);
        Assert.That(output.GetResult("Pnd").Equation, Is.EqualTo("Eq.E4-1"));
    } 
    
    [Test]
    public void  EqE4__2_IsCorrect()
    {
        var output = new Output();
        var Pnd = AISIS100.ChapterECompression. EqE4__2(5.36, 20.19,  output);

        var expected = 8.09;
        var actual = Pnd;
        Assert.That(actual, Is.EqualTo(expected).Within(1.0).Percent);
        Assert.That(output.GetResult("Pnd").Equation, Is.EqualTo("Eq.E4-2"));
    } 
    
    
    [Test]
    public void  EqE4__5_IsCorrect()
    {
        var output = new Output();
        var Lambdad = AISIS100.ChapterECompression. EqE4__5(20.19, 5.364, output);

        var expected = 1.94;
        var actual = Lambdad;
        Assert.That(actual, Is.EqualTo(expected).Within(1.0).Percent);
        Assert.That(output.GetResult("Lambdad").Equation, Is.EqualTo("Eq.E4-5"));
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
    public void AvailableGlobalBucklingStrengthPne_IsCorrect()
    {
        
        var PneLRFD = AISIS100.ChapterECompression.AvailableGlobalBucklingStrengthPne(9.43, "LRFD");
        var PneLRFDexpected = 9.43 * 0.85;
        Assert.That(PneLRFD, Is.EqualTo(PneLRFDexpected).Within(1.0).Percent);
        
        var PneASD = AISIS100.ChapterECompression.AvailableGlobalBucklingStrengthPne(9.43, "ASD");
        var PneASDexpected = 9.43 / 1.80;
        Assert.That(PneASD, Is.EqualTo(PneASDexpected).Within(1.0).Percent);
        
        var PneLSD = AISIS100.ChapterECompression.AvailableGlobalBucklingStrengthPne(9.43, "LSD");
        var PneLSDexpected = 9.43 * 0.80;
        Assert.That(PneLSD, Is.EqualTo(PneLSDexpected).Within(1.0).Percent);
       
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
    
    [Test]
    public void AvailableLocalBucklingStrengthPnl_IsCorrect()
    {
        
        var PnlLRFD = AISIS100.ChapterECompression.AvailableLocalBucklingStrengthPnl(7.04, "LRFD");
        var PnlLRFDexpected = 7.04 * 0.85;
        Assert.That(PnlLRFD, Is.EqualTo(PnlLRFDexpected).Within(1.0).Percent);
        
        var PnlASD = AISIS100.ChapterECompression.AvailableLocalBucklingStrengthPnl(7.04, "ASD");
        var PnlASDexpected = 7.04 / 1.80;
        Assert.That(PnlASD, Is.EqualTo(PnlASDexpected).Within(1.0).Percent);
        
        var PnlLSD = AISIS100.ChapterECompression.AvailableLocalBucklingStrengthPnl(7.04, "LSD");
        var PnlLSDexpected = 7.04 * 0.80;
        Assert.That(PnlLSD, Is.EqualTo(PnlLSDexpected).Within(1.0).Percent);
       
    }

    
    
    
    [Test]
    public void DistortionalBucklingStrengthPnd_IsCorrect()
    {
        var output = new Output();
        var Pnd = AISIS100.ChapterECompression.DistortionalBucklingStrengthPnd(20.19, 5.36, output);

        var expectedPnd = 8.09;
        Assert.That(Pnd, Is.EqualTo(expectedPnd).Within(1.0).Percent);
        
        var expectedLambdad = 1.94;
        Assert.That(output.GetResult("Lambdad").Value, Is.EqualTo(expectedLambdad).Within(1.0).Percent);    
        
    }
    
    [Test]
    public void AvailableDistortionalBucklingStrengthPnd_IsCorrect()
    {
        
        var PndLRFD = AISIS100.ChapterECompression.AvailableDistortionalBucklingStrengthPnd(8.09, "LRFD");
        var PndLRFDexpected = 8.09 * 0.85;
        Assert.That(PndLRFD, Is.EqualTo(PndLRFDexpected).Within(1.0).Percent);
        
        var PndASD = AISIS100.ChapterECompression.AvailableDistortionalBucklingStrengthPnd(8.09, "ASD");
        var PndASDexpected = 8.09 / 1.80;
        Assert.That(PndASD, Is.EqualTo(PndASDexpected).Within(1.0).Percent);
        
        var PndLSD = AISIS100.ChapterECompression.AvailableDistortionalBucklingStrengthPnd(8.09, "LSD");
        var PndLSDexpected = 8.09 * 0.80;
        Assert.That(PndLSD, Is.EqualTo(PndLSDexpected).Within(1.0).Percent);
       
    }
    
}


