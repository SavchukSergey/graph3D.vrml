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
            AddExposedField("image",  new SFImage());
        }

        public SFImage Image {
            get { return GetExposedField("image") as SFImage; }
        }

        protected override BaseNode CreateInstance() {
            return new PixelTextureNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }

    }
}
