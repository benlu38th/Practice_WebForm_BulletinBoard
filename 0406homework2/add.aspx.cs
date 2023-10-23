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
    public partial class add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if ( string.IsNullOrEmpty(TextBox1.Text) || string.IsNullOrEmpty(TextBox2.Text) || string.IsNullOrEmpty(TextBox3.Text))
            {
                if (string.IsNullOrEmpty(TextBox1.Text))
                {
                    TextBox1.CssClass = "placecolor-red";
                    TextBox1.Attributes["placeholder"] = "請填入主題";
                    TextBox1.BorderColor = System.Drawing.Color.Red;
                }
                if (string.IsNullOrEmpty(TextBox2.Text))
                {
                    TextBox2.CssClass = "placecolor-red";
                    TextBox2.Attributes["placeholder"] = "請填入暱稱";
                    TextBox2.BorderColor = System.Drawing.Color.Red;
                    
                }
                if (string.IsNullOrEmpty(TextBox3.Text))
                {
                    TextBox3.CssClass = "placecolor-red";
                    TextBox3.Attributes["placeholder"] = "請填入暱稱";
                    TextBox3.BorderColor = System.Drawing.Color.Red;

                }
            }
            else
            {
                //1.連線資料庫
                SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["0406homework2ConnectionString"].ConnectionString);

                //2.sql語法，VALUES先使用@參數來取代直接給值，以防SQL Injection 程式碼
                string sql = "INSERT INTO Article(Article_theme,Article_name,Article_description) VALUES(@Article_theme,@Article_name,@Article_description)";

                //3.創建command物件
                SqlCommand command = new SqlCommand(sql, connection);

                //4.參數化，Parameters:為了防止SQL Injection 程式碼攻擊，所以寫入SQL時，要使用參數「@參數名稱」來代替直接給的值，而給予參數的資料型態要使用Add
                command.Parameters.AddWithValue("@Article_theme", TextBox1.Text);
                command.Parameters.AddWithValue("@Article_name", TextBox2.Text);
                command.Parameters.AddWithValue("@Article_description", Ans(TextBox3.Text));

                //5.資料庫連線開啟
                connection.Open();

                //6.執行sql (新增刪除修改)
                command.ExecuteNonQuery(); //無回傳值

                //7.資料庫關閉
                connection.Close();

                Response.Redirect("home.aspx");
            }
            
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("home.aspx");
        }
        public static string Ans(string words)
        {
            words = words.Replace("\n", "<br>");
            return words;
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
                TextBox1.Attributes["placeholder"] = "請填入主題";
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
                TextBox2.Attributes["placeholder"] = "請填入暱稱";
            }
        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBox3.Text))
            {
                TextBox3.BorderColor = System.Drawing.Color.Black;
            }
            else
            {
                TextBox3.BorderColor = System.Drawing.Color.Red;
                TextBox3.CssClass = "placecolor-red";
                TextBox3.Attributes["placeholder"] = "請填入內容";
            }
        }
    }

}