using Graph3D.Vrml.Fields;

namespace Graph3D.Vrml.Nodes {
    /// <summary>
    /// Color { 
    ///   exposedField MFColor color  []         # [0,1]
    /// }
    /// </summary>
    public class ColorNode : Node {

        public ColorNode() {
            addExposedField("color", new MFColor());
        }

        public MFColor color {
            get { return getExposedField("color") as MFColor; }
        }

        protected override BaseNode createInstance() {
            return new ColorNode();
        }

        public override void acceptVisitor(INodeVisitor visitor) {
            visitor.visit(this);
        }

    }

}
