using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
namespace UtilitiesLibrary
{
	namespace Data
	{
		/// <summary>
		/// Summary description for Databasedelegate.
		/// </summary>
		public class Databasedelegate
		{
			public Databasedelegate()
			{
				SelectDelegete=new GetmethodDelegete(this.select);
				SelectsimpleDelegete=new GetmethodDelegete1(this.selectClass);
				SelectStoredDelegete=new GetmethodDelegete2(this.selectStored);
				// TODO: Add constructor logic here
			}

            public delegate DataSet GetmethodDelegete(DataBaseEngine database, string selectStatement, SqlDbType[] Types, int[] size, string[] Values);
            public delegate DataSet GetmethodDelegete1(DataBaseEngine database, string selectStatement, Parameter Add);
            public delegate DataSet GetmethodDelegete2(DataBaseEngine database, string StoredProcedureName, Parameter Add, out ArrayList Output);
			public GetmethodDelegete SelectDelegete;
			public GetmethodDelegete1 SelectsimpleDelegete;
			public GetmethodDelegete2 SelectStoredDelegete;
            public DataSet insertClass(DataBaseEngine database, string insertStatement, Parameter Add, DataSet Old)
            {
                if (database.TryConnectiongToServer())
                {
                    DataSet ds = new DataSet(); SqlDataAdapter dp;
                    SqlConnection con = new SqlConnection(database.ConnectionString);
                    SqlCommand cmd = new SqlCommand(insertStatement, con);
                    ds = addParameterClass(CountChar(insertStatement), insertStatement, cmd, Add, Old);
                    dp = new SqlDataAdapter();
                    dp.InsertCommand = cmd;
                    dp.Update(ds.Tables[0]);
                    return ds;
                }
                else
                    return null;
            }

            private DataSet select(DataBaseEngine database, string selectStatement, SqlDbType[] Types, int[] size, string[] Values)
			{
                if (database.TryConnectiongToServer())
                {
                    DataSet ds = new DataSet();
                    SqlConnection con = new SqlConnection(database.ConnectionString);
                    SqlCommand cmd = new SqlCommand(selectStatement, con);
                    AddParameter(CountChar(selectStatement), selectStatement, cmd, Types, size, Values);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    adp.Fill(ds);
                    return ds;
                }
                else
                    return null;

			}
            private DataSet selectClass(DataBaseEngine database, string selectStatement, Parameter Add)
			{
                if (database.TryConnectiongToServer())
                {
                    DataSet ds = new DataSet();
                    SqlConnection con = new SqlConnection(database.ConnectionString);
                    SqlCommand cmd = new SqlCommand(selectStatement, con);
                    int num = CountChar(selectStatement);
                    if (num != 0)
                        AddParameterClass(num, selectStatement, cmd, Add);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    adp.Fill(ds);
                    return ds;
                }
                else
                    return null;

			}
            private DataSet selectStored(DataBaseEngine database, string StoredProcedureName, Parameter Add, out ArrayList Output)
			{
                if (database.TryConnectiongToServer())
                {
                    Output = new ArrayList();
                    SqlConnection con = new SqlConnection();
                    SqlCommand cmd = new SqlCommand();
                    SqlDataAdapter adp = new SqlDataAdapter();
                    DataSet ds = new DataSet();
                    con.ConnectionString = database.ConnectionString;
                    cmd.Connection = con;
                    cmd.CommandText = StoredProcedureName;
                    cmd.CommandType = CommandType.StoredProcedure;
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
                    adp.SelectCommand = cmd;
                    adp.Fill(ds);
                    Out = Add.Output;
                    for (int i = 0; i < Add.Output; i++)
                    {
                        Output.Add(cmd.Parameters[(string)Add.Parameters[(Add.Total + Out) * 4 - 4]].Value);
                        Out--;
                    }
                    return ds;
                }
                else
                {
                    Output = null;
                    return null;
                }
			}
			private DataSet addParameterClass(int NumerOfParmeter,string statement,SqlCommand cmd,Parameter p,DataSet too)
			{
				string temp="";
				DataRow nwRow=too.Tables[0].NewRow();
				for(int x=statement.Length-1;x!=15&NumerOfParmeter!=0;x--)
				{
					if((statement[x]==')'||statement[x-1]!=',')&&(statement[x-1]!='('))
						temp=statement[x-1].ToString()+temp;
					else
					{	
						for(int j=x;j!=15&NumerOfParmeter!=0;j--)
						{
							if(statement[j]==','||statement[j]==')')
							{
								x=j+1;j=16;
							}
						
						}
						cmd.Parameters.Add(temp,(SqlDbType)p.Parameters[NumerOfParmeter*3-3],(int)p.Parameters[NumerOfParmeter*3-2],null);
						cmd.Parameters[temp].Value=(string)p.Parameters[NumerOfParmeter*3-1];
						nwRow[temp.Trim('@')]=(string)p.Parameters[NumerOfParmeter*3-1];
						NumerOfParmeter--;temp="";
					}
				}
				too.Tables[0].Rows.Add(nwRow);
				return too;
			}
			private void AddParameter(int NumerOfParmeter,string statement,SqlCommand cmd,SqlDbType []Types,int []size,string []Values)
			{
				string temp="";
				for(int x=statement.Length-1;x!=25&NumerOfParmeter!=0;x--)
				{
					if(statement[x]==')'||statement[x]!='@')
						temp=statement[x-1].ToString()+temp;
					else
					{	
					
						for(int j=x;j!=25&NumerOfParmeter!=0;j--)
						{
							if(statement[j]==')')
							{
								x=j+1;j=26;
							}
						}
						cmd.Parameters.Add(temp,Types[NumerOfParmeter-1],size[NumerOfParmeter-1],temp.Trim('@'));
						cmd.Parameters[temp].Value=Values[NumerOfParmeter-1];
						NumerOfParmeter--;temp="";
					}
				}
			}
			private void AddParameterClass(int NumerOfParmeter,string statement,SqlCommand cmd,Parameter p)
			{
				string temp="";
				for(int x=statement.Length-1;x!=25&NumerOfParmeter!=0;x--)
				{
					if(statement[x]==')'||statement[x]!='@')
						temp=statement[x-1].ToString()+temp;
					else
					{	
					
						for(int j=x;j!=25&NumerOfParmeter!=0;j--)
						{
							if(statement[j]==')')
							{
								x=j+1;j=26;
							}
						}
						cmd.Parameters.Add(temp,(SqlDbType)p.Parameters[NumerOfParmeter*3-3],(int)p.Parameters[NumerOfParmeter*3-2],temp.Trim('@'));
						cmd.Parameters[temp].Value=(string)p.Parameters[NumerOfParmeter*3-1];int xyz=(int)p.Parameters[NumerOfParmeter*3-2];
						NumerOfParmeter--;temp="";
					}
				}
			}
			private int CountChar(string name)
			{	
				int count=0;
				for(int i=0;i!=name.Length;i++)
				{
					if(name[i]=='@')
						count++;
				}
				return count;
			}

			
		



		}
	}
}