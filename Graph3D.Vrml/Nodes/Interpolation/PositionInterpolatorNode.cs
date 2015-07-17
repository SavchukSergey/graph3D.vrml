using Graph3D.Vrml.Fields;

namespace Graph3D.Vrml.Nodes.Interpolation {
    public class PositionInterpolatorNode : InterpolatorNode<MFVec3f> {
        
        protected override BaseNode createInstance() {
            return new PositionInterpolatorNode();
        }

        public override void acceptVisitor(INodeVisitor visitor) {
            visitor.visit(this);
        }
    }
}
