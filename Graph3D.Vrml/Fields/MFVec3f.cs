namespace Graph3D.Vrml.Fields {
    public class MFVec3f : MField<SFVec3f> {

        public MFVec3f() {
        }

        public MFVec3f(params SFVec3f[] items)
            : base(items) {
        }

        public override void AcceptVisitor(IFieldVisitor visitor) {
            visitor.Visit(this);
        }

        public override Field Clone() {
            var clone = new MFVec3f();
            foreach (var child in this.Values) {
                clone.AppendValue((SFVec3f)child.Clone());
            }
            return clone;
        }

        public override FieldType Type {
            get { return FieldType.MFVec3f; }
        }

    }
}
