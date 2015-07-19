namespace Graph3D.Vrml.Fields {
    public class SFVec3f : Field {

        public SFVec3f()
            : this(0, 0, 0) {
        }

        public SFVec3f(float x, float y, float z) {
            _x = x;
            _y = y;
            _z = z;
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

        private float _z;
        public float z {
            get { return _z; }
            set { _z = value; }
        }

        public override void AcceptVisitor(IFieldVisitor visitor) {
            visitor.visit(this);
        }

        public override Field Clone() {
            return new SFVec3f(_x, _y, _z);
        }

       public override FieldType Type {
           get { return FieldType.SFVec3f; }
       }

        public override string ToString() {
            return string.Format("{{x={0}, y={1}, z={2}}}", _x, _y, _z);
        }

    }
}
