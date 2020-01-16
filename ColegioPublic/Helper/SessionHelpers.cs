using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ColegioPublic.Helper
{
   
        public class SessionHelpers
        {
            private HttpSessionStateBase session;

            public SessionHelpers(HttpSessionStateBase session)
            {
                this.session = session;
            }
        }
    
}