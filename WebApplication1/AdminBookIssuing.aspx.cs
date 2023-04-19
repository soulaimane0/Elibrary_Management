using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class AdminBookIssuing : System.Web.UI.Page
    {
        string strcnx = ConfigurationManager.ConnectionStrings["cnx"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
            // GridView1.Rows[0].Cells[5].Text.ToString();

           // txtdateS.Text.ToString("dd-mm-yyyy");
        }

        // go button
        protected void Button1_Click(object sender, EventArgs e)
        {
            getNames();
        }

        // issue button
        protected void Button3_Click(object sender, EventArgs e)
        {
            //Response.Write("<script>alert('test');</script>");
            if (checkIfBookExist() && checkIfMemberExist())
            {

                if (checkIfIssueEntryExist())
                {
                    Response.Write("<script>alert('This Member already has this book');</script>");
                }
                else
                {
                    issueBook();
                }

            }
            else
            {
                Response.Write("<script>alert('Wrong Book ID or Member ID');</script>");
            }
        }

        // return button
        //protected void Button4_Click(object sender, EventArgs e)
        //{
        //    Response.Write("<script>alert('Test');</script>");

        //    if (checkIfBookExist() && checkIfMemberExist())
        //    {

        //        if (checkIfIssueEntryExist())
        //        {
        //            returnBook();
        //        }
        //        else
        //        {
        //            Response.Write("<script>alert('This Entry does not exist');</script>");
        //        }

        //    }
        //    else
        //    {
        //        Response.Write("<script>alert('Wrong Book ID or Member ID');</script>");
        //    }
        //}
        //protected void Button4_Click(object sender, EventArgs e)
        //{
        //    Response.Write("<script>alert('Test');</script>");

        //    if (checkIfBookExist() && checkIfMemberExist())
        //    {

        //        if (checkIfIssueEntryExist())
        //        {
        //            returnBook();
        //        }
        //        else
        //        {
        //            Response.Write("<script>alert('This Entry does not exist');</script>");
        //        }

        //    }
        //    else
        //    {
        //        Response.Write("<script>alert('Wrong Book ID or Member ID');</script>");
        //    }
        //}




        // definds functions
        void getNames()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcnx);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select book_name from book_master WHERE book_id='" + txtbookID.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    txtbookname.Text = dt.Rows[0]["book_name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Wrong Book ID');</script>");
                }

                cmd = new SqlCommand("select full_name from member_master WHERE member_id='" + txtmemID.Text.Trim() + "'", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    txtmemName.Text = dt.Rows[0]["full_name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Wrong User ID');</script>");
                }


            }
            catch (Exception ex)
            {

            }
        }


        //checkes
        bool checkIfMemberExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcnx);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select full_name from member_master WHERE member_id='" + txtmemID.Text.Trim() + "'", con);
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
                return false;
            }

        }

        bool checkIfBookExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcnx);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from book_master WHERE book_id='" + txtbookID.Text.Trim() + "' AND current_stock >0", con);
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
                return false;
            }

        }



        bool checkIfIssueEntryExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcnx);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from book_issue WHERE member_id='" + txtmemID.Text.Trim() + "' AND book_id='" + txtbookID.Text.Trim() + "'", con);
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
                return false;

            }

        }



        //issue book

        void issueBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcnx);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO book_issue(member_id,member_name,book_id,book_name,issue_date,due_date) values(@member_id,@member_name,@book_id,@book_name,@issue_date,@due_date)", con);

                cmd.Parameters.AddWithValue("@member_id", txtmemID.Text.Trim());
                cmd.Parameters.AddWithValue("@member_name", txtmemName.Text.Trim());
                cmd.Parameters.AddWithValue("@book_id", txtbookID.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", txtbookname.Text.Trim());
                cmd.Parameters.AddWithValue("@issue_date", txtdateS.Text.Trim());
                cmd.Parameters.AddWithValue("@due_date", txtdateE.Text.Trim());

                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("update  book_master set current_stock = current_stock-1 WHERE book_id='" + txtbookID.Text.Trim() + "'", con);

                cmd.ExecuteNonQuery();

                con.Close();
                Response.Write("<script>alert('Book Issued Successfully');</script>");

                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }


        //return book
        void returnBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcnx);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                SqlCommand cmd = new SqlCommand("Delete from book_issue WHERE book_id='" + txtbookID.Text.Trim() + "' AND member_id='" + txtmemID.Text.Trim() + "'", con);
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {

                    cmd = new SqlCommand("update book_master set current_stock = current_stock+1 WHERE book_id='" + txtbookID.Text.Trim() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    Response.Write("<script>alert('Book Returned Successfully');</script>");
                    GridView1.DataBind();

                    //con.Close();

                }
                else
                {
                    Response.Write("<script>alert('Error - Invalid details');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        //protected void Return_button(object sender, EventArgs e)
        //{
        //    Response.Write("<script>alert('text');</script>");
        //}

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkIfBookExist() && checkIfMemberExist())
            {

                if (checkIfIssueEntryExist())
                {
                    returnBook();
                }
                else
                {
                    Response.Write("<script>alert('This Entry does not exist');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Wrong Book ID or Member ID');</script>");
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //Check your condition here
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;
                    if (today > dt)
                    {
                        e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}