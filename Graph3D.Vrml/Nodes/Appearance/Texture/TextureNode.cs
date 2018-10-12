using Graph3D.Vrml.Fields;

namespace Graph3D.Vrml.Nodes.Appearance.Texture {
    public abstract class TextureNode : Node {

        public TextureNode() {
            AddField("repeatS", new SFBool(true));
            AddField("repeatT", new SFBool(true));
        }

        public SFBool RepeatS {
            get { return GetField("repeatS") as SFBool ; }
        }

        public SFBool RepeatT {
            get { return GetField("repeatT") as SFBool; }
        }
    }
}
