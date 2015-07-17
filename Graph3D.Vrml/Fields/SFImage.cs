namespace Graph3D.Vrml.Fields {
    public class SFImage : Field {

        private byte[,,] _value = new byte[0, 0, 0];
        public byte[,,] value {
            get { return _value; }
            set { _value = value; }
        }

        public int width {
            get { return _value.GetLength(1); }
        }

        public int height {
            get { return _value.GetLength(0); }
        }

        public int componentsNumber {
            get { return _value.GetLength(2); }
        }

        public override void acceptVisitor(IFieldVisitor visitor) {
            visitor.visit(this);
        }

        public override Field clone() {
            SFImage clone = new SFImage();
            clone._value = (byte[,,])_value.Clone();
            return clone;
        }

        public override FieldType getType() {
            return FieldType.SFImage;
        }


    }
}
