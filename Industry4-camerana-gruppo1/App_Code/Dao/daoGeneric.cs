using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Industry4_camerana_gruppo1.App_Code.Dao
{

    public class daoGeneric {
        
        public daoGeneric() { }

        public Dictionary<int, string> GetAllRuoli() {
            DbEntity db = new DbEntity();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = String.Format(@"SELECT * FROM TipoRuolo");

            DataTable dt = db.eseguiQuery(cmd);

            Dictionary<int, string> ruoli = null;

            if (dt.Rows.Count > 0) {
                ruoli = new Dictionary<int, string>();
                foreach (DataRow dr in dt.Rows) {
                    ruoli.Add((int)dr["idruolo"], (string)dr["descrizione"]);
                }
            }
            return ruoli;
        }

    }

}