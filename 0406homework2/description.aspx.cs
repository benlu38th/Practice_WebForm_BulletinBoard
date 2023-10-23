using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _0406homework2
{
    public partial class description : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
				string id = Request.QueryString["id"];

				//1.連線資料庫
				SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["0406homework2ConnectionString"].ConnectionString);

				//2.sql語法
				string sql = $"SELECT * FROM Article WHERE Article_id = {id}";

				//3.創建command物件
				SqlCommand command = new SqlCommand(sql, connection);

				//4.資料庫連線開啟
				connection.Open();

				//5.執行sql (連線的作法-需自行關閉)
				SqlDataReader reader = command.ExecuteReader();
				//DataReader速度快只能逐筆單向有上往下而且不能計算，適合用來抓單筆資料
				//for (int i = 0; i < Convert.ToInt32(id) - 1; i++)
				//{
				//	if (reader.HasRows)
				//	{
				//		reader.Read();
				//	}
				//}
				if (reader.HasRows)
				{
					reader.Read();
					Label2.Text = reader["Article_theme"].ToString();
					Label4.Text = reader["Article_name"].ToString();
					Label6.Text = reader["Initdate"].ToString();
					Label8.Text = reader["Article_description"].ToString();
				}


				//6.資料庫關閉
				connection.Close();


				//1.連線資料庫
				SqlConnection connection2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["0406homework2ConnectionString2"].ConnectionString);

				//2.sql語法
				string sql2 = $"SELECT * FROM Reply WHERE Article_id = {id}";

				//3.創建command物件
				SqlCommand command2 = new SqlCommand(sql2, connection2);

				//4.資料庫連線開啟
				connection2.Open();

				//5.執行sql (連線的作法-需自行關閉)
				SqlDataReader reader2 = command2.ExecuteReader();
				//DataReader速度快只能逐筆單向有上往下而且不能計算，適合用來抓單筆資料
				//控制器資料來源
				Repeater1.DataSource = reader2; //(拿資料)
												//控制器綁定 (真的把資料放進去)
				Repeater1.DataBind();

				//6.資料庫關閉
				connection2.Close();
			}

		}

        protected void Button4_Click(object sender, EventArgs e)
        {
			Response.Redirect("home.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
			string id = Request.QueryString["id"];
			Response.Redirect("reply.aspx?id="+id);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
			string id = Request.QueryString["id"];
			//1.連線資料庫
			SqlConnection connection2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["0406homework2ConnectionString2"].ConnectionString);

			//2.sql語法
			string sql2 = $"SELECT * FROM Reply WHERE Article_id = {id} ORDER BY Reply_id DESC";

			//3.創建command物件
			SqlCommand command2 = new SqlCommand(sql2, connection2);

			//4.資料庫連線開啟
			connection2.Open();

			//5.執行sql (連線的作法-需自行關閉)
			SqlDataReader reader2 = command2.ExecuteReader();
			//DataReader速度快只能逐筆單向有上往下而且不能計算，適合用來抓單筆資料
			//控制器資料來源
			Repeater1.DataSource = reader2; //(拿資料)
											//控制器綁定 (真的把資料放進去)
			Repeater1.DataBind();

			//6.資料庫關閉
			connection2.Close();
		}

        protected void Button3_Click(object sender, EventArgs e)
        {
			string id = Request.QueryString["id"];
			//1.連線資料庫
			SqlConnection connection2 = new SqlConnection(WebConfigurationManager.ConnectionStrings["0406homework2ConnectionString2"].ConnectionString);

			//2.sql語法
			string sql2 = $"SELECT * FROM Reply WHERE Article_id = {id} ";

			//3.創建command物件
			SqlCommand command2 = new SqlCommand(sql2, connection2);

			//4.資料庫連線開啟
			connection2.Open();

			//5.執行sql (連線的作法-需自行關閉)
			SqlDataReader reader2 = command2.ExecuteReader();
			//DataReader速度快只能逐筆單向有上往下而且不能計算，適合用來抓單筆資料
			//控制器資料來源
			Repeater1.DataSource = reader2; //(拿資料)
											//控制器綁定 (真的把資料放進去)
			Repeater1.DataBind();

			//6.資料庫關閉
			connection2.Close();
		}
    }
}