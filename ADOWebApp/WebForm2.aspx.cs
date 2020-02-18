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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (var con = new SqlConnection(constr))
            {
                var command = new SqlCommand("spAddEmployee", con);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Name", txtEmployeeName.Text);
                command.Parameters.AddWithValue("@Gender", ddlGender.SelectedValue);
                command.Parameters.AddWithValue("@Salary", txtSalary.Text);

                var outputParameter = new SqlParameter();
                outputParameter.ParameterName = "@EmployeeId";
                outputParameter.SqlDbType = System.Data.SqlDbType.Int;
                outputParameter.Direction = System.Data.ParameterDirection.Output;
                command.Parameters.Add(outputParameter);

                con.Open();
                command.ExecuteNonQuery();
                string empId = outputParameter.Value.ToString();
                lblMessage.Text = "Employee Id: " + empId;
            }
        }
    }
}