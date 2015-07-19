namespace Graph3D.Vrml.Fields {
    public class SFTime : Field {

        public SFTime() {
        }

        public SFTime(double value) {
            Value = value;
        }

        public double Value { get; set; }

        public override FieldType Type {
            get { return FieldType.SFTime; }
        }

        public override void AcceptVisitor(IFieldVisitor visitor) {
            visitor.visit(this);
        }

        public override Field Clone() {
            return new SFTime(Value);
        }
    }
}
