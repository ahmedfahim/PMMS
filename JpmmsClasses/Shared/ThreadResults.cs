using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JpmmsClasses
{
    public class ThreadResults
    {

        private static Hashtable results = new Hashtable();

        public static string message = "";


        public static object Get(Guid itemId)
        {
            return results[itemId];
        }

        public static void Add(Guid itemId, object result)
        {
            results[itemId] = result;
        }

        public static void Remove(Guid itemId)
        {
            results.Remove(itemId);
        }

        public static bool Contains(Guid itemId)
        {
            return results.Contains(itemId);
        }

    }
}
