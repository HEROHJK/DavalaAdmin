using DavalaAdmin.데이터포맷들;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace DavalaAdmin.데이터베이쓰
{
    class CategoryManagement : BaseManagement
    {
        public CategoryManagement(string info)
        {
            loginInfo = info;
            conn = new MySqlConnection(loginInfo);
        }

        public List<CategoryFormat> GetCategories()
        {
            conn.Open();
            List<CategoryFormat> list = GetCategory(0);
            conn.Close();

            return list;
        }

        private List<CategoryFormat> GetCategory(int parentIndex)
        {
            /*
            **재귀 함수
            * 1.DB에서 부모인덱스의 값을 가진 데이터들을 데이터포맷에 올린다.
            * 2.데이터포맷의 숫자만큼 반복한다
            *   1.부모인덱스를 I튜플의 인덱스로 주는 재귀 함수를 실행한다.
            **재귀함수 끝
            */
            List<CategoryFormat> tmpList = new List<CategoryFormat>();

            //데이터 포맷에 해당 부모인덱스 값을 가진 데이터들을 올린다.
            MySqlCommand cmd = new MySqlCommand(string.Format("SELECT * FROM davala.ProductCategory WHERE parentIndex={0};", parentIndex), conn);

            using (MySqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    tmpList.Add(new CategoryFormat(Convert.ToInt32(rdr[0]), rdr[1].ToString(), Convert.ToInt32(rdr[2])));
                }
            }

            //데이터 포맷의 숫자만큼 반복한다
            for (int i = 0; i < tmpList.Count; i++)
            {
                //부모인덱스를 자신의 인덱스로 주는 재귀 함수를 실행한다.
                tmpList[i].childList = GetCategory(tmpList[i].index);
            }

            return tmpList;
        }

        public bool AddCategory(int parentIndex, string categoryName)
        {
            bool result;
            
            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(string.Format("Insert Into davala.`ProductCategory` (name,parentIndex) VALUES('{0}', {1})", categoryName, parentIndex), conn);

                cmd.ExecuteNonQuery();

                conn.Close();

                result = true;
            }
            catch
            {
                result = false;
            }

            return result;
        }

        public bool RemoveCategory(int index)
        {
            bool result;

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(string.Format("Delete From davala.`ProductCategory` where `index` = {0};", index), conn);

                cmd.ExecuteNonQuery();

                conn.Close();

                result = true;
            }
            catch
            {
                result = false;
            }

            return result;
        }
    }
}