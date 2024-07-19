namespace AISIS100.Tests;

public class ChapterCStabilityTests
{
    [Test]
    public void EqC1_2_1_1__3_ReturnsCorrectValue()
    {
        var exepcted = 1.90;
        var actual = ChapterCStability.EqC1_2_1_1__3(0.95, 0.5, 1.0, "LRFD");
        Assert.That(actual, Is.EqualTo(exepcted).Within(1.0).Percent);
    }
    
    [Test]
    public void EqC1_1_1_3__1_ReturnsCorrectValue()
    {
        var expected = 1.0;
        var actual = ChapterCStability.EqC1_1_1_3__1(0.5, 1.0, "LRFD");
        Assert.That(actual, Is.EqualTo(expected).Within(1.0).Percent);
    }

    [Test]
    public void EqC1_1_1_3__2_ReturnCorrectValue()
    {
        var expected = 0.9216;
        var actual = ChapterCStability.EqC1_1_1_3__2(0.4, 1.0, "ASD");
        Assert.That(actual, Is.EqualTo(expected).Within(1.0).Percent);
    }

    [Test]
    public void EqC1_2_1_1__1_ReturnCorrectValue()
    {
        var expected = 1.65;
        var actual = ChapterCStability.EqC1_2_1_1__1(0.5, 0.75, 1.2, 1.4);
        Assert.That(actual, Is.EqualTo(expected).Within(1.0).Percent);
    }

    [Test]
    public void EqC1_2_1_1__2_ReturnCorrectValue()
    {
        var expected = 1.55;
        var actual = ChapterCStability.EqC1_2_1_1__2(0.5, 0.75, 1.4);
        Assert.That(actual, Is.EqualTo(expected).Within(1.0).Percent);
    }

    [TestCase(1.1, 0.4, 3.056)]
    [TestCase(0.6, 0.1, 1.0)]
    public void EqC1_2_1_1__3_ReturnCorrectValue(double Cm, double Pbar_Py, double expected)
    {
        var actual = ChapterCStability.EqC1_2_1_1__3(Cm, Pbar_Py, 1.0, "ASD");
        Assert.That(actual, Is.EqualTo(expected).Within(1.0).Percent);
    }

    [Test]
    public void EqC1_2_1_1__4_ReturnCorrectValue()
    {
        var expected = 1.0;
        var actual = ChapterCStability.EqC1_2_1_1__4(-1.0, 1.0);
        Assert.That(actual, Is.EqualTo(expected).Within(1.0).Percent);
    }

    [Test]
    public void EqC1_2_1_1__5_ReturnCorrectValue()
    {
        var expected = 3947.84;
        var actual = ChapterCStability.EqC1_2_1_1__5(100.0, 0.5, 1.0);
        Assert.That(actual, Is.EqualTo(expected).Within(1.0).Percent);
    }

    [Test]
    public void CalculateB1WithTransverseLoading_ReturnCorrectValue()
    {
        var expected = 1.243;
        var actual = ChapterCStability.CalculateB1WithTransverseLoading(0.4, 1.0, 10.0, 0.5, 10.0, "ASD", true);
        Assert.That(actual, Is.EqualTo(expected).Within(1.0).Percent);
    }
}