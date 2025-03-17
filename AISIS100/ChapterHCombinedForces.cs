using System.ComponentModel.DataAnnotations;
using AISIS100.Reporting;

namespace AISIS100;

public class ChapterHCombinedForces
{
    public static (double interaction, string passOrFail) EqH1_2__1(double Pbar, double Mxbar, double Mybar, double Pa, double Max, double May, Output? output = null)
    {
        var interaction = Pbar / Pa + Mxbar / Max + Mybar / May;
        output?.AddResult("interaction", interaction, "Eq.H1.2-1");

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
    
    public static (double interaction, string passOrFail) EqH2__1(double Mbar, double Vbar, double Malo, double Va, Output? output = null)
    {
        var interaction = Math.Sqrt(Math.Pow(Mbar / Malo, 2.0) + Math.Pow(Vbar / Va, 2.0));
        output?.AddResult("interaction", interaction, "Eq.H2-1");
        
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
    
    public static (double interaction, string passOrFail) EqH3__1a(double Pbar, double Mbar, double Pn, double Mnlo, double omega, Output? output = null)
    {

        var interaction = 0.91 * (Pbar / Pn) + (Mbar / Mnlo);
        output?.AddResult("interaction", interaction, "Eq.H3-1a");
        
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
    
    public static (double interaction, string passOrFail) EqH3__2a(double Pbar, double Mbar, double Pn, double Mnlo, double phi, Output? output = null)
    {

        var interaction = 0.91 * (Pbar / Pn) + (Mbar / Mnlo);
        output?.AddResult("interaction", interaction, "Eq.H3-1b");
        
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

    public static (double interaction, string passOrFail) Section3__2a(double Pbar, double Mbar, double Pn, double Mnlo, string designMethod, Output? output = null)

    {

        if (designMethod == "ASD")
        {
            var omega = 1.70;
            return EqH3__1a(Pbar, Mbar, Pn, Mnlo, omega, output);

        }
        
        if (designMethod == "LRFD")
        {
            var phi = 0.90;
            return EqH3__2a(Pbar, Mbar, Pn, Mnlo, phi, output);
        }
        else
        {
            var phi = 0.75;
            return EqH3__2a(Pbar, Mbar, Pn, Mnlo, phi, output);
        }

    }
    
}