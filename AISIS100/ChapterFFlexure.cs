namespace AISIS100;

public class ChapterFFlexure
{
    static double EqF2_1__1(double sfc, double fn, double my)
    {
        var mne = Math.Min(sfc * fn, my);
        return mne;
    }
    
    static double EqF2_1__2(double sf, double fy)
    {
        var my = sf * fy;
        return my;
    }

    static double F2_1__3(double fy)
    {
        var fn = fy;
        return fn;
    }
    
    static double F2_1__4(double fy, double fcre)
    {
        var fn = 10.0 / 9.0 * fy * (1 - (10 * fy) / (36 * fcre));
        return fn;
    }
    
    static double F2_1__5(double fcre)
    {
        var fn = fcre;
        return fn;
    }
    
    static double F3_2__1(double mne)
    {
        var mnl = mne;
        return mnl;
    }

    static double F3_2__2(double mcrl, double mne, double my)
    {

        var mneBar = Math.Min(mne, my);
        var mnl = (1 - 0.15 * Math.Pow((mcrl / mne), 0.4)) * Math.Pow(mcrl / mneBar, 0.4) * mneBar;
        return mnl;
    }

    static double F3_2__3(double mneBar, double mcrl)
    {
        var lambdal = Math.Sqrt(mneBar/mcrl);
        return lambdal;
    }
    
}