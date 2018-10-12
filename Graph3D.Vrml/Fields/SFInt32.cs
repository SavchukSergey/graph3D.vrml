namespace Graph3D.Vrml.Fields {
    public class SFInt32 : Field {

        public SFInt32() {
        }

        public SFInt32(int value) {
            Value = value;
        }

        public int Value { get; set; }

        public static implicit operator int(SFInt32 field) {
            return field.Value;
        }

        public override void AcceptVisitor(IFieldVisitor visitor) {
            visitor.Visit(this);
        }

        public override FieldType Type {
            get { return FieldType.SFInt32; }
        }

        public override Field Clone() {
            return new SFInt32(Value);
        }

    }
}
