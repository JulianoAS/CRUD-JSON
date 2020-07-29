using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layers.DAL
{
    class Scon
    {        

        private string sCon = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\\Crud.mdf';Integrated Security=True;Connect Timeout=30";
        public string GetSCon()
        {
            return sCon;
        }
    }
}
  
