<%@ Page Title="" Language="C#" MasterPageFile="~/Survei.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="SuveriBidikmisi.home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/js/libs/jquery-1.11.2.js") %>"></script>

    <script type="text/javascript"  src="<%= Page.ResolveUrl("~/js/libs/bootstrap.min.js") %>"></script>
    <script type="text/javascript"  src="<%= Page.ResolveUrl("~/js/plugins/datatables/jquery.dataTables.min.js")%>"></script>
    <script type="text/javascript"  src="<%= Page.ResolveUrl("~/js/plugins/datatables/dataTables.bootstrap.min.js")%>"></script> 
    <script type="text/javascript"  src="<%= Page.ResolveUrl("~/js/plugins/datatables/DT_bootstrap.js")%>"></script> 
    <script type="text/javascript"  src="<%= Page.ResolveUrl("~/js/plugins/tableCheckable/jquery.tableCheckable.js")%>"></script> 
    <script type="text/javascript"  src="<%= Page.ResolveUrl("~/js/plugins/icheck/jquery.icheck.min.js")%>"></script> 

    <script type="text/javascript">
        $(document).ready(function () {
            console.log($(location).attr('pathname'));

            $('#datatable').DataTable({
                columns: [
                        { "data": "npm" },
                        { "data": "nama" },
                //{ "data": "gender" },
                        {"data": "prog_study" },
                        { "data": "gelombang" },
                //{
                //    "render": function (data, type, JsonResultRow, meta) {
                //        return '<img src="' + JsonResultRow.poto + '"height="85" >'
                //    }
                //},
                //{ "data": "thn_angkatan" },
                        {
                        "render": function (data, type, JsonResultRow, meta) {
                            //return '<a class="btn btn-sm btn-success" href="http://localhost:15389/services/beasiswa.asmx/GetBorang?npm=' + JsonResultRow.npm + '" title="Input"><i class="glyphicon glyphicon-edit"></i></a>'
                            return '<a class="btn btn-sm btn-success" runat="server" href="~/user/pribadi.aspx?npm=' + JsonResultRow.npm + '" title="Input"><i class="glyphicon glyphicon-edit"></i></a>'
                        }
                    }
                ],
                processing: true,
                lengthMenu: [[25, 100, 200, 300, 400, -1], [25, 100, 200, 300, 400, "All"]],
                bServerSide: true,
                sAjaxSource: $(location).attr('pathname') + 'services/beasiswa.asmx/GetEmployees',
                //sAjaxSource: 'http://localhost:15389/services/beasiswa.asmx/GetEmployees',
                sServerMethod: 'get'

            });
        });


    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content-header">
        <h1>
            Dashboard</h1>
    </div>
    <!-- #content-header -->
    <div id="content-container">
        <div class="row">
            <div class="col-md-12">
                <div class="portlet">
                    <div class="portlet-header">
                        <h3>
                            <i class="fa fa-table"></i>Daftar Mahasiswa Bidik Misi
                        </h3>
                    </div>
                    <!-- /.portlet-header -->
                    <div class="portlet-content">
                        <div class="table-responsive">
                            <table id="datatable" class="table table-striped table-bordered table-hover dataTable-helper dataTable">
                                <thead>
                                    <tr>
                                        <th>
                                            NPM
                                        </th>
                                        <th>
                                            Nama
                                        </th>
                                        <%--<th>
                                            Gender
                                        </th>--%>
                                        <th>
                                            Program Studi
                                        </th>
                                        <th>
                                            Jalur
                                        </th>
                                        <%--<th>
                                            Poto
                                        </th>--%><%--
                                        <th>
                                            Tahun
                                        </th>--%>
                                        
                                        <th>
                                            Verifikasi
                                        </th>
                                    </tr>
                                </thead>
                                <%--<tfoot>
                                    <tr>
                                        <th>
                                            NPM
                                        </th>
                                        <th>
                                            Nama
                                        </th>
                                        <th>
                                            Gender
                                        </th>
                                        <th>
                                            Program Studi
                                        </th>
                                        <th>
                                            Jalur
                                        </th>
                                        <th>
                                            Poto
                                        </th>
                                        <th>
                                            Tahun
                                        </th>
                                    </tr>
                                </tfoot>--%>
                            </table>
                        </div>
                        <!-- /.table-responsive -->
                    </div>
                    <!-- /.portlet-content -->
                </div>
                <!-- /.portlet -->
            </div>
            <!-- /.col -->
        </div>
        <!-- /.row -->
    </div>
    <!-- /#content-container -->



    <script type="text/javascript" src="<%= Page.ResolveUrl("~/js/App.js") %>"></script>
</asp:Content>
