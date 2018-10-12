using Graph3D.Vrml.Fields;

namespace Graph3D.Vrml.Nodes {
    /// <summary>
    /// Coordinate { 
    ///   exposedField MFVec3f point  []      # (-,)
    ///}
    /// </summary>
    public class CoordinateNode : Node {

        public CoordinateNode() {
            AddExposedField("point", new MFVec3f());
        }

        public MFVec3f Point {
            get { return GetExposedField("point") as MFVec3f; }
        }

        protected override BaseNode CreateInstance() {
            return new CoordinateNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }

    }
}
