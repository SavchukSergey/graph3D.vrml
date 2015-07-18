namespace Graph3D.Vrml.Fields {
    public class MFColor : MField<SFColor> {

        public override void AcceptVisitor(IFieldVisitor visitor) {
            visitor.visit(this);
        }

        public override Field clone() {
            MFColor clone = new MFColor();
            foreach (var child in this.values) {
                clone.appendValue((SFColor)child.clone());
            }
            return clone;
        }

        public override FieldType getType() {
            return FieldType.MFColor;
        }



    }
}
