namespace apps.Helpers.Clipboard;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;

public class ClipboardHelperApps : IClipboardHelperApps
{
static Type type = typeof(ClipboardHelperApps);
    public const uint CF_UNICODETEXT = 13U;
    public const uint CF_DSPTEXT = 0x0081;
    public const uint CF_LOCALE = 16U;
    public const uint CF_OEMTEXT = 7U;
    public const uint CF_TEXT = 1U;
    IClipboardMonitor clipboardMonitor = null;
    public static ClipboardHelperApps Instance = new ClipboardHelperApps();
    private ClipboardHelperApps()
    {
    }
    #region Get,Set
    /// <summary>
    /// Use here only managed method! I could avoid reinstall Windows (RepairJpn). Use only managed also for working with formats.
    /// not working if was pasted into visual studio (but code yes), created SetText2
    /// </summary>
    /// <param name="value"></param>
    public void SetText(string value)
    {
        if (clipboardMonitor != null)
        {
            
            clipboardMonitor.AfterSet = null;
        }
        if (!string.IsNullOrWhiteSpace(value))
        {
            // In use from SunamoCzAdmin.Cmd: Current thread must be set to single thread apartment (STA) mode before OLE calls can be made. Ensure that your Main function has STAThreadAttribute marked on it. 
            // Ani Dispatcher ani Thread nepomohl
            //WpfApp.cd.Invoke(() =>
            //{
            //new System.Threading.Thread(delegate ()
            //{
            SetTextWorker(value);
            //}).Start();
            //});
        }
    }
    void SetTextWorker(string value)
    {
        var dataPackage = new DataPackage();
        dataPackage.SetText(value);
        Clipboard.SetContent(dataPackage);
    }
  
    public void SetText2(string text)
    {
        // Nastavím text a místo toho se mi  uloží nějaký úplně starý
        SetTextWorker(text);
    }
   
    #endregion
    public async Task GetFirstWordOfList()
    {
        Console.WriteLine("Copy text to clipboard.");
        Console.ReadLine();
        StringBuilder stringBuilder = new StringBuilder();
        var text =  GetLines();
        foreach (var item in text)
        {
            string task = item.Trim();
            if (task.EndsWith(AllStrings.colon))
            {
                stringBuilder.AppendLine(item);
            }
            else if (task == "")
            {
                stringBuilder.AppendLine(task);
            }
            else
            {
                stringBuilder.AppendLine(SH.GetFirstWord(task));
            }
        }
        SetText(stringBuilder.ToString());
    }
    public void SetList(List<string> items)
    {
        SetLines(items);
    }
    public void SetLines(List<string> lines)
    {
        string text = SH.JoinNL(lines);
        SetText(text);
    }
    public void CutFiles(params string[] selected)
    {
        //byte[] moveEffect = { 2, 0, 0, 0 };
        //MemoryStream dropEffect = new MemoryStream();
        //dropEffect.Write(moveEffect, 0, moveEffect.Length);
        //StringCollection filestToCut = new StringCollection();
        //filestToCut.AddRange(selected);
        //DataObject data = new DataObject("Preferred DropEffect", dropEffect);
        //data.SetFileDropList(filestToCut);
        //Clipboard.Clear();
        //Clipboard.SetDataObject(data, true);
    }
    public void SetText(TextBuilder stringBuilder)
    {
        SetText(stringBuilder.ToString());
    }
    public void SetText(StringBuilder stringBuilder)
    {
        SetText(stringBuilder.ToString());
    }
    public void SetText3(string text)
    {
     
    }
 
    public void SetLines(IEnumerable lines)
    {
        ThrowEx.NotImplementedMethod();
    }
    public bool ContainsText()
    {
        return !string.IsNullOrWhiteSpace(GetText());
    }
    /// <summary>
    /// Use here only managed method! I could avoid reinstall Windows (RepairJpn). Use only managed also for working with formats.
    /// </summary>
    public string GetText()
    {
        #region Nepoužívat, 1) celá třída vypadá jak by ji psal totální amatér. 2) havaruje mi to app a nevyhodi pritom zadnou UnhaldedException
        //ClipboardAsync ca = new ClipboardAsync();
        //string s = ca.GetText();
        //return s;
        #endregion
        string result = "";
        //result = GetTextW32();
        result = AsyncHelperApps.ci.GetResult<string>(Clipboard.GetContent().GetTextAsync());
        return result;
    }
    public List<string> GetLines()
    {
        var text = GetText();
        return SH.GetLines(text);
    }
}
