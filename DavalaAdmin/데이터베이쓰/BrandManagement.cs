using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavalaAdmin.데이터베이쓰
{
    class BrandManagement : BaseManagement
    {

        public BrandManagement(string info)
        {
            loginInfo = info;
        }


        public string[] LoadBrand()
        {
            string[] brands;

            using (conn = new MySqlConnection(loginInfo))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("Select Count(*) From davala.`Brand`;", conn);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    brands = new string[count];

                    cmd.CommandText = "Select * From davala.`Brand`;";

                    MySqlDataReader rdr = cmd.ExecuteReader();

                    int current = 0;

                    while (rdr.Read()) brands[current++] = string.Format("{0:000}|{1:0}",Convert.ToInt32(rdr[0]), rdr[1].ToString()) ;
                }
                catch
                {
                    brands = new string[0];
                }
            }
            return brands;
        }

        public bool AddBrand(string name)
        {
            using (conn = new MySqlConnection(loginInfo))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(string.Format("Insert Into davala.`Brand`(brandName) VALUES('{0}');",name), conn);

                    cmd.ExecuteNonQuery();

                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool RemoveBrand(int index)
        {
            using (conn = new MySqlConnection(loginInfo))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(string.Format("Delete From davala.`Brand` where `index` = {0};", index), conn);

                    cmd.ExecuteNonQuery();

                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}