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
    public partial class reply : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			string id = Request.QueryString["id"] ;
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
            if (reader.Read())
            {
                Label3.Text = "Re:" + reader[1];
            }
            //6.資料庫關閉
            connection.Close();
		}

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(TextBox1.Text) || string.IsNullOrEmpty(TextBox2.Text) )
            {
                if (string.IsNullOrEmpty(TextBox1.Text))
                {
                    TextBox1.CssClass = "placecolor-red";
                    TextBox1.Attributes["placeholder"] = "請填入暱稱";
                    TextBox1.BorderColor = System.Drawing.Color.Red;
                }
                if (string.IsNullOrEmpty(TextBox2.Text))
                {
                    TextBox2.CssClass = "placecolor-red";
                    TextBox2.Attributes["placeholder"] = "請填入內容";
                    TextBox2.BorderColor = System.Drawing.Color.Red;

                }
            }
            else
            {
                string id = Request.QueryString["id"];
                //1.連線資料庫
                SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["0406homework2ConnectionString2"].ConnectionString);

                //2.sql語法，VALUES先使用@參數來取代直接給值，以防SQL Injection 程式碼
                string sql = "INSERT INTO Reply(Reply_name,Reply_description,Article_id) VALUES(@Reply_name,@Reply_description,@Article_id)";

                //3.創建command物件
                SqlCommand command = new SqlCommand(sql, connection);

                //4.參數化，Parameters:為了防止SQL Injection 程式碼攻擊，所以寫入SQL時，要使用參數「@參數名稱」來代替直接給的值，而給予參數的資料型態要使用Add
                command.Parameters.AddWithValue("@Reply_name", TextBox1.Text);
                command.Parameters.AddWithValue("@Reply_description", Ans(TextBox2.Text));
                command.Parameters.AddWithValue("@Article_id", id);

                //5.資料庫連線開啟
                connection.Open();

                //6.執行sql (新增刪除修改)
                command.ExecuteNonQuery(); //無回傳值

                //7.資料庫關閉
                connection.Close();

                Response.Redirect("description.aspx?id=" + id);
            }
                
        }
        public static string Ans(string words)
        {
            words = words.Replace("\n", "<br>");
            return words;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("home.aspx");
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBox1.Text))
            {
                TextBox1.BorderColor = System.Drawing.Color.Black;
            }
            else
            {
                TextBox1.BorderColor = System.Drawing.Color.Red;
                TextBox1.CssClass = "placecolor-red";
                TextBox1.Attributes["placeholder"] = "請填入暱稱";
            }
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBox2.Text))
            {
                TextBox2.BorderColor = System.Drawing.Color.Black;
            }
            else
            {
                TextBox2.BorderColor = System.Drawing.Color.Red;
                TextBox2.CssClass = "placecolor-red";
                TextBox2.Attributes["placeholder"] = "請填入內容";
            }
        }
    }
}