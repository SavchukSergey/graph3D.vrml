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
            this._values = (T[])items.Clone();
        }

        private T[] _values = new T[0];
        public virtual IEnumerable<T> values {
            get { return _values; }
        }

        public virtual T this[int index] {
            get { return _values[index]; }
            set { _values[index] = value; }
        }

        public virtual int length {
            get { return _values.Length; }
        }

        public virtual void appendValue(T value) {
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
            foreach (var item in this.values) {
                if (!string.IsNullOrEmpty(childStr)) childStr += ", \r\n";
                childStr += item.ToString();
            }
            return string.Format("[{0}]", childStr);
        }


        #region IEnumerable<T> Members

        public IEnumerator<T> GetEnumerator() {
            return (IEnumerator<T>)values.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return _values.GetEnumerator();
        }

        #endregion
    }
}
