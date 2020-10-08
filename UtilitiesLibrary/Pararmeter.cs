using System.Collections;
using System.Data;
namespace UtilitiesLibrary
{

    namespace Data
    {
        /// <summary>
        /// Summary description for Pararmeter.
        /// </summary>
        public class Parameter
        {
            ArrayList sum;
            ArrayList Sum;
            int Count = 0;
            int OutPut = 0;
            bool InputOutput;

            public Parameter()
            {
                //
                // TODO: Add constructor logic here
                //
            }

            public void AddParameter(SqlDbType type, int size, string values)
            {
                if (Sum == null)
                    Sum = new ArrayList();
                Sum.Add(type);
                Sum.Add(size);
                Sum.Add(values);

            }


            public void AddParameter(string NameOfParameter, SqlDbType type, int size, ParameterDirection Direction)
            {
                if (sum == null)
                    sum = new ArrayList();
                if (Direction == ParameterDirection.InputOutput)
                    InputOutput = true;//under construction
                sum.Add(NameOfParameter);
                sum.Add(type);
                sum.Add(size);
                sum.Add(Direction);
                OutPut++;
            }

            public void AddParameter(string NameOfParameter, SqlDbType type, int size, string values)
            {
                if (sum == null)
                    sum = new ArrayList();
                sum.Add(NameOfParameter);
                sum.Add(type);
                sum.Add(size);
                sum.Add(values);
                Count++;

            }
            public ArrayList Parameters
            {
                get
                {
                    return sum;
                }
            }
            public ArrayList parameters
            {
                get
                {
                    return Sum;
                }
            }

            public int Total
            {
                get
                {
                    return Count;
                }
            }

            public int Output
            {
                get
                {
                    return OutPut;
                }
            }



        } 
    }
}

