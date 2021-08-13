using System;
using System.Data;
using System.Data.SqlClient;

namespace Test
{

    class Program
    {


        SqlConnection sqlConnection = null;
        //IP
        string strDBIP = "127.0.0.1";
        //ID
        string strDBID = "user";
        //PW
        string strDBPW = "12345";
        //DB
        string strDBName = "dbName";
        //DB 인스턴스 생성
        public SqlConnection connSql()
        {
            sqlConnection = new SqlConnection("Server= localhost; Database= windowform Integrated Security = True;");

            //DB 오픈
            if (sqlConnection != null && sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
            return sqlConnection;
        }
    

    static void Main(string[] args)
        {

            DataSet Lds = new DataSet();
            //쿼리
            string srQuery = "SELECT * FROM TABLE;";
            //DB 연결
            SqlConnection sqlConnection = connSql();
            //조회 요청
            try
            {
                SqlDataAdapter Ldap = new SqlDataAdapter(srQuery, connSql());
                //조회결과 저장
                Ldap.Fill(Lds);
            }
            catch (Exception exe)
            {
                Console.WriteLine("조회 도중 에러 발생 : " + exe.Message);
            }

        }

    }
}
