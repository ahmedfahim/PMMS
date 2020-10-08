<%@ Control Language="VB" AutoEventWireup="false" CodeFile="right_menu.ascx.vb" Inherits="Controls_right_menu" %>

<link href="../Css/GeneralStyle.css"   rel="stylesheet" type="text/css" /> 


 <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>

<script type="text/javascript" src="../JS/jquery.min.js"  ></script>
<script type="text/javascript" src= "../JS/ddaccordion.js"></script>
<script type="text/javascript">

    ddaccordionRightMenu.initRightMenu({
        headerclass: "MainHeaders", //Shared CSS class name of headers group
        contentclass: "SubMenusContent", //Shared CSS class name of contents group
        revealtype: "click", //Reveal content when user clicks or onmouseover the header? Valid value: "click", "clickgo", or "mouseover"
        mouseoverdelay: 200, //if revealtype="mouseover", set delay in milliseconds before header expands onMouseover
        collapseprev: true, //Collapse previous content (so only one open at any time)? true/false
        defaultexpanded: [], //index of content(s) open by default [index1, index2, etc] [] denotes no content
        onemustopen: false, //Specify whether at least one header should be open always (so never all headers closed)
        animatedefault: false, //Should contents open by default be animated into view?
        persiststate: false, //persist state of opened contents within browser session?
        toggleclass: ["", ""], //Two CSS classes to be applied to the header when it's collapsed and expanded, respectively ["class1", "class2"]
        togglehtml: ["src", "../images/RightMenu/PlusIcon.png", "../images/RightMenu/MinusIcon.png"],  //Additional HTML added to the header when it's collapsed and expanded, respectively  ["position", "html1", "html2"] (see docs)
        animatespeed: "fast", //speed of animation: integer in milliseconds (ie: 200), or keywords "fast", "normal", or "slow"
        oninit: function(headers, expandedindices) { //custom code to run when headers have initalized
            //do nothing
        },
        onopenclose: function(header, index, state, isuseractivated) { //custom code to run whenever a header is opened or closed
            //do nothing
        }
    })


</script>    
                              
 
<table cellpadding="0" cellspacing="0" width="167px" style="border: 0px red solid;">
 <tr>
  <td align="center" colspan="3"><img src="../images/RightMenu/MenuTop.jpg" alt=""  width="167px" height="17px"/></td>
 </tr>
 
 
 <tr>
  <td align="center" width="6px" style="background: url('images/RightMenu/RepeatRightBorder.jpg') repeat-y top left;border: 0px red solid"></td>
 
  <td align="center" width="155px" style="padding-top:5px; background-color: #F7F7F7">
 
