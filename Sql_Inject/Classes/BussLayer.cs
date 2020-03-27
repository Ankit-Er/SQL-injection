using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Sql_Inject.Classes
{
    public class BussLayer
    {
        private DBLayer db;

        public BussLayer() {
            db = new DBLayer();
        }

        public String getRecords(String employeeId, String Pswd)
        {
            //String q = "select * from temp where empid = @EmpId and Passwd= @Pswd";
            //DataTable dt = db.executeQuery(q, employeeId,Pswd);

            DataTable dt = db.executeQuery(employeeId,Pswd);

            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0][1].ToString();
            }
            else
            {
                return null;
            }
        }
    }
}