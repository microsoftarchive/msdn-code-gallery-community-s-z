namespace WPFGroupingSample
{
    /// <summary>
    /// 表示用のデータクラス
    /// </summary>
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            // 画面表示用の文字列を作成
            return string.Format("{0}, {1}才", this.Name, this.Age);
        }
    }
}
