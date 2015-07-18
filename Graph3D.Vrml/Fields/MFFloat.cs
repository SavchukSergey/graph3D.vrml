namespace Graph3D.Vrml.Fields {
    public class MFFloat : MField<SFFloat> {

        public override void AcceptVisitor(IFieldVisitor visitor) {
            visitor.visit(this);
        }

        public override Field clone() {
            var clone = new MFFloat();
            foreach (var child in this.values) {
                clone.appendValue((SFFloat)child.clone());
            }
            return clone;
        }

        public override FieldType getType() {
            return FieldType.MFFloat;
        }

    }
}
