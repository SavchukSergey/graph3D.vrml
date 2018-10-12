namespace Graph3D.Vrml.Fields {
    public class MFFloat : MField<SFFloat> {

        public override void AcceptVisitor(IFieldVisitor visitor) {
            visitor.Visit(this);
        }

        public override Field Clone() {
            var clone = new MFFloat();
            foreach (var child in Values) {
                clone.AppendValue((SFFloat)child.Clone());
            }
            return clone;
        }

        public override FieldType Type {
            get { return FieldType.MFFloat; }
        }

    }
}
