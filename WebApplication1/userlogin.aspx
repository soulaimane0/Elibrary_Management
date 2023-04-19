<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="userlogin.aspx.cs" Inherits="WebApplication1.userlogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            position: relative;
            width: 100%;
            -ms-flex-preferred-size: 0;
            flex-basis: 0;
            -ms-flex-positive: 1;
            flex-grow: 1;
            max-width: 100%;
            left: 0px;
            top: -430px;
            padding-left: 15px;
            padding-right: 15px;
        }
    </style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="150px" src="imgs/generaluser.png" />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Member Login</h3>
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
                            <div class="col">
                                <label>Member ID </label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox1" CssClass="form-control" placeholder="Member ID" runat="server"></asp:TextBox>
                                </div>

                                <label>Password </label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox2" CssClass="form-control" placeholder="Password" runat="server" TextMode="Password"></asp:TextBox>
                                </div>

                                <div class="form-group">
                                    <asp:Button ID="Button1" class="btn btn-success btn-block btn-lg" runat="server" Text="Login" OnClick="Button1_Click" />
                                </div>

                                <div class="form-group">
                                    <a href="signup.aspx" style="text-decoration:none;">
                                        <input id="Button2" class="btn btn-info btn-block btn-lg" type="button" value="Sign Up" />
                                    </a>
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
