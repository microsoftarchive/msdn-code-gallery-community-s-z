using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleClassLibrary.SystemFakes
{
    public class NowUser
    {
        public DateTime Now { get; private set; }

        /// <summary>
        /// 引数 userName が "a" であり、かつ 現在の日付（System.DateTime.Now）が 2015年1月1日より未来の日時の場合 True を返します。それ以外は False を返します。
        /// また、実行時の日時を Now プロパティに保存します。
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool Execute(string userName)
        {
            this.Now = System.DateTime.Now;
            return (userName == "a") && (new System.DateTime(2015, 1, 1) < this.Now);
        } // end function

    } // end class
} // end namespace
