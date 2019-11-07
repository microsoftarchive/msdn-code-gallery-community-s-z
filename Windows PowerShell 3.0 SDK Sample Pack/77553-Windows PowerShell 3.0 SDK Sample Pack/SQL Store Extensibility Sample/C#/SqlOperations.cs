// <copyright file="AssemblyInfo.cs" company="Microsoft Corporation">
// Copyright (c) 2012 Microsoft Corporation. All rights reserved.
// </copyright>
// DISCLAIMER OF WARRANTY: The software is licensed “as-is.” You 
// bear the risk of using it. Microsoft gives no express warranties, 
// guarantees or conditions. You may have additional consumer rights 
// under your local laws which this agreement cannot change. To the extent 
// permitted under your local laws, Microsoft excludes the implied warranties 
// of merchantability, fitness for a particular purpose and non-infringement.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace SQLStoreExtensibilitySample
{
    // This class performs SQL database operations.
    public class SqlOperations
    {
        private readonly string adoConnectionString;

        // Constructor that takes the connection string as an input.
        internal SqlOperations(string connectionString)
        {
            this.adoConnectionString = connectionString;
        }

        // Store the data. You must pass the workflow instance ID, the name of the database, and the database instance.
        // it is important to pass the the workflow instance id and name of data and the data itself
        internal void StoreState(Guid workflowInstanceID, string name, ArraySegment<byte> data)
        {
            string commandText = @"IF EXISTS (SELECT 1 FROM dbo.WorkflowState WHERE WorkflowInstanceID = @WorkflowID AND Name = @ParamName)
                                    UPDATE dbo.WorkflowState SET Data = @ParamData
                                 ELSE
                                INSERT INTO dbo.WorkflowState (WorkflowInstanceID, Name, Data) VALUES (@WorkflowID, @ParamName, @ParamData)";

            using (SqlConnection connection = new SqlConnection(this.adoConnectionString))
            {
                SqlParameter workflowIDParam = new SqlParameter("@WorkflowID", System.Data.SqlDbType.UniqueIdentifier);
                workflowIDParam.Value = workflowInstanceID;

                SqlParameter dataNameParam = new SqlParameter("@ParamName", System.Data.SqlDbType.NVarChar);
                dataNameParam.Value = name;

                SqlParameter dataValueParam = new SqlParameter("@ParamData", System.Data.SqlDbType.VarBinary);
                dataValueParam.Size = int.MaxValue;
                dataValueParam.Value = ToArray(data);

                connection.Open();

                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.Parameters.Add(workflowIDParam);
                    command.Parameters.Add(dataNameParam);
                    command.Parameters.Add(dataValueParam);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Load the data from the SQL store.
        internal ArraySegment<byte>? LoadState(Guid workflowInstanceID, string name)
        {
            string commandText = @"SELECT 1 FROM dbo.WorkflowState WHERE WorkflowInstanceID = @WorkflowID AND Name = @ParamName";

            using (SqlConnection connection = new SqlConnection(this.adoConnectionString))
            {
                SqlParameter workflowIDParam = new SqlParameter("@WorkflowID", System.Data.SqlDbType.UniqueIdentifier);
                workflowIDParam.Value = workflowInstanceID;

                SqlParameter dataNameParam = new SqlParameter("@ParamName", System.Data.SqlDbType.NVarChar);
                dataNameParam.Value = name;

                connection.Open();

                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.Parameters.Add(workflowIDParam);
                    command.Parameters.Add(dataNameParam);

                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return (ArraySegment<byte>)result;
                    }
                }
            }

            return null;
        }

        // Delet the data from the SQL store specified by the workflow instance id.
        internal void DeleteState(Guid workflowInstanceID)
        {
            string commandText = "DELETE FROM dbo.WorkflowState WHERE WorkflowInstanceID = @WorkflowID";

            using (SqlConnection connection = new SqlConnection(this.adoConnectionString))
            {
                SqlParameter workflowIDParam = new SqlParameter("@WorkflowID", System.Data.SqlDbType.UniqueIdentifier);
                workflowIDParam.Value = workflowInstanceID;
                connection.Open();

                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.Parameters.Add(workflowIDParam);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Utility method.
        static private byte[] ToArray(ArraySegment<byte> data)
        {
            var result = new byte[data.Count];
            Array.Copy(data.Array, data.Offset, result, 0, data.Count);
            return result;
        }
    }
}
