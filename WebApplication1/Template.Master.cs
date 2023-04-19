using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Template : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty((string)Session["role"]))
                   // if (Session["role"].Equals(""))
                {
                    LinkButton2.Visible = true; //login
                    LinkButton3.Visible = true; //sign up

                    LinkButton4.Visible = false; //logout
                    LinkButton5.Visible = false; // hello user (admin)

                    LinkButton6.Visible = true; //admin
                    LinkButton7.Visible = false;
                    LinkButton8.Visible = false;
                    LinkButton9.Visible = false;
                    LinkButton10.Visible = false;
                    LinkButton11.Visible = false;
                }
                else if (Session["role"].Equals("user"))
                {
                    LinkButton2.Visible = false; //login
                    LinkButton3.Visible = false; //sign up

                    LinkButton4.Visible = true; //logout
                    LinkButton5.Visible = true; // hello user (admin)
                    LinkButton5.Text = "Hello " + Session["username"].ToString();  // hello user (admin)


                    LinkButton6.Visible = true; //admin
                    LinkButton7.Visible = false;
                    LinkButton8.Visible = false;
                    LinkButton9.Visible = false;
                    LinkButton10.Visible = false;
                    LinkButton11.Visible = false;
                }
                else if (Session["role"].Equals("admin")){


                    LinkButton2.Visible = false; //login
                    LinkButton3.Visible = false; //sign up

                    LinkButton4.Visible = true; //logout
                    LinkButton5.Visible = true; // hello user (admin)
                    LinkButton5.Text = "Hello Admin";  // hello user (admin)


                    LinkButton6.Visible = false; //admin
                    LinkButton7.Visible = true;
                    LinkButton8.Visible = true;
                    LinkButton9.Visible = true;
                    LinkButton10.Visible = true;
                    LinkButton11.Visible = true;
                }
            }
            catch (Exception ex) { Response.Write("<script> alert('" + ex.Message + "')</script>"); }
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminAuthorManagement.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPublisherManagement.aspx");

        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminbookinventory.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminBookIssuing.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminmemebermanagement.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewbooks.aspx"); 
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("userlogin.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("signup.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            
            Session["username"] = "";
            Session["fullname"] = "";
            Session["role"] = "";
            Session["status"] = "";

            LinkButton2.Visible = true; //login
            LinkButton3.Visible = true; //sign up

            LinkButton4.Visible = false; //logout
            LinkButton5.Visible = false; // hello user (admin)

            LinkButton6.Visible = true; //admin
            LinkButton7.Visible = false;
            LinkButton8.Visible = false;
            LinkButton9.Visible = false;
            LinkButton10.Visible = false;
            LinkButton11.Visible = false;
            Response.Redirect("homepage.aspx");

        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            if (LinkButton5.Text=="Hello "+Session["username"].ToString().Trim())
                Response.Redirect("userprofile.aspx");
        }
    }
}