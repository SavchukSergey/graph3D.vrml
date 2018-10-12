namespace Graph3D.Vrml.Fields {
    public class SFColor : Field {

        public SFColor() {
        }

        public SFColor(float red, float green, float blue) {
            Red = red;
            Green = green;
            Blue = blue;
        }

        public float Red { get; set; }

        public float Green { get; set; }

        public float Blue { get; set; }

        public override void AcceptVisitor(IFieldVisitor visitor) {
            visitor.Visit(this);
        }

        public override Field Clone() {
            return new SFColor(Red, Green, Blue);
        }

        public override FieldType Type {
            get { return FieldType.SFColor; }
        }

        public override string ToString() {
            return string.Format("{{red={0}, green={1}, blue={2}}}", Red, Green, Blue);
        }

    }
}
