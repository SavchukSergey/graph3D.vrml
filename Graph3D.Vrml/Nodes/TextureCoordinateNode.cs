using Graph3D.Vrml.Fields;

namespace Graph3D.Vrml.Nodes {
    /// <summary>
    /// TextureCoordinate { 
    ///   exposedField MFVec2f point  []      # (-,)
    /// }
    /// </summary>
    public class TextureCoordinateNode : Node {

        public TextureCoordinateNode() {
            AddExposedField("point", new MFVec2f());
        }

        public MFVec2f Point {
            get { return GetExposedField("point") as MFVec2f; }
        }

        protected override BaseNode CreateInstance() {
            return new TextureCoordinateNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }
    }
}
