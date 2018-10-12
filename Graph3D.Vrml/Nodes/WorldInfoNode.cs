using Graph3D.Vrml.Fields;

namespace Graph3D.Vrml.Nodes {
    public class WorldInfoNode : BaseNode, IChildNode {

        public WorldInfoNode() {
            AddExposedField("info", new MFString());
            AddExposedField("title", new SFString());
        }

        protected override BaseNode CreateInstance() {
            return new WorldInfoNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }

    }
}