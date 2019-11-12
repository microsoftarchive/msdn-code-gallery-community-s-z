using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleClassLibrary.UseDatabases
{
    public class ConfigDBConnectionExecutor
    {
        /// <summary>
        /// 指定されたテキストを、App.config の接続文字列 UnitTestSampleEntities で指定された DB の SampleText テーブルに保存します。
        /// ただし、指定されたテキストが既に登録されている時は例外を返します。
        /// </summary>
        /// <param name="updateText"></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public void Execute(string updateText)
        {

            // ※下記実装は、本来 static メソッドであるべきですが、このテスト用サンプルは DBConnectionExecutor と比較出来るように、
            // インスタンスとして何らかの処理をすることをイメージしたものとなっています。

            if (string.IsNullOrEmpty(updateText)) throw new ArgumentException("updateText に Empty 文字、および null 参照 (Visual Basic の場合は Nothing) を指定することは出来ません。", "updateText");

            // DB の接続文字列は、Entity Framework 標準機能により（コンストラクタに何も指定しないことで）App.config から取得して動作します。
            // このクラスの場合、そつ族文字列の名前は UnitTestSampleEntities です。
            using (var db = new UnitTestSampleEntities())
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
        /// App.config の接続文字列 UnitTestSample で指定された DB の SampleTexts テーブルの件数をSQLコマンドで取得して返します。
        /// </summary>
        /// <returns>テーブルの件数を返します。</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public int Count()
        {

            // ※下記実装は、本来 static メソッドであるべきですが、このテスト用サンプルは DBConnectionExecutor と比較出来るように、
            // インスタンスとして何らかの処理をすることをイメージしたものとなっています。

            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["UnitTestSample"].ConnectionString))
            using (var command = new SqlCommand("SELECT COUNT(*) FROM [SampleTexts]", db))
            {
                db.Open();

                var r = command.ExecuteScalar() as int?;
                return r.Value;
            } // end using (db)

        } // end function
    } // end class
} // end namespace
