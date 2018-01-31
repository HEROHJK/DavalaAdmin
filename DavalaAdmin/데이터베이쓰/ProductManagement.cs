using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavalaAdmin.데이터베이쓰
{
    class ProductManagement : BaseManagement
    {

        public ProductManagement(string info)
        {
            loginInfo = info;
            conn = new MySqlConnection(loginInfo);
        }

        public int InsertProductData(string name, int brandIndex, int categoryIndex, Decimal price)
        {
            using (conn = new MySqlConnection(loginInfo))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(string.Format("Insert Into davala.`Product`(name, brandKey, categoryKey, price) VALUES('{0}','{1}','{2}', '{3}');", name, brandIndex, categoryIndex, price), conn);

                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "Select LAST_INSERT_ID();";

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch
                {
                    return -1;
                }
            }
        }

        public int InsertProductSubData(int index, string discount)
        {
            using (conn = new MySqlConnection(loginInfo))
            {
                try
                {
                    conn.Open();
                    char dc = 'F';
                    if(discount != null && discount != "")
                    {
                        dc = 'T';
                    }
                    MySqlCommand cmd = new MySqlCommand(string.Format("Insert Into davala.`ProductInfo`(productKey, discount, discountPercentage) VALUES('{0}','{1}','{2}');", index, dc, Convert.ToInt32(discount)), conn);

                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "Select LAST_INSERT_ID();";

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch
                {
                    return -1;
                }
            }
        }

        public bool InsertProductImages(string[] urls, int productKey)
        {
            StringBuilder cmdTxt = new StringBuilder();

            cmdTxt.Append("Insert Into davala.`ProductImage`(productKey, url) VALUES");

            foreach(string url in urls)
            {
                cmdTxt.Append(string.Format("('{0}','{1}'),", productKey, url));
            }
            cmdTxt.Remove(cmdTxt.Length-1,1);//마지막 콤마 제거
            cmdTxt.Append(";");

            using (conn = new MySqlConnection(loginInfo))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(cmdTxt.ToString(), conn);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public void DeleteProductData(int index)
        {
            using (conn = new MySqlConnection(loginInfo))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(string.Format("Delete From davala.`Product` Where `index` = {0}",index), conn);
                    cmd.ExecuteNonQuery();
                }
                catch
                {

                }
            }
        }

        public void DeleteProductSubData(int index)
        {
            using (conn = new MySqlConnection(loginInfo))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(string.Format("Delete From davala.`ProductInfo` Where `index` = {0}", index), conn);
                    cmd.ExecuteNonQuery();
                }
                catch
                {

                }
            }
        }
    }
}
