namespace Graph3D.Vrml.Fields {
    public class SFColor : Field {

        public SFColor() {
        }

        public SFColor(float red, float green, float blue) {
            _red = red;
            _green = green;
            _blue = blue;
        }

        private float _red;
        public float red {
            get { return _red; }
            set { _red = value; }
        }

        private float _green;
        public float green {
            get { return _green; }
            set { _green = value; }
        }
        
        private float _blue;
        public float blue {
            get { return _blue; }
            set { _blue = value; }
        }

        public override void AcceptVisitor(IFieldVisitor visitor) {
            visitor.visit(this);
        }

        public override Field Clone() {
            return new SFColor(_red, _green, _blue);
        }

        public override FieldType getType() {
            return FieldType.SFColor;
        }

        public override string ToString() {
            return string.Format("{{red={0}, green={1}, blue={2}}}", _red, _green, _blue);
        }

    }
}
