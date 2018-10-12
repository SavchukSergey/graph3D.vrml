namespace Graph3D.Vrml.Fields {
    public class SFBool : Field {

        public SFBool()
            : this(false) {
        }

        public SFBool(bool value) {
            Value = value;
        }

        public bool Value { get; set; }

        public static implicit operator bool(SFBool field) {
            return field.Value;
        }

        public override void AcceptVisitor(IFieldVisitor visitor) {
            visitor.Visit(this);
        }

        public override FieldType Type {
            get { return FieldType.SFBool; }
        }

        public override Field Clone() {
            return new SFBool(Value);
        }

        public override string ToString() {
            return Value ? "TRUE" : "FALSE";
        }

    }
}
