using Graph3D.Vrml.Nodes;

namespace Graph3D.Vrml.Fields {
    public class SFNode : Field {

        public SFNode() {
        }

        public SFNode(BaseNode value) {
            Node = value;
        }

        public BaseNode Node { get; set; }

        public override void AcceptVisitor(IFieldVisitor visitor) {
            visitor.Visit(this);
        }

        public override Field Clone() {
            return new SFNode(Node?.Clone());
        }

        public override FieldType Type {
            get { return FieldType.SFNode; }
        }

        public override string ToString() {
            return string.Format("[{0}]", Node);
        }
    }
}
