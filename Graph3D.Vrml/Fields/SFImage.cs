namespace Graph3D.Vrml.Fields {
    public class SFImage : Field {
        
        public SFImage() {
            Value = new byte[0, 0, 0];
        }

        public byte[, ,] Value { get; set; }

        public int Width {
            get { return Value.GetLength(1); }
        }

        public int Height {
            get { return Value.GetLength(0); }
        }

        public int ComponentsNumber {
            get { return Value.GetLength(2); }
        }

        public override void AcceptVisitor(IFieldVisitor visitor) {
            visitor.visit(this);
        }

        public override Field Clone() {
            var clone = new SFImage { Value = (byte[, ,])Value.Clone() };
            return clone;
        }

        public override FieldType Type {
            get { return FieldType.SFImage; }
        }

    }
}
