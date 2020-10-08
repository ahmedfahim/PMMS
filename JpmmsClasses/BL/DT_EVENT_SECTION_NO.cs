using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JpmmsClasses.BL
{
    public class DT_EVENT_SECTION_NO
    {
        public string Survey_ID { get; set; }
        public string SECTION_NO { get; set; }
        public string CHAINAGE_START { get; set; }
        public string CHAINAGE_END { get; set; }
        public string LENGTH { get; set; }
        public string LRP_NUMBER_START { get; set; }
        public string LRP_OFFSET_START { get; set; }
        public string LRP_NUMBER_END { get; set; }
        public string LRP_OFFSET_END { get; set; }
        public string FRAME_START { get; set; }
        public string FRAME_END { get; set; }
        public string COMMENT1 { get; set; }
        public string COMMENT_1 { get; set; }
        public string COMMENT_2 { get; set; }
        public string COMMENT_3 { get; set; }
        public string COMMENT_4 { get; set; }
        public string PHOTO_SET { get; set; }
        public string X { get; set; }
        public string Y { get; set; }
        public string Z { get; set; }
        public string X_END { get; set; }
        public string Y_END { get; set; }
        public string Z_END { get; set; }
        public string CreateDate { get; set; }
        public string Done_By { get; set; }
    }
    public class DT_EVENT_SECTION_NOComparer : IEqualityComparer<DT_EVENT_SECTION_NO>
    {
        public bool Equals(DT_EVENT_SECTION_NO x, DT_EVENT_SECTION_NO y)
        {
            if (x.Survey_ID == y.Survey_ID &&
                x.CHAINAGE_START == y.CHAINAGE_START && x.CHAINAGE_END.ToLower() == y.CHAINAGE_END.ToLower() &&
                x.FRAME_START == y.FRAME_START && x.FRAME_END.ToLower() == y.FRAME_END.ToLower())
                return true;

            return false;
        }

        public int GetHashCode(DT_EVENT_SECTION_NO obj)
        {
            return obj.GetHashCode();
        }
    }
}
