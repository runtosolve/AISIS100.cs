using AISIS100.Reporting;

namespace AISIS100.Tests;

public class ChapterFFlexureTests
{
    [Test]
    public void EqF2_1__1_IsCorrect()
    {
        var output = new Output();
        var Mne = AISIS100.ChapterFFlexure.EqF2_1__1(0.6294163319, 38.18, 31.47, output);
        
        var expected = 24.03;
        var actual = Mne;
        Assert.That(actual, Is.EqualTo(expected).Within(1.0).Percent);
        Assert.That(output.GetResult("Mne").Equation, Is.EqualTo("Eq.F2.1-1"));
    }
    
    [Test]
    public void EqF2_1__2_IsCorrect()
    {
        var output = new Output();
        var My = AISIS100.ChapterFFlexure.EqF2_1__2(0.6294163319, 50, output);
        
        var expected = 31.47;
        var actual = My;
        Assert.That(actual, Is.EqualTo(expected).Within(1.0).Percent);
        Assert.That(output.GetResult("My").Equation, Is.EqualTo("Eq.F2.1-2"));
    }
    
    [Test]
    public void EqF2_1__3_IsCorrect()
    {
        var output = new Output();
        var Fn = AISIS100.ChapterFFlexure.EqF2_1__3(50.0, output);
        
        var expected = 50.0;
        var actual = Fn;
        Assert.That(actual, Is.EqualTo(expected).Within(1.0).Percent);
        Assert.That(output.GetResult("Fn").Equation, Is.EqualTo("Eq.F2.1-3"));
    }

    
    [Test]
    public void EqF2_1__4_IsCorrect()
    {
        var output = new Output();
        var Fn = AISIS100.ChapterFFlexure.EqF2_1__4(50.0, 44.42, output);
        
        var expected = 38.18;
        var actual = Fn;
        Assert.That(actual, Is.EqualTo(expected).Within(1.0).Percent);
        Assert.That(output.GetResult("Fn").Equation, Is.EqualTo("Eq.F2.1-4"));
    }
    
    [Test]
    public void EqF2_1__5_IsCorrect()
    {
        var output = new Output();
        var Fn = AISIS100.ChapterFFlexure.EqF2_1__5(44.42, output);
        
        var expected = 44.42;
        var actual = Fn;
        Assert.That(actual, Is.EqualTo(expected).Within(1.0).Percent);
        Assert.That(output.GetResult("Fn").Equation, Is.EqualTo("Eq.F2.1-5"));
    }
    
    [Test]
    public void EqF3_2__1_IsCorrect()
    {
        var output = new Output();
        var Mnl = AISIS100.ChapterFFlexure.EqF3_2__1(24.03, output);
        
        var expected = 24.03;
        var actual = Mnl;
        Assert.That(actual, Is.EqualTo(expected).Within(1.0).Percent);
        Assert.That(output.GetResult("Mnl").Equation, Is.EqualTo("Eq.F3.2-1"));
    }
    
    
    [Test]
    public void EqF3_2__2_IsCorrect()
    {
        var output = new Output();
        var Mnl = AISIS100.ChapterFFlexure.EqF3_2__2(84.92, 24.03, 31.47, output);
        
        var expected = 29.92;
        var actual = Mnl;
        Assert.That(actual, Is.EqualTo(expected).Within(1.0).Percent);
        Assert.That(output.GetResult("Mnl").Equation, Is.EqualTo("Eq.F3.2-2"));
    }
    
    
    [Test]
    public void EqF3_2__3_IsCorrect()
    {
        var output = new Output();
        var Lambdal = AISIS100.ChapterFFlexure.EqF3_2__3(24.03, 31.47, 84.92, output);
        
        var expected = 0.53;
        var actual = Lambdal;
        Assert.That(actual, Is.EqualTo(expected).Within(1.0).Percent);
        Assert.That(output.GetResult("Lambdal").Equation, Is.EqualTo("Eq.F3.2-3"));
    }
    
    
    [Test]
    public void EqF4__1_IsCorrect()
    {
        var output = new Output();
        var Mnd = AISIS100.ChapterFFlexure.EqF4__1(31.47, output);
        
        var expected = 31.47;
        var actual = Mnd;
        Assert.That(actual, Is.EqualTo(expected).Within(1.0).Percent);
        Assert.That(output.GetResult("Mnd").Equation, Is.EqualTo("Eq.F4-1"));
    }

    [Test]
    public void EqF4__2_IsCorrect()
    {
        var output = new Output();
        var Mnd = AISIS100.ChapterFFlexure.EqF4__2(28.47, 31.47, output);
        
        var expected = 23.67;
        var actual = Mnd;
        Assert.That(actual, Is.EqualTo(expected).Within(1.0).Percent);
        Assert.That(output.GetResult("Mnd").Equation, Is.EqualTo("Eq.F4-2"));
    }

    
    
    [Test]
    public void EqF4__5_IsCorrect()
    {
        var output = new Output();
        var Lambdad = AISIS100.ChapterFFlexure.EqF4__5(31.47, 28.47, output);
        
        var expected = 1.05;
        var actual = Lambdad;
        Assert.That(actual, Is.EqualTo(expected).Within(1.0).Percent);
        Assert.That(output.GetResult("Lambdad").Equation, Is.EqualTo("Eq.F4-5"));
    }
    
    
    
    
    [Test]
    public void GlobalBucklingStressFn_IsCorrect()
    {
        var output = new Output();
        var Fn = AISIS100.ChapterFFlexure.GlobalBucklingStressFn(50.0, 44.42, output);
        
        var expected = 38.18;
        var actual = Fn;
        Assert.That(actual, Is.EqualTo(expected).Within(1.0).Percent);
      
    }
    
    [Test]
    public void LocalBucklingStressMnl_IsCorrect()
    {
        var output = new Output();
        var Mnl = AISIS100.ChapterFFlexure.LocalBucklingStrengthMnl(24.03, 31.47, 84.92, output);
        
        var expected = 24.03;
        var actual = Mnl;
        Assert.That(actual, Is.EqualTo(expected).Within(1.0).Percent);
      
    }
    
    [Test]
    public void DistortionalBucklingStrengthMnd_IsCorrect()
    {
        var output = new Output();
        var Mnd = AISIS100.ChapterFFlexure.DistortionalBucklingStrengthMnd(31.47, 28.47, output);
        
        var expected = 23.67;
        var actual = Mnd;
        Assert.That(actual, Is.EqualTo(expected).Within(1.0).Percent);
      
    }
    
    [Test]
    public void SectionF1_IsCorrect()
    {
        var output = new Output();
        var aMn = AISIS100.ChapterFFlexure.SectionF1(21.63, 21.63, 21.30, output);
        
        var expected = 21.30;
        var actual = aMn;
        Assert.That(actual, Is.EqualTo(expected).Within(1.0).Percent);
      
    }
    
    
    
    
    
}