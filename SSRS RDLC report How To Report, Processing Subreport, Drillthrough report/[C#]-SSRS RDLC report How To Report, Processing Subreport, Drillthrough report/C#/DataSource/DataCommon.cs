
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

// DataCommon class PASS VERACODE security 
class DataCommon
{

    private int gedSQLTimeOut = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["SQLTimeout"]);

    private string _connectionString = "";  // can be null
    private string _providerName = "";          // can be null 
    private int _intEffected = -1;

    private DbConnection conn;
    private DbCommand _commandDB;
    private string _strError;

    public int intEffected
    {
        get { return _intEffected; }
    }

    public string strError
    {
        get { return _strError; }
    }


    public string connectionString
    {
        get { return _connectionString; }
        set { _connectionString = value; }
    }

    public string providerName
    {
        get { return _providerName; }
        set { _providerName = value; }
    }
    

    public DbCommand commandDB(string connectionName = "") // if you have different name 
    {
        if (connectionName == "")   // Default Name
        {
            //_connectionString =  
            //_providerName = 
        }
        else                     
        {
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            _providerName = System.Configuration.ConfigurationManager.ConnectionStrings[connectionName].ProviderName;
        }

        conn = CreateDbConnection();
        _commandDB = conn.CreateCommand();
        _commandDB.CommandTimeout = gedSQLTimeOut;
        return _commandDB;

    }



    private DbConnection CreateDbConnection()
    {
        // Assume failure.
        conn = null;

        // Create the DbProviderFactory and DbConnection.
        if (_connectionString != null && _providerName != null)
        {
            try
            {
                DbProviderFactory factory = DbProviderFactories.GetFactory(_providerName);

                conn = factory.CreateConnection();
                conn.ConnectionString = connectionString;
            }
            catch (Exception ex)
            {
                // Set the connection to null if it was created.
                if (conn != null)
                {
                    conn = null;
                }
                _strError = ex.Message;
            }
        }
        // Return the connection.
        return conn;
    }

    public int ExecuteSqlNonQuery(DbCommand cmd, CommandType comType, Dictionary<string, object> parameters, out string strError)
    {

        int intEffected = -1;
        strError = "";

        try
        {
            conn = cmd.Connection;
            conn.Open();
        }
        catch (Exception ex)
        {
            strError = ex.Message;
            return intEffected;
        }

        try
        {
            cmd.CommandType = comType;
            if ((parameters != null))
            {
                cmd.Parameters.Clear();
                if (parameters.Count > 0)
                {
                    SetCmd(ref cmd, parameters);
                }
            }

            intEffected = cmd.ExecuteNonQuery();
            conn.Close();
        }
        catch (Exception ex)
        {
            strError = ex.Message;
            intEffected = -1;
        }
        finally
        {
            conn.Close();
        }

        return intEffected;
    }

    public DataSet GetDataSet(DbCommand cmd, CommandType comType, Dictionary<string, object> parameters)
    {
        _intEffected = -1;

        try
        {
            conn = cmd.Connection;
            conn.Open();
        }
        catch (Exception ex)
        {
            _strError = ex.Message;
            return null;
        }

        DataSet dataSet = new DataSet();
        DbProviderFactory factory = DbProviderFactories.GetFactory(_providerName);

        try
        {
            //System.Data.Common.DbCommand
            DbDataAdapter dbAdapter = factory.CreateDataAdapter();

            cmd.CommandType = comType;
            if ((parameters != null))
            {
                cmd.Parameters.Clear();
                if (parameters.Count > 0)
                {
                    SetCmd(ref cmd, parameters);
                }
            }

            dbAdapter.SelectCommand = cmd;
            dbAdapter.FillLoadOption = LoadOption.PreserveChanges;
            _intEffected = dbAdapter.Fill(dataSet);

            conn.Close();
        }
        catch (Exception ex)
        {
            _strError = ex.Message;
            conn.Close();
        }
        return dataSet;

    }

    private void SetCmd(ref DbCommand cmd, Dictionary<string, object> parameters)
    {
        foreach (var pair in parameters)
        {
            var param = cmd.CreateParameter();
            param.ParameterName = pair.Key;
            param.Value = pair.Value;
            cmd.Parameters.Add(param);
        }
    }

    public bool TestConnection()
    {
        _strError = "";
        try
        {
            conn.Open();
            conn.Close();
            return true;
        }
        catch (Exception ex)
        {
            _strError = ex.Message;
            return false;
        }
    }

    public bool closeConnection()
    {
        // Use it if you need to brake long RUN;
        try
        {
            conn.Close();
            return true;
        }
        catch (Exception ex)
        {
            _strError = ex.Message;
            return false;
        }
    }

}






