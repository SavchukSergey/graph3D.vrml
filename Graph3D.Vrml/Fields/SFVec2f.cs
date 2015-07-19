namespace Graph3D.Vrml.Fields {
    public class SFVec2f : Field {

        public SFVec2f()
            : this(0, 0) {
        }

        public SFVec2f(float x, float y) {
            X = x;
            Y = y;
        }

        public float X { get; set; }

        public float Y { get; set; }

        public override void AcceptVisitor(IFieldVisitor visitor) {
            visitor.visit(this);
        }

        public override Field Clone() {
            return new SFVec2f(X, Y);
        }

        public override FieldType Type {
            get { return FieldType.SFVec2f; }
        }

        public override string ToString() {
            return string.Format("SFVec2f: x={0}, y={1}", X, Y);
        }

    }
}
