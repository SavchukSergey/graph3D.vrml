namespace Graph3D.Vrml.Fields {
    public class SFString : Field {

        public SFString() {
        }

        public SFString(string value) {
            Value = value;
        }

        public string Value { get; set; }

        public static implicit operator string(SFString field) {
            return field.Value;
        }

        public static implicit operator SFString(string value) {
            return new SFString(value);
        }

        public override void AcceptVisitor(IFieldVisitor visitor) {
            visitor.Visit(this);
        }

        public override Field Clone() {
            return new SFString(Value);
        }

        public override FieldType Type {
            get { return FieldType.SFString; }
        }

        public override string ToString() {
            return string.Format("\"{0}\"", Value);
        }

    }
}
