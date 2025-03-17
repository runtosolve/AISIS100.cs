using AISIS100.Reporting;

namespace AISIS100.Tests;

public class ChapterJConnectionTests
{
    [Test]
    public void EqJ4_3_1__1_IsCorrect()
    {
        var output = new Output();
        var Pnv = ChapterJConnections.EqJ4_3_1__1(0.0451, 0.190, 45000.0, output);
        
        var expected = 789.0;  // AISI D110-16, p1-31
        var actual = Pnv;
        Assert.That(actual, Is.EqualTo(expected).Within(1.0).Percent);
        Assert.That(output.GetResult("PnvTilting").Equation, Is.EqualTo("Eq.J4.3.1-1"));
    }
    
    [Test]
    public void EqJ4_3_1__2_IsCorrect()
    {
        var output = new Output();
        var Pnv = ChapterJConnections.EqJ4_3_1__2(0.0566, 0.190, 65000.0, output);
        
        var expected = 1887.0;  // AISI D110-16, p1-31
        var actual = Pnv;
        Assert.That(actual, Is.EqualTo(expected).Within(1.0).Percent);
        Assert.That(output.GetResult("PnvBearingPly1t1t210").Equation, Is.EqualTo("Eq.J4.3.1-2"));
    }
    
    [Test]
    public void EqJ4_3_1__3_IsCorrect()
    {
        var output = new Output();
        var Pnv = ChapterJConnections.EqJ4_3_1__3(0.0451, 0.190, 45000.0, output);
        
        var expected = 1041.0;  // AISI D110-16, p1-31
        var actual = Pnv;
        Assert.That(actual, Is.EqualTo(expected).Within(1.0).Percent);
        Assert.That(output.GetResult("PnvBearingPly2t2t1Lt1").Equation, Is.EqualTo("Eq.J4.3.1-3"));
    }
    
    [Test]
    public void EqJ4_3_1__4_IsCorrect()
    {
        var output = new Output();
        var Pnv = ChapterJConnections.EqJ4_3_1__4(0.0566, 0.190, 65000.0, output);
        
        var expected = 1887.0;  // AISI D110-16, p1-31
        var actual = Pnv;
        Assert.That(actual, Is.EqualTo(expected).Within(1.0).Percent);
        Assert.That(output.GetResult("PnvBearingPly1t2t1Gt1").Equation, Is.EqualTo("Eq.J4.3.1-4"));
    }
    
    [Test]
    public void EqJ4_3_1__5_IsCorrect()
    {
        var output = new Output();
        var Pnv = ChapterJConnections.EqJ4_3_1__5(0.0451, 0.190, 45000.0, output);
        
        var expected = 1041.0;  // AISI D110-16, p1-31
        var actual = Pnv;
        Assert.That(actual, Is.EqualTo(expected).Within(1.0).Percent);
        Assert.That(output.GetResult("PnvBearingPly2t2t1Gt1").Equation, Is.EqualTo("Eq.J4.3.1-5"));
    }
    
    [Test]
    public void EqJ4_4__1_IsCorrect()
    {
        var output = new Output();
        var Pnot = ChapterJConnections.EqJ4_4_1__1(0.0451, 0.190, 45000.0, "inches", output);
        
        var expected = 306.0;  // AISI D110-16, p2-23, with updated factor from S100-16 S3/22
        var actual = Pnot;
        Assert.That(actual, Is.EqualTo(expected).Within(1.0).Percent);
        Assert.That(output.GetResult("Pnot").Equation, Is.EqualTo("Eq.J4.4.1-1"));
    }
    
    [Test]
    public void EqJ4_4_2__1_IsCorrect()
    {
        var output = new Output();
        var Pnov = ChapterJConnections.EqJ4_4_2__1(0.0566, 0.400, 65000.0, output);
        
        var expected = 1324.0;  // AISI D110-16, p2-23, also https://www.strongtie.com/strongdrive_metalscrews/xe_screw/p/strong-drive-xe-exterior-structural-metal-screw
        var actual = Pnov;
        Assert.That(actual, Is.EqualTo(expected).Within(1.0).Percent);
        Assert.That(output.GetResult("Pnov").Equation, Is.EqualTo("Eq.J4.4.2-1"));
    }
    
    
}