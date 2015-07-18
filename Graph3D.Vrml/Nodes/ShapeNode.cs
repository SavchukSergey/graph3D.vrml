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
            addExposedField("appearance", new SFNode());
            addExposedField("geometry", new SFNode());
        }

        public SFNode appearance {
            get { return GetExposedField("appearance") as SFNode; }
        }

        public SFNode geometry {
            get { return GetExposedField("geometry") as SFNode; }
        }

        protected override BaseNode createInstance() {
            return new ShapeNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }
    }
}
