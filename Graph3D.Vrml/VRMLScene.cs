namespace Graph3D.Vrml.Nodes {
    public class VRMLScene {
        public VRMLScene() {
            root.name = "SCENEGRAPH";
        }

        public SceneGraphNode root = new SceneGraphNode();
    }
}
