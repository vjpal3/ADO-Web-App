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
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string cmdText = "Insert into People values('Leila', 'Jones')";
                var cmd = new SqlCommand(cmdText, con);
                con.Open();
                int totalRows = cmd.ExecuteNonQuery();
                Response.Write("Total Rows inserted: " + totalRows + "<br />" );

                cmdText = "select * from tblEmployee";
                cmd = new SqlCommand(cmdText, con);
                using (var reader = cmd.ExecuteReader())
                {
                    GridView1.DataSource = reader;
                    GridView1.DataBind();
                }


                cmdText = "Select count(Id) from People";
                cmd = new SqlCommand(cmdText, con);

                ////use ExecuteScalar() when retrieving single value, more effiecient than ExecuteReader
                var scalarReader = cmd.ExecuteScalar();
                totalRows = (int)scalarReader;
                Response.Write("Total Rows in People table: " + totalRows + "<br />");
                //cmd.Dispose();
                

                cmdText = "Update People set FirstName='Maggie' where LastName='Coote'";
                cmd = new SqlCommand(cmdText, con);
                totalRows = cmd.ExecuteNonQuery();
                Response.Write("Total Rows updated: " + totalRows + "<br />");

                cmdText = "Delete from People where Id=17";
                cmd = new SqlCommand(cmdText, con);
                
                //cmd.Connection = con;
                //con.Open();
                totalRows = cmd.ExecuteNonQuery();
                Response.Write("Total Rows deleted: " + totalRows);

            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                string cmdText = "Select * from People  where Lastname like @lname";
                var cmd = new SqlCommand(cmdText, con);

                cmd.Parameters.AddWithValue("@lname", TextBox1.Text + "%");
                con.Open();
                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
            }
        }
    }
}