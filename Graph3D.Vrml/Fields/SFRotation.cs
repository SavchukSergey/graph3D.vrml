namespace Graph3D.Vrml.Fields {
    public class SFRotation : Field {

        public SFRotation() {
        }

        public SFRotation(float x, float y, float z, float angle) {
            _x = x;
            _y = y;
            _z = z;
            _angle = angle;
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
        
        private float _angle;
        public float angle {
            get { return _angle; }
            set { _angle = value; }
        }

        public override void AcceptVisitor(IFieldVisitor visitor) {
            visitor.visit(this);
        }

        public override Field Clone() {
            return new SFRotation(_x, _y, _z, _angle);
        }

        public override FieldType getType() {
            return FieldType.SFRotation;
        }

        public override string ToString() {
            return string.Format("{{x={0}, y={1}, z={2}, angle={3}}}", _x, _y, _z, angle);
        }

    }
}
