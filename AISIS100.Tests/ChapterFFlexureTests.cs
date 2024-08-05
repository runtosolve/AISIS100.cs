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
}