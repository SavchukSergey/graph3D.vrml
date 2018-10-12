using Graph3D.Vrml.Nodes.Grouping;

namespace Graph3D.Vrml.Nodes {
    public class SceneGraphNode : GroupingNode {

        protected override BaseNode CreateInstance() {
            return new SceneGraphNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }

    }
}
