using System.ComponentModel.DataAnnotations;

namespace AISIS100;

public class DirectStrengthMethod
{
    public static double AxialCompressiveStrength(string designMethod, double Fy, double Ag, double Pcre, double Pcrl, double Pcrd, Output? output = null)
    {

        var Fcre = AISIS100.Appendix2Buckling.Eq2_3_1_1__1(Pcre, Ag, output);
        
        var Pne = AISIS100.ChapterECompression.GlobalBucklingStrengthPne(Fy, Fcre, Ag, output);
        var aPne = AISIS100.ChapterECompression.AvailableGlobalBucklingStrengthPne(Pne, designMethod, output);

        var Pnl = AISIS100.ChapterECompression.LocalBucklingStrengthPnl(Pne, Pcrl, output);
        var aPnl = AISIS100.ChapterECompression.AvailableLocalBucklingStrengthPnl(Pnl, designMethod, output);
        
        var Py = AISIS100.ChapterECompression.EqE4__9(Ag, Fy, output);
        var Pnd = AISIS100.ChapterECompression.DistortionalBucklingStrengthPnd(Py, Pcrd, output);
        var aPnd = AISIS100.ChapterECompression.AvailableDistortionalBucklingStrengthPnd(Pnd, designMethod, output);
        
        var aPn = AISIS100.ChapterECompression.SectionE1(aPne, aPnl, aPnd, output);
        
        return aPn;

    }
    
    public static double FlexuralStrength(string designMethod, double Fy, double Sfc, double Sf, double Mcre, double Mcrl, double Mcrd, Output? output = null)
    {
        
        var Fcre = AISIS100.Appendix2Buckling.Eq2_3_1_2__1(Mcre, Sfc, output);
        
        var My = AISIS100.ChapterFFlexure.EqF2_1__2(Sf, Fy);

        var Mne = AISIS100.ChapterFFlexure.GlobalBucklingStrengthMne(Fy, Fcre, Sfc, My);
        var aMne = AISIS100.ChapterFFlexure.AvailableGlobalBucklingStrengthMne(Mne, designMethod);

        var Mnl = AISIS100.ChapterFFlexure.LocalBucklingStrengthMnl(Mne, My, Mcrl);
        var aMnl = AISIS100.ChapterFFlexure.AvailableLocalBucklingStrengthMnl(Mnl, designMethod);

        var Mnd = AISIS100.ChapterFFlexure.DistortionalBucklingStrengthMnd(My, Mcrd);
        var aMnd = AISIS100.ChapterFFlexure.AvailableDistortionalBucklingStrengthMnd(Mnd, designMethod);
        
        var aMn = AISIS100.ChapterFFlexure.SectionF1(aMne, aMnl, aMnd, output);

        return aMn;
        
    }
        
    
    
    
}

// double e, double g, double ag, double ix, double iy, double j, double cw, double xo, double ro, double kx, double lx, double ky, double ly, double kt, double lt, 
// var pcre = AISIS100.Appendix2Buckling.Section2_3_1_1_2(e, g, ix, iy, j, cw, xo, ro, kx, lx, ky, ly, kt, lt);