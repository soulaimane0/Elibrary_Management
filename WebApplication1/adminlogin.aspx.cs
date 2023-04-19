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
    public partial class adminlogin : System.Web.UI.Page
    {
        string strcnx = ConfigurationManager.ConnectionStrings["cnx"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cnx = new SqlConnection(strcnx);
                if (cnx.State == ConnectionState.Open) cnx.Close();
                cnx.Open();
                SqlCommand cmd = new SqlCommand("select * from admin_login where username='" + TextBox1.Text.Trim() + "' and [password]='" + TextBox2.Text.Trim() + "' ", cnx);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Response.Write("<script> alert('Login Successful !!')</script>");
                        Session["username"] = dr.GetValue(0).ToString();
                        Session["fullname"] = dr.GetValue(2).ToString();
                        Session["role"] = "admin";
                   //     Session["status"] = dr.GetValue(10).ToString();
                    }
                    Response.Redirect("homepage.aspx");
                }
                else
                {
                    Response.Write("<script> alert('Invalid Credentials');</script>");
                }

                cnx.Close();

            }
            catch (Exception ex) { Response.Write("<script> alert('" + ex.Message + "')</script>"); }

        }
    }
}