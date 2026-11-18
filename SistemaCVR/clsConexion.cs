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
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadena))
                using (SqlDataAdapter adaptador = new SqlDataAdapter(sql, conexion))
                {
                    adaptador.Fill(tabla);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable(); 
            }

            return tabla;
        }

        public DataTable FiltrarDatos(string sql, SqlParameter[] parametros)
        {
            DataTable tabla = new DataTable();
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadena))
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    if (parametros != null) comando.Parameters.AddRange(parametros);

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                    {
                        adaptador.Fill(tabla);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
            return tabla;
        }

        public int ejecutarComando(string sql, SqlParameter[] parametros)
        {
            int filasAfectadas = 0;
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadena))
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    if (parametros != null) comando.Parameters.AddRange(parametros);

                    conexion.Open();
                    filasAfectadas = comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar el comando en la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            return filasAfectadas;
        }

        public object ejecutarEscalar(string sql, SqlParameter[] parametros)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar el comando en la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
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
            try
            {
                combo.DataSource = Consultar(sql);
                combo.DisplayMember = visible;
                combo.ValueMember = valor;
                combo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el ComboBox: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public string GenerarHashMD5(string texto)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el hash MD5: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

    }
}
