namespace Graph3D.Vrml.Fields {
    public class SFFloat : Field {

        public SFFloat() {
        }

        public SFFloat(float value) {
            Value = value;
        }

        public float Value { get; set; }

        public static implicit operator SFFloat(float value) {
            return new SFFloat(value);
        }

        public override void AcceptVisitor(IFieldVisitor visitor) {
            visitor.Visit(this);
        }

        public override Field Clone() {
            return new SFFloat(Value);
        }

        public override FieldType Type {
            get { return FieldType.SFFloat; }
        }

        public override string ToString() {
            return Value.ToString();
        }


    }
}
