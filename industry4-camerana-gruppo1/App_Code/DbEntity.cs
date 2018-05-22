using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descrizione di riepilogo per DbEntity
/// </summary>
public class DbEntity
{
    public DbEntity()
    {

    }

    //
    // TODO: aggiungere qui la logica del costruttore
    //
    SqlConnection conn = new SqlConnection();
    private void ApriConnessione()
    {
        //conn.ConnectionString = @"Data Source=ALI8-01-W7\SQLEXPRESS;Initial Catalog=TDPC09;Integrated Security=true";
        //conn.ConnectionString = @"Data Source=NB7-ZHEUNIAK\SQLEXPRESS;Initial Catalog=TDPC09;Integrated Security=true";
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        if (conn.State == ConnectionState.Open)
        {
            conn.Close();
        }
        conn.Open();
    }
    private void ChiudiConnessione()
    {
        if (conn.State == ConnectionState.Open)
        {
            conn.Close();
        }
    }
    public DataTable eseguiQuery(SqlCommand cmd)
    {
        cmd.Connection = conn;
        DataTable dt = new DataTable();
        ApriConnessione();
        SqlDataAdapter DA = new SqlDataAdapter();
        DA.SelectCommand = cmd;
        DA.Fill(dt);
        ChiudiConnessione();
        return dt;

    }
    public void eseguiQueryNOreturn(SqlCommand cmd)
    {
        cmd.Connection = conn;
        ApriConnessione();
        cmd.ExecuteNonQuery();
        ChiudiConnessione();
    }
}