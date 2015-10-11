<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DataFromWService._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
                <h2>Modify this template to jump-start your ASP.NET application.</h2>
            </hgroup>
            <p>
                To learn more about ASP.NET, visit <a href="http://asp.net" title="ASP.NET Website">http://asp.net</a>.
                The page features <mark>videos, tutorials, and samples</mark> to help you get the most from ASP.NET.
                If you have any questions about ASP.NET visit
                <a href="http://forums.asp.net/18.aspx" title="ASP.NET Forum">our forums</a>.
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>DepartmentTask wise Students list:</h3>
    
    <div>
        
        <table class="auto-style1">
            
            <tr>
                <td>Department</td>
                <td>
                    <%--<select id="ddlDepartment"></select>--%>
                    <asp:DropDownList ID="ddlDepartment" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Student</td>
                <td>
                    <select id="ddlStudent"></select>
                </td>
            </tr>
        </table>
        
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            var ddlDpt = $('#<%=ddlDepartment.ClientID%>');
            var ddlStu = $('#ddlStudent'); <%--$('#<%=ddlStudent.ClientID%>');--%>

            $.ajax({
                url: 'DataService.asmx/LoadDepartments',
                type: 'post',
                dataType: 'json',
                success: function (data) {
                    ddlDpt.append($('<option/>', { value: -1, text: 'Select Department' }));
                    ddlStu.append($('<option/>', { value: -1, text: 'Select Student' }));
                    ddlStu.prop('disable', true);
                    $(data).each(function (index, item) {
                        ddlDpt.append($('<option/>', { value: item.Id, text: item.Name }));
                    });
                },
                error: OnError
            });

            ddlDpt.change(function() {
                if ($(this).val() == "-1") {
                    ddlStu.empty();
                    ddlStu.append($('<option/>', { value: -1, text: 'Select Student' }));
                    ddlStu.val('-1');
                    ddlStu.prop('disable', true);
                }
                else {

                    $.ajax({
                        url: 'DataService.asmx/LoadStudents',
                        type: 'post',
                        data: { departmentId: $(this).val() },
                        dataType: 'json',
                        success: function(data) {
                            ddlStu.empty();
                            ddlStu.append($('<option/>', { value: -1, text: 'Select Student' }));
                            ddlStu.prop('disable', false);
                            $(data).each(function(index, item) {
                                ddlStu.append($('<option/>', { value: item.Id, text: item.Name }));
                            });
                        }
                });
                }
            });

        });

        function OnError(result) {
            alert(result.status + ':' + result.statusText);
        }
        
    </script>
    
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</asp:Content>

