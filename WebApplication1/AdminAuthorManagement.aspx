<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="AdminAuthorManagement.aspx.cs" Inherits="WebApplication1.AdminAuthorManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
      $(document).ready( function () {
        $('.table').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable();
        } );

    </script>
  
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">


                             <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Author Details</h4>
                                </center>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col">
                                <center>
                                    
                                    <img  width="100px" src="imgs/writer.png" />
                                </center>
                            </div>
                        </div>

                       <div class="row">
                            <div class="col">
                                <center>
                                    <hr />
                                </center>
                            </div>
                        </div>

                         <div class="row">
                            <div class="col-md-4">
                                 <label>Author ID </label>
                                <div class="form-group">
                                    <div class="input-group">
                                    <asp:TextBox ID="TextBox3" CssClass="form-control" placeholder="ID" runat="server"></asp:TextBox>
                                    <asp:Button ID="Button1" class="btn btn-secondary" runat="server" Text="GO" OnClick="Button1_Click" />

                                    </div>
                                </div>
                            </div>
                              <div class="col-md-8">
                                 <label>Author Name</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox4" CssClass="form-control"  runat="server" placeholder="Author Name"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                       <div class="row">
                           <div class="col-4">
                               <asp:Button ID="Button3" class="btn btn-success btn-lg btn-block" runat="server" Text="Add" OnClick="Button3_Click" />
                           </div>
                            <div class="col-4">
                               <asp:Button ID="Button4" class="btn btn-primary btn-lg btn-block" runat="server" Text="Update" OnClick="Button4_Click" />
                           </div>
                            <div class="col-4">
                               <asp:Button ID="Button5" class="btn btn-danger btn-lg btn-block" runat="server" Text="Delete" OnClick="Button5_Click" />
                           </div>
                       </div>

                    </div>
                 
                </div>
                     <a href="homepage.aspx"> << Back To Home </a> <br /><br />
            </div>


               
 
         
            
            
            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">


                        
                             <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Author List</h4>
                                </center>
                            </div>
                            </div>
                            
                        
                    
                       
                        <div class="row">
                            <div class="col">
                                <center>
                                    <hr />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" SelectCommand="SELECT * FROM [author_master]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView ID="GridView1"  class="table table-striped table-borderd table-hover"  runat="server" AutoGenerateColumns="False" DataKeyNames="author_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="author_id" HeaderText="author_id" ReadOnly="True" SortExpression="author_id" />
                                        <asp:BoundField DataField="author_name" HeaderText="author_name" SortExpression="author_name" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>       
                    </div>
                </div>
               
            </div>

         </div>
    </div>




</asp:Content>
