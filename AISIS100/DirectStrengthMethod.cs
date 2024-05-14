using System.ComponentModel.DataAnnotations;

namespace AISIS100;

public class DirectStrengthMethod
{
    public static double AxialCompressiveStrength(string designMethod, double fy, double ag, double pcre, double pcrl, double pcrd)
    {
        
        var fcre = pcre / ag;
        
        var pne = AISIS100.ChapterECompression.GlobalBucklingStrengthPne(fy, fcre, ag);
        var aPne = AISIS100.ChapterECompression.AvailableGlobalBucklingStrengthPne(pne, designMethod);

        var pnl = AISIS100.ChapterECompression.LocalBucklingStrengthPnl(pne, pcrl);
        var aPnl = AISIS100.ChapterECompression.AvailableLocalBucklingStrengthPnl(pnl, designMethod);

        var py = fy * ag;
        var pnd = AISIS100.ChapterECompression.DistortionalBucklingStrengthPnd(py, pcrd);
        var aPnd = AISIS100.ChapterECompression.AvailableDistortionalBucklingStrengthPnd(pnd, designMethod);

        var aPn = Math.Min(Math.Min(aPne, aPnl), aPnd);

        return aPn;

    }
    
    public static double FlexuralStrength(string designMethod, double fy, double sfc, double sf, double mcre, double mcrl, double mcrd)
    {

        var fcre = mcre / sfc;
        
        var my = AISIS100.ChapterFFlexure.EqF2_1__2(sf, fy);

        var mne = AISIS100.ChapterFFlexure.GlobalBucklingStrengthMne(fy, fcre, sfc, my);
        var aMne = AISIS100.ChapterFFlexure.AvailableGlobalBucklingStrengthMne(mne, designMethod);

        var mnl = AISIS100.ChapterFFlexure.LocalBucklingStrengthMnl(mne, my, mcrl);
        var aMnl = AISIS100.ChapterFFlexure.AvailableLocalBucklingStrengthMnl(mnl, designMethod);

        var mnd = AISIS100.ChapterFFlexure.DistortionalBucklingStrengthMnd(my, mcrd);
        var aMnd = AISIS100.ChapterFFlexure.AvailableDistortionalBucklingStrengthMnd(mnd, designMethod);
        
        var aMn = Math.Min(Math.Min(aMne, aMnl), aMnd);

        return aMn;
        
    }
        
    
    
    
}

// double e, double g, double ag, double ix, double iy, double j, double cw, double xo, double ro, double kx, double lx, double ky, double ly, double kt, double lt, 
// var pcre = AISIS100.Appendix2Buckling.Section2_3_1_1_2(e, g, ix, iy, j, cw, xo, ro, kx, lx, ky, ly, kt, lt);