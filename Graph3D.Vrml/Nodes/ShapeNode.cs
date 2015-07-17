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
            get { return getExposedField("appearance") as SFNode; }
        }

        public SFNode geometry {
            get { return getExposedField("geometry") as SFNode; }
        }

        protected override BaseNode createInstance() {
            return new ShapeNode();
        }

        public override void acceptVisitor(INodeVisitor visitor) {
            visitor.visit(this);
        }
    }
}
