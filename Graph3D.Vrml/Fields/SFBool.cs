namespace Graph3D.Vrml.Fields {
    public class SFBool : Field {

        public SFBool()
            : this(false) {
        }

        public SFBool(bool value) {
            _value = value;
        }

        private bool _value;
        public bool value {
            get { return _value; }
            set { _value = value; }
        }

        public static implicit operator bool(SFBool field) {
            return field.value;
        }

        public override void AcceptVisitor(IFieldVisitor visitor) {
            visitor.visit(this);
        }

        public override FieldType getType() {
            return FieldType.SFBool;
        }
        public override Field clone() {
            return new SFBool(_value);
        }

        public override string ToString() {
            return _value ? "TRUE" : "FALSE";
        }

    }
}
