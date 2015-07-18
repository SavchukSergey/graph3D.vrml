namespace Graph3D.Vrml.Fields {
    public class SFInt32 : Field {

        public SFInt32() {
        }

        public SFInt32(int value) {
            this._value = value;
        }

        private int _value;
        public int value {
            get { return _value; }
            set { _value = value; }
        }

        public static implicit operator int(SFInt32 field) {
            return field.value;
        }

        public override void AcceptVisitor(IFieldVisitor visitor) {
            visitor.visit(this);
        }

        public override FieldType getType() {
            return FieldType.SFInt32;
        }

        public override Field clone() {
            return new SFInt32(_value);
        }

    }
}
