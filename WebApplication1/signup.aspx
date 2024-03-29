﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="WebApplication1.signup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-8 mx-auto">
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
                                    <h4>Memeber Sign Up</h4>
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
                                    <asp:TextBox ID="txtDOB" CssClass="form-control"  runat="server" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                          <div class="row">
                            <div class="col-md-6">
                                 <label>Contact Number </label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtContact" CssClass="form-control" placeholder="Contact Number" runat="server" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                              <div class="col-md-6">
                                 <label>Email ID </label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtEmail" CssClass="form-control"  placeholder="Email ID"  runat="server" TextMode="Email"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                          <div class="row">
                            <div class="col-md-4">
                                 <label>State </label>
                                <div class="form-group">
                                     <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                              <asp:ListItem Text="Select" Value="select" />
                            <asp:ListItem Text="Sous Massa" Value="Andhra Pradesh" />
                            <asp:ListItem Text="Casablanca Settat" Value="Andhra Pradesh" />
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
                              <asp:ListItem Text="Nagaland" Value="Nagaland" />
                              <asp:ListItem Text="Odisha" Value="Odisha" />
                              <asp:ListItem Text="Punjab" Value="Punjab" />
                              <asp:ListItem Text="Rajasthan" Value="Rajasthan" />
                              <asp:ListItem Text="Sikkim" Value="Sikkim" />
                              <asp:ListItem Text="Tamil Nadu" Value="Tamil Nadu" />
                              <asp:ListItem Text="Telangana" Value="Telangana" />
                              <asp:ListItem Text="Tripura" Value="Tripura" />
                              <asp:ListItem Text="Uttar Pradesh" Value="Uttar Pradesh" />
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
                                    <asp:TextBox ID="txtpincode" CssClass="form-control"  placeholder="Pin Code"  runat="server" ></asp:TextBox>
                                </div>
                            </div>
                        </div>


                         <div class="row">
                            <div class="col-md-12">
                                 <label>Full Adress </label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtFullAdr" CssClass="form-control" placeholder="Full Adress" runat="server" TextMode="MultiLine" Rows="2"></asp:TextBox>
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
                            <div class="col-md-6">
                                 <label>Member ID </label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox1" CssClass="form-control" placeholder="Member ID" runat="server"></asp:TextBox>
                                </div>                         
                            </div>
                            <div class="col-md-6">
                                  <label>Password </label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtpass" CssClass="form-control" placeholder="Password" runat="server" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                              
                        </div>
                           <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <asp:Button ID="Button1" class="btn btn-success btn-block btn-lg" runat="server" Text="Sign Up" OnClick="Button1_Click" />
                                </div>
                            </div>
                        </div>

                      

                    </div>
                </div>


                 <a href="homepage.aspx"> << Back To Home </a> <br /><br />
            </div>
        </div>
    </div>

</asp:Content>
