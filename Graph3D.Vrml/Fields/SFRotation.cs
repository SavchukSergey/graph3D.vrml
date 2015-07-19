namespace Graph3D.Vrml.Fields {
    public class SFRotation : Field {

        public SFRotation() {
        }

        public SFRotation(float x, float y, float z, float angle) {
            X = x;
            Y = y;
            Z = z;
            Angle = angle;
        }

        public float X { get; set; }

        public float Y { get; set; }

        public float Z { get; set; }

        public float Angle { get; set; }

        public override void AcceptVisitor(IFieldVisitor visitor) {
            visitor.visit(this);
        }

        public override Field Clone() {
            return new SFRotation(X, Y, Z, Angle);
        }

        public override FieldType Type {
            get { return FieldType.SFRotation; }
        }

        public override string ToString() {
            return string.Format("{{x={0}, y={1}, z={2}, angle={3}}}", X, Y, Z, Angle);
        }

    }
}
