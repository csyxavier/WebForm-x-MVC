using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace WebApp_WebForm
{
    public partial class EmployeePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UpdateGrid();
            }
        }
        protected void EmployeeList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string primaryKey = EmployeeList.DataKeys[e.NewEditIndex].Value.ToString();
            Response.Redirect("~/EditEmployeePage?id=" + primaryKey);
        }
        protected void EmployeeList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int primaryKey = Convert.ToInt32(EmployeeList.DataKeys[e.RowIndex].Value);
            using (var db = new DbEntities())
            {
                db.Employee.Remove(db.Employee.Where(x => x.PK == primaryKey).FirstOrDefault());
                db.SaveChanges();
            }
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new DbEntities())
                {
                    db.Employee.Add(new Employee()
                    {
                        Name = Name.Text.Trim(),
                        Age = Convert.ToInt32(Age.Text),
                        Birthday = Convert.ToDateTime(Birthday.Text).Date,
                    });
                    db.SaveChanges();
                }
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowError", $"alert('不合法格式');", true);
            }

        }
        protected void UpdateGrid()
        {
            using (var db = new DbEntities())
            {
                List<Employee> employeeList = db.Employee.ToList();
                EmployeeList.DataSource = employeeList;
                EmployeeList.DataBind();
            }
        }

    }
}