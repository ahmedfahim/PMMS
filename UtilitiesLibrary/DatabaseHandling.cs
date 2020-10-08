using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace UtilitiesLibrary
{
    namespace Data
    {
        /// <summary>
        /// Summary description for Class1.
        /// </summary>
        public class DatabaseHandling
        {
            DataBaseEngine DataBaseInformation;
            SqlConnection con;
            SqlCommand cmd;
            SqlDataAdapter adp;
            DataSet ds;
            public DatabaseHandling(DataBaseEngine DataBaseInformation)
            {
                this.DataBaseInformation = DataBaseInformation;
            }

            public SqlException ExecuteCommand(string Command)
            {

                try
                {
                    InitializeComponent(Command, 0);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    return null;
                }
                catch (SqlException SqlError)
                {
                    return SqlError;
                }
                finally
                {
                    con.Close();
                }



            }
            public DataSet select(string selectStatement, SqlDbType[] Types, int[] size, string[] Values)
            {
                InitializeComponent(selectStatement, 1);
                AddParameter(CountChar(selectStatement), selectStatement, cmd, Types, size, Values);
                adp.Fill(ds);
                return ds;

            }
            public DataSet select(string selectStatement, Parameter Add)
            {

                InitializeComponent(selectStatement, 1);
                int num = CountChar(selectStatement);
                if (num != 0)
                    AddParameterClass(num, selectStatement, cmd, Add);
                adp.Fill(ds);
                return ds;
            }
            public DataSet select(string StoredProcedureName, Parameter Add, out ArrayList Output)
            {
                Output = new ArrayList();
                InitializeComponent(StoredProcedureName, 3);
                int Total = Add.Total;
                int Out = Add.Output;
                if (Total != 0)
                    for (int i = 0; i < Add.Total; i++)
                    {
                        cmd.Parameters.Add((string)Add.Parameters[Total * 4 - 4], (SqlDbType)Add.Parameters[Total * 4 - 3], (int)Add.Parameters[Total * 4 - 2]);
                        cmd.Parameters[(string)Add.Parameters[Total * 4 - 4]].Value = (string)Add.Parameters[Total * 4 - 1];
                        Total--;
                    }
                if (Out != 0)
                    for (int i = 0; i < Add.Output; i++)
                    {
                        cmd.Parameters.Add(new SqlParameter(
                            (string)Add.Parameters[(Add.Total + Out) * 4 - 4],
                            (SqlDbType)Add.Parameters[(Add.Total + Out) * 4 - 3],
                            (int)Add.Parameters[(Add.Total + Out) * 4 - 2])).Direction =
                            (ParameterDirection)Add.Parameters[(Add.Total + Out) * 4 - 1];
                        Out--;
                    }
                adp.Fill(ds);
                Out = Add.Output;
                for (int i = 0; i < Add.Output; i++)
                {
                    Output.Add(cmd.Parameters[(string)Add.Parameters[(Add.Total + Out) * 4 - 4]].Value);
                    Out--;
                }

                return ds;
            }

            public ArrayList select(string StoredProcedureName, ref Parameter Add)
            {
                ArrayList Output = new ArrayList();
                InitializeComponent(StoredProcedureName, 2);
                int Total = Add.Total;
                int Out = Add.Output;
                if (Total != 0)
                    for (int i = 0; i < Add.Total; i++)
                    {
                        cmd.Parameters.Add((string)Add.Parameters[Total * 4 - 4], (SqlDbType)Add.Parameters[Total * 4 - 3], (int)Add.Parameters[Total * 4 - 2]);
                        //						if((string)Add.Parameters[Total*4-1]==string.Empty)
                        //						cmd.Parameters[(string)Add.Parameters[Total*4-4]].Value=null;
                        //						else
                        cmd.Parameters[(string)Add.Parameters[Total * 4 - 4]].Value = (string)Add.Parameters[Total * 4 - 1];
                        Total--;
                    }
                if (Out != 0)
                    for (int i = 0; i < Add.Output; i++)
                    {
                        cmd.Parameters.Add(new SqlParameter(
                            (string)Add.Parameters[(Add.Total + Out) * 4 - 4],
                            (SqlDbType)Add.Parameters[(Add.Total + Out) * 4 - 3],
                            (int)Add.Parameters[(Add.Total + Out) * 4 - 2])).Direction =
                            (ParameterDirection)Add.Parameters[(Add.Total + Out) * 4 - 1];
                        Out--;
                    }
                con.Open();
                Output.Add(cmd.ExecuteScalar());
                if (Output[0] == null)
                    Output = new ArrayList();
                Out = Add.Output;
                for (int i = 0; i < Add.Output; i++)
                {
                    Output.Add(cmd.Parameters[(string)Add.Parameters[(Add.Total + Out) * 4 - 4]].Value);
                    Out--;
                }
                con.Close();
                Add = new Parameter();
                return Output;
            }
            public bool update(string StoredProcedureName, ref Parameter Add)
            {
                bool state = false;
                InitializeComponent(StoredProcedureName, 2);
                int Total = Add.Total;
                for (int i = 0; i < Add.Total; i++)
                {
                    cmd.Parameters.Add((string)Add.Parameters[Total * 4 - 4], (SqlDbType)Add.Parameters[Total * 4 - 3], (int)Add.Parameters[Total * 4 - 2]);
                    cmd.Parameters[(string)Add.Parameters[Total * 4 - 4]].Value = (string)Add.Parameters[Total * 4 - 1];
                    Total--;
                }
                con.Open();
                if (cmd.ExecuteNonQuery() != 0)
                    state = true;
                con.Close();
                Add = new Parameter();
                return state;
            }
            public bool update(string updateStatement, SqlDbType[] Types, int[] size, string[] Values)
            {
                bool state = false;
                InitializeComponent(updateStatement, 0);
                AddParameterupdate(CountChar(updateStatement), updateStatement, cmd, Types, size, Values);
                con.Open();
                if (cmd.ExecuteNonQuery() != 0)
                    state = true;
                con.Close();
                return state;
            }
            public bool update(SqlConnection Connection, SqlCommand Command, string[] ParametersName, string[] values)
            {
                bool state = false;
                for (int i = 0; i < Command.Parameters.Count; i++)
                    Command.Parameters[ParametersName[i]].Value = values[i];
                Connection.Open();
                if (Command.ExecuteNonQuery() != 0)
                    state = true;
                Connection.Close();
                return state;
            }
            public bool insert(string StoredProcedureName, ref Parameter Add)
            {
                bool state = false;
                InitializeComponent(StoredProcedureName, 2);
                int Total = Add.Total;
                for (int i = 0; i < Add.Total; i++)
                {
                    cmd.Parameters.Add((string)Add.Parameters[Total * 4 - 4], (SqlDbType)Add.Parameters[Total * 4 - 3], (int)Add.Parameters[Total * 4 - 2]);
                    cmd.Parameters[(string)Add.Parameters[Total * 4 - 4]].Value = (string)Add.Parameters[Total * 4 - 1];
                    Total--;
                }
                con.Open();
                if (cmd.ExecuteNonQuery() != 0)
                    state = true;
                con.Close();
                Add = new Parameter();
                return state;
            }

            public bool insert(string insertStatement, SqlDbType[] Types, int[] size, string[] Values)
            {
                bool state = false;
                InitializeComponent(insertStatement, 0);
                addParameter(CountChar(insertStatement), insertStatement, cmd, Types, size, Values);
                con.Open();
                if (cmd.ExecuteNonQuery() != 0)
                    state = true;
                con.Close();
                return state;
            }
            public bool insert(string insertStatement, Parameter Add)
            {
                bool state = false;
                InitializeComponent(insertStatement, 0);
                int num = CountChar(insertStatement);
                if (num != 0 || Add != null)
                    addParameterClass(num, insertStatement, cmd, Add);
                con.Open();
                if (cmd.ExecuteNonQuery() != 0)
                    state = true;
                con.Close();
                return state;
            }
            public bool insert(SqlConnection Connection, SqlCommand Command, string[] ParametersName, string[] values)
            {
                bool state = false;
                for (int i = 0; i < Command.Parameters.Count; i++)
                    Command.Parameters[ParametersName[i]].Value = values[i];
                Connection.Open();
                if (Command.ExecuteNonQuery() != 0)
                    state = true;
                Connection.Close();
                return state;


            }
            public bool delete(string deleteStatement, SqlDbType[] Types, int[] size, string[] Values)
            {
                bool state = false;
                InitializeComponent(deleteStatement, 0);
                AddParameter(CountChar(deleteStatement), deleteStatement, cmd, Types, size, Values);
                con.Open();
                if (cmd.ExecuteNonQuery() != 0)
                    state = true;
                con.Close();
                return state;
            }
            public bool delete(string StoredProcedureName, ref Parameter Add)
            {
                bool state = false;
                InitializeComponent(StoredProcedureName, 2);
                int Total = Add.Total;
                for (int i = 0; i < Add.Total; i++)
                {
                    cmd.Parameters.Add((string)Add.Parameters[Total * 4 - 4], (SqlDbType)Add.Parameters[Total * 4 - 3], (int)Add.Parameters[Total * 4 - 2]);
                    cmd.Parameters[(string)Add.Parameters[Total * 4 - 4]].Value = (string)Add.Parameters[Total * 4 - 1];
                    Total--;
                }
                con.Open();
                if (cmd.ExecuteNonQuery() != 0)
                    state = true;
                con.Close();
                Add = new Parameter();
                return state;
            }
            public bool delete(string deleteStatement, Parameter Add)
            {
                bool state = false;
                InitializeComponent(deleteStatement, 0);
                int num = CountChar(deleteStatement);
                if (num != 0)
                    AddParameterClass(num, deleteStatement, cmd, Add);
                con.Open();
                if (cmd.ExecuteNonQuery() != 0)
                    state = true;
                con.Close();
                return state;
            }

            public bool delete(SqlConnection Connection, SqlCommand Command, string[] ParametersName, string[] values)
            {
                bool state = false;
                for (int i = 0; i < Command.Parameters.Count; i++)
                    Command.Parameters[ParametersName[i]].Value = values[i];
                Connection.Open();
                if (Command.ExecuteNonQuery() != 0)
                    state = true;
                Connection.Close();
                return state;


            }
            private void AddParameterClass(int NumerOfParmeter, string statement, SqlCommand cmd, Parameter p)
            {
                string temp = "";
                for (int x = statement.Length - 1; x != 25 & NumerOfParmeter != 0; x--)
                {
                    if (statement[x] == ')' || statement[x] != '@')
                        temp = statement[x - 1].ToString() + temp;
                    else
                    {

                        for (int j = x; j != 25 & NumerOfParmeter != 0; j--)
                        {
                            if (statement[j] == ')')
                            {
                                x = j + 1; j = 26;
                            }
                        }
                        cmd.Parameters.Add(temp, (SqlDbType)p.parameters[NumerOfParmeter * 3 - 3], (int)p.parameters[NumerOfParmeter * 3 - 2], temp.Trim('@'));
                        cmd.Parameters[temp].Value = (string)p.parameters[NumerOfParmeter * 3 - 1];
                        NumerOfParmeter--; temp = "";
                    }
                }
            }
            private void AddParameter(int NumerOfParmeter, string statement, SqlCommand cmd, SqlDbType[] Types, int[] size, string[] Values)
            {
                string temp = "";
                for (int x = statement.Length - 1; x != 25 & NumerOfParmeter != 0; x--)
                {
                    if (statement[x] == ')' || statement[x] != '@')
                        temp = statement[x - 1].ToString() + temp;
                    else
                    {

                        for (int j = x; j != 25 & NumerOfParmeter != 0; j--)
                        {
                            if (statement[j] == ')')
                            {
                                x = j + 1; j = 26;
                            }
                        }
                        cmd.Parameters.Add(temp, Types[NumerOfParmeter - 1], size[NumerOfParmeter - 1], temp.Trim('@'));
                        cmd.Parameters[temp].Value = Values[NumerOfParmeter - 1];
                        NumerOfParmeter--; temp = "";
                    }
                }
            }

            private void addParameterClass(int NumerOfParmeter, string statement, SqlCommand cmd, Parameter p)
            {
                string temp = "";
                for (int x = statement.Length - 1; x != 15 & NumerOfParmeter != 0; x--)
                {
                    if ((statement[x] == ')' || statement[x - 1] != ',') && (statement[x - 1] != '('))
                        temp = statement[x - 1].ToString() + temp;
                    else
                    {
                        for (int j = x; j != 15 & NumerOfParmeter != 0; j--)
                        {
                            if (statement[j] == ',' || statement[j] == ')')
                            {
                                x = j + 1; j = 16;
                            }

                        }
                        cmd.Parameters.Add(temp, (SqlDbType)p.parameters[NumerOfParmeter * 3 - 3], (int)p.parameters[NumerOfParmeter * 3 - 2], null);
                        cmd.Parameters[temp].Value = (string)p.parameters[NumerOfParmeter * 3 - 1];
                        NumerOfParmeter--; temp = "";
                    }
                }
            }

            private void addParameter(int NumerOfParmeter, string statement, SqlCommand cmd, SqlDbType[] Types, int[] size, string[] Values)
            {
                string temp = "";
                for (int x = statement.Length - 1; x != 15 & NumerOfParmeter != 0; x--)
                {
                    if ((statement[x] == ')' || statement[x - 1] != ',') && (statement[x - 1] != '('))
                        temp = statement[x - 1].ToString() + temp;
                    else
                    {
                        for (int j = x; j != 15 & NumerOfParmeter != 0; j--)
                        {
                            if (statement[j] == ',' || statement[j] == ')')
                            {
                                x = j + 1; j = 16;
                            }

                        }
                        cmd.Parameters.Add(temp, Types[NumerOfParmeter - 1], size[NumerOfParmeter - 1], null);
                        cmd.Parameters[temp].Value = Values[NumerOfParmeter - 1];
                        NumerOfParmeter--; temp = "";
                    }
                }
            }
            private void AddParameterupdate(int NumerOfParmeter, string statement, SqlCommand cmd, SqlDbType[] Types, int[] size, string[] Values)
            {
                string temp = "";
                for (int x = statement.Length - 1; x != 25 & NumerOfParmeter != 0; x--)
                {
                    if (statement[x] == ')' || statement[x] != '@')
                        temp = statement[x - 1].ToString() + temp;
                    else
                    {

                        for (int j = x; j != 25 & NumerOfParmeter != 0; j--)
                        {
                            if (statement[j] == ' ' || statement[j] == ')')
                            {
                                x = j + 1; j = 26;
                            }
                        }
                        cmd.Parameters.Add(temp, Types[NumerOfParmeter - 1], size[NumerOfParmeter - 1], temp.Trim('@'));
                        cmd.Parameters[temp].Value = Values[NumerOfParmeter - 1];
                        NumerOfParmeter--; temp = "";
                    }
                }
            }
            private void InitializeComponent(string Statement, int Know)
            {
                con = new SqlConnection(DataBaseInformation.ConnectionString);
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = Statement;
                if (Know == 0 || Know == 1)
                    cmd.CommandType = CommandType.Text;
                if (Know == 2 || Know == 3)
                    cmd.CommandType = CommandType.StoredProcedure;
                if (Know == 1 || Know == 3)
                {
                    adp = new SqlDataAdapter();
                    adp.SelectCommand = cmd;
                    ds = new DataSet();
                }
            }
            private int CountChar(string name)
            {
                int count = 0;
                for (int i = 0; i != name.Length; i++)
                {
                    if (name[i] == '@')
                        count++;
                }
                return count;
            }
            public string UpdateDataSet(string InsertStatement, string UpdateStatement, string DeleteStatement, DataTable ParamterNameTypeSize, DataSet Old)
            {
                string state = "Successfully Operation";
                try
                {
                    con = new SqlConnection(DataBaseInformation.ConnectionString);

                    SqlCommand InsertCommand = new SqlCommand(InsertStatement, con);
                    SqlCommand UpdateCommand = new SqlCommand(UpdateStatement, con);
                    SqlCommand DeleteCommand = new SqlCommand(DeleteStatement, con);

                    adp = new SqlDataAdapter();

                    adp.InsertCommand = InsertCommand;
                    adp.UpdateCommand = UpdateCommand;
                    adp.DeleteCommand = DeleteCommand;

                    for (int i = 0; i < CountChar(InsertStatement); i++)
                        for (int j = 0; j < 1; j++)
                            InsertCommand.Parameters.Add("@" + ParamterNameTypeSize.Rows[i][j].ToString(), CustFromString(ParamterNameTypeSize.Rows[i][1].ToString())
                                , (int)ParamterNameTypeSize.Rows[i][2], ParamterNameTypeSize.Rows[i][j].ToString());

                    for (int i = 0; i < (CountChar(UpdateStatement) / 2); i++)
                        for (int j = 0; j < 1; j++)
                        {
                            UpdateCommand.Parameters.Add(new SqlParameter("@original_" + ParamterNameTypeSize.Rows[i][j].ToString(),
                                CustFromString(ParamterNameTypeSize.Rows[i][1].ToString()), (int)ParamterNameTypeSize.Rows[i][2], ParameterDirection.Input
                                , false, 0, 0, ParamterNameTypeSize.Rows[i][j].ToString(), DataRowVersion.Original, null));

                            UpdateCommand.Parameters.Add(new SqlParameter("@" + ParamterNameTypeSize.Rows[i][j].ToString(),
                                CustFromString(ParamterNameTypeSize.Rows[i][1].ToString()), (int)ParamterNameTypeSize.Rows[i][2], ParameterDirection.Input
                                , false, 0, 0, ParamterNameTypeSize.Rows[i][j].ToString(), DataRowVersion.Current, null));
                        }

                    for (int i = 0; i < CountChar(DeleteStatement) - 1; i++)
                        for (int j = 0; j < 1; j++)
                            DeleteCommand.Parameters.Add(new SqlParameter("@original_" + ParamterNameTypeSize.Rows[i][j].ToString(),
                                CustFromString(ParamterNameTypeSize.Rows[i][1].ToString()), (int)ParamterNameTypeSize.Rows[i][2], ParameterDirection.Input
                                , false, 0, 0, ParamterNameTypeSize.Rows[i][j].ToString(), DataRowVersion.Original, null));

                    adp.Update(Old);
                }
                catch (SqlException Sql)
                {
                    state = Sql.Number + "::" + Sql.Message;
                }
                catch (Exception exp)
                {
                    state = exp.Message;
                }
                return state;
            }
            public static SqlDbType CustFromString(string SqlDatabType)
            {
                SqlDbType Type;
                switch (SqlDatabType)
                {
                    case "bigint":
                        Type = SqlDbType.BigInt;
                        break;
                    case "binary":
                        Type = SqlDbType.Binary;
                        break;
                    case "bit":
                        Type = SqlDbType.Bit;
                        break;
                    case "char":
                        Type = SqlDbType.Char;
                        break;
                    case "datetime":
                        Type = SqlDbType.DateTime;
                        break;
                    case "decimal":
                        Type = SqlDbType.Decimal;
                        break;
                    case "numeric":
                        Type = SqlDbType.Decimal;
                        break;
                    case "float":
                        Type = SqlDbType.Float;
                        break;
                    case "image":
                        Type = SqlDbType.Image;
                        break;
                    case "int":
                        Type = SqlDbType.Int;
                        break;
                    case "money":
                        Type = SqlDbType.Money;
                        break;
                    case "nchar":
                        Type = SqlDbType.NChar;
                        break;
                    case "ntext":
                        Type = SqlDbType.NText;
                        break;
                    case "nvarchar":
                        Type = SqlDbType.NVarChar;
                        break;
                    case "real":
                        Type = SqlDbType.Real;
                        break;
                    case "smalldatetime":
                        Type = SqlDbType.SmallDateTime;
                        break;
                    case "smallint":
                        Type = SqlDbType.SmallInt;
                        break;
                    case "smallmoney":
                        Type = SqlDbType.SmallMoney;
                        break;
                    case "text":
                        Type = SqlDbType.Text;
                        break;
                    case "timestamp":
                        Type = SqlDbType.Timestamp;
                        break;
                    case "tinyint":
                        Type = SqlDbType.TinyInt;
                        break;
                    case "uniqueidentifier":
                        Type = SqlDbType.UniqueIdentifier;
                        break;
                    case "varbinary":
                        Type = SqlDbType.VarBinary;
                        break;
                    case "varchar":
                        Type = SqlDbType.VarChar;
                        break;
                    case "sql_variant":
                        Type = SqlDbType.Variant;
                        break;
                    default:
                        Type = SqlDbType.Variant;//<---when wrong value
                        break;
                }
                return Type;
            }


        } 
    }
	
}
