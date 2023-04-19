<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="AdminBookIssuing.aspx.cs" Inherits="WebApplication1.AdminBookIssuing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

      <script type="text/javascript">
      $(document).ready( function () {
        $('.table').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable();
          });

     

    </script>
  
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <div class="container-fluid">
      <div class="row">
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">

                       <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Book Issuing</h4>
                                </center>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col">
                                <center>
                                    
                                    <img  width="100px" src="imgs/books.png" />
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

                              <div class="col-md-6">
                                 <label>Member ID</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtmemID" CssClass="form-control"  runat="server" placeholder="Member ID"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                 <label>Book ID </label>
                                <div class="form-group">
                                    <div class="input-group">
                                    <asp:TextBox ID="txtbookID" CssClass="form-control" placeholder="Book ID" runat="server"></asp:TextBox>
                                    <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="GO" OnClick="Button1_Click" />

                                    </div>
                                </div>
                            </div>
                             
                        </div>

                         <div class="row">
                            <div class="col-md-6">
                                 <label>Member Name </label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtmemName" CssClass="form-control" placeholder="Member Name" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                              <div class="col-md-6">
                                 <label>Book Name</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtbookname" CssClass="form-control"  runat="server" placeholder="Book Name" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                         <div class="row">
                             <div class="col-md-6">
                                 <label>Start Date</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtdateS" CssClass="form-control"  runat="server" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                            
                              <div class="col-md-6">
                                 <label>End Date</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtdateE" CssClass="form-control"  runat="server" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                        </div>



                       <div class="row">
                           <div class="col-6">
                               <asp:Button ID="Button3"  class="btn btn-primary btn-lg btn-block" runat="server" Text="Issue" OnClick="Button3_Click" />
                           </div>
                            <div class="col-6">
                               <asp:Button ID="Button4"  class="btn btn-success btn-lg btn-block" runat="server" Text="Return" OnClientClick="Button4_Click" OnClick="Button4_Click"/>
                           </div>
                          
                       </div>

                    </div>
                 
                </div>
            </div>
                     
            

            
            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">


                        
                             <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Issued Book List</h4>
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
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" SelectCommand="SELECT * FROM [book_issue]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView ID="GridView1"  class="table table-striped table-borderd table-hover"  runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnRowDataBound="GridView1_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="member_id" HeaderText="Member ID" SortExpression="member_id" />
                                        <asp:BoundField DataField="member_name" HeaderText="Member Name" SortExpression="member_name" />
                                        <asp:BoundField DataField="book_id" HeaderText="Book ID" SortExpression="book_id" />
                                        <asp:BoundField DataField="book_name" HeaderText="Book Name" SortExpression="book_name" />
                                        <asp:BoundField DataField="issue_date" HeaderText="Date Issue" SortExpression="issue_date" />
                                        <asp:BoundField DataField="due_date" HeaderText="Date Due" SortExpression="due_date" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>       
                    </div>
                </div>
               
            </div>

         </div>
     <br />
    </div>
</asp:Content>
