namespace visorParcelas_1.Config
{
    /// <summary>
    /// Utilizamos esta clase para leer los datos de conexión al incio de la ejecución
    /// Almacenamos la conexión tanto en forma de clase como de string, de manera que solo hay 
    /// que hacer una conversión.
    /// </summary>
    public class Information_Singleton
    {
        private static Information_Singleton instance = new Information_Singleton();

        private Connection connection;
        private string connection_String;

        private Information_Singleton()
        {

        }

        public static Information_Singleton getInstance()
        {
            return instance;
        } 

        public void setConnection(Connection connec) {
            connection = connec;
            connection_String = "Host=" + connec.Host.ToString() + ";Username=" + connec.Username.ToString() +
            ";Password=" + connec.Password.ToString() + ";DataBase=" + connec.DataBase.ToString();
        }

        public string getConnectionString() { return  connection_String; }
    }
}
