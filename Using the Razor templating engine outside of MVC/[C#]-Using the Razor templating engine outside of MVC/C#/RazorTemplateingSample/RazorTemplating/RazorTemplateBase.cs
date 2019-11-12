using System.Text;

namespace RazorTemplateingSample.RazorTemplating
{
    public abstract class RazorTemplateBase<T>
    {
        public T Model { get; set; }

        public StringBuilder Buffer { get; set; }

        protected RazorTemplateBase()
        {
            Buffer = new StringBuilder();
        }

        public abstract void Execute();

        public virtual void Write(object value)
        {
            WriteLiteral(value);
        }

        public virtual void WriteLiteral(object value)
        {
            Buffer.Append(value);
        }

    }
}
