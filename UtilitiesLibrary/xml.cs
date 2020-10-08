using System.Data;
using System.Data.SqlClient;
using UtilitiesLibrary.Data;
namespace UtilitiesLibrary
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	namespace XML
	{
		public class xml
		{
			
			public xml()
			{


			}
			public DataSet DisplayXml(string XmlName,string SchemaName)
			{
				DataSet ds=new DataSet();
				if(SchemaName==null)
					ds.ReadXml(XmlName);
				else if(XmlName==null)
					ds.ReadXmlSchema(SchemaName);
				return ds;
				//dataSet12.Relations[0].Nested=true;
			}
			public void WriteXml(DataBaseEngine DataBase,string TableName,string XmlName,string SchemaName)
			{
                if (DataBase.TryConnectiongToServer())
                {
                    DataSet ds = new DataSet();
                    SqlConnection con = new SqlConnection(DataBase.ConnectionString);
                    SqlCommand cmd = new SqlCommand("select " + TableName + ".* from " + TableName, con);
                    SqlDataAdapter dep = new SqlDataAdapter(cmd);
                    dep.Fill(ds);
                    if (SchemaName == null)
                        ds.WriteXml(XmlName);
                    else if (XmlName == null)
                        ds.WriteXmlSchema(SchemaName);
                    else
                    {
                        ds.WriteXml(XmlName);
                        ds.WriteXmlSchema(SchemaName);
                    }
                }
			
				

			}


		}

	}
}
