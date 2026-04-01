using Microsoft.AspNetCore.Mvc.ViewFeatures;
namespace demo.project.site.Extensions;

public static class NotificationExtensions
{
    // ── Toast ────────────────────────────────

    public static void ToastSuccess(this ITempDataDictionary tempData,
        string message, string title = "Completado")
        => SetToast(tempData, "success", title, message);

    public static void ToastError(this ITempDataDictionary tempData,
        string message, string title = "Error")
        => SetToast(tempData, "error", title, message);

    public static void ToastWarning(this ITempDataDictionary tempData,
        string message, string title = "Atención")
        => SetToast(tempData, "warning", title, message);

    public static void ToastInfo(this ITempDataDictionary tempData,
        string message, string title = "Información")
        => SetToast(tempData, "info", title, message);

    private static void SetToast(ITempDataDictionary tempData,
        string type, string title, string message)
    {
        tempData["Toast.Type"] = type;
        tempData["Toast.Title"] = title;
        tempData["Toast.Message"] = message;
    }

    // ── Banner ───────────────────────────────

    public static void BannerSuccess(this ITempDataDictionary tempData, string message)
        => SetBanner(tempData, "success", message);

    public static void BannerError(this ITempDataDictionary tempData, string message)
        => SetBanner(tempData, "error", message);

    public static void BannerWarning(this ITempDataDictionary tempData, string message)
        => SetBanner(tempData, "warning", message);

    public static void BannerInfo(this ITempDataDictionary tempData, string message)
        => SetBanner(tempData, "info", message);

    private static void SetBanner(ITempDataDictionary tempData, string type, string message)
    {
        tempData["Banner.Type"] = type;
        tempData["Banner.Message"] = message;
    }
}