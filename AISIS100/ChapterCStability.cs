// ReSharper disable InconsistentNaming

namespace AISIS100;

public static class ChapterCStability
{
    public static double EqC1_1_1_3__1(double Pbar, double Py, string designMethod)
    {
        double alpha = designMethod switch
        {
            "LRFD" or "LSD" => 1.0,
            "ASD" => 1.6,
            _ => throw new Exception("Invalid design method")
        };

        if (alpha * Pbar / Py > 0.5)
        {
            throw new Exception("Equation does not apply to alpha * Pbar / Py > 0.5");
        }

        double taub = 1.0;
        return taub;
    }

    public static double EqC1_1_1_3__2(double Pbar, double Py, string designMethod)
    {
        double alpha = designMethod switch
        {
            "LRFD" or "LSD" => 1.0,
            "ASD" => 1.6,
            _ => throw new Exception("Invalid design method")
        };

        if (alpha * Pbar / Py <= 0.5)
        {
            throw new Exception("Equation does not apply to alpha * Pbar / Py <= 0.5");
        }

        if (alpha * Pbar / Py >= 1.0)
        {
            throw new Exception("Factored load is too high (alpha * Pbar / Py >= 1.0)");
        }

        var taub = 4 * (alpha * Pbar / Py) * (1 - alpha * Pbar / Py);
        return taub;
    }

    public static double EqC1_2_1_1__1(double Mntbar, double Mltbar, double B1, double B2)
    {
        var Mbar = (B1 * Mntbar + B2 * Mltbar);
        return Mbar;
    }

    public static double EqC1_2_1_1__2(double Pntbar, double Pltbar, double B2)
    {
        var Pbar = (Pntbar + B2 * Pltbar);
        return Pbar;
    }

    public static double EqC1_2_1_1__3(double Cm, double Pbar, double Pe1, string designMethod)
    {
        double alpha = designMethod switch
        {
            "LRFD" or "LSD" => 1.0,
            "ASD" => 1.6,
            _ => throw new Exception("Invalid design method")
        };

        if (alpha * Pbar / Pe1 >= 1.0)
        {
            throw new Exception("Factored load is too high (alpha * Pbar / Pe1 >= 1.0)");
        }

        var B1 = Math.Max(Cm / (1 - alpha * Pbar / Pe1), 1.0);

        // This is only needed for effective length method.
        // Let user decide if they should limit B1 or not.
        // if (B1 > 1.5)
        // {
        //     throw new Exception("B1 exceeds the maximum allowed value of 1.5");
        // }

        return B1;
    }

    public static double EqC1_2_1_1__4(double M1, double M2)
    {
        var Cm = 0.6 - 0.4 * (M1 / M2);
        return Cm;
    }

    public static double EqC1_2_1_1__5(double kf, double K1, double L)
    {
        var Pe1 = Math.PI * Math.PI * kf / Math.Pow(K1 * L, 2.0);
        return Pe1;
    }

    /// <summary>
    /// Calculate B1 with member with transverse loading
    /// </summary>
    /// <param name="Pbar">Required axial compressive strength (factored)</param>
    /// <param name="EI1">Flexural stiffness unreduced in the plane of bending</param>
    /// <param name="K1">Effective length factor in the plane of bending</param>
    /// <param name="L">Member length</param>
    /// <param name="designMethod">ASD, LRFD, LSD</param>
    /// <param name="flexuralStiffnessForStability">Whether flexural stiffness contribute stability of structure</param>
    /// <returns></returns>
    public static double CalculateB1WithTransverseLoading(double Pbar, double Py, double EI1, double K1, double L,
        string designMethod, bool flexuralStiffnessForStability = true)
    {
        var Cm = 1.0; // can be conservatively taken 1.0 for all cases if transverse loading exists

        double alpha = designMethod switch
        {
            "LRFD" or "LSD" => 1.0,
            "ASD" => 1.6,
            _ => throw new Exception("Invalid design method")
        };
        var taub = 1.0;
        if (flexuralStiffnessForStability)
        {
            taub = alpha * Pbar / Py <= 0.5 ? EqC1_1_1_3__1(Pbar, Py, designMethod) : EqC1_1_1_3__2(Pbar, Py, designMethod);
        }

        var kf = 0.9 * taub * EI1;
        var Pe1 = EqC1_2_1_1__5(kf, K1, L);
        var B1 = EqC1_2_1_1__3(Cm, Pbar, Pe1, designMethod);

        return B1;
    }
}