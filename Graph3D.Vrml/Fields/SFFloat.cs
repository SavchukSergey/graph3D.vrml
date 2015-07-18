namespace Graph3D.Vrml.Fields {
    public class SFFloat : Field {

        public SFFloat() {
        }

        public SFFloat(float value) {
            _value = value;
        }

        private float _value;
        public float value {
            get { return _value; }
            set { _value = value; }
        }

        public static implicit operator SFFloat(float value) {
            return new SFFloat(value);
        }

        public override void AcceptVisitor(IFieldVisitor visitor) {
            visitor.visit(this);
        }

        public override Field clone() {
            return new SFFloat(_value);
        }

        public override FieldType getType() {
            return FieldType.SFFloat;
        }

        public override string ToString() {
            return _value.ToString();
        }


    }
}
