namespace Graph3D.Vrml.Fields {
    public class MFRotation : MField<SFRotation> {

        public override FieldType Type {
            get { return FieldType.MFRotation; }
        }

        public override void AcceptVisitor(IFieldVisitor visitor) {
            visitor.visit(this);
        }

        public override Field Clone() {
            var clone = new MFRotation();
            foreach (var child in Values) {
                clone.AppendValue((SFRotation)child.Clone());
            }
            return clone;

        }
    }
}
