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
    public partial class AdminPublisherManagement : System.Web.UI.Page
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
                    Response.Write("<script> alert('Publisher with ID already exist . you cannot add another Publisher with the same ID ')</script>");
                }
                else if (TextBox3.Text == null || TextBox3.Text == "")
                {
                    Response.Write("<script> alert('Invalid Publisher ID ')</script>");

                }

                else
                {
                    addNewPublisher();
                }
            }
            catch (Exception ex) { Response.Write("<script> alert('" + ex.Message + "')</script>"); }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkExistAuthor())
                {
                    updatePublisher();
                }
                else
                {
                    Response.Write("<script> alert('Publisher does not exist !!')</script>");

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
                    deletePublisher();
                }
                else
                {
                    Response.Write("<script> alert('Publisher does not exist !!')</script>");

                }
            }
            catch (Exception ex) { Response.Write("<script> alert('" + ex.Message + "')</script>"); }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            getPublisherByID();
        }




        //check author exested
        bool checkExistAuthor()
        {
            try
            {
                SqlConnection cnx = new SqlConnection(strcnx);
                if (cnx.State == ConnectionState.Open) cnx.Close();
                cnx.Open();
                SqlCommand cmd = new SqlCommand("select * from publisher_master where publisher_id='" + TextBox3.Text.Trim() + "'", cnx);

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

        void deletePublisher()
        {
            try
            {
                SqlConnection cnx = new SqlConnection(strcnx);
                if (cnx.State == ConnectionState.Open) cnx.Close();
                cnx.Open();
                SqlCommand cmd = new SqlCommand("delete from publisher_master where publisher_id='" + TextBox3.Text.Trim() + "'", cnx);

                cmd.ExecuteNonQuery();
                cnx.Close();
                Response.Write("<script> alert('Publisher Deleted Successfully')</script>");
                clearinfo();
                GridView1.DataBind();

            }
            catch (Exception ex) { Response.Write("<script> alert('" + ex.Message + "')</script>"); }
        }




        void updatePublisher()
        {
            try
            {
                SqlConnection cnx = new SqlConnection(strcnx);
                if (cnx.State == ConnectionState.Open) cnx.Close();
                cnx.Open();
                SqlCommand cmd = new SqlCommand("update publisher_master set publisher_name = @publisher_name where publisher_id='" + TextBox3.Text.Trim() + "'", cnx);

                cmd.Parameters.AddWithValue("@publisher_id", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@publisher_name", TextBox4.Text.Trim());

                cmd.ExecuteNonQuery();
                cnx.Close();
                Response.Write("<script> alert('Publisher Updated Successfully')</script>");
                clearinfo();
                GridView1.DataBind();
            }
            catch (Exception ex) { Response.Write("<script> alert('" + ex.Message + "')</script>"); }
        }





        void addNewPublisher()
        {
            try
            {
                SqlConnection cnx = new SqlConnection(strcnx);
                if (cnx.State == ConnectionState.Open) cnx.Close();
                cnx.Open();
                SqlCommand cmd = new SqlCommand("insert into publisher_master values(@publisher_id,@publisher_name)", cnx);

                cmd.Parameters.AddWithValue("@publisher_id", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@publisher_name", TextBox4.Text.Trim());

                cmd.ExecuteNonQuery();
                cnx.Close();
                Response.Write("<script> alert('Publisher Added Successfully')</script>");
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



        void getPublisherByID()
        {
            try
            {
                SqlConnection cnx = new SqlConnection(strcnx);
                if (cnx.State == ConnectionState.Open) cnx.Close();
                cnx.Open();
                SqlCommand cmd = new SqlCommand("select * from publisher_master where publisher_id='" + TextBox3.Text.Trim() + "'", cnx);

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox4.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script> alert('Invalid Publisher ID')</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "')</script>");

            }
        }
    }
}