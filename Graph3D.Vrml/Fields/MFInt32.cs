namespace Graph3D.Vrml.Fields {
    public class MFInt32 : MField<SFInt32> {

        public override void acceptVisitor(IFieldVisitor visitor) {
            visitor.visit(this);
        }

        public override Field clone() {
            var clone = new MFInt32();
            foreach (var child in this.values) {
                clone.appendValue((SFInt32)child.clone());
            }
            return clone;
        }

        public override FieldType getType() {
            return FieldType.MFInt32;
        }


    }
}
