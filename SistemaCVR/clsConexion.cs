using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaCVR
{
    internal class clsConexion
    {
        private readonly string cadena =
        @"Data Source=.;Initial Catalog=SistemaCVR;Integrated Security=True";

        public DataTable Consultar(string sql) 
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conexion = new SqlConnection(cadena))
            using(SqlDataAdapter adaptador = new SqlDataAdapter(sql, conexion))
            {
                adaptador.Fill(tabla);
            }

            return tabla;
        }

        public DataTable FiltrarDatos(string sql, SqlParameter[] parametros)
        {
            DataTable tabla = new DataTable();
            using (SqlConnection conexion = new SqlConnection(cadena))
            using (SqlCommand comando = new SqlCommand(sql, conexion))
            {
                if(parametros != null) comando.Parameters.AddRange(parametros);
                using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                {
                    adaptador.Fill(tabla);
                }

            }
            return tabla;
        }

        public int ejecutarComando(string sql, SqlParameter[] parametros)
        {
            int filasAfectadas = 0;
            using (SqlConnection conexion = new SqlConnection(cadena))
            using (SqlCommand comando = new SqlCommand(sql, conexion))
            {
                
                    comando.Parameters.AddRange(parametros);
                    conexion.Open();
                    filasAfectadas = comando.ExecuteNonQuery();
            }
            return filasAfectadas;
        }

        public object ejecutarEscalar(string sql, SqlParameter[] parametros)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            using (SqlCommand comando = new SqlCommand(sql, conexion))
            {
                if (parametros != null)
                    comando.Parameters.AddRange(parametros);

                conexion.Open();
                return comando.ExecuteScalar();
            }
        }

        // -------------------------
        public void CargarCombos(
            ComboBox combo,
            string sql,
            string visible,
            string valor
            )
        {
            combo.DataSource = Consultar(sql);
            combo.DisplayMember = visible;
            combo.ValueMember = valor;
            combo.SelectedIndex = -1;
        }


        public string GenerarHashMD5(string texto)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] entrada = Encoding.UTF8.GetBytes(texto);
                byte[] hash = md5.ComputeHash(entrada);

                StringBuilder resultado = new StringBuilder();

                foreach (byte b in hash)
                {
                    resultado.Append(b.ToString("x2"));
                }

                return resultado.ToString();
            }
        }

    }
}
