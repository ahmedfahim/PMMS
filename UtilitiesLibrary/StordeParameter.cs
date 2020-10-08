using System;
using System.Collections;
using System.Text;
using System.Data.SqlTypes;
using System.Data;

namespace UtilitiesLibrary
{
    namespace Data
    {
        public class StordeParameters
        {
            #region Private Members
            private bool HandleNullvalues;
            private Hashtable parameters;
            #endregion

            #region Private Methodes
            private object HandlingNullValues(ref object value)
            {
                if (HandleNullvalues && value == null)
                    return DBNull.Value;
                else
                    return value;
            }
            #endregion

            #region Internal Properties
            internal Hashtable AllParameters
            {
                get { return parameters; }
                set { parameters = value; }
            }
            #endregion

            #region Public Costructors
            public StordeParameters(bool HandlingNullvalues):this()
            {
                this.HandleNullvalues = HandlingNullvalues;
                
            }
            public StordeParameters()
            {
                parameters = new Hashtable();
            }
            #endregion

            #region Public Methodes
            public void AddWithValue(string Name, object Value)
            {
                StringBuilder MyString = new StringBuilder();
                if (!Name.StartsWith("@"))
                    MyString.Append('@');

                MyString.Append(Name.Trim());
                parameters.Add(MyString, HandlingNullValues(ref Value));
            }
            #endregion
        } 
    }
}
