namespace Graph3D.Vrml.Fields {
    public class MFString : MField<SFString> {

        public MFString() {
        }

        public MFString(params SFString[] items)
            : base(items) {
        }

        public override void AcceptVisitor(IFieldVisitor visitor) {
            visitor.visit(this);
        }

        public override Field Clone() {
            var clone = new MFString();
            foreach (var child in Values) {
                clone.AppendValue((SFString)child.Clone());
            }
            return clone;
        }

        public override FieldType getType() {
            return FieldType.MFString;
        }


    }
}

