using Graph3D.Vrml.Nodes;

namespace Graph3D.Vrml.Fields {
    public class SFNode : Field {

        public SFNode() {
        }

        public SFNode(BaseNode value) {
            this._node = value;
        }

        private BaseNode _node ;
        public BaseNode node {
            get { return _node; }
            set { _node = value; }
        }

        public override void AcceptVisitor(IFieldVisitor visitor) {
            visitor.visit(this);
        }

        public override Field clone() {
            return new SFNode(_node != null ? _node.clone() : null);
        }

        public override FieldType getType() {
            return FieldType.SFNode;
        }

        public override string ToString() {
            return string.Format("[{0}]", _node);
        }


    }
}
