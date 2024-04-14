using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
namespace test 
{
	/// <summary>
	/// Summary description for DB.
	/// </summary>
	public class DB: IDisposable
	{
        public DB()
        {

        }

        #region Global Variables

        public static string ConnectionString = "Data Source=190.239.163.89;Initial Catalog=test;User ID=boss; Password=12qwaszx34erdfcv";

        private SqlConnection Connection = new SqlConnection(ConnectionString);
        #endregion
        
        #region Global Methods
        
        protected DataSet ExecuteStoredProcedure(string SPName, ref ArrayList Parameters)
        {
            DataSet dsResult = new DataSet();
            SqlCommand Command =new SqlCommand(SPName, Connection);
            Command.CommandTimeout = 0;
            Command.CommandType = CommandType.StoredProcedure;

            if (Parameters != null)
            {
                for (int i = 0; i < Parameters.Count; i++)
                {
                    Command.Parameters.Add(Parameters[i]);
                }
            }

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(Command);
                adapter.Fill(dsResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dsResult;
        }

        //private Component componentes = new Component();
        private DataSet dataSetDisposable = new DataSet();
 
        // Indica si ya se llamo al método Dispose. (default = false)
        private Boolean disposed;
 
        /// <summary>
        /// Implementación de IDisposable. No se sobreescribe.
        /// </summary>
        public void Dispose() {
            this.Dispose(true);
            // GC.SupressFinalize quita de la cola de finalización al objeto.
            GC.SuppressFinalize(this);
        }
 
        /// <summary>
        /// Limpia los recursos manejados y no manejados.
        /// </summary>
        /// <param name="disposing">
        /// Si es true, el método es llamado directamente o indirectamente
        /// desde el código del usuario.
        /// Si es false, el método es llamado por el finalizador
        /// y sólo los recursos no manejados son finalizados.
        /// </param>
        protected virtual void Dispose(bool disposing) {
            // Preguntamos si Dispose ya fue llamado.
            if (!this.disposed) {
                if (disposing) {
                    // Llamamos al Dispose de todos los RECURSOS MANEJADOS.
                    //this.componentes.Dispose();
                    this.dataSetDisposable.Dispose();
                }
 
                // Acá finalizamos correctamente los RECURSOS NO MANEJADOS
                // ...
 
            }
            this.disposed = true;
        }
 
        /// <summary>
        /// Destructor de la instancia
        /// </summary>
        ~DB() {
            this.Dispose(false);
        }

            // Use C# destructor syntax for finalization code.
        
            #endregion
        }
}