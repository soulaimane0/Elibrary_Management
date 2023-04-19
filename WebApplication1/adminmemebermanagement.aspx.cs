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
    public partial class adminmemebermanagement : System.Web.UI.Page
    {
        string strcnx = ConfigurationManager.ConnectionStrings["cnx"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            getmemberInfoByID();
        }

        //activ button
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            updateMumberStatus("active");
        }
        
        //pending button
        protected void LinkButton2_Click(object sender, EventArgs e)
        {

            updateMumberStatus("pending");
        }

        //desactiv button
        protected void LinkButton3_Click(object sender, EventArgs e)
        {

            updateMumberStatus("deactive");
        }

        void getmemberInfoByID()
        {
            try
            {
                SqlConnection cnx = new SqlConnection(strcnx);
                if (cnx.State == ConnectionState.Open) cnx.Close();
                cnx.Open();
                SqlCommand cmd = new SqlCommand("select * from member_master where member_id='" + txtID.Text.Trim() + "'", cnx);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                       // txtID.Text = dr.GetValue(0).ToString();
                        txtfullname.Text = dr.GetValue(1).ToString();
                        txtDOB.Text = dr.GetValue(2).ToString();
                        txtContact.Text = dr.GetValue(3).ToString();
                        txtEmail.Text = dr.GetValue(4).ToString();
                        txtstate.Text = dr.GetValue(5).ToString();
                        txtcity.Text = dr.GetValue(6).ToString();
                        txtpinCode.Text = dr.GetValue(7).ToString();
                        txtFullAdr.Text = dr.GetValue(8).ToString();
                        txtaccS.Text = dr.GetValue(10).ToString();

                    }
            
                }
                else
                {
                    Response.Write("<script> alert('Invalid Member ID');</script>");
                }

                cnx.Close();

            }
            catch (Exception ex) { Response.Write("<script> alert('" + ex.Message + "')</script>"); }

        }

        void updateMumberStatus(string status)
        {
            if (checkExistMember())
            {
                try
                {
                    SqlConnection cnx = new SqlConnection(strcnx);
                    if (cnx.State == ConnectionState.Open) cnx.Close();
                    cnx.Open();
                    SqlCommand cmd = new SqlCommand("update member_master set account_status='" + status + "' where member_id='" + txtID.Text.Trim() + "' ", cnx);
                    cmd.ExecuteNonQuery();
                    cnx.Close();
                    GridView1.DataBind();
                    Response.Write("<script> alert('Member Status Updated');</script>");



                }
                catch (Exception ex) { Response.Write("<script> alert('" + ex.Message + "')</script>"); }
            }
            else
            {
                Response.Write("<script> alert('Invalid Member ID');</script>");
            }
          

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkExistMember())
            {
                deletemember();
            }
            else
            {
                Response.Write("<script> alert('Invalid Credentials');</script>");
            }
           
        }

        // delete function

        void deletemember()
        {
            try
            {
                SqlConnection cnx = new SqlConnection(strcnx);
                if (cnx.State == ConnectionState.Open) cnx.Close();
                cnx.Open();
                SqlCommand cmd = new SqlCommand("delete from member_master where member_id='" + txtID.Text.Trim() + "'", cnx);

                cmd.ExecuteNonQuery();
                cnx.Close();
                Response.Write("<script> alert('Member Deleted Successfully')</script>");
                clearinfo();
                GridView1.DataBind();

            }
            catch (Exception ex) { Response.Write("<script> alert('" + ex.Message + "')</script>"); }
        }


        void clearinfo()
        {

            txtID.Text = "";
            txtfullname.Text = "";
            txtDOB.Text = "";
            txtContact.Text = "";
            txtEmail.Text = "";
            txtstate.Text = "";
            txtcity.Text = "";
            txtpinCode.Text = "";
            txtFullAdr.Text = "";
            txtaccS.Text = "";
        }

        // check function

        bool checkExistMember()
        {
            try
            {
                SqlConnection cnx = new SqlConnection(strcnx);
                if (cnx.State == ConnectionState.Open) cnx.Close();
                cnx.Open();
                SqlCommand cmd = new SqlCommand("select * from member_master where member_id='" + txtID.Text.Trim() + "'", cnx);

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



    }
}