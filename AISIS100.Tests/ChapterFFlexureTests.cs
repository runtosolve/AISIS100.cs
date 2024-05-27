namespace AISIS100.Tests;

public class ChapterFFlexureTests
{
    [Test]
    public void EqF2_1__1_IsCorrect()
    {
        var actual = AISIS100.ChapterFFlexure.EqF2_1__1(1, 50, 100);
        
        Assert.That(actual, Is.EqualTo(30));
    }
}