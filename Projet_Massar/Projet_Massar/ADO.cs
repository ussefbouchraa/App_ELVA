using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
namespace Projet_Massar
{
    class ADO
    {

        public OleDbConnection cn = new OleDbConnection(@"provider= Microsoft.ACE.OLEDB.12.0 ; Data Source=C:\Users\user\OneDrive\Bureau\Projet_Stage_PFF\ELVA\DATA.accdb ; persist Security Info=False");
        public OleDbCommand cmd = new OleDbCommand();
        public OleDbDataAdapter DA = new OleDbDataAdapter();
        public DataTable DT = new DataTable();
        

        public void connecter()
        {
            if (cn.State == ConnectionState.Broken || cn.State == ConnectionState.Closed) {cn.Open(); }
        
        }
        public void deconnecter()
        {
            if (cn.State == ConnectionState.Open ) { cn.Close(); }

        }

     


    }
}
