using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoadInfoReport
{
    class MarkerInfo
    {
        public string m_strTitle;
        public string m_strContent;
        public string m_strLocation;
        public string m_strImageName;

        public MarkerInfo(string strTitle, string strContent, string strLocation, string strImageName)
        {
            m_strTitle = strTitle;
            m_strContent = strContent;
            m_strLocation = strLocation;
            m_strImageName = strImageName;
        }

    }
}
