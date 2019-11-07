using System.Threading.Tasks;

namespace TranslateTextApp.Business_Layer.Interface
{
    interface ITranslateText
    {
        Task<string> Translate(string uri, string text, string key);
    }
}
