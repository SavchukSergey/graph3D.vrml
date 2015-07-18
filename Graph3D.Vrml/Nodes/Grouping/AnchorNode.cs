namespace Graph3D.Vrml.Nodes.Grouping {
    //TODO: Add fields.
    public class AnchorNode : GroupingNode, IChildNode {

        public AnchorNode() {
        }

        protected override BaseNode createInstance() {
            return new AnchorNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }
    }
}
