<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="adminmemebermanagement.aspx.cs" Inherits="WebApplication1.adminmemebermanagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

      <script type="text/javascript">
      $(document).ready( function () {
        $('.table').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable();
        } );

    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="container-fluid">
      <div class="row">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-body">

                       <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Memeber Details</h4>
                                </center>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="95px" src="imgs/generaluser.png" />
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

                              <div class="col-md-3">
                                 <label>Member ID</label>
                                   <div class="form-group">
                                    <div class="input-group">
                                    <asp:TextBox ID="txtID"  CssClass="form-control" placeholder="ID" runat="server"></asp:TextBox>
                                    <asp:Button ID="Button2" class="btn btn-primary" runat="server" Text="GO" OnClick="Button2_Click" />

                                    </div>
                                </div>
                                <%--<div class="form-group">
                                    <asp:TextBox ID="TextBox4" CssClass="form-control"  runat="server" placeholder="Member ID"></asp:TextBox>
                                </div>--%>
                            </div>

                            <div class="col-md-4">
                                 <label>Full Name</label>
                                <div class="form-group">
                                    <div class="input-group">
                                    <asp:TextBox ID="txtfullname" CssClass="form-control" placeholder="Full Name" runat="server" ReadOnly="True"></asp:TextBox>

                                    </div>
                                </div>
                            </div>

                               <div class="col-md-5">
                                 <label>Account Status</label>
                                 
                                <div class="form-group">                                 
                                    <div class="input-group">
                                    <asp:TextBox ID="txtaccS" CssClass="form-control" placeholder="Status" runat="server" ReadOnly="True"></asp:TextBox>
                                    <asp:LinkButton ID="LinkButton1" class="btn btn-success mr-1" runat="server" OnClick="LinkButton1_Click"><i class="fas fa-check-circle"></i></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton2" class="btn btn-warning mr-1" runat="server" OnClick="LinkButton2_Click"><i class="far fa-pause-circle"></i></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton3" class="btn btn-danger" runat="server" OnClick="LinkButton3_Click" ><i class="fas fa-times-circle"></i></asp:LinkButton>

                                    </div>
                                </div>
                            </div>
                             
                        </div>

                         <div class="row">
                            <div class="col-md-4">
                                 <label>DOB</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtDOB" CssClass="form-control" placeholder="Member Name" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                              <div class="col-md-4">
                                 <label>Cntact Num</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtContact"  CssClass="form-control" runat="server" placeholder="Contact Nu" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                 <label>E-mail ID</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtEmail" CssClass="form-control"  runat="server" placeholder="Book Name" ReadOnly="True" TextMode="Email"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                          <div class="row">
                            <div class="col-md-4">
                                 <label>State</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtstate" CssClass="form-control" placeholder="State" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                              <div class="col-md-4">
                                 <label>City</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtcity" CssClass="form-control"  runat="server" placeholder="City" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                 <label>Pin Code</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtpinCode" CssClass="form-control"  runat="server" placeholder="Pin Code" ReadOnly="True" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                          <div class="row">
                            <div class="col-md-12">
                                 <label>Full Postal Adress </label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtFullAdr" CssClass="form-control" placeholder="Full Postal Adress" runat="server" TextMode="MultiLine" Rows="2" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                       <div class="row">
                           <div class="col-md-10 mx-auto">
                               <asp:Button ID="Button3" class="btn btn-danger btn-lg btn-block" runat="server" Text="Delete User Permanently" OnClick="Button3_Click" />
                           </div>                        
                       </div>

                    </div>
                 
                </div>
            </div>
                     
            

            
            <div class="col-md-6">
                <div class="card">
                    <div class="card-body">


                        
                             <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Member List</h4>
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
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" SelectCommand="SELECT * FROM [member_master]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView ID="GridView1"  class="table table-striped table-borderd table-hover"  runat="server" AutoGenerateColumns="False" DataKeyNames="member_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="member_id" HeaderText="ID" ReadOnly="True" SortExpression="member_id" />
                                        <asp:BoundField DataField="full_name" HeaderText="Name" SortExpression="full_name" />
                                        <asp:BoundField DataField="account_status" HeaderText="Status" SortExpression="account_status" />
                                        <asp:BoundField DataField="contact_num" HeaderText="Contact" SortExpression="contact_num" />
                                        <asp:BoundField DataField="email" HeaderText="E-mail" SortExpression="email" />
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
