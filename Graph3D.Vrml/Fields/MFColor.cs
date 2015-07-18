namespace Graph3D.Vrml.Fields {
    public class MFColor : MField<SFColor> {

        public override void AcceptVisitor(IFieldVisitor visitor) {
            visitor.visit(this);
        }

        public override Field Clone() {
            MFColor clone = new MFColor();
            foreach (var child in this.Values) {
                clone.AppendValue((SFColor)child.Clone());
            }
            return clone;
        }

        public override FieldType getType() {
            return FieldType.MFColor;
        }



    }
}
