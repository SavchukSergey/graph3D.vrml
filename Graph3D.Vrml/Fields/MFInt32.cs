namespace Graph3D.Vrml.Fields {
    public class MFInt32 : MField<SFInt32> {

        public override void AcceptVisitor(IFieldVisitor visitor) {
            visitor.visit(this);
        }

        public override Field Clone() {
            var clone = new MFInt32();
            foreach (var child in Values) {
                clone.AppendValue((SFInt32)child.Clone());
            }
            return clone;
        }

        public override FieldType Type {
            get { return FieldType.MFInt32; }
        }

    }
}
