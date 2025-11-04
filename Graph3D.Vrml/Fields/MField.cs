using System;
using System.Collections.Generic;
using Graph3D.Vrml.Parser;

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

        public virtual int Length => _values.Count;

        public virtual void AppendValue(T value) {
            _values.Add(value);
        }

        public virtual void ClearValues() {
            _values.Clear();
        }

        public override string ToString() {
            return $"[{string.Join(", \n\r", Values)}]";
        }

        protected static void ParseMField(ParserContext context, Action<ParserContext> itemParser) {
            var next = context.PeekNextToken();
            if (next.Value.Type == VRML97TokenType.OpenBracket) {
                context.ReadOpenBracket();
                while (true) {
                    next = context.PeekNextToken();
                    if (next.Value.Type == VRML97TokenType.CloseBracket) break;
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

        public TTarget GetFirstOfType<TTarget>() where TTarget : class, T {
            foreach (var value in Values) {
                if (value.GetType() == typeof(TTarget)) return value as TTarget;
            }
            return null;
        }


        public IEnumerator<TTarget> GetAllOfType<TTarget>() where TTarget : class, T {
            foreach (var value in Values) {
                if (value.GetType() == typeof(TTarget)) yield return value as TTarget;
            }
            yield break;
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return _values.GetEnumerator();
        }

        #endregion
    }
}
