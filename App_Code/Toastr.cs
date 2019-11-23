using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
/// <summary>
/// Summary description for Toastr
/// </summary>
public class Toastr
{
    public Toastr()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public enum ToastType
    {
        Success,
        Info,
        Warning,
        error
         //Reserved word so we use []
    }
    public enum ToastPosition
    {
        TopRight,
        TopLeft,
        TopCenter,
        TopStretch,
        BottomRight,
        BottomLeft,
        BottomCenter,
        BottomStretch
    }
    public static string ShowToast(Page page,ToastType typs,string msg,string title="",ToastPosition position=ToastPosition.BottomRight,bool showCloseButton=true)
    {
        var strtype = "";
        var strposition = "";
        switch (typs)
        {
            case ToastType.Success:
                strtype = "success";
                break;
            case ToastType.Info:
                strtype = "info";
                break;
            case ToastType.Warning:
                strtype = "warning";
                break;
            case ToastType.error:
                strtype = "error";
                break;
            default:
                break;
        }
        switch (position)
        {
            case ToastPosition.TopRight:
                strposition = "toast-top-right";
                break;
            case ToastPosition.TopLeft:
                strposition = "toast-top-left";
                break;
            case ToastPosition.TopCenter:
                strposition = "toast-top-center";
                break;
            case ToastPosition.TopStretch:
                strposition = "toast-top-full-width";
                break;
            case ToastPosition.BottomRight:
                strposition = "toast-bottom-right";
                break;
            case ToastPosition.BottomLeft:
                strposition = "toast-bottom-left";
                break;
            case ToastPosition.BottomCenter:
                strposition = "toast-bottom-center";
                break;
            case ToastPosition.BottomStretch:
                strposition = "toast-bottom-full-width";
                break;
            default:
                break;
        }
        var script = "toastify('" + strtype + "','" + CleanStr(msg) + "','" + CleanStr(title) + "','" + strposition + "','" + showCloseButton + "')";
        page.ClientScript.RegisterStartupScript(page.GetType(), "toastedMsg", script, true);
        return script;
    }
    private static string CleanStr(string text)
    {
        return text.Replace("'", "&#39;");
    }

}