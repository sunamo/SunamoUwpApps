namespace apps;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

public class AsyncHelperApps //: sunamo.AsyncHelper
{
    public static AsyncHelperApps ci = new AsyncHelperApps();
    private AsyncHelperApps()
    {

    }

    public  T GetResult<T>(IAsyncOperation<T> task)
    {
        var op = task.AsTask();
        return AsyncHelper.ci.GetResult<T>(op);
    }

    public  void GetResult(IAsyncAction task)
    {
        var op = task.AsTask();
        AsyncHelper.ci.GetResult(op);
    }

    /// <summary>
    /// 
    /// 
    /// I think for return value it will be must use Thread 
    /// void I think is not good, because its intergrated feature of compiler. 
    /// </summary>
    public  T RunAsyncWithoutAwait<T, p1>(IAsyncOperation<T> t, p1 pa1)
    {
        /*
         * Je to píčovina, je to protože může trvat vykonávání.
         * Vždycky existuje cesta interoperability mezi apps and classic. 
         */
        return default(T);
        //    T value = default(T); 
        //    var thread = new Thread(() =>
        //    {
        //        value = t.Invoke(pa1);
        //    });
        //    thread.Start();
        //    thread.Join();
        //    return value;
    }
}
