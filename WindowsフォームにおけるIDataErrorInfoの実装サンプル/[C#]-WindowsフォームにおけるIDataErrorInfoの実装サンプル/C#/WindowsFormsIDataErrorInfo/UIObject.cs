using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsIDataErrorInfo
{
    /// <summary>
    /// 画面にバインドするクラス
    /// </summary>
    public class UIObject : IDataErrorInfo
    {
        //エラー情報を保持
        private Dictionary<string, string> _errors = new Dictionary<string, string>();

        #region プロパティ

        string _A;
        public string A
        {
            get { return _A; }
            set
            {
                if (_A == value) return;
                _A = value;
                ValidateA();
            }
        }

        string _B;
        public string B
        {
            get { return _B; }
            set
            {
                if (_B == value) return;
                _B = value;
                ValidateB();
            }
        }

        string _C;
        public string C
        {
            get { return _C; }
            set
            {
                if (_C == value) return;
                _C = value;
                ValidateC();
            }
        }

        /// <summary>
        /// エラーの有無 
        /// </summary>
        public bool HasError
        {
            get
            {
                return _errors.Count != 0;
            }
        }

        #endregion

        #region イベント

        public event Action<bool> HasErrorChanged;

        private void OnHasErrorChanged(bool hasError)
        {
            if (HasErrorChanged != null)
                HasErrorChanged(hasError);
        }

        #endregion

        #region エラーチェック

        public void ValidateA()
        {
            ClearError("A");
            if (_A == "")
                SetError("A", "Ａは空にはできません。");

            OnHasErrorChanged(HasError);
        }

        public void ValidateB()
        {
            ClearError("B");
            int i = 0;
            if (!int.TryParse(_B.ToString(), out i))
                SetError("B", "Ｂは整数ではありません。");

            OnHasErrorChanged(HasError);
        }

        public void ValidateC()
        {
            ClearError("C");
            decimal i = 0;
            if (!decimal.TryParse(_C.ToString(), out i))
                SetError("C", "Ｃは数値を入力して下さい。");

            OnHasErrorChanged(HasError);
        }

        //全てのエラーチェックを実行
        public void ValidateAll()
        {
            ValidateA();
            ValidateB();
            ValidateC();
        }

        #endregion

        #region エラー情報操作メソッド

        /// <summary>
        /// 指定したプロパティにエラー情報をセットする
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="error"></param>
        protected void SetError(string propertyName, string error)
        {
            _errors[propertyName] = error;
        }

        /// <summary>
        /// 指定したプロパティのエラー情報を消去する
        /// </summary>
        /// <param name="propertyName"></param>
        public void ClearError(string propertyName)
        {
            if (!_errors.ContainsKey(propertyName))
            {
                return;
            }
            _errors.Remove(propertyName);
        }

        /// <summary>
        /// 全てのプロパティのエラー情報を消去する
        /// </summary>
        /// <param name="propertyName"></param>
        public void ClearErrorAll()
        {
            _errors.Clear();
        }

        /// <summary>
        /// 指定したプロパティのエラーを取得する
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        protected string GetError(string propertyName)
        {
            string error = null;
            _errors.TryGetValue(propertyName, out error);
            return error;
        }

        /// <summary>
        /// 現在エラーがあるプロパティ名の配列を取得する
        /// </summary>
        /// <returns></returns>
        protected string[] GetErrorPropertyNames()
        {
            return _errors.Keys.ToArray();
        }

        #endregion

        #region IDataErrorInfo メンバ

        public string Error
        {
            get
            {
                var sb = new StringBuilder();
                foreach (var propertyName in GetErrorPropertyNames())
                {
                    sb.AppendLine(this[propertyName]);
                }
                return sb.ToString();
            }
        }

        public string this[string propertyName]
        {
            get { return GetError(propertyName); }
        }

        #endregion
    }
}
