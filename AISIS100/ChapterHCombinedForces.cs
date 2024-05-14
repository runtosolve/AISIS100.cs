using System.ComponentModel.DataAnnotations;

namespace AISIS100;

public class ChapterHCombinedForces
{
    public static double EqH1_2__1(double pbar, double mxbar, double mybar, double pa, double max, double may)
    {
        var interaction = pbar / pa + mxbar / max + mybar / may;
        return interaction;
    }
}