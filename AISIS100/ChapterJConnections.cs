// ReSharper disable InconsistentNaming
// ReSharper disable RedundantNameQualifier

using AISIS100.Reporting;

namespace AISIS100;

/// <summary>
/// AISI S100 Chapter J equations for calculating welded, bolted, and screw-fastened connection strength
/// </summary>
public class ChapterJConnections
{
    /// <summary>
    /// Calculate nominal single shear screw connection strength limited by tilting
    /// </summary>
    /// <param name="t2">Thickness of ply not in contact with screw head or washer</param>
    /// <param name="d">Nominal screw diameter</param>
    /// <param name="Fu2">Tensile strength of member not in contact with screw head or washer</param>
    /// <param name="output">Container for nominal strength and equation number label</param>
    /// <returns>Pnv - nominal single shear screw connection strength limited by tilting</returns>
    public static double EqJ4_3_1__1(double t2, double d, double Fu2, Output? output = null)
    {
        var Pnv = 4.2 * Math.Sqrt(Math.Pow(t2, 3) * d) * Fu2;
        output?.AddResult("PnvTilting", Pnv, "Eq.J4.3.1-1");
        return Pnv;
    }

    /// <summary>
    /// Calculate nominal single shear screw connection strength limited by bearing on ply in contact with fastener head
    /// </summary>
    /// <param name="t1">Thickness of ply in contact with screw head or washer</param>
    /// <param name="d">Nominal screw diameter</param>
    /// <param name="Fu1">Tensile strength of member in contact with screw head or washer</param>
    /// <param name="output">Container for nominal strength and equation number label</param>
    /// <returns>Pnv - nominal single shear screw connection strength limited by bearing on ply in contact with fastener head</returns>
    public static double EqJ4_3_1__2(double t1, double d, double Fu1, Output? output = null)
    {
        var Pnv = 2.7 * t1 * d * Fu1;
        output?.AddResult("PnvBearingPly1t1t210", Pnv, "Eq.J4.3.1-2");
        return Pnv;
    }

    /// <summary>
    /// Calculate nominal single shear screw connection strength limited by bearing on ply not in contact with fastener head
    /// </summary>
    /// <param name="t2">Thickness of ply not in contact with screw head or washer</param>
    /// <param name="d">Nominal screw diameter</param>
    /// <param name="Fu2">Tensile strength of member not in contact with screw head or washer</param>
    /// <param name="output">Container for nominal strength and equation number label</param>
    /// <returns>Pnv - nominal single shear screw connection strength limited by bearing on ply not in contact with fastener head</returns>
    public static double EqJ4_3_1__3(double t2, double d, double Fu2, Output? output = null)
    {
        var Pnv = 2.7 * t2 * d * Fu2;
        output?.AddResult("PnvBearingPly2t2t1Lt1", Pnv, "Eq.J4.3.1-3");
        return Pnv;
    }

    /// <summary>
    /// Calculate nominal single shear screw connection strength limited by bearing on ply in contact with fastener head
    /// </summary>
    /// <param name="t1">Thickness of ply in contact with screw head or washer</param>
    /// <param name="d">Nominal screw diameter</param>
    /// <param name="Fu1">Tensile strength of member in contact with screw head or washer</param>
    /// <param name="output">Container for nominal strength and equation number label</param>
    /// <returns>Pnv - nominal single shear screw connection strength limited by bearing on ply in contact with fastener head</returns>
    public static double EqJ4_3_1__4(double t1, double d, double Fu1, Output? output = null)
    {
        var Pnv = 2.7 * t1 * d * Fu1;
        output?.AddResult("PnvBearingPly1t2t1Gt1", Pnv, "Eq.J4.3.1-4");
        return Pnv;
    }

    /// <summary>
    /// Calculate nominal single shear screw connection strength limited by bearing on ply not in contact with fastener head
    /// </summary>
    /// <param name="t2">Thickness of ply not in contact with screw head or washer</param>
    /// <param name="d">Nominal screw diameter</param>
    /// <param name="Fu2">Tensile strength of member not in contact with screw head or washer</param>
    /// <param name="output">Container for nominal strength and equation number label</param>
    /// <returns>Pnv - nominal single shear screw connection strength limited by bearing on ply not in contact with fastener head</returns>
    public static double EqJ4_3_1__5(double t2, double d, double Fu2, Output? output = null)
    {
        var Pnv = 2.7 * t2 * d * Fu2;
        output?.AddResult("PnvBearingPly2t2t1Gt1", Pnv, "Eq.J4.3.1-5");
        return Pnv;
    }

    /// <summary>
    /// Calculate nominal single shear screw connection strength limited by tilting and bearing
    /// </summary>
    /// <param name="t1">Thickness of ply in contact with screw head or washer</param>
    /// <param name="t2">Thickness of ply not in contact with screw head or washer</param>
    /// <param name="Fu1">Tensile strength of member in contact with screw head or washer</param>
    /// <param name="Fu2">Tensile strength of member not in contact with screw head or washer</param>
    /// <param name="d">Nominal screw diameter</param>
    /// <param name="output">Container for nominal strength and equation number label</param>
    /// <returns>Pnvtb - nominal single shear screw connection strength limited by tilting and bearing</returns>
    public static double SingleShearScrewConnectionStrengthTiltingBearing(double t1, double t2, double Fu1, double Fu2, double d, Output? output = null)
    {
        if ((t2 / t1) > 1.0 && (t2 / t1) < 2.5)
        {
            var Pnv1 = EqJ4_3_1__1(t2, d, Fu2, output);
            var Pnv2 = EqJ4_3_1__2(t1, d, Fu1, output);
            var Pnv3 = EqJ4_3_1__3(t2, d, Fu2, output);
            var Pnv123 = Math.Min(Math.Min(Pnv1, Pnv2), Pnv3);

            var Pnv4 = EqJ4_3_1__4(t1, d, Fu1, output);
            var Pnv5 = EqJ4_3_1__5(t2, d, Fu2, output);
            var Pnv45 = Math.Min(Pnv4, Pnv5);

            var slope = (Pnv45 - Pnv123) / (2.5 - 1.0);
            var Pnvtb = Pnv123 + slope * (t2 / t1 - 1.0);
            return Pnvtb;
        }

        if ((t2 / t1) <= 1.0)
        {
            var Pnv1 = EqJ4_3_1__1(t2, d, Fu2, output);
            var Pnv2 = EqJ4_3_1__2(t1, d, Fu1, output);
            var Pnv3 = EqJ4_3_1__3(t2, d, Fu2, output);
            var Pnvtb = Math.Min(Math.Min(Pnv1, Pnv2), Pnv3);
            return Pnvtb;
        }

        else //((t2 / t1) >= 2.5)
        {
            var Pnv4 = EqJ4_3_1__4(t1, d, Fu1, output);
            var Pnv5 = EqJ4_3_1__5(t2, d, Fu2, output);
            var Pnvtb = Math.Min(Pnv4, Pnv5);
            return Pnvtb;
        }
    }

    /// <summary>
    /// Calculate available single shear screw connection strength limited by tilting and bearing
    /// </summary>
    /// <param name="Pnvtb">Nominal single shear screw connection strength limited by tilting and bearing</param>
    /// <param name="designMethod">ASD, LRFD, or LSD</param>
    /// <param name="output">Container for nominal strength and equation number label</param>
    /// <returns>aPnvtb - available single shear screw connection strength limited by tilting and bearing</returns>
    public static double AvailableSingleShearScrewConnectionStrengthTiltingBearing(double Pnvtb, string designMethod, Output? output = null)

    {
        Dictionary<string, double> safetyResistanceFactors =
            new Dictionary<string, double>();

        safetyResistanceFactors.Add("ASD", 2.80);
        safetyResistanceFactors.Add("LRFD", 0.55);
        safetyResistanceFactors.Add("LSD", 0.45);

        var tempOutput = new Output();
        var aPnvtb = AISIS100.Core.CalculateAvailableStrength(Pnvtb, designMethod, safetyResistanceFactors, tempOutput);
        output?.AddResult("aPnvtb", aPnvtb, tempOutput.GetResultEquation("aRn") ?? "");
        
        return aPnvtb;
    }

    /// <summary>
    /// Calculate available screw shear rupture strength
    /// </summary>
    /// <param name="Pnvs">Nominal screw shear rupture strength, usually determined by test</param>
    /// <param name="designMethod">ASD, LRFD, or LSD</param>
    /// <param name="output">Container for nominal strength and equation number label</param>
    /// <returns>aPnvs - available screw shear rupture strength</returns>
    public static double AvailableScrewConnectionStrengthShear(double Pnvs, string designMethod, Output? output = null)

    {
        Dictionary<string, double> safetyResistanceFactors =
            new Dictionary<string, double>();

        safetyResistanceFactors.Add("ASD", 3.00);
        safetyResistanceFactors.Add("LRFD", 0.50);
        safetyResistanceFactors.Add("LSD", 0.40);

        var tempOutput = new Output();
        var aPnvs = AISIS100.Core.CalculateAvailableStrength(Pnvs, designMethod, safetyResistanceFactors, tempOutput);
        output?.AddResult("aaPnvs", aPnvs, tempOutput.GetResultEquation("aRn") ?? "");
        
        return aPnvs;
    }

    /// <summary>
    /// Calculate available single shear screw connection strength considering tilting and bearing and screw shear rupture
    /// </summary>
    /// <param name="aPnvtb">Available single shear screw connection strength limited by tilting and bearing</param>
    /// <param name="aPnvs">Available screw shear rupture strength</param>
    /// <param name="output">Container for nominal strength and equation number label</param>
    /// <returns>aPnv - available single shear screw connection strength considering tilting and bearing and screw shear rupture</returns>
    public static double AvailableSingleShearScrewConnectionStrength(double aPnvtb, double aPnvs, Output? output = null)

    {
        var aPnv = Math.Min(aPnvtb, aPnvs);
        return aPnv;
    }


