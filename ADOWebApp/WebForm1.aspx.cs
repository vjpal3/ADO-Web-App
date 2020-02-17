using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADOWebApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            //using (SqlConnection con = new SqlConnection(constr))
            //{
            //    string cmdText = "Select from People where Lastname like @lname";
            //    var cmd = new SqlCommand(cmdText, con);
            //    cmd.Parameters.AddWithValue(@lname, )
            //    con.Open();


                //SqlCommand cmd = new SqlCommand("select * from tblEmployee", con);
                //con.Open();
                //GridView1.DataSource = cmd.ExecuteReader();
                //GridView1.DataBind();

                //var cmd = new SqlCommand();
                //cmd.CommandText = "Select count(Id) from People";
                //cmd.Connection = con;
                //con.Open();

                ////use ExecuteScalar() when retrieving single value, more effiecient than ExecuteReader
                //int totalRows = (int)cmd.ExecuteScalar();
                //Response.Write("Total Rows in People table: " + totalRows);

                //var cmd = new SqlCommand();
                //cmd.CommandText = "Insert into People values('Leila', 'Jones')";
                //cmd.Connection = con;
                //con.Open();
                //int totalRows = cmd.ExecuteNonQuery();
                //Response.Write("Total Rows inserted: " + totalRows);

                //cmd.CommandText = "Update People set FirstName='Maggie' where LastName='Coote'";
                //totalRows = cmd.ExecuteNonQuery();
                //Response.Write("Total Rows updated: " + totalRows);

                //var cmd = new SqlCommand();
                //cmd.CommandText = "Delete from People where Id=1003";
                //cmd.Connection = con;
                //con.Open();
                //int totalRows = cmd.ExecuteNonQuery();
                //Response.Write("Total Rows deleted: " + totalRows);


            //}

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                string cmdText = "Select * from People where Lastname like @lname";
                var cmd = new SqlCommand(cmdText, con);

                cmd.Parameters.AddWithValue("@lname", TextBox1.Text + "%");
                con.Open();
                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
            }
        }
    }
}