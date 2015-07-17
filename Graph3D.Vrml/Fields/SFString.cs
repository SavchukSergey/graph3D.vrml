namespace Graph3D.Vrml.Fields {
    public class SFString : Field {

        public SFString() {
        }

        public SFString(string value) {
            this._value = value;
        }

        private string _value;
        public string value {
            get { return _value; }
            set { _value = value; }
        }

        public static implicit operator string(SFString field) {
            return field._value;
        }

        public static implicit operator SFString(string value) {
            return new SFString(value);
        }

        public override void acceptVisitor(IFieldVisitor visitor) {
            visitor.visit(this);
        }

        public override Field clone() {
            return new SFString(_value);
        }

        public override FieldType getType() {
            return FieldType.SFString;
        }

        public override string ToString() {
            return string.Format("\"{0}\"", _value);
        }

    }
}
