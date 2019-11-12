
namespace WPFSortSample
{
    /// <summary>
    /// 画面に表示するためのダミーオブジェクト
    /// </summary>
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            // 画面に表示するための文字列を作成
            return string.Format("{0} {1}才", this.Name, this.Age);
        }
    }
}
