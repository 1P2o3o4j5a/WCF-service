using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
	SqlConnection con = new SqlConnection(@"Server=LAPTOP-T65PDTRN\SQLEXPRESS;Database=Project1;Integrated Security=True");
	public string Get_AccBal(int accno, int uid)
	{
		string s = "Select Balance_Amt from AccTab where Acc_No=" + accno + " and User_Id=" + uid + "";
		SqlCommand cmd = new SqlCommand(s, con);
		con.Open();
		string bal = cmd.ExecuteScalar().ToString();
		con.Close();
		return bal;

	}
	public int Update_AccTab(int rembal, int accno, int uid)
	{

		string s = "Update AccTab set Balance_Amt=" + rembal + " where Acc_No=" + accno + " and User_Id=" + uid + "";
		SqlCommand cmd = new SqlCommand(s, con);
		con.Open();
		int i = cmd.ExecuteNonQuery();
		con.Close();
		return i;
	}
	public string GetData(int value)
	{
		return string.Format("You entered: {0}", value);
	}

	public CompositeType GetDataUsingDataContract(CompositeType composite)
	{
		if (composite == null)
		{
			throw new ArgumentNullException("composite");
		}
		if (composite.BoolValue)
		{
			composite.StringValue += "Suffix";
		}
		return composite;
	}
}
