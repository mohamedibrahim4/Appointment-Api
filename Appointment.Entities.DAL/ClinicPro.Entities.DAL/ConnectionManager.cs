using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Entities.DAL
{
   public sealed class ConnectionManager
    {
        public static SqlConnection GetConnection(string DBConString = "")
        {
            // Get the connection string from the configuration file

            string connectionString;
            if (DBConString == "")
            {

                connectionString = ConfigurationManager.ConnectionStrings["AppointmentConnectionString"].ToString();
            }
            else
            {
                connectionString = ConfigurationManager.ConnectionStrings["AppointmentImagingCon"].ToString();
            }

            //"Data Source=safwat;Initial Catalog=Appointment;Persist Security Info=True;User ID=sa;Password=p@ssw0rd";
            //ConfigurationSettings.AppSettings["GOVCOMConnectionString"];
            //System.Configuration
            // Create a new connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // Handle connection events
            //connection.StateChange += Logger.LogConnectionStateChange;
            //connection.InfoMessage += Logger.LogConnectionInfoMessage;

            // Open the connection, and return it
            connection.Open();
            return connection;
        }

    }
}
