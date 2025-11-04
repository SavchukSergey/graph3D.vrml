using Graph3D.Vrml.Fields;

namespace Graph3D.Vrml.Nodes.Appearance.Texture {
    public class ImageTextureNode : TextureNode {

        public ImageTextureNode() {
            AddExposedField("url", new SFString());
        }

        public SFString Url {
            get { return GetExposedField< SFString>("url"); }
        }

        protected override BaseNode CreateInstance() {
            return new ImageTextureNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }

    }
}
