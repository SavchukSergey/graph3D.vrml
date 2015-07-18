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

        public override Field clone() {
            var clone = new MFVec2f();
            foreach (var child in this.values) {
                clone.appendValue((SFVec2f)child.clone());
            }
            return clone;
        }

        public override FieldType getType() {
            return FieldType.MFVec2f;
        }


    }
}

