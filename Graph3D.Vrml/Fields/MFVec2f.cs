namespace Graph3D.Vrml.Fields {
    public class MFVec2f : MField<SFVec2f> {

        public MFVec2f() {
        }

        public MFVec2f(params SFVec2f[] items)
            : base(items) {
        }

        public override void AcceptVisitor(IFieldVisitor visitor) {
            visitor.visit(this);
        }

        public override Field Clone() {
            var clone = new MFVec2f();
            foreach (var child in Values) {
                clone.AppendValue((SFVec2f)child.Clone());
            }
            return clone;
        }

        public override FieldType Type {
            get { return FieldType.MFVec2f; }
        }

    }
}

