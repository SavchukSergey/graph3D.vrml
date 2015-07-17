namespace Graph3D.Vrml.Fields {
    public class MFString : MField<SFString> {

        public MFString() {
        }

        public MFString(params SFString[] items)
            : base(items) {
        }

        public override void acceptVisitor(IFieldVisitor visitor) {
            visitor.visit(this);
        }

        public override Field clone() {
            var clone = new MFString();
            foreach (var child in this.values) {
                clone.appendValue((SFString)child.clone());
            }
            return clone;
        }

        public override FieldType getType() {
            return FieldType.MFString;
        }


    }
}

