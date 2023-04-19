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
    public partial class AdminAuthorManagement : System.Web.UI.Page
    {
        string strcnx = ConfigurationManager.ConnectionStrings["cnx"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkExistAuthor())
                {
                    Response.Write("<script> alert('Author with ID already exist . you cannot add another Author with the same ID ')</script>");

                }
                else if (TextBox3.Text == null || TextBox3.Text == "")
                {
                    Response.Write("<script> alert('Invalid Author ID ')</script>");

                }

                else
                {
                    addNewAuthor();
                }
            }
            catch (Exception ex) { Response.Write("<script> alert('" + ex.Message + "')</script>"); }
           
        }



        //check author exested
        bool checkExistAuthor()
        {
            try
            {
                SqlConnection cnx = new SqlConnection(strcnx);
                if (cnx.State == ConnectionState.Open) cnx.Close();
                cnx.Open();
                SqlCommand cmd = new SqlCommand("select * from author_master where author_id='" + TextBox3.Text.Trim() + "'", cnx);

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);

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
                Response.Write("<script> alert('" + ex.Message + "')</script>");
                return false;
            }
        }


        //definded function

        void deleteAuthor()
        {
            try
            {
                SqlConnection cnx = new SqlConnection(strcnx);
                if (cnx.State == ConnectionState.Open) cnx.Close();
                cnx.Open();
                SqlCommand cmd = new SqlCommand("delete from author_master where author_id='" + TextBox3.Text.Trim() + "'", cnx);
       
                cmd.ExecuteNonQuery();
                cnx.Close();
                Response.Write("<script> alert('Author Deleted Successfully')</script>");
                clearinfo();
                GridView1.DataBind();

            }
            catch (Exception ex) { Response.Write("<script> alert('" + ex.Message + "')</script>"); }
        }




        void updateAuthor()
        {
            try
            {
                SqlConnection cnx = new SqlConnection(strcnx);
                if (cnx.State == ConnectionState.Open) cnx.Close();
                cnx.Open();
                SqlCommand cmd = new SqlCommand("update author_master set author_name = @author_name where author_id='"+TextBox3.Text.Trim()+"'", cnx);

                cmd.Parameters.AddWithValue("@author_id", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@author_name", TextBox4.Text.Trim());

                cmd.ExecuteNonQuery();
                cnx.Close();
                Response.Write("<script> alert('Author Updated Successfully')</script>");
                clearinfo();
                GridView1.DataBind();
            }
            catch (Exception ex) { Response.Write("<script> alert('" + ex.Message + "')</script>"); }
        }





        void addNewAuthor()
        {
            try
            {
                SqlConnection cnx = new SqlConnection(strcnx);
                if (cnx.State == ConnectionState.Open) cnx.Close();
                cnx.Open();
                SqlCommand cmd = new SqlCommand("insert into author_master values(@author_id,@author_name)", cnx);

                cmd.Parameters.AddWithValue("@author_id", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@author_name", TextBox4.Text.Trim());

                cmd.ExecuteNonQuery();
                cnx.Close();
                Response.Write("<script> alert('Author Added Successfully')</script>");
                clearinfo();
                GridView1.DataBind();

            }
            catch (Exception ex) { Response.Write("<script> alert('" + ex.Message + "')</script>"); }

        }
        
        void clearinfo()
        {
            TextBox3.Text = "";
            TextBox4.Text = "";
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkExistAuthor())
                {
                    updateAuthor();
                }
                else
                {
                    Response.Write("<script> alert('Author does not exist !!')</script>");

                }
            }
            catch (Exception ex) { Response.Write("<script> alert('" + ex.Message + "')</script>"); }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkExistAuthor())
                {
                    deleteAuthor();
                }
                else
                {
                    Response.Write("<script> alert('Author does not exist !!')</script>");

                }
            }
            catch (Exception ex) { Response.Write("<script> alert('" + ex.Message + "')</script>"); }
        }

        // go button function
        void getAuthorByID()
        {
            try
            {
                SqlConnection cnx = new SqlConnection(strcnx);
                if (cnx.State == ConnectionState.Open) cnx.Close();
                cnx.Open();
                SqlCommand cmd = new SqlCommand("select * from author_master where author_id='" + TextBox3.Text.Trim() + "'", cnx);

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox4.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script> alert('Invalid Author ID')</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "')</script>");
               
            }
        }
        

        protected void Button1_Click(object sender, EventArgs e)
        {
            getAuthorByID();
        }
    }
}