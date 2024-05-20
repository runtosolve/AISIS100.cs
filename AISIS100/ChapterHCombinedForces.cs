using System.ComponentModel.DataAnnotations;

namespace AISIS100;

public class ChapterHCombinedForces
{
    public static (double interaction, string passOrFail) EqH1_2__1(double pbar, double mxbar, double mybar, double pa, double max, double may)
    {
        var interaction = pbar / pa + mxbar / max + mybar / may;

        if (interaction >= 1.0)
        {
            var passOrFail = "fail";
            return (interaction, passOrFail);
        }
        else
        {
            var passOrFail = "pass";
            return (interaction, passOrFail);
        } 
        
    }
    
    public static (double interaction, string passOrFail) EqH2__1(double mbar, double vbar, double malo, double va)
    {
        var interaction = Math.Sqrt(Math.Pow(mbar / malo, 2.0) + Math.Pow(vbar / va, 2.0));
        
        if (interaction >= 1.0)
        {
            var passOrFail = "fail";
            return (interaction, passOrFail);
        }
        else
        {
            var passOrFail = "pass";
            return (interaction, passOrFail);
        } 
        
    }
    
    public static (double interaction, string passOrFail) EqH3__1a(double pbar, double mbar, double pn, double mnlo, double omega)
    {

        var interaction = 0.91 * (pbar / pn) + (mbar / mnlo);
        
        if (interaction >= 1.33 / omega)
        {
            var passOrFail = "fail";
            return (interaction, passOrFail);
        }
        else
        {
            var passOrFail = "pass";
            return (interaction, passOrFail);
        } 
        
    }
    
    public static (double interaction, string passOrFail) EqH3__2a(double pbar, double mbar, double pn, double mnlo, double phi)
    {

        var interaction = 0.91 * (pbar / pn) + (mbar / mnlo);
        
        if (interaction >= (1.33 * phi))
        {
            var passOrFail = "fail";
            return (interaction, passOrFail);
        }
        else
        {
            var passOrFail = "pass";
            return (interaction, passOrFail);
        } 
        
    }

    public static (double interaction, string passOrFail) Section3__2a(double pbar, double mbar, double pn, double mnlo, string designMethod)

    {

        if (designMethod == "ASD")
        {
            var omega = 1.70;
            return EqH3__1a(pbar, mbar, pn, mnlo, omega);

        }
        
        if (designMethod == "LRFD")
        {
            var phi = 0.90;
            return EqH3__2a(pbar, mbar, pn, mnlo, phi);
        }
        else
        {
            var phi = 0.75;
            return EqH3__2a(pbar, mbar, pn, mnlo, phi);
        }

    }
    
}