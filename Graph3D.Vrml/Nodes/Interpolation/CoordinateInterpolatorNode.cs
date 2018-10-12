using Graph3D.Vrml.Fields;

namespace Graph3D.Vrml.Nodes.Interpolation {
    public class CoordinateInterpolatorNode : InterpolatorNode<MFVec3f> {

        public CoordinateInterpolatorNode() {
        }
        
        protected override BaseNode CreateInstance() {
            return new CoordinateInterpolatorNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }
    }
}
