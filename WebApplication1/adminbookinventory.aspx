<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="adminbookinventory.aspx.cs" Inherits="WebApplication1.adminbookinventory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

      <script type="text/javascript">
       $(document).ready(function () {
           $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
       });

       function readURL(input) {
           if (input.files && input.files[0]) {
               var reader = new FileReader();

               reader.onload = function (e) {
                   $('#imgview').attr('src', e.target.result);
               };

               reader.readAsDataURL(input.files[0]);
           }
       }

   </script>

      <style type="text/css">
          .auto-style1 {
              position: relative;
              width: 100%;
              -ms-flex: 0 0 100%;
              flex: 0 0 100%;
              max-width: 100%;
              direction: ltr;
              padding-left: 15px;
              padding-right: 15px;
          }
      </style>

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
                                    <h4>Book Details</h4>
                                </center>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img id="imgview"  width ="100px" height="150px" src="book_inventory/books.png" />
                                </center>
                            </div>
                        </div>

                       <div class="row">
                            <div class="col">
                                    <hr />                       
                            </div>
                        </div>

                          <div class="row">
                            <div class="col">
                                <asp:FileUpload onchange="readURL(this);" ID="FileUpload1" class="form-control" runat="server" />
                            </div>
                        </div>
                         <div class="row">

                            <div class="col-md-3">
                                 <label>Book ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                    <asp:TextBox ID="txtbookID" CssClass="form-control" placeholder="ID" runat="server"></asp:TextBox>
                                     <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="GO" OnClick="Button1_Click" />
                                    </div>
                                </div>
                            </div>

                               <div class="col-md-9">
                                 <label>Book Name</label>
                                 
                                <div class="form-group">                                                                    
                                      <asp:TextBox ID="txtbookname" CssClass="form-control" placeholder="Book Name" runat="server"></asp:TextBox>                                </div>
                            </div>
                             
                        </div>

                         <div class="row">
                            <div class="col-md-4">
                                 <label>Languege</label>
                                <div class="form-group">
                                    <asp:DropDownList ID="DropDownList1" class="form-control" runat="server">
                                        <asp:ListItem Text="English" Value="English" />
                                        <asp:ListItem Text="Hindi" Value="Arabic" />
                                        <asp:ListItem Text="Marathi" Value="German" />
                                        <asp:ListItem Text="French" Value="French" />
                                        <asp:ListItem Text="German" Value="Spanish" />
                                     </asp:DropDownList>
                                </div>  
                                <label>Publisher Name</label>
                                <div class="form-group">
                                    <asp:DropDownList ID="DropDownList2" class="form-control" runat="server">
                                        <asp:ListItem Text="Publisher 1" Value="Publisher 1" />
                                        <asp:ListItem Text="Publisher 2" Value="Publisher 2" />
                                     </asp:DropDownList>
                                </div>  
                            </div>
                              <div class="col-md-5">
                                 <label>Author Name</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownList3" runat="server">
                                      <asp:ListItem Text="A1" Value="a1" />
                                      <asp:ListItem Text="a2" Value="a2" />
                                    </asp:DropDownList>
                                </div>
                                   <label>Publish Date</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox1" class="form-control" runat="server" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-3">
                                 <label>Genre</label>
                                <div class="form-group">
                                    <asp:ListBox ID="ListBox1" class="form-control" runat="server" SelectionMode="Multiple" Rows="5">

                                         <asp:ListItem Text="Action" Value="Action" />
                              <asp:ListItem Text="Adventure" Value="Adventure" />
                              <asp:ListItem Text="Comic Book" Value="Comic Book" />
                              <asp:ListItem Text="Self Help" Value="Self Help" />
                              <asp:ListItem Text="Motivation" Value="Motivation" />
                              <asp:ListItem Text="Healthy Living" Value="Healthy Living" />
                              <asp:ListItem Text="Wellness" Value="Wellness" />
                              <asp:ListItem Text="Crime" Value="Crime" />
                              <asp:ListItem Text="Drama" Value="Drama" />
                              <asp:ListItem Text="Fantasy" Value="Fantasy" />
                              <asp:ListItem Text="Horror" Value="Horror" />
                              <asp:ListItem Text="Poetry" Value="Poetry" />
                              <asp:ListItem Text="Personal Development" Value="Personal Development" />
                              <asp:ListItem Text="Romance" Value="Romance" />
                              <asp:ListItem Text="Science Fiction" Value="Science Fiction" />
                              <asp:ListItem Text="Suspense" Value="Suspense" />
                              <asp:ListItem Text="Thriller" Value="Thriller" />
                              <asp:ListItem Text="Art" Value="Art" />
                              <asp:ListItem Text="Autobiography" Value="Autobiography" />
                              <asp:ListItem Text="Encyclopedia" Value="Encyclopedia" />
                              <asp:ListItem Text="Health" Value="Health" />
                              <asp:ListItem Text="History" Value="History" />
                              <asp:ListItem Text="Math" Value="Math" />
                              <asp:ListItem Text="Textbook" Value="Textbook" />
                              <asp:ListItem Text="Science" Value="Science" />
                              <asp:ListItem Text="Travel" Value="Travel" />

                                    </asp:ListBox>
                                </div>
                            </div>
                        </div>

                          <div class="row">
                            <div class="col-md-4">
                                 <label>Edition</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtEdition" CssClass="form-control" placeholder="Edition" runat="server" ReadOnly="False"></asp:TextBox>
                                </div>
                            </div>
                              <div class="col-md-4">
                                 <label>Book Cost (per unit)</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtbookCost" CssClass="form-control"  runat="server" placeholder="Book Cost" ReadOnly="False" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                 <label>Pages</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtpage" CssClass="form-control"  runat="server" placeholder="Pages" ReadOnly="False" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                         <div class="row">
                            <div class="col-md-4">
                                 <label>Actual Stock</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtAccStock" CssClass="form-control" placeholder="Actual Stock" runat="server" ReadOnly="False"></asp:TextBox>
                                </div>
                            </div>
                              <div class="col-md-4">
                                 <label>Current Stock </label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtCurrStock" CssClass="form-control"  runat="server" placeholder="Current Stock" ReadOnly="True" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                 <label>Issued Books</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtIssue" CssClass="form-control"  runat="server" placeholder="Issued Books" ReadOnly="True" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                          <div class="row">
                            <div class="col-md-12">
                                 <label>Book Description </label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtBookDesc" CssClass="form-control" placeholder="Book Description" runat="server" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                       <div class="row">
                           <div class="col-4">
                               <asp:Button ID="Button3" class="btn btn-success btn-lg btn-block" runat="server" Text="Add" OnClick="Button3_Click" />
                           </div>             
                            <div class="col-4">
                               <asp:Button ID="Button2" class="btn btn-primary btn-lg btn-block" runat="server" Text="Update" OnClick="Button2_Click" />
                           </div>             
                            <div class="col-4">
                               <asp:Button ID="Button4" class="btn btn-danger btn-lg btn-block" runat="server" Text="Delete" OnClick="Button4_Click" />
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
                                    <h4>Book Iventory List</h4>
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
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" SelectCommand="SELECT * FROM [book_master]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView ID="GridView1"  class="table table-striped table-borderd table-hover"  runat="server" AutoGenerateColumns="False" DataKeyNames="book_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="book_id" HeaderText="ID" ReadOnly="True" SortExpression="book_id" >
                                        
                                        <ItemStyle Font-Bold="True" />
                                        </asp:BoundField>
                                        
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="container-fluid">
                                                    <div class="row">
                                                        <div class="col-lg-9">
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("book_name") %>' Font-Bold="True" Font-Size="Large"></asp:Label>
                                                                </div>
                                                            </div>
                                                              <div class="row">
                                                                  Author -
                                                                  <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("author_name") %>' Font-Size="Medium"></asp:Label>
                                                                  &nbsp;| Genre -
                                                                  <asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("genre") %>'></asp:Label>
                                                                  &nbsp;| Langauge -
                                                                  <asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("language") %>'></asp:Label>
                                                            </div>
                                                              <div class="row">
                                                                <div class="auto-style1">

                                                                    Publisher -
                                                                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("publisher_name") %>'></asp:Label>
                                                                    &nbsp;| Publish Date -
                                                                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Text='<%# Eval("publish_date") %>'></asp:Label>
                                                                    &nbsp;| Pages -
                                                                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Text='<%# Eval("no_of_pages") %>'></asp:Label>
                                                                    &nbsp;| Edition -
                                                                    <asp:Label ID="Label8" runat="server" Font-Bold="True" Text='<%# Eval("edition") %>'></asp:Label>

                                                                </div>
                                                            </div>
                                                              <div class="row">
                                                                <div class="col-12">

                                                                    Cost -
                                                                    <asp:Label ID="Label9" runat="server" Font-Bold="True" Text='<%# Eval("book_cost") %>'></asp:Label>
                                                                    &nbsp;| Actual stock -
                                                                    <asp:Label ID="Label10" runat="server" Font-Bold="True" Text='<%# Eval("actual_stock") %>'></asp:Label>
                                                                    &nbsp;| Available -
                                                                    <asp:Label ID="Label11" runat="server" Font-Bold="True" Text='<%# Eval("current_stock") %>'></asp:Label>

                                                                </div>
                                                            </div>
                                                              <div class="row">
                                                                <div class="col-12">

                                                                    Description
                                                                    <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Smaller" Text='<%# Eval("book_description") %>'></asp:Label>

                                                                </div>
                                                            </div>

                                                            
                                                       
                                                        </div>
                                                         <div class="col-lg-3">
                                                            <asp:Image ID="Image1" runat="server" class="img-fluid" ImageUrl='<%# Eval("book_img_link") %>' />
                                                        </div>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
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
