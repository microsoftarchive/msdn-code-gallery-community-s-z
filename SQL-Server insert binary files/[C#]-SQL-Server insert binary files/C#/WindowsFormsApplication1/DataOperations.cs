using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class DataOperations
    {
        public string ExceptionMessage { get; set; } 

        public bool FilePutSimple(string FilePath, ref int NewIdentifier,string FileName)
        {
            byte[] fileByes;

            using (var stream = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new BinaryReader(stream))
                {
                    fileByes = reader.ReadBytes((int)stream.Length);
                }
            }

            using (SqlConnection cn = new SqlConnection() { ConnectionString = Properties.Settings.Default.ConnectionString })
            {
                var statement = "INSERT INTO Table1 (FileContents,FileName) VALUES (@FileContents,@FileName);SELECT CAST(scope_identity() AS int);";
                using (SqlCommand cmd = new SqlCommand() { Connection = cn, CommandText = statement })
                {
                    cmd.Parameters.Add("@FileContents", SqlDbType.VarBinary, fileByes.Length).Value = fileByes;
                    cmd.Parameters.AddWithValue("@FileName", FileName);

                    try
                    {
                        cn.Open();

                        NewIdentifier = Convert.ToInt32(cmd.ExecuteScalar());
                        return true;

                    }
                    catch (Exception ex)
                    {
                        ExceptionMessage = ex.Message;
                        return false;
                    }
                }
            }
        }
        public bool FileGetSimple(int Identifier, string fileName)
        {
            using (SqlConnection cn = new SqlConnection() { ConnectionString = Properties.Settings.Default.ConnectionString })
            {

                var statement = "SELECT id, [FileContents], FileName FROM Table1  WHERE id = @id;";

                using (SqlCommand cmd = new SqlCommand() { Connection = cn, CommandText = statement})
                {
                    cmd.Parameters.AddWithValue("@id", Identifier);

                    try
                    {
                        cn.Open();

                        var reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            reader.Read();

                            // the blob field
                            int ndx = reader.GetOrdinal("FileContents");

                            var blob = new Byte[(reader.GetBytes(ndx, 0, null, 0, int.MaxValue))];
                            reader.GetBytes(ndx, 0, blob, 0, blob.Length);

                            using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                                fs.Write(blob, 0, blob.Length);

                        }
                        return true;

                    }

                    catch (Exception ex)
                    {
                        ExceptionMessage = ex.Message;
                        return false;
                    }
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="FileName">Path and file name to insert</param>
        /// <param name="NewIdentifier">id for new record</param>
        /// <param name="EventIdentifier">id for parent row</param>
        /// <returns></returns>
        /// <remarks>
        /// Note that I'm storing file name and exension in two fields, I could
        /// of done just the file name or had a column for file type or mime type.
        /// 
        /// What matters for a real app is do we need the original file name or
        /// allow the user a new file name.
        /// </remarks>
        public bool FilePutForEvents(string FileName, ref int NewIdentifier, int EventIdentifier)
        {
            var FileExtention = Path.GetExtension(FileName);
            var FileBaseName = Path.GetFileNameWithoutExtension(FileName);

            byte[] fileByes;

            using (var stream = new FileStream(FileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new BinaryReader(stream))
                {
                    fileByes = reader.ReadBytes((int)stream.Length);
                }
            }

            using (SqlConnection cn = new SqlConnection() { ConnectionString = Properties.Settings.Default.ConnectionString })
            {

                var statement = "INSERT INTO EventAttachments (FileContent,FileExtention,FileBaseName,EventId) VALUES (@FileContent,@FileExtention,@FileBaseName,@EventIdentifier);SELECT CAST(scope_identity() AS int);";

                using (SqlCommand cmd = new SqlCommand() { Connection = cn, CommandText = statement })
                {

                    cmd.Parameters.Add("@FileContent", SqlDbType.VarBinary, fileByes.Length).Value = fileByes;
                    cmd.Parameters.AddWithValue("@FileExtention", FileExtention);
                    cmd.Parameters.AddWithValue("@FileBaseName", FileBaseName);
                    cmd.Parameters.AddWithValue("@EventIdentifier", EventIdentifier);

                    try
                    {
                        cn.Open();

                        NewIdentifier = Convert.ToInt32(cmd.ExecuteScalar());
                        return true;

                    }
                    catch (Exception ex)
                    {
                        ExceptionMessage = ex.Message;
                        return false;
                    }
                }
            }
        }
        public DataTable GetAttachmentsForEvent(int id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection() { ConnectionString = Properties.Settings.Default.ConnectionString })
            {
                var statement = @"
                SELECT Events.Description,EventAttachments.id,EventAttachments.FileBaseName + EventAttachments.FileExtention As FileName
                FROM EventAttachments 
                INNER JOIN Events ON EventAttachments.EventId = Events.id WHERE dbo.Events.id = @Id";

                using (SqlCommand cmd = new SqlCommand() { Connection = cn, CommandText = statement })
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cn.Open();
                    dt.Load(cmd.ExecuteReader());
                    dt.Columns["id"].ColumnMapping = MappingType.Hidden;
                }

            }

            return dt;
        }
        public int GetCourseIdentifier(string courseName)
        {
            int identifier = 0;
            using (SqlConnection cn = new SqlConnection() { ConnectionString = Properties.Settings.Default.ConnectionString })
            {
                var statement = "SELECT id FROM [Events] WHERE Description = @Title";

                using (SqlCommand cmd = new SqlCommand() { Connection = cn, CommandText = statement })
                {
                    cmd.Parameters.AddWithValue("@Title", courseName);
                    cn.Open();
                    identifier = Convert.ToInt32(cmd.ExecuteScalar());
                }

            }

            return identifier;
        }

    }
}
