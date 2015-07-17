using Graph3D.Vrml.Fields;

namespace Graph3D.Vrml.Nodes.Appearance.Texture {
    public abstract class TextureNode : Node {

        public TextureNode() {
            addField("repeatS", new SFBool(true));
            addField("repeatT", new SFBool(true));
        }

        public SFBool repeatS {
            get { return getField("repeatS") as SFBool ; }
        }

        public SFBool repeatT {
            get { return getField("repeatT") as SFBool; }
        }
    }
}
