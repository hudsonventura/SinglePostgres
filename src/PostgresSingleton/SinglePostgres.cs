using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace HudsonVentura
{
    public class SinglePostgres
    {
        private static Dictionary<string, SinglePostgres> _instances = new Dictionary<string, SinglePostgres>();
        private static Dictionary<string, string> _stringConnections = new Dictionary<string, string>();
    


        private string id;
        private NpgsqlConnection _conn = new  NpgsqlConnection();
        public string _stringConnection
        {
            get; private set;
        }




        private SinglePostgres(string strinConnection) {
            _stringConnection = strinConnection;
            _conn = new NpgsqlConnection(strinConnection);
        }

        public bool IsDataDabaseOnline()
        {
            if (_conn.State == ConnectionState.Open)
            {
                return true;
            }
            else {
                try
                {
                    _conn.Open();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        
        public bool IsConnected()
        {
            if (_conn.State == ConnectionState.Open)
            {
                return true;
            }
            else {
                return false;
            }
        }

        public static SinglePostgres Initialize(string stringConnection = null)
        {
            return Initialize((0).ToString(), stringConnection);
        }

        public static SinglePostgres Initialize(int id, string stringConnection = null) {
            return Initialize(id.ToString(), stringConnection);
        }
        
        public static SinglePostgres Initialize(string id, string stringConnection = null) {
            if (_stringConnections.ContainsValue(stringConnection)) {
                string key = _stringConnections.Where(x => x.Value == stringConnection).FirstOrDefault().Key;
                return _instances[key];
            }
            if (stringConnection == null)
            {
                return _instances[id];
            }
            else {
                _instances.Add(id, new SinglePostgres(stringConnection));
                _stringConnections.Add(id, stringConnection);
                return _instances[id];
            }
        }





        

        public DataTable query(string query)
        {
            NpgsqlCommand comando = new NpgsqlCommand();
            comando.Connection = _conn;
            comando.CommandText = query;
            if (_conn.State == ConnectionState.Closed)
            {
                _conn.Open();
            }
            comando.Prepare();

            NpgsqlDataReader read = comando.ExecuteReader();
            DataTable schemaTable = new DataTable();

            schemaTable.Load(read);
            read.Dispose();
            //_conn.Close();
            return schemaTable;
        }

        public DataTable query(NpgsqlCommand command)
        {
            command.Connection = _conn;
            if (_conn.State == ConnectionState.Closed)
            {
                _conn.Open();
            }
            command.Prepare();

            NpgsqlDataReader read = command.ExecuteReader();
            DataTable schemaTable = new DataTable();

            schemaTable.Load(read);
            read.Dispose();
            //_conn.Close();
            return schemaTable;
        }







        public int execute(string query)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = _conn;
            command.CommandText = query;

            if (_conn.State == ConnectionState.Closed)
            {
                _conn.Open();
            }
            command.Prepare();

            return command.ExecuteNonQuery();
        }

        public int execute(NpgsqlCommand command)
        {
            command.Connection = _conn;

            if (_conn.State == ConnectionState.Closed)
            {
                _conn.Open();
            }
            command.Prepare();

            return command.ExecuteNonQuery();
        }







        public void Dispose() {
            _conn.Close();
        }
    }
}
