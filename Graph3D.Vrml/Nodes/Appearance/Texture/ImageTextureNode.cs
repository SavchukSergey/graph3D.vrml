using Graph3D.Vrml.Fields;
using System;
using System.Collections.Generic;
using System.Text;

namespace Graph3D.Vrml.Nodes.Appearance.Texture {
    public class ImageTextureNode : TextureNode {

        public ImageTextureNode() {
            AddExposedField("url", new SFString());
        }

        public SFString Url {
            get { return GetExposedField("url") as SFString; }
        }

        protected override BaseNode CreateInstance() {
            return new ImageTextureNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }

    }
}