<div class="AccordionMenu">
 
 <div class='MainHeaders'>
   <a href="#" style="font-weight:normal;">
      <img src="../images/RightMenu/PlusIcon.png" alt="" class="StatusIcon" />
   عمليات الرخص
  </a>
 </div>
 
 <div class='SubMenusContent'>
    <ul>
     <li><asp:LinkButton ID="Lnk_NewL" runat="server">إصدار رخصة</asp:LinkButton></li>
     <li><asp:LinkButton ID="Lnk_ReNew" runat="server">تجديد رخصة</asp:LinkButton></li>
     <li><asp:LinkButton ID="Lnk_TransferOwn" runat="server">نقل ملكية</asp:LinkButton></li>
     <li><asp:LinkButton ID="Lnk_ChangeActive" runat="server">تغيير نشاط</asp:LinkButton></li>
     <li><asp:LinkButton ID="Lnk_RenewTrans" runat="server">تجديد ونقل ملكية</asp:LinkButton></li>
     <li><asp:LinkButton ID="Lnk_RenewChange" runat="server">تجديد وتغيير نشاط</asp:LinkButton></li>
     <li><asp:LinkButton ID="Lnk_Cancel" runat="server">إلغاء رخصة</asp:LinkButton></li>
     <li><asp:LinkButton ID="Lnk_Damaged" runat="server">بدل تالف</asp:LinkButton></li>
     <li><asp:LinkButton ID="Lnk_Lost" runat="server">بدل فاقد</asp:LinkButton></li>
    </ul>
 </div>
 
 
  <div class='MainHeaders'>
  <a href="#" style="font-weight:normal;">
      <img src="../images/RightMenu/PlusIcon.png" alt="" class="StatusIcon" />
   عمليات إدارية
  </a>
 </div>
 
 <div class='SubMenusContent'>
    <ul>
     <li><asp:LinkButton ID="Lnk_Customer" runat="server">إضافة/تعديل بيانات عميل</asp:LinkButton></li>
     <li><asp:LinkButton ID="Lnk_SCenter" runat="server">إضافة مركز خدمة</asp:LinkButton></li>
    </ul>
 </div>
 
 
 <div class='MainHeaders'>
  <a href="#" style="font-weight:normal;">
      <img src="../images/RightMenu/PlusIcon.png" alt="" class="StatusIcon" />
   عمليات رخص البسطات
  </a>
 </div>
 
 <div class='SubMenusContent'>
    <ul>
     <li><asp:LinkButton ID="Lnk_NewB" runat="server">إصدار رخصة بسطة</asp:LinkButton></li>
     <li><asp:LinkButton ID="Lnk_RenewB" runat="server">تجديد رخصة بسطة</asp:LinkButton></li>
     <li><asp:LinkButton ID="Lnk_CancelB" runat="server">إلغاء رخصة بسطة</asp:LinkButton></li>
     <li><asp:LinkButton ID="Lnk_LostDamagedB" runat="server">بدل فاقد/تالف بسطة</asp:LinkButton></li>
    </ul>
 </div>

 
 <div class='MainHeaders'>
  <a href="#" style="font-weight:normal;">
      <img src="../images/RightMenu/PlusIcon.png" alt="" class="StatusIcon" />
   عمليات المعاينة
  </a>
 </div>
 
 <div class='SubMenusContent'>
    <ul>
     <li><asp:LinkButton ID="Lnk_AssigniIns" runat="server">تعيين كشاف</asp:LinkButton></li>
     <li><asp:LinkButton ID="Lnk_InsertIns" runat="server">إدخال بيانات المعاينة</asp:LinkButton></li>
     <li><asp:LinkButton ID="Lnk_UnderInspect" runat="server">طلبات تحت المعاينة</asp:LinkButton></li>
    </ul>
 </div>
 
 
 
 <div class='MainHeaders'>
  <a href="#" style="font-weight:normal;">
      <img src="../images/RightMenu/PlusIcon.png" alt="" class="StatusIcon" />
   عرض الطلبات
  </a>
 </div>
 
 <div class='SubMenusContent'>
    <ul>
     <li><asp:LinkButton ID="Lnk_ReqBrowse" runat="server">عرض طلب</asp:LinkButton></li>
     <li><asp:LinkButton ID="Lnk_ReqNonComp" runat="server">طلبات غير مكتملة</asp:LinkButton></li>
     <li><asp:LinkButton ID="Lnk_ReqInternet" runat="server">طلبات الانترنت</asp:LinkButton></li>
     <li><asp:LinkButton ID="Lnk_ReqNote" runat="server">طلبات عليها ملاحظات</asp:LinkButton></li>
    </ul>
 </div>
 

 
 <div class='MainHeaders'>
  <a href="#" style="font-weight:normal;">
      <img src="../images/RightMenu/PlusIcon.png" alt="" class="StatusIcon" />
   الموافقات
  </a>
 </div>
 
 <div class='SubMenusContent'>
    <ul>
     <li><asp:LinkButton ID="Lnk_LicManager" runat="server">مدير الرخص</asp:LinkButton></li>
     <li><asp:LinkButton ID="Lnk_ServManager" runat="server">مدير الخدمات</asp:LinkButton></li>
     <li><asp:LinkButton ID="Lnk_BaladHead" runat="server">رئيس البلدية</asp:LinkButton></li>
    </ul>
 </div>
 
 
 <div class='MainHeaders'>
  <a href="#" style="font-weight:normal;">
      <img src="../images/RightMenu/PlusIcon.png" alt="" class="StatusIcon" />
   عمليات الرخص
  </a>
 </div>
 
 <div class='SubMenusContent'>
    <ul>
     <li><asp:LinkButton ID="Lnk_Print" runat="server">طباعة رخصة</asp:LinkButton></li>
     <li><asp:LinkButton ID="Lnk_Finished" runat="server">تسليم رخصة</asp:LinkButton></li>
     <li><asp:LinkButton ID="Lnk_CorctLic" runat="server">تصحيح بيانات رخصة مطبوعة</asp:LinkButton></li>
     <li><asp:LinkButton ID="Lnk_CorctLoc" runat="server">تصحيح بيانات موقع رخصة</asp:LinkButton></li>
     <li><asp:LinkButton ID="Lnk_ChangPlate" runat="server">تغيير بيانات لوحة</asp:LinkButton></li>
    </ul>
 </div>
 
 
  <div class='MainHeaders'>
  <a href="#" style="font-weight:normal;">
      <img src="../images/RightMenu/PlusIcon.png" alt="" class="StatusIcon" />
   الاستعلام
  </a>
 </div>
 
 <div class='SubMenusContent'>
    <ul>
     <li><asp:LinkButton ID="Lnk_Sadad" runat="server">استعلام عن حالة سداد</asp:LinkButton></li>
     <li><asp:LinkButton ID="Lnk_RwqStatus" runat="server">استعلام عن حالة طلب</asp:LinkButton></li>
    </ul>
 </div>
 
 
 </div>
 <div style="height:2px;background: #FFFFFF"></div>
  </td>
 
  <td align="center" width="6px" style="background: url('images/RightMenu/RepeatLeftBorder.jpg') repeat-y top right;"></td>
 </tr>
 
 <tr>
  <td align="center" colspan="3"><img src="../images/RightMenu/MenuBottom.jpg" alt=""  width="167px" height="17px" /></td>
 </tr>
</table>
