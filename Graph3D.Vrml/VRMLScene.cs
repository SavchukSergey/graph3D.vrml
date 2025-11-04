using Graph3D.Vrml.Nodes;

namespace Graph3D.Vrml {
    public class VrmlScene {
        
        public VrmlScene() {
            Root.Name = "SCENEGRAPH";
        }

        public SceneGraphNode Root = new();
    }
}
