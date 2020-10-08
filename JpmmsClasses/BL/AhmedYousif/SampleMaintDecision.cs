using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JpmmsClasses.BL.AhmedYousif
{
    public class SampleMaintDecision
    {
        public int SampleID;
        public int MaintDecisionID;
        public int UDI;
        public double MaintArea;

        public SampleMaintDecision()
        {
            SampleID = 0;
            MaintDecisionID = 1;
            UDI = 0;
            MaintArea = 0;
        }

        public SampleMaintDecision(int sampleID, int maintDecisionID, int udi, double maintArea)
        {
            SampleID = sampleID;
            MaintDecisionID = maintDecisionID;
            UDI = udi;
            MaintArea = maintArea;
        }

        public void SetData(int sampleID, int maintDecisionID, int udi, double maintArea)
        {
            SampleID = sampleID;
            MaintDecisionID = maintDecisionID;
            UDI = udi;
            MaintArea = (MaintArea == 0) ? maintArea : (MaintArea + maintArea);
        }

        public void AddArea(double maintArea)
        {
            MaintArea += maintArea;
        }
    }

}
