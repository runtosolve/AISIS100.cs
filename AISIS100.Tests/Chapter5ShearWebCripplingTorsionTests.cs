namespace AISIS100.Tests;

public class Chapter5ShearWebCripplingTorsionTests
{
    [Test]
    public void TableG5__2_ReturnsExpectedValues()
    {
        // Arrange
        var expected = new Dictionary<string, double>
        {
            { "C", 24 },
            { "Cr", 0.52 },
            { "Cn", 0.15 },
            { "Ch", 0.001 },
            { "Omegaw", 1.9 },
            { "PhiwLrfd", 0.80 },
            { "PhiwLsd", 0.65 }
        };
        
        // Act
        var actual = ChapterGShearWebCripplingTorsion.TableG5__2(
            supportAndFlangeConditions: ChapterGShearWebCripplingTorsion.SupportAndFlangeConditions.UnfastenedStiffenedOrPartiallyStiffenedFlanges,
            loadCases: ChapterGShearWebCripplingTorsion.LoadCases.TwoFlangeLoadingOrReactionInterior,
            R: 2.9 * 0.054,
            t: 0.054
        );
        
        Assert.Multiple(() =>
        {
            Assert.That(actual.C, Is.EqualTo(expected["C"]).Within(0.1).Percent);
            Assert.That(actual.Cr, Is.EqualTo(expected["Cr"]).Within(0.1).Percent);
            Assert.That(actual.Cn, Is.EqualTo(expected["Cn"]).Within(0.1).Percent);
            Assert.That(actual.Ch, Is.EqualTo(expected["Ch"]).Within(0.1).Percent);
            Assert.That(actual.Omegaw, Is.EqualTo(expected["Omegaw"]).Within(0.1).Percent);
            Assert.That(actual.PhiwLrfd, Is.EqualTo(expected["PhiwLrfd"]).Within(0.1).Percent);
            Assert.That(actual.PhiwLsd, Is.EqualTo(expected["PhiwLsd"]).Within(0.1).Percent);
        });
    }
}