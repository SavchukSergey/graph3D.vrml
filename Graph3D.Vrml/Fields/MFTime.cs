namespace Graph3D.Vrml.Fields {
    public class MFTime : MField<SFTime> {

        public MFTime() {
        }

        public MFTime(params SFTime[] items)
            : base(items) {
        }

        public override void AcceptVisitor(IFieldVisitor visitor) {
            visitor.Visit(this);
        }

        public override Field Clone() {
            var clone = new MFTime();
            foreach (var child in this.Values) {
                clone.AppendValue((SFTime)child.Clone());
            }
            return clone;
        }

        public override FieldType Type {
            get { return FieldType.MFTime; }
        }

    }
}
