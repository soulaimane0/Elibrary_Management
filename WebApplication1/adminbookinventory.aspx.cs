using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.IO;

namespace WebApplication1
{
    public partial class adminbookinventory : System.Web.UI.Page
    {
        string strcnx = ConfigurationManager.ConnectionStrings["cnx"].ConnectionString;
        static string global_filepath;
        static int global_actual_stock, global_current_stock, global_issued_books;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                fillAuthorPublisherValues();
            }
            GridView1.DataBind();
        }
        //add button
        protected void Button3_Click(object sender, EventArgs e)
        {

            if (checkIfBookExists())
            {
                Response.Write("<script>alert('Book Already Exists, try some other Book ID');</script>");
            }
            else if (txtbookID.Text == null || txtbookID.Text == "")
            {
                Response.Write("<script> alert('Invalid Book ID ')</script>");

            }
            else
            {
                addNewBook();
            }
        }


        //update button
        protected void Button2_Click(object sender, EventArgs e)
        {
            updateBookByID();
        }

        //delete button
        protected void Button4_Click(object sender, EventArgs e)
        {
            deleteBookByID();
        }

        // go button
        protected void Button1_Click(object sender, EventArgs e)
        {
            getBookByID();
        }







        //definds function
        void fillAuthorPublisherValues()
        {
            try
            {
                SqlConnection cnx = new SqlConnection(strcnx);
                if (cnx.State == ConnectionState.Closed)
                {
                    cnx.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT author_name from author_master ;", cnx);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList3.DataSource = dt;
                DropDownList3.DataValueField = "author_name";
                DropDownList3.DataBind();

                cmd = new SqlCommand("SELECT publisher_name from publisher_master ;", cnx);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                DropDownList2.DataSource = dt;
                DropDownList2.DataValueField = "publisher_name";
                DropDownList2.DataBind();

            }
            catch (Exception ex) { Response.Write("<script> alert('" + ex.Message + "')</script>"); }
        }

        bool checkIfBookExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcnx);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from book_master where book_id='" + txtbookID.Text.Trim() + "' OR book_name='" + txtbookname.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        // add fun
        void addNewBook()
        {
            try
            {
                string genres = "";
                foreach (int i in ListBox1.GetSelectedIndices())
                {
                    genres = genres + ListBox1.Items[i] + ",";
                }
                // genres = Adventure,Self Help,
                genres = genres.Remove(genres.Length - 1);

                string filepath = "~/book_inventory/books.png";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(Server.MapPath("book_inventory/" + filename));
                filepath = "~/book_inventory/" + filename;


                SqlConnection con = new SqlConnection(strcnx);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO book_master values(@book_id,@book_name,@genre,@author_name," +
                    "@publisher_name,@publish_date,@language,@edition,@book_cost,@no_of_pages," +
                    "@book_description,@actual_stock,@current_stock,@book_img_link)", con);

                cmd.Parameters.AddWithValue("@book_id", txtbookID.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", txtbookname.Text.Trim());
                cmd.Parameters.AddWithValue("@genre", genres);
                cmd.Parameters.AddWithValue("@author_name", DropDownList3.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publish_date", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@edition", txtEdition.Text.Trim());
                cmd.Parameters.AddWithValue("@book_cost", txtbookCost.Text.Trim());
                cmd.Parameters.AddWithValue("@no_of_pages", txtpage.Text.Trim());
                cmd.Parameters.AddWithValue("@book_description", txtBookDesc.Text.Trim());
                cmd.Parameters.AddWithValue("@actual_stock", txtAccStock.Text.Trim());
                cmd.Parameters.AddWithValue("@current_stock", txtAccStock.Text.Trim());
                cmd.Parameters.AddWithValue("@book_img_link", filepath);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Book added successfully.');</script>");
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }


        //void clearinfo()
        //{

        //    txtbookID.Text = "";
        //    txtbookname.Text = "";
        //    txtbookname.Text = "";
        //    txtContact.Text = "";
        //    txtEmail.Text = "";
        //    txtstate.Text = "";
        //    txtcity.Text = "";
        //    txtpinCode.Text = "";
        //    txtFullAdr.Text = "";
        //    txtaccS.Text = "";
        //}

        // get book id 
        void getBookByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcnx);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from book_master WHERE book_id='" + txtbookID.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    txtbookname.Text = dt.Rows[0]["book_name"].ToString();
                    TextBox1.Text = dt.Rows[0]["publish_date"].ToString();
                    txtEdition.Text = dt.Rows[0]["edition"].ToString();
                    txtbookCost.Text = dt.Rows[0]["book_cost"].ToString().Trim();
                    txtpage.Text = dt.Rows[0]["no_of_pages"].ToString().Trim();
                    txtAccStock.Text = dt.Rows[0]["actual_stock"].ToString().Trim();
                    txtCurrStock.Text = dt.Rows[0]["current_stock"].ToString().Trim();
                    txtBookDesc.Text = dt.Rows[0]["book_description"].ToString();
                    txtIssue.Text = "" + (Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString()) - Convert.ToInt32(dt.Rows[0]["current_stock"].ToString()));

                    DropDownList1.SelectedValue = dt.Rows[0]["language"].ToString().Trim();
                    DropDownList2.SelectedValue = dt.Rows[0]["publisher_name"].ToString().Trim();
                    DropDownList3.SelectedValue = dt.Rows[0]["author_name"].ToString().Trim();

                    ListBox1.ClearSelection();
                    string[] genre = dt.Rows[0]["genre"].ToString().Trim().Split(',');
                    for (int i = 0; i < genre.Length; i++)
                    {
                        for (int j = 0; j < ListBox1.Items.Count; j++)
                        {
                            if (ListBox1.Items[j].ToString() == genre[i])
                            {
                                ListBox1.Items[j].Selected = true;

                            }
                        }
                    }

                    global_actual_stock = Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString().Trim());
                    global_current_stock = Convert.ToInt32(dt.Rows[0]["current_stock"].ToString().Trim());
                    global_issued_books = global_actual_stock - global_current_stock;
                    global_filepath = dt.Rows[0]["book_img_link"].ToString();

                }
                else
                {
                    Response.Write("<script>alert('Invalid Book ID');</script>");
                }

            }
            catch (Exception ex)
            {

            }
        }




        // Update button proc
        void updateBookByID()
        {

            if (checkIfBookExists())
            {
                try
                {

                    int actual_stock = Convert.ToInt32(txtAccStock.Text.Trim());
                    int current_stock = Convert.ToInt32(txtCurrStock.Text.Trim());

                    if (global_actual_stock == actual_stock)
                    {

                    }
                    else
                    {
                        if (actual_stock < global_issued_books)
                        {
                            Response.Write("<script>alert('Actual Stock value cannot be less than the Issued books');</script>");
                            return;


                        }
                        else
                        {
                            current_stock = actual_stock - global_issued_books;
                            txtCurrStock.Text = "" + current_stock;
                        }
                    }

                    string genres = "";
                    foreach (int i in ListBox1.GetSelectedIndices())
                    {
                        genres = genres + ListBox1.Items[i] + ",";
                    }
                    genres = genres.Remove(genres.Length - 1);

                    string filepath = "~/book_inventory/books";
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    if (filename == "" || filename == null)
                    {
                        filepath = global_filepath;

                    }
                    else
                    {
                        FileUpload1.SaveAs(Server.MapPath("book_inventory/" + filename));
                        filepath = "~/book_inventory/" + filename;
                    }

                    SqlConnection con = new SqlConnection(strcnx);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("UPDATE book_master set book_name=@book_name, genre=@genre, author_name=@author_name, publisher_name=@publisher_name, publish_date=@publish_date, language=@language, edition=@edition, book_cost=@book_cost, no_of_pages=@no_of_pages, book_description=@book_description, actual_stock=@actual_stock, current_stock=@current_stock, book_img_link=@book_img_link where book_id='" + txtbookID.Text.Trim() + "'", con);

                    cmd.Parameters.AddWithValue("@book_name", txtbookname.Text.Trim());
                    cmd.Parameters.AddWithValue("@genre", genres);
                    cmd.Parameters.AddWithValue("@author_name", DropDownList3.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publish_date", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@edition", txtEdition.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_cost", txtbookCost.Text.Trim());
                    cmd.Parameters.AddWithValue("@no_of_pages", txtpage.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_description", txtBookDesc.Text.Trim());
                    cmd.Parameters.AddWithValue("@actual_stock", actual_stock.ToString());
                    cmd.Parameters.AddWithValue("@current_stock", current_stock.ToString());
                    cmd.Parameters.AddWithValue("@book_img_link", filepath);


                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    Response.Write("<script>alert('Book Updated Successfully');</script>");


                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Book ID');</script>");
            }
        }



        //delete book 
        void deleteBookByID()
        {
            if (checkIfBookExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcnx);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("DELETE from book_master WHERE book_id='" + txtbookID.Text.Trim() + "'", con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Book Deleted Successfully');</script>");

                    GridView1.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Invalid Member ID');</script>");
            }
        }



    }
}