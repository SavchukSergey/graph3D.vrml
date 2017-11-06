using Graph3D.Vrml.Fields;

namespace Graph3D.Vrml.Nodes {
    public class WorldInfoNode : BaseNode, IChildNode {

        public WorldInfoNode() {
            addExposedField("info", new MFString());
            addExposedField("title", new SFString());
        }

        protected override BaseNode createInstance() {
            return new WorldInfoNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }

    }
}