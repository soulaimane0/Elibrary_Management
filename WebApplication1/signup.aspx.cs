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
    public partial class signup : System.Web.UI.Page
    {
        string strcnx = ConfigurationManager.ConnectionStrings["cnx"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkExistMember())
            {
                Response.Write("<script> alert('Member Already Exest with this member ID , Please try other ID !!')</script>");
            }
            else
            {
                signUpNewMember();
            }
        }
        void signUpNewMember()
        {
            try
            {
                SqlConnection cnx = new SqlConnection(strcnx);
                if (cnx.State == ConnectionState.Open) cnx.Close();
                cnx.Open();
                SqlCommand cmd = new SqlCommand("insert into member_master values(@member_id,@full_name,@dob,@contact_num," +
                    "@email,@state,@city,@pincode,@full_adress,@password,@account_status)", cnx);
                cmd.Parameters.AddWithValue("@member_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@full_name", txtfullname.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", txtDOB.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_num", txtContact.Text.Trim());
                cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@city", txtcity.Text.Trim());
                cmd.Parameters.AddWithValue("@pincode", txtpincode.Text.Trim());
                cmd.Parameters.AddWithValue("@full_adress", txtFullAdr.Text.Trim());
                cmd.Parameters.AddWithValue("@password", txtpass.Text.Trim());
                cmd.Parameters.AddWithValue("@account_status", "pending");

                cmd.ExecuteNonQuery();
                cnx.Close();
                Response.Write("<script> alert('Sign Up Successful. Go to User Login to Login')</script>");

            }
            catch (Exception ex){ Response.Write("<script> alert('" + ex.Message + "')</script>"); }
         
        }
        bool checkExistMember()
        {
            try
            {
                SqlConnection cnx = new SqlConnection(strcnx);
                if (cnx.State == ConnectionState.Open) cnx.Close();
                cnx.Open();
                SqlCommand cmd = new SqlCommand("select * from member_master where member_id='"+TextBox1.Text.Trim()+"'", cnx);

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
            catch (Exception ex) { Response.Write("<script> alert('" + ex.Message + "')</script>");
                return false;

            }
        }
    }
}