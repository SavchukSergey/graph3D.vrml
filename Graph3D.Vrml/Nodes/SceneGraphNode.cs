using Graph3D.Vrml.Nodes.Grouping;

namespace Graph3D.Vrml.Nodes {
    public class SceneGraphNode : GroupingNode {

        public SceneGraphNode() {
        }

        protected override BaseNode createInstance() {
            return new SceneGraphNode();
        }

        public override void acceptVisitor(INodeVisitor visitor) {
            visitor.visit(this);
        }

    }
}
