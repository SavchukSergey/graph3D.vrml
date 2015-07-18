using System;
using System.Collections.Generic;
using Graph3D.Vrml.Parser;
using Graph3D.Vrml.Tokenizer;

namespace Graph3D.Vrml.Fields {

    public abstract class MField : Field {

        protected MField()
            : base() {
        }
    }

    public abstract class MField<T> : MField, IEnumerable<T> {

        protected MField() {
        }

        protected MField(params T[] items) {
            this._values = (T[])items.Clone();
        }

        private T[] _values = new T[0];
        public virtual IEnumerable<T> Values {
            get { return _values; }
        }

        public virtual T this[int index] {
            get { return _values[index]; }
            set { _values[index] = value; }
        }

        public virtual int length {
            get { return _values.Length; }
        }

        public virtual void AppendValue(T value) {
            T[] newValues = new T[_values.Length + 1];
            _values.CopyTo(newValues, 0);
            newValues[_values.Length] = value;
            _values = newValues;
        }

        public virtual void clearValues() {
            _values = new T[0];
        }

        public override string ToString() {
            string childStr = "";
            foreach (var item in this.Values) {
                if (!string.IsNullOrEmpty(childStr)) childStr += ", \r\n";
                childStr += item.ToString();
            }
            return string.Format("[{0}]", childStr);
        }

        protected static void ParseMField(ParserContext context, Action<ParserContext> itemParser) {
            var next = context.PeekNextToken();
            if (next.Type == VRML97TokenType.OpenBracket) {
                context.ReadOpenBracket();
                while (true) {
                    next = context.PeekNextToken();
                    if (next.Type == VRML97TokenType.CloseBracket) break;
                    itemParser(context);
                }
                context.ReadCloseBracket();
            } else {
                itemParser(context);
            }
        }


        #region IEnumerable<T> Members

        public IEnumerator<T> GetEnumerator() {
            return (IEnumerator<T>)Values.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return _values.GetEnumerator();
        }

        #endregion
    }
}
