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
            _values = new List<T>(items);
        }

        private readonly List<T> _values = new List<T>();
        public virtual IEnumerable<T> Values {
            get { return _values; }
        }

        public virtual T this[int index] {
            get { return _values[index]; }
            set { _values[index] = value; }
        }

        public virtual int length => _values.Count;

        public virtual void AppendValue(T value) {
            _values.Add(value);
        }

        public virtual void clearValues() {
            _values.Clear();
        }

        public override string ToString() {
            return $"[{string.Join(", \n\r", Values)}]";
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
