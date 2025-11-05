using System.Collections.Generic;

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
            _values = [.. items];
        }

        private readonly List<T> _values = [];
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

        #region IEnumerable<T> Members

        public IEnumerator<T> GetEnumerator() {
            return (IEnumerator<T>)Values.GetEnumerator();
        }

        public TTarget? GetFirstOfType<TTarget>() where TTarget : class, T {
            foreach (var value in Values) {
                if (value is TTarget target) return target;
            }
            return default;
        }


        public IEnumerator<TTarget> GetAllOfType<TTarget>() where TTarget : class, T {
            foreach (var value in Values) {
                if (value is TTarget target) yield return target;
            }
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return _values.GetEnumerator();
        }

        #endregion
    }
}
