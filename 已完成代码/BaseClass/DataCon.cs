using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace SMS.BaseClass
{
    class DataCon
    {
        #region  �������ݿ�����
        /// <summary>
        /// �������ݿ�����.
        /// </summary>
        /// <returns>����SqlConnection����</returns>
        public SqlConnection getcon()
        {
            string M_str_sqlcon = "Data Source=XIAOKE;Database=db_SMS;Integrated Security=SSPI;";
            SqlConnection myCon = new SqlConnection(M_str_sqlcon);
            return myCon;
        }
        #endregion

        #region  ִ��SqlCommand����
        /// <summary>
        /// ִ��SqlCommand
        /// </summary>
        /// <param name="M_str_sqlstr">SQL���</param>
        public void getcom(string M_str_sqlstr)
        {
            SqlConnection sqlcon = this.getcon();
            sqlcon.Open();
            SqlCommand sqlcom = new SqlCommand(M_str_sqlstr, sqlcon);
            sqlcom.ExecuteNonQuery();
            sqlcom.Dispose();
            sqlcon.Close();
            sqlcon.Dispose();
        }
        #endregion

        #region  ����DataSet����
        /// <summary>
        /// ����һ��DataSet����
        /// </summary>
        /// <param name="M_str_sqlstr">SQL���</param>
        /// <param name="M_str_table">����</param>
        /// <returns>����DataSet����</returns>
        public DataSet getds(string M_str_sqlstr, string M_str_table)
        {
            SqlConnection sqlcon = this.getcon();
            SqlDataAdapter sqlda = new SqlDataAdapter(M_str_sqlstr, sqlcon);
            DataSet myds = new DataSet();
            sqlda.Fill(myds, M_str_table);
            return myds;
        }
        #endregion

        #region  ����SqlDataReader����
        /// <summary>
        /// ����һ��SqlDataReader����
        /// </summary>
        /// <param name="M_str_sqlstr">SQL���</param>
        /// <returns>����SqlDataReader����</returns>
        public SqlDataReader getread(string M_str_sqlstr)
        {
            SqlConnection sqlcon = this.getcon();
            SqlCommand sqlcom = new SqlCommand(M_str_sqlstr, sqlcon);
            sqlcon.Open();
            SqlDataReader sqlread = sqlcom.ExecuteReader(CommandBehavior.CloseConnection);
            return sqlread;
        }
        #endregion
    }
}
