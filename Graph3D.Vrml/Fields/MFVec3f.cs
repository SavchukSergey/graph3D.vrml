namespace Graph3D.Vrml.Fields {
    public class MFVec3f : MField<SFVec3f> {

        public MFVec3f() {
        }

        public MFVec3f(params SFVec3f[] items)
            : base(items) {
        }

        public override void AcceptVisitor(IFieldVisitor visitor) {
            visitor.visit(this);
        }

        public override Field clone() {
            var clone = new MFVec3f();
            foreach (var child in this.values) {
                clone.appendValue((SFVec3f)child.clone());
            }
            return clone;
        }

        public override FieldType getType() {
            return FieldType.MFVec3f;
        }

    }
}
