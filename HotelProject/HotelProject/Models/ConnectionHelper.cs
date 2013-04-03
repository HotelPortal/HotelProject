using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace HotelProject.Models
{
    public class ConnectionHelper
    {

        private static HotelDBContext con; 
        
        public static HotelDBContext getContextInstance()
        {
            if (con == null)
            {
                con = new HotelDBContext();
            }
            else
            {

                if (con.IsDisposed)
                {
                   con = new HotelDBContext();
       
                }
            }

            return con ;
        }

    }
}