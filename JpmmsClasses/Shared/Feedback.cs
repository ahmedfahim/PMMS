using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;


    /// <summary>
    /// Summary description for Feedback
    /// </summary>
public class Feedback
{
    #region Message Feedback

    public static string UpdateUNSuccessfull()
    {
        return "يوجد خطأ في التحديث!";
    }
    public static string EmailSentSuccessfull()
    {
        return "تم الإرسال بنجاح!";
    }

    public static string EmailSentException()
    {
        return "لم يتم الإرسال!";
    }

    public static string InsertSuccessfull()
    {
        return "تم الحفظ بنجاح!";
    }

    public static string InsertException()
    {
        return "لم يتم الحفظ!";
    }

    public static string InsertExceptionUnique()
    {
        return "لم يتم الحفظ بسبب وجود بيانات شبيهة محفوظة مسبقاً!";
    }

    public static string UpdateSuccessfull()
    {
        return "تم الحفظ بنجاح!";
    }

    public static string UpdateException()
    {
        return "لم يتم الحفظ!";
    }

    public static string UpdateExceptionUnique()
    {
        return "لم يتم الحفظ بسبب وجود بيانات شبيهة محفوظة مسبقاً!";
    }

    public static string DeleteSuccessfull()
    {
        return "تم الحذف بنجاح!";
    }

    public static string DeleteException()
    {
        return "لم يتم الحذف!";
    }

    public static string DeleteException(string relatedData)
    {
        return "لم يتم الحذف بسبب وجود بيانات مرتبطة!";
    }

    public static string StatusUpdateSuccessfull()
    {
        return "تم تحديث الحالة بنجاح";
    }

    public static string NoData()
    {
        return "لاتوجد بيانات للعرض!";
    }

    #endregion


    public static string SampleUpdateSuccessful()
    {
        return "تم تعديل بيانات العينة";
    }

    public static string NoPermissions()
    {
        return "ليست لديك صلاحية التنفيذ";
    }

    #region validation

    public static string InvalidImageFile()
    {
        return "الرجاء اختيار ملف بنوع JPG أو GIF!";
    }

    public static string NoImageFileSelected()
    {
        return "الرجاء اختيار ملف الصورة";
    }

    public static string DistressAreaLargerThanSampleArea()
    {
        return "لايمكن لمساحة العيب أن تتجاوز مساحة العينة";
    }

    public static string PatchDistressAreaLargerThanPatchArea()
    {
        return "لايمكن لمساحة عيب الترقيعة أن تتجاوز مساحة الترقيعة";
    }

    public static string NoSurveyDateNum()
    {
        return "الرجاء اختيار رقم وتاريخ المسح";
    }

    public static string NoSurveyNum()
    {
        return "الرجاء إدخال رقم المسح";
    }

    public static string NoSurveyDate()
    {
        return "الرجاء إدخال تاريخ المسح";
    }

    public static string NoDateSelected()
    {
        return "الرجاء إدخال التاريخ ";
    }



    public static string NoIntersectSampleSelected()
    {
        return "الرجاء اختيار عينة تقاطع لإدخال عيوبها";
    }

    public static string NoSectionSampleSelected()
    {
        return "الرجاء اختيار عينة مقطع لإدخال عيوبها";
    }

    public static string NoRegionSecStreetSampleSelected()
    {
        return "الرجاء اختيار عينة الشارع الفرعي لإدخال عيوبها";
    }

    public static string NoMainStreetSelected()
    {
        return "الرجاء اختيار الشارع الرئيسي";
    }

    public static string NoSectionSelected()
    {
        return "الرجاء اختيار المقطع";
    }

    public static string NoIntersectionSelected()
    {
        return "الرجاء اختيار التقاطع";
    }

    public static string NoRegionSelected()
    {
        return "الرجاء اختيار المنطقة الفرعية";
    }

    public static string NoSecondaryStreetSelected()
    {
        return "الرجاء اختيار الشارع الفرعي";
    }

    public static string NoRegionNameSelected()
    {
        return "الرجاء اختيار الحي الفرعي";
    }

    public static string NoRegionsAreaNameSelected()
    {
        return "الرجاء اختيار منطقة الأحياء الفرعية";
    }

    public static string NoMuniciplaitySelected()
    {
        return "الرجاء اختيار البلدية الفرعية";
    }

    public static string NoSurveyorSelected()
    {
        return "الرجاء اختيار المساح";
    }

    public static string NoSearchBeginDate()
    {
        return "الرجاء اختيار تاريخ بداية فترة البحث";
    }

    public static string NoSearchEndDate()
    {
        return "الرجاء اختيار تاريخ نهاية فترة البحث";
    }

    public static string SearchBeginDateAfterEndDate()
    {
        return "تاريخ نهاية فترة البحث لايمكن أن يكون سابقا لتاريخ بداية فترة البحث";
    }

    public static string DistressSelectedReturn()
    {
        return "الرجاء حذف العيوب قبل اعادة التحليل";
    }
    public static string DistressSelectedNotEnterd()
    {
        return "الرجاء ادخال العيوب قبل الإدخال النهائي";
    }
    public static string NoDistressSelected()
    {
        return "الرجاء اختيار نوع العيب";
    }

    public static string NoDistressSeveritySelected()
    {
        return "الرجاء اختيار شدة العيب";
    }

    public static string NonReadySample()
    {
        return "العينة غير جاهزة لعدم حساب المساحة أو عدم ترقيمها، لذا لايمكن إدخال العيوب عليها";
    }

    public static string NonUpdateableDistress()
    {
        return "لايمكن تعديل هذا العيب بسبب وجود حسابات UDI وقرارات صيانة عليه";
    }
    public static string NonDeleteableDistress()
    {
        return "لايمكن حذف هذا العيب بسبب وجود حسابات UDI وقرارات صيانة عليه";
    }

    #endregion
}
