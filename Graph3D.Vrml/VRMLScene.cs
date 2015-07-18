using Graph3D.Vrml.Nodes;

namespace Graph3D.Vrml {
    public class VrmlScene {
        
        public VrmlScene() {
            root.name = "SCENEGRAPH";
        }

        public SceneGraphNode root = new SceneGraphNode();
    }
}
