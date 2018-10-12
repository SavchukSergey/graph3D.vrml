namespace Graph3D.Vrml.Nodes {
    public class ScriptNode : BaseNode {

        public ScriptNode() {
        }

        protected override BaseNode CreateInstance() {
            return new ScriptNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }

    }
}
