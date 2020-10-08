using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JpmmsClasses.BL
{
    public class DT_LCMS_POTHOLES_PROCESSED
    {
        public string SURVEY_ID { get; set; }
        public string CHAINAGE { get; set; }
        public string LRP_NUMBER { get; set; }
        public string LRP_CHAINAGE { get; set; }
        public string AREA { get; set; }
        public string MAX_DEPTH { get; set; }
        public string AVE_DEPTH { get; set; }
        public string SEVERITY { get; set; }
        public string IMAGE_FILE_INDEX { get; set; }
        public string CreateDate { get; set; }
        public string Done_By { get; set; }
    }
}
