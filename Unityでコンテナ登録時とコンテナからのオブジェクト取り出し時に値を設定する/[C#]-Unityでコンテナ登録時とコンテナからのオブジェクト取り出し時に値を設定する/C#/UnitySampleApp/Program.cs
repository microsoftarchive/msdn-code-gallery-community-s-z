using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitySampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var container = new UnityContainer())
            {
                // 型の登録時に、プロパティの値を設定できる
                container.RegisterType<MessageProvider>(
                    new InjectionProperty("Message", "Hello world"));
                // コンストラクタの値も設定できる。
                container.RegisterType<Greeter>(
                    new InjectionConstructor(new ResolvedParameter<MessageProvider>()));
                // 普通にResolveした場合
                {
                    // コンテナに登録した値を取得
                    var greeter = container.Resolve<Greeter>();
                    greeter.Greet(); // -> Helo world
                }

                // Resolve時に値を注入
                {
                    // コンテナから値を取得するタイミングでデフォルトの値を上書き可能
                    var provider = container.Resolve<MessageProvider>(
                        new PropertyOverride("Message", "こんにちは世界"));
                    // コンストラクタの値も変更可能
                    var greeter = container.Resolve<Greeter>(
                        new ParameterOverride("messageProvider", provider));
                    greeter.Greet(); // -> こんにちは世界 
                }
            }
        }
    }

    // Messageプロパティを持つだけのシンプルなクラス
    public class MessageProvider
    {
        public string Message { get; set; }
    }

    // コンストラクタでMessageProviderクラスを受け取るクラス
    public class Greeter
    {
        private MessageProvider MessageProvider { get; set; }
        // デフォルト
        public Greeter()
        {
            this.MessageProvider = new MessageProvider { Message = "Hello defualtt message." };
        }
        // コンストラクタでMessageProviderを指定することでメッセージを指定可能
        public Greeter(MessageProvider messageProvider)
        {
            this.MessageProvider = messageProvider;
        }

        // MessageProviderクラスのMessageプロパティの値を表示する
        public void Greet()
        {
            Console.WriteLine(this.MessageProvider.Message);
        }
    }
}
