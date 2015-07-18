namespace Graph3D.Vrml.Fields {
    public class SFVec2f : Field {

        public SFVec2f()
            : this(0, 0) {
        }

        public SFVec2f(float x, float y) {
            _x = x;
            _y = y;
        }

        private float _x;
        public float x {
            get { return _x; }
            set { _x = value; }
        }

        private float _y;
        public float y {
            get { return _y; }
            set { _y = value; }
        }

        public override void AcceptVisitor(IFieldVisitor visitor) {
            visitor.visit(this);
        }

        public override Field clone() {
            return new SFVec2f(_x, _y);
        }

        public override FieldType getType() {
            return FieldType.SFVec2f;
        }

        public override string ToString() {
            return string.Format("SFVec2f: x={0}, y={1}", _x, _y);
        }

    }
}
