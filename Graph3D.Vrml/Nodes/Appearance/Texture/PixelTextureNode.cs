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
            AddField("repeatS", new SFBool(true));
            AddField("repeatT", new SFBool(true));
        }

        public SFImage Image {
            get { return GetExposedField<SFImage>("image"); }
        }


        public SFBool RepeatS
        {
            get { return GetExposedField<SFBool>("repeatS"); }
        }

        public SFBool RepeatT
        {
            get { return GetExposedField<SFBool>("repeatT"); }
        }

        protected override BaseNode CreateInstance() {
            return new PixelTextureNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }

    }
}
