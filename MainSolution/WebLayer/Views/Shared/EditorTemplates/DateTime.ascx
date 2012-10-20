<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<System.DateTime?>" %>

<%= Html.TextBox(string.Empty, (Model.HasValue) ? Model.Value.ToString("dd MMM yyyy") : "", new { style = "width:90px" })%>


<script type="text/javascript" >
    $(document).ready(function () 
    {
        //set the date picker
        var dtp = '#<%=ViewData.TemplateInfo.GetFullHtmlFieldId("") %>';
        dtp = dtp.replace("[", "_");
        dtp = dtp.replace("]", "_");
        //window.alert($(dtp).attr("value"));
        var hid = ($(dtp).attr("type") == "hidden");
        if (!hid) 
        {
            $(dtp).datepicker({
                showOn: 'button', buttonImage: '<%= ResolveUrl("~/Content/images/calendar.gif")%>', buttonImageOnly: true
               , changeMonth: true, changeYear: true
               , dateFormat: 'dd M yy'//, numberOfMonths: 2
            });
        }
        
    });
	
</script>


