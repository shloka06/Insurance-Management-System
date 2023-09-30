using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static System.Collections.Specialized.BitVector32;

namespace InsuranceManagementSystem
{
    public class CurrentSession
    {
        public string SessionName
        {
            get; set;
        }
        public int SessionID
        {
            get; set;
        }
        private CurrentSession()
        {
            SessionName = string.Empty;
            SessionID = 0;
        }

        public static CurrentSession currentSession
        {
            get
            {
                CurrentSession currentSession = (CurrentSession)HttpContext.Current.Session["CurrentSession"];
                if (currentSession == null)
                {
                    currentSession = new CurrentSession();
                    HttpContext.Current.Session["CurrentSession"] = currentSession;
                }
                return currentSession;
            }
        }

        public void Abandon()
        {
            HttpContext.Current.Session.Abandon();
        }
        
    }
}