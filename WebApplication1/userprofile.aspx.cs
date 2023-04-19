﻿using System;
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
    public partial class userprofile : System.Web.UI.Page
    {
        string strcnx = ConfigurationManager.ConnectionStrings["cnx"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["username"].ToString() == "" || Session["username"] == null)
                {
                    Response.Write("<script>alert('Session Expired Login Again');</script>");
                    Response.Redirect("userlogin.aspx");
                }
                else
                {
                    getUserBookData();

                    if (!Page.IsPostBack)
                    {
                        getUserPersonalDetails();
                    }

                }
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("userlogin.aspx");
            }
        }

        //update button
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["username"].ToString() == "" || Session["username"] == null)
            {
                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("userlogin.aspx");
            }
            else
            {

               // Response.Write("<script>alert('test lkdfj');</script>");
                updateUserPersonalDetails();

            }
        }



        //definds function


        /*
          SqlCommand cmd = new SqlCommand("update member_master_table set full_name=@full_name, dob=@dob, contact_no=@contact_no, email=@email, state=@state, city=@city, pincode=@pincode, full_address=@full_address, password=@password, account_status=@account_status WHERE member_id='" + Session["username"].ToString().Trim() + "'", con);

            cmd.Parameters.AddWithValue("@full_name", TextBox1.Text.Trim());
            cmd.Parameters.AddWithValue("@dob", TextBox2.Text.Trim());
            cmd.Parameters.AddWithValue("@contact_no", TextBox3.Text.Trim());
            cmd.Parameters.AddWithValue("@email", TextBox4.Text.Trim());
            cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@city", TextBox6.Text.Trim());
            cmd.Parameters.AddWithValue("@pincode", TextBox7.Text.Trim());
            cmd.Parameters.AddWithValue("@full_address", TextBox5.Text.Trim());
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@account_status", "pending");

            int result = cmd.ExecuteNonQuery();*/

        void updateUserPersonalDetails()
        {
            string password = "";
            if (txtNewPass.Text.Trim() == "" || txtNewPass.Text == null)
            {
                password = txtOldPass.Text.Trim();
            }
            else
            {
                password = txtNewPass.Text.Trim();
            }
            try
            {
                SqlConnection con = new SqlConnection(strcnx);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                SqlCommand cmd = new SqlCommand("update member_master set full_name=@full_name, dob=@dob, contact_num=@contact_no, email=@email, state=@state, city=@city, pincode=@pincode, full_adress=@full_address, password=@password, account_status=@account_status WHERE member_id='" + txtuserID.Text.Trim() + "'", con);

                cmd.Parameters.AddWithValue("@full_name", txtfullname.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", txtdob.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", txtcontact.Text.Trim());
                cmd.Parameters.AddWithValue("@email", txtemail.Text.Trim());
                cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@city", txtcity.Text.Trim());
                cmd.Parameters.AddWithValue("@pincode", txtpincode.Text.Trim());
                cmd.Parameters.AddWithValue("@full_address", txtfullAdr.Text.Trim());
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@account_status", "pending");

                int result = cmd.ExecuteNonQuery();

                con.Close();
                if (result > 0)
                {

                    Response.Write("<script>alert('Your Details Updated Successfully');</script>");
                    getUserPersonalDetails();
                    getUserBookData();
                }
                else
                {
                    Response.Write("<script>alert('Invaid entry');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }



        void getUserPersonalDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcnx);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from member_master where member_id='" + Session["username"].ToString().Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                txtfullname.Text = dt.Rows[0]["full_name"].ToString();
                txtdob.Text = dt.Rows[0]["dob"].ToString();
                txtcontact.Text = dt.Rows[0]["contact_num"].ToString();
                txtemail.Text = dt.Rows[0]["email"].ToString();
                DropDownList1.SelectedValue = dt.Rows[0]["state"].ToString().Trim();
                txtcity.Text = dt.Rows[0]["city"].ToString();
                txtpincode.Text = dt.Rows[0]["pincode"].ToString();
                txtfullAdr.Text = dt.Rows[0]["full_adress"].ToString();
                txtuserID.Text = dt.Rows[0]["member_id"].ToString();
                txtOldPass.Text = dt.Rows[0]["password"].ToString();

                Label1.Text = dt.Rows[0]["account_status"].ToString().Trim();

                if (dt.Rows[0]["account_status"].ToString().Trim() == "active")
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-success");
                }
                else if (dt.Rows[0]["account_status"].ToString().Trim() == "pending")
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-warning");
                }
                else if (dt.Rows[0]["account_status"].ToString().Trim() == "deactive")
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-danger");
                }
                else
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-info");
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }




        void getUserBookData()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcnx);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from book_issue where member_id='" + Session["username"].ToString() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

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