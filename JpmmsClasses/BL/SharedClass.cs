using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace JpmmsClasses.BL
{
    public class SharedClass
    {

        public ListItem[] CreateRadioBtnSurveys(string Surveys)
        {
            int result;
            if (int.TryParse(Surveys, out result))
            {
                ListItem[] SurveysItems = new ListItem[result];
                for (int i = 0, j = 3; i < SurveysItems.Length; i++, j++)
                {
                    SurveysItems[i] = new ListItem(" المسح رقم " + j, j.ToString());
                }
                return SurveysItems;
            }
            else
                return null;
        }
        public ListItem CreateRadioBtnMaxSurveys(string Surveys)
        {
            int result;
            if (int.TryParse(Surveys, out result))
            {
                return new ListItem(" المسح رقم " + Surveys, Surveys);
            }
            else
                return null;
        }
    }
}
