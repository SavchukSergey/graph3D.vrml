using Graph3D.Vrml.Fields;

namespace Graph3D.Vrml.Nodes {
    /// <summary>
    /// Shape {
    ///   exposedField SFNode appearance NULL
    ///   exposedField SFNode geometry   NULL
    /// }
    /// </summary>
    public class ShapeNode : Node, IChildNode {

        public ShapeNode() {
            AddExposedField("appearance", new SFNode());
            AddExposedField("geometry", new SFNode());
        }

        public SFNode Appearance {
            get { return GetExposedField("appearance") as SFNode; }
        }

        public SFNode Geometry {
            get { return GetExposedField("geometry") as SFNode; }
        }

        protected override BaseNode CreateInstance() {
            return new ShapeNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }
    }
}
