using Graph3D.Vrml.Fields;

namespace Graph3D.Vrml.Nodes.Interpolation {
    public class PositionInterpolatorNode : InterpolatorNode<MFVec3f> {
        
        protected override BaseNode CreateInstance() {
            return new PositionInterpolatorNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }
    }
}