    /// <summary>
    /// Calculate the nominal pull-out strength of sheet per screw
    /// </summary>
    /// <param name="tc">Lesser of depth of penetration and thickness t2</param>
    /// <param name="d">Nominal screw diameter</param>
    /// <param name="Fu2">Tensile strength of member not in contact with screw head or washer</param>
    /// <param name="units">Inches or millimeters</param>
    /// <param name="output">Container for nominal strength and equation number label</param>
    /// <returns>Pnot - nominal pull-out strength of sheet per screw</returns>
    public static double EqJ4_4_1__1(double tc, double d, double Fu2, string units, Output? output = null)
    {
        if (units == "inches")
        {
            var alpha = 1.0;
            var Pnot = 0.85 * tc * d * Fu2 * (1.63 * Math.Pow(alpha * tc, 0.18));
            output?.AddResult("Pnot", Pnot, "Eq.J4.4.1-1");
            return Pnot;
        }
        else
        {
            var alpha = 0.0394;
            var Pnot = 0.85 * tc * d * Fu2 * (1.63 * Math.Pow(alpha * tc, 0.18));
            output?.AddResult("Pnot", Pnot, "Eq.J4.4.1-1");
            return Pnot;
        }
    }

    /// <summary>
    /// Calculate the nominal pull-over strength of a sheet per screw
    /// </summary>
    /// <param name="t1">Thickness of member in contact with screw head or washer</param>
    /// <param name="dPrimew">Effective pull-over resistance diameter</param>
    /// <param name="Fu1">Tensile strength of member in contact with screw head or washer</param>
    /// <param name="output">Container for nominal strength and equation number label</param>
    /// <returns>Pnov - nominal pull-over strength of a sheet per screw</returns>
    public static double EqJ4_4_2__1(double t1, double dPrimew, double Fu1, Output? output = null)
    {
        var Pnov = 0.90 * t1 * dPrimew * Fu1;
        output?.AddResult("Pnov", Pnov, "Eq.J4.4.2-1");

        return Pnov;
    }

    /// <summary>
    /// Calculate effective pull-over resistance diameter
    /// </summary>
    /// <param name="dh">Screw head diameter or hex washer integral washer diameter</param>
    /// <param name="tw">Steel washer thickness</param>
    /// <param name="t1">Thickness of member in contact with screw head or washer</param>
    /// <param name="dw">Steel washer diameter</param>
    /// <param name="output">Container for nominal strength and equation number label</param>
    /// <returns>dPrimew - effective pull-over resistance diameter</returns>
    public static double EqJ4_4_2__3(double dh, double tw, double t1, double dw, Output? output = null)
    {
        var dPrimew = Math.Min(dh + 2 * tw + t1, dw);
        output?.AddResult("dPrimew", dPrimew, "Eq.J4.4.2-3");

        return dPrimew;
    }


    /// <summary>
    /// Calculate available pull-out strength of sheet per screw
    /// </summary>
    /// <param name="Pnot">Nominal pull-out strength of sheet per screw</param>
    /// <param name="designMethod">ASD, LRFD, or LSD</param>
    /// <param name="output">Container for nominal strength and equation number label</param>
    /// <returns>aPnot - available pull-out strength of sheet per screw</returns>
    public static double AvailablePulloutStrength(double Pnot, string designMethod, Output? output = null)

    {
        Dictionary<string, double> safetyResistanceFactors =
            new Dictionary<string, double>();

        safetyResistanceFactors.Add("ASD", 2.80);
        safetyResistanceFactors.Add("LRFD", 0.55);
        safetyResistanceFactors.Add("LSD", 0.45);

        var tempOutput = new Output();
        var aPnot = AISIS100.Core.CalculateAvailableStrength(Pnot, designMethod, safetyResistanceFactors, tempOutput);
        output?.AddResult("aPnot", aPnot, tempOutput.GetResultEquation("aRn") ?? "");
        
        return aPnot;
    }


    /// <summary>
    /// Calculate available pull-over strength of a sheet per screw
    /// </summary>
    /// <param name="Pnov">Nominal pull-over strength of a sheet per screw</param>
    /// <param name="designMethod">ASD, LRFD, or LSD</param>
    /// <param name="output">Container for nominal strength and equation number label</param>
    /// <returns>aPnov - available pull-over strength of a sheet per screw</returns>
    public static double AvailablePulloverStrength(double Pnov, string designMethod, Output? output = null)

    {
        Dictionary<string, double> safetyResistanceFactors =
            new Dictionary<string, double>();

        safetyResistanceFactors.Add("ASD", 2.90);
        safetyResistanceFactors.Add("LRFD", 0.55);
        safetyResistanceFactors.Add("LSD", 0.40);

        var tempOutput = new Output();
        var aPnov = AISIS100.Core.CalculateAvailableStrength(Pnov, designMethod, safetyResistanceFactors, tempOutput);
        output?.AddResult("aPnov", aPnov, tempOutput.GetResultEquation("aRn") ?? "");
        
        return aPnov;
    }
}