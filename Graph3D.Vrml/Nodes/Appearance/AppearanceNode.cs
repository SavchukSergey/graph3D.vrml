using Graph3D.Vrml.Fields;

namespace Graph3D.Vrml.Nodes.Appearance {
    /// <summary>
    /// Appearance { 
    ///   exposedField SFNode material          NULL
    ///   exposedField SFNode texture           NULL
    ///   exposedField SFNode textureTransform  NULL
    /// }
    /// </summary>
    public class AppearanceNode : Node {

        public AppearanceNode() {
            addExposedField("material", new SFNode());
            addExposedField("texture", new SFNode());
            addExposedField("textureTransform", new SFNode());
        }

        public SFNode material {
            get { return getExposedField("material") as SFNode; }
        }

        public SFNode texture {
            get { return getExposedField("texture") as SFNode; }
        }

        public SFNode textureTransform {
            get { return getExposedField("textureTransform") as SFNode; }
        }

        protected override BaseNode createInstance() {
            return new AppearanceNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }

    }
}
