<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="userprofile.aspx.cs" Inherits="WebApplication1.userprofile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

      <script type="text/javascript">
       $(document).ready(function () {
           $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
       });
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
                                    <img width="100px" src="imgs/generaluser.png" />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Your Profile</h4>
                                    <span> Account Status -</span><asp:Label ID="Label1" class="badge badge-pill badge-info" runat="server" Text="your Status"></asp:Label>
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
                                 <label>Full Name </label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtfullname" CssClass="form-control" placeholder="Full Name" runat="server"></asp:TextBox>
                                </div>
                            </div>
                              <div class="col-md-6">
                                 <label>Date of Birth </label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtdob" CssClass="form-control"  runat="server" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                          <div class="row">
                            <div class="col-md-6">
                                 <label>Contact Number </label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtcontact" CssClass="form-control" placeholder="Contact Number" runat="server" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                              <div class="col-md-6">
                                 <label>Email ID </label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtemail" CssClass="form-control"  placeholder="Email ID"  runat="server" TextMode="Email"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                          <div class="row">
                            <div class="col-md-4">
                                 <label>State </label>
                                <div class="form-group">
                                     <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                                          <asp:ListItem Text="Sous Massa" Value="Andhra Pradesh" />
                            <asp:ListItem Text="Casablanca Settat" Value="Andhra Pradesh" />
                              <asp:ListItem Text="Select" Value="select" />
                              <asp:ListItem Text="Andhra Pradesh" Value="Andhra Pradesh" />
                              <asp:ListItem Text="Arunachal Pradesh" Value="Arunachal Pradesh" />
                              <asp:ListItem Text="Assam" Value="Assam" />
                              <asp:ListItem Text="Bihar" Value="Bihar" />
                              <asp:ListItem Text="Chhattisgarh" Value="Chhattisgarh" />
                              <asp:ListItem Text="Rajasthan" Value="Rajasthan" />
                              <asp:ListItem Text="Goa" Value="Goa" />
                              <asp:ListItem Text="Gujarat" Value="Gujarat" />
                              <asp:ListItem Text="Haryana" Value="Haryana" />
                              <asp:ListItem Text="Himachal Pradesh" Value="Himachal Pradesh" />
                              <asp:ListItem Text="Jammu and Kashmir" Value="Jammu and Kashmir" />
                              <asp:ListItem Text="Jharkhand" Value="Jharkhand" />
                              <asp:ListItem Text="Karnataka" Value="Karnataka" />
                              <asp:ListItem Text="Kerala" Value="Kerala" />
                              <asp:ListItem Text="Madhya Pradesh" Value="Madhya Pradesh" />
                              <asp:ListItem Text="Maharashtra" Value="Maharashtra" />
                              <asp:ListItem Text="Manipur" Value="Manipur" />
                              <asp:ListItem Text="Meghalaya" Value="Meghalaya" />
                              <asp:ListItem Text="Mizoram" Value="Mizoram" />
                              <asp:ListItem Text="Uttarakhand" Value="Uttarakhand" />
                              <asp:ListItem Text="West Bengal" Value="West Bengal" />
                           </asp:DropDownList>
                                </div>
                            </div>
                              <div class="col-md-4">
                                 <label>City </label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtcity" CssClass="form-control"  placeholder="City"  runat="server"></asp:TextBox>
                                </div>
                            </div>
                               <div class="col-md-4">
                                 <label>Pin Code</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtpincode" CssClass="form-control"  placeholder="Pin Code"  runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                         <div class="row">
                            <div class="col-md-12">
                                 <label>Full Adress </label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtfullAdr" CssClass="form-control" placeholder="Full Adress" runat="server" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                       
                        
                         <div class="row">
                            <div class="col">
                                <center>
                                    <span class="badge badge-pill badge-info">Login Credentials</span>
                                </center>
                            </div>
                        </div>
                       


                        <div class="row">
                            <div class="col-md-4">
                                 <label>User ID </label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtuserID" CssClass="form-control" placeholder="User ID" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>                         
                            </div>
                            <div class="col-md-4">
                                  <label>Old Password </label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtOldPass" CssClass="form-control" placeholder="Old Password" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                              <div class="col-md-4">
                                  <label>New Password </label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtNewPass" CssClass="form-control" placeholder="New Password" runat="server" ></asp:TextBox>
                                </div>
                            </div>
                              
                        </div>
                           <div class="row">
                            <div class="col-12">
                                <div>
                                    <asp:Button ID="Button1" class="btn btn-primary btn-block btn-lg" runat="server" Text="Update" OnClientClick="Button1_Click" OnClick="Button1_Click" />
                                </div>
                            </div>
                              

                        </div>

                      

                    </div>
                </div>


                 <a href="homepage.aspx"> << Back To Home </a> <br /><br />
            </div>


             <div class="col-md-6">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" src="imgs/books1.png" />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Your Issued Books</h4>
                                    <asp:Label ID="Label2" class="badge badge-pill badge-info" runat="server" Text="your books info"></asp:Label>
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
                            <div class="col">
                                <asp:GridView ID="GridView1"  class="table table-striped table-borderd table-hover table-responsive"  runat="server" OnRowDataBound="GridView1_RowDataBound"></asp:GridView>
                            </div>
                        </div>       
                </div>
            </div>
        </div>
    </div>
    </div>


</asp:Content>
