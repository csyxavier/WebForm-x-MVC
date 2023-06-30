using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp_WebForm
{
    public partial class EditEmployeePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                    {
                        int id = Convert.ToInt32(Request.QueryString["id"]);
                        using (DbEntities db = new DbEntities())
                        {
                            Employee targetEmployee = db.Employee.Where(x => x.PK == id).FirstOrDefault();
                            Name.Text = targetEmployee.Name;
                            Age.Text = targetEmployee.Age.ToString();
                            Birthday.Text = targetEmployee.Birthday.ToString("yyyy-MM-dd");
                        }
                    }
                    else
                    {
                        Response.Redirect("~/EmployeePage");
                    }
                }
                catch
                {
                    Response.Redirect("~/EmployeePage");
                }
            }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                using (DbEntities db = new DbEntities())
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    Employee targetEmployee = db.Employee.Where(x => x.PK == id).FirstOrDefault();
                    targetEmployee.Name = Name.Text.Trim();
                    targetEmployee.Age = Convert.ToInt32(Age.Text);
                    targetEmployee.Birthday = Convert.ToDateTime(Birthday.Text);
                    db.SaveChanges();
                }
                Response.Redirect("~/EmployeePage");
            }
            catch
            {
                Response.Redirect("~/EmployeePage");
            }

        }
    }
}