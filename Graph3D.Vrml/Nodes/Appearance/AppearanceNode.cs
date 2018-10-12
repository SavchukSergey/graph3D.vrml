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
            AddExposedField("material", new SFNode());
            AddExposedField("texture", new SFNode());
            AddExposedField("textureTransform", new SFNode());
        }

        public SFNode Material {
            get { return GetExposedField("material") as SFNode; }
        }

        public SFNode Texture {
            get { return GetExposedField("texture") as SFNode; }
        }

        public SFNode TextureTransform {
            get { return GetExposedField("textureTransform") as SFNode; }
        }

        protected override BaseNode CreateInstance() {
            return new AppearanceNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }

    }
}
