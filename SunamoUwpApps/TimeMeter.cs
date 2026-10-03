using System;
using System.Diagnostics;
using apps;

public class TimeMeter
{
    Stopwatch sw = null;
    bool inRelease = false;
    /// <summary>
    /// Zobrazí vždy všechno bez ohledu na DEBUG nebo jakékoliv proměnné
    /// </summary>
    public bool force = false;

    /// <summary>
    /// A1 zda se má zobrazovat výsledek i v release verzi programu
    /// </summary>
    /// <param name="inRelease"></param>
    public TimeMeter(bool inRelease, bool inDebug)
    {
        this.inRelease = inRelease;
        if (inRelease)
        {
            Start();
        }
        else
        {
#if DEBUG
            if (inDebug)
            {
                Start();
            }
#endif
        }
    }

    private void Start()
    {
        sw = new Stopwatch();
        sw.Start();
    }

    /// <summary>
    /// Vrátí null pokud se npočítalo
    /// POokud bylo v ctor A1, je zde do A1 nutno předat název operace ve správném jazyku - podle RL.l
    /// </summary>
    public string Stop(string operation)
    {
        if (sw != null)
        {
            string ods = LogServiceData.ods;
            TimeSpan ts = sw.Elapsed;
            string s = null;
            if (RL.l == Langs.cs)
            {
                s= sess.i18n("Operation") + AllStrings.space + ods + operation + ods + AllStrings.space + sess.i18n("lasted") + AllStrings.space + ods;
            }
            else
            {
                s = sess.i18n("Operation") + AllStrings.space + ods + operation  + ods + AllStrings.space+sess.i18n("lasted")+AllStrings.space + ods;
            }
            if (inRelease)
            {
                s += DTHelper.OperationLastedInLocalizateString(ts, Langs.cs) + ods;
            }
            else
            {
                s += ts.ToString() + LogServiceData.ods;
            }
            return s;
        }
        return null;
    }
}