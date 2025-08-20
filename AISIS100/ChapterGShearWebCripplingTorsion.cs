// ReSharper disable InconsistentNaming

using System.Collections.Immutable;
using AISIS100.Entities;
using AISIS100.Reporting;

namespace AISIS100;

public class ChapterGShearWebCripplingTorsion
{
    private static readonly IList<WebCripplingParameters> TableG5__2Data;
    
    public static SafetyResistanceFactors SafetyResistanceFactorsForShear = new()
    {
        ASD = 1.67,
        LRFD = 0.90,
        LSD = 0.75,
    };

    static ChapterGShearWebCripplingTorsion()
    {
        TableG5__2Data = new ChapterGShearWebCripplingTorsion().InitializeTableG5__2().ToImmutableList();
    }

    public static double EqG2_1__1(double Vy, Output? output = null)
    {
        var Vn = Vy;
        output?.AddResult("Vn", Vn, "Eq.G2.1-1");
        return Vn;
    }


    public static double EqG2_1__2(double Vcr, double Vy, Output? output = null)
    {
        var Vn = (1 - 0.25 * Math.Pow(Vcr / Vy, 0.65)) * Math.Pow((Vcr / Vy), 0.65) * Vy;
        output?.AddResult("Vn", Vn, "Eq.G2.1-2");
        return Vn;
    }


    public static double EqG2_1__3(double Vy, double Vcr, Output? output = null)
    {
        var Lambdav = Math.Sqrt(Vy / Vcr);
        output?.AddResult("Lambdav", Lambdav, "Eq.G2.1-3");
        return Lambdav;
    }

    public static double EqG2_1__4(double Aw, double Fy, Output? output = null)
    {
        var Vy = 0.6 * Aw * Fy;
        output?.AddResult("Vy", Vy, "Eq.G2.1-4");
        return Vy;
    }

    public static double EqG2_1__5(double h, double t, Output? output = null)
    {
        var Aw = h * t;
        output?.AddResult("Aw", Aw, "Eq.G2.1-5");
        return Aw;
    }

    public static double ShearStrengthVn(double Aw, double Fy, double E, double kv, double mu, double h, double t, Output? output = null)
    {
        var Vy = EqG2_1__4(Aw, Fy);
        output?.AddResult("Vy", Vy, "Eq.G2.1-4");

        var Fcr = EqG2_3__2(E, kv, mu, h, t);
        output?.AddResult("Fcr", Fcr, "Eq.G2.3-2");

        var Vcr = EqG2_3__1(Aw, Fcr);
        output?.AddResult("Vcr", Vcr, "Eq.G2.3-1");

        var Lambdav = EqG2_1__3(Vy, Vcr);
        output?.AddResult("Lambdav", Lambdav, "Eq.G2.1-3");

        double Vn;
        if (Lambdav <= 0.587)
        {
            Vn = EqG2_1__1(Vy);
            output?.AddResult("Vn", Vn, "Eq.G2.1-1");
            return Vn;
        }

        Vn = EqG2_1__2(Vcr, Vy);
        output?.AddResult("Vn", Vn, "Eq.G2.1-2");
        return Vn;
    }

    public static double AvailableShearStrengthVn(double Vn, string designMethod, Output? output = null)
    {
        var safetyResistanceFactors = SafetyResistanceFactorsForShear.ToDictionary();
        var aVn = Core.CalculateAvailableStrength(Vn, designMethod, safetyResistanceFactors, output);

        return aVn;
    }

    public static double EqG2_3__1(double Aw, double Fcr, Output? output = null)
    {
        var Vcr = Aw * Fcr;
        output?.AddResult("Vcr", Vcr, "Eq.G2.3-1");
        return Vcr;
    }

    public static double EqG2_3__2(double E, double kv, double mu, double h, double t, Output? output = null)
    {
        var Fcr = (Math.Pow(Math.PI, 2.0) * E * kv) / (12 * (1 - Math.Pow(mu, 2.0)) * Math.Pow(h / t, 2.0));
        output?.AddResult("Fcr", Fcr, "Eq.G2.3-2");
        return Fcr;
    }

    public static double EqG5__1(double C, double t, double Fy, double theta, double Cr, double R, double Cn, double N, double Ch,
        double h, Output? output = null)

    {
        var Pn = C * Math.Pow(t, 2.0) * Fy * Math.Sin(theta * (2 * Math.PI) / 360.0) * (1 - Cr * Math.Sqrt(R / t)) *
                 (1 + Cn * Math.Sqrt(N / t)) * (1 - Ch * Math.Sqrt(h / t));
        output?.AddResult("Pn", Pn, "Eq.G5-1");
        return Pn;
    }

    public static (double C, double Cr, double Cn, double Ch, double Omegaw, double PhiwLrfd, double PhiwLsd) TableG5__2(SupportAndFlangeConditions supportAndFlangeConditions,
        LoadCases loadCases, double R, double t, Output? output = null)
    {
        foreach (var row in TableG5__2Data)
        {
            var sameSupportAndFlangeConditions = row.SupportAndFlangeConditions == supportAndFlangeConditions;
            var sameLoadCases = row.LoadCases == loadCases;

            if (sameSupportAndFlangeConditions && sameLoadCases)
            {
                var RtRatio = R / t;
                if (RtRatio > row.RtRatio && row.RtRatio != 0)
                {
                    throw new Exception($"R/t ratio of {RtRatio} exceeds maximum value of {row.RtRatio} for the selected conditions in Table G5-2.");
                }

                var C = row.C;
                var Cr = row.Cr;
                var Cn = row.Cn;
                var Ch = row.Ch;
                var Omegaw = row.Omegaw;
                var PhiwLrfd = row.PhiwLrfd;
                var PhiwLsd = row.PhiwLsd;

                output?.AddResult("C", C, "TABLE G5-2");
                output?.AddResult("Cr", Cr, "TABLE G5-2");
                output?.AddResult("Cn", Cn, "TABLE G5-2");
                output?.AddResult("Ch", Ch, "TABLE G5-2");
                output?.AddResult("Omegaw", Omegaw, "TABLE G5-2");
                output?.AddResult("PhiwLrfd", PhiwLrfd, "TABLE G5-2");
                output?.AddResult("PhiwLsd", PhiwLsd, "TABLE G5-2");

                return (C, Cr, Cn, Ch, Omegaw, PhiwLrfd, PhiwLsd);
            }
        }

        return (Double.NaN, Double.NaN, Double.NaN, Double.NaN, Double.NaN, Double.NaN, Double.NaN);
    }


    public static double AvailableWebCripplingStrengthPn(double t, double Fy, double theta, double R, double N, double h, SupportAndFlangeConditions supportAndFlangeConditions, LoadCases loadCases,
        string designMethod, Output? output = null)
    {
        var (C, Cr, Cn, Ch, Oemgaw, PhiwLrfd, PhiwLsd) = TableG5__2(supportAndFlangeConditions, loadCases, R, t, output);

        var Pn = EqG5__1(C, t, Fy, theta, Cr, R, Cn, N, Ch, h, output);

        var safetyResistanceFactors = new Dictionary<string, double>
        {
            { "ASD", Oemgaw },
            { "LRFD", PhiwLrfd },
            { "LSD", PhiwLsd }
        };

        var aPn = Core.CalculateAvailableStrength(Pn, designMethod, safetyResistanceFactors, output);

        return aPn;
    }

    private IList<WebCripplingParameters> InitializeTableG5__2()
    {
        var table = new List<WebCripplingParameters>
        {
            new()
            {
                SupportAndFlangeConditions = SupportAndFlangeConditions.FastenedToSupport,
                LoadCases = LoadCases.OneFlangeLoadingOrReactionEnd,
                C = 4.0,
                Cr = 0.14,
                Cn = 0.35,
                Ch = 0.02,
                Omegaw = 1.75,
                PhiwLrfd = 0.85,
                PhiwLsd = 0.75,
                RtRatio = 9.0
            },
            new()
            {
                SupportAndFlangeConditions = SupportAndFlangeConditions.FastenedToSupport,
                LoadCases = LoadCases.OneFlangeLoadingOrReactionInterior,
                C = 13.0,
                Cr = 0.23,
                Cn = 0.14,
                Ch = 0.01,
                Omegaw = 1.65,
                PhiwLrfd = 0.90,
                PhiwLsd = 0.80,
                RtRatio = 5.0
            },
            new()
            {
                SupportAndFlangeConditions = SupportAndFlangeConditions.FastenedToSupport,
                LoadCases = LoadCases.TwoFlangeLoadingOrReactionEnd,
                C = 7.5,
                Cr = 0.08,
                Cn = 0.12,
                Ch = 0.048,
                Omegaw = 1.75,
                PhiwLrfd = 0.85,
                PhiwLsd = 0.75,
                RtRatio = 12.0
            },
            new()
            {
                SupportAndFlangeConditions = SupportAndFlangeConditions.FastenedToSupport,
                LoadCases = LoadCases.TwoFlangeLoadingOrReactionInterior,
                C = 20.0,
                Cr = 0.10,
                Cn = 0.08,
                Ch = 0.031,
                Omegaw = 1.75,
                PhiwLrfd = 0.85,
                PhiwLsd = 0.75,
                RtRatio = 12.0
            },
            new()
            {
                SupportAndFlangeConditions = SupportAndFlangeConditions.UnfastenedStiffenedOrPartiallyStiffenedFlanges,
                LoadCases = LoadCases.OneFlangeLoadingOrReactionEnd,
                C = 4.0,
                Cr = 0.14,
                Cn = 0.35,
                Ch = 0.02,
                Omegaw = 1.85,
                PhiwLrfd = 0.80,
                PhiwLsd = 0.70,
                RtRatio = 0.0
            },
            new()
            {
                SupportAndFlangeConditions = SupportAndFlangeConditions.UnfastenedStiffenedOrPartiallyStiffenedFlanges,
                LoadCases = LoadCases.OneFlangeLoadingOrReactionInterior,
                C = 13.0,
                Cr = 0.23,
                Cn = 0.14,
                Ch = 0.01,
                Omegaw = 1.65,
                PhiwLrfd = 0.90,
                PhiwLsd = 0.80,
                RtRatio = 5.0
            },
            new()
            {
                SupportAndFlangeConditions = SupportAndFlangeConditions.UnfastenedStiffenedOrPartiallyStiffenedFlanges,
                LoadCases = LoadCases.TwoFlangeLoadingOrReactionEnd,
                C = 13.0,
                Cr = 0.32,
                Cn = 0.05,
                Ch = 0.04,
                Omegaw = 1.65,
                PhiwLrfd = 0.90,
                PhiwLsd = 0.80,
                RtRatio = 3.0
            },
            new()
            {
                SupportAndFlangeConditions = SupportAndFlangeConditions.UnfastenedStiffenedOrPartiallyStiffenedFlanges,
                LoadCases = LoadCases.TwoFlangeLoadingOrReactionInterior,
                C = 24.0,
                Cr = 0.52,
                Cn = 0.15,
                Ch = 0.001,
                Omegaw = 1.90,
                PhiwLrfd = 0.80,
                PhiwLsd = 0.65,
                RtRatio = 3.0
            },
            new()
            {
                SupportAndFlangeConditions = SupportAndFlangeConditions.UnfastenedUnstiffenedFlanges,
                LoadCases = LoadCases.OneFlangeLoadingOrReactionEnd,
                C = 4.0,
                Cr = 0.40,
                Cn = 0.60,
                Ch = 0.03,
                Omegaw = 1.80,
                PhiwLrfd = 0.85,
                PhiwLsd = 0.70,
                RtRatio = 2.0
            },
            new()
            {
                SupportAndFlangeConditions = SupportAndFlangeConditions.UnfastenedUnstiffenedFlanges,
                LoadCases = LoadCases.OneFlangeLoadingOrReactionInterior,
                C = 13.0,
                Cr = 0.32,
                Cn = 0.10,
                Ch = 0.01,
                Omegaw = 1.80,
                PhiwLrfd = 0.85,
                PhiwLsd = 0.70,
                RtRatio = 1.0
            },
            new()
            {
                SupportAndFlangeConditions = SupportAndFlangeConditions.UnfastenedUnstiffenedFlanges,
                LoadCases = LoadCases.TwoFlangeLoadingOrReactionEnd,
                C = 2.0,
                Cr = 0.11,
                Cn = 0.37,
                Ch = 0.01,
                Omegaw = 2.00,
                PhiwLrfd = 0.75,
                PhiwLsd = 0.65,
                RtRatio = 1.0
            },
            new()
            {
                SupportAndFlangeConditions = SupportAndFlangeConditions.UnfastenedUnstiffenedFlanges,
                LoadCases = LoadCases.TwoFlangeLoadingOrReactionInterior,
                C = 13.0,
                Cr = 0.47,
                Cn = 0.25,
                Ch = 0.04,
                Omegaw = 1.90,
                PhiwLrfd = 0.80,
                PhiwLsd = 0.65,
                RtRatio = 1.0
            }
        };
        return table;
    }

    public enum SupportAndFlangeConditions
    {
        FastenedToSupport,
        UnfastenedStiffenedOrPartiallyStiffenedFlanges,
        UnfastenedUnstiffenedFlanges,
    }

    public enum LoadCases
    {
        OneFlangeLoadingOrReactionEnd,
        OneFlangeLoadingOrReactionInterior,
        TwoFlangeLoadingOrReactionEnd,
        TwoFlangeLoadingOrReactionInterior,
    }

    private record WebCripplingParameters
    {
        public SupportAndFlangeConditions SupportAndFlangeConditions { get; init; }
        public LoadCases LoadCases { get; init; }
        public double C { get; init; }
        public double Cr { get; init; }
        public double Cn { get; init; }
        public double Ch { get; init; }
        public double Omegaw { get; init; }
        public double PhiwLrfd { get; init; }
        public double PhiwLsd { get; init; }
        public double RtRatio { get; init; }
    }
}