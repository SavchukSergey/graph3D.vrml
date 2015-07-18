using Graph3D.Vrml.Fields;

namespace Graph3D.Vrml.Nodes.Appearance.Texture {
    /// <summary>
    /// PixelTexture { 
    ///   exposedField SFImage  image      0 0 0 
    ///   field        SFBool   repeatS    TRUE
    ///   field        SFBool   repeatT    TRUE
    /// }
    /// </summary>
    public class PixelTextureNode : TextureNode {

        public PixelTextureNode() {
            addExposedField("image",  new SFImage());
        }

        public SFImage Image {
            get { return getExposedField("image") as SFImage; }
        }

        protected override BaseNode createInstance() {
            return new PixelTextureNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }

    }
}
