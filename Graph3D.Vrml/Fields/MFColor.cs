namespace Graph3D.Vrml.Fields {
    public class MFColor : MField<SFColor> {

        public override void AcceptVisitor(IFieldVisitor visitor) {
            visitor.Visit(this);
        }

        public override Field Clone() {
            var clone = new MFColor();
            foreach (var child in Values) {
                clone.AppendValue((SFColor)child.Clone());
            }
            return clone;
        }

        public override FieldType Type {
            get { return FieldType.MFColor; }
        }

    }
}
