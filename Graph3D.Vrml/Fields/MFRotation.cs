namespace Graph3D.Vrml.Fields {
    public class MFRotation : MField<SFRotation> {

        public MFRotation() {
        }

        public override FieldType getType() {
            return FieldType.MFRotation;
        }
        
        public override void acceptVisitor(IFieldVisitor visitor) {
            visitor.visit(this);
        }

        public override Field clone() {
            var clone = new MFRotation();
            foreach (var child in this.values) {
                clone.appendValue((SFRotation)child.clone());
            }
            return clone;

        }
    }
}
