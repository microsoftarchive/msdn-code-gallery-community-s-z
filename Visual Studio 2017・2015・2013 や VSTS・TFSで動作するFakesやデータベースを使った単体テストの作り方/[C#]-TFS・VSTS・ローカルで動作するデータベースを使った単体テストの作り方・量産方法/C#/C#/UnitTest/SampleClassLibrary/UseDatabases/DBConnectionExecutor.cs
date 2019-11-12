using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleClassLibrary.UseDatabases
{
    public class DBConnectionExecutor
    {
        public DBConnectionExecutorEnvironment Environment { get; set; }

        /// <summary>
        /// 指定されたテキストを、Environment.EntityConnectionString プロパティで指定された接続で SampleText テーブルに保存します。
        /// ただし、指定されたテキストが既に登録されている時は例外を返します。
        /// </summary>
        /// <param name="updateText"></param>
        public void Execute(string updateText)
        {

            if (string.IsNullOrEmpty(updateText)) throw new ArgumentException("updateText に Empty 文字、および null 参照 (Visual Basic の場合は Nothing) を指定することは出来ません。", "updateText");
            if (this.Environment == null) throw new InvalidOperationException("Environment プロパティが指定されていません。Execute メソッドを実行するまえに、Environment プロパティを指定してください。");
            if (string.IsNullOrWhiteSpace(this.Environment.EntityConnectionString)) throw new InvalidOperationException("Environment プロパティの EntityConnectionString プロパティが指定されていません。Execute メソッドを実行するまえに、Environment.EntityConnectionString プロパティを指定してください。");

            using (var db = new UnitTestSampleEntities(this.Environment.EntityConnectionString))
            {

                // ※ Text フィールドにインデックスがないと、大量データだととても遅くなりますね。
                var count =
                    (from row in db.SampleTexts
                     where row.Text == updateText
                     select row).Count();

                if (count > 0) throw new ArgumentException("データベースに既に保存されているテキストを更新することは出来ません。別の値を指定してください。", "updateText");

                var newRow = new SampleText() { Text = updateText };
                db.SampleTexts.Add(newRow);
                db.SaveChanges();
            } // end using (db)

        } // end sub

        /// <summary>
        /// Environment.CommandConnectionString プロパティで指定された接続で SampleTexts テーブルの件数をSQLコマンドで取得して返します。
        /// </summary>
        /// <returns>テーブルの件数を返します。</returns>
        public int Count()
        {

            if (this.Environment == null) throw new InvalidOperationException("Environment プロパティが指定されていません。Execute メソッドを実行するまえに、Environment プロパティを指定してください。");
            if (string.IsNullOrWhiteSpace(this.Environment.CommandConnectionString)) throw new InvalidOperationException("Environment プロパティの CommandConnectionString プロパティが指定されていません。Execute メソッドを実行するまえに、Environment.CommandConnectionString プロパティを指定してください。");

            using (var db = new SqlConnection(this.Environment.CommandConnectionString))
            using (var command = new SqlCommand("SELECT COUNT(*) FROM [SampleTexts]", db))
            {
                db.Open();

                var r = command.ExecuteScalar() as int?;
                return r.Value;
            } // end using (db)

        } // end function

    } // end class

    public class DBConnectionExecutorEnvironment
    {
        public string EntityConnectionString { get; set; }
        public string CommandConnectionString { get; set; }


        /// <summary>
        /// 現在のオブジェクトを表す文字列を返します。
        /// </summary>
        /// <returns>現在のオブジェクトを説明する文字列。</returns>
        public override string ToString()
        {

            // 匿名型の ToString 同様に、各プロパティの内容を全て出力します。

            // 名前と値をフォーマットするラムダ式
            Func<string, object, string> formmat = (name, value) =>
            {
                if (name == "EntityConnectionString" && string.IsNullOrWhiteSpace((string)value) == false){

                    return name + ":\r\n\r\n" +
                        value +
                        "\r\n\r\n";
                }
                else
                {
                    if (value == null){
                        return name + " = null 参照 ( Visual Basic の場合は Nothing )";
                    }
                    else{
                        return name + " = " + value.ToString();
                    } // end if
                } // end if
            };

            // パブリックメンバーを探して出力します。
            var nameAndValues =
                from p in this.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)
                select formmat(p.Name, p.GetValue(this));

            return "{ " + string.Join(", ", nameAndValues) + " }";
        } // end function 


    } // end class

} // end namespace
