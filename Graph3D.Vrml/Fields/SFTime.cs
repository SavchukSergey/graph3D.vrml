namespace Graph3D.Vrml.Fields {
    public class SFTime : Field {

        public SFTime() {
        }

        public SFTime(double value) {
            this._value = value;
        }

        private double _value;
        public double value {
            get { return this._value; }
            set { this._value = value; }
        }

        public override FieldType getType() {
            return FieldType.SFTime;
        }
        
        public override void AcceptVisitor(IFieldVisitor visitor) {
            visitor.visit(this);
        }

        public override Field clone() {
            return new SFTime(_value);
        }
    }
}
