using Graph3D.Vrml.Fields;

namespace Graph3D.Vrml.Nodes.Interpolation {
    public class OrientationInterpolatorNode : InterpolatorNode<MFRotation> {

        public OrientationInterpolatorNode() {
        }

        protected override BaseNode CreateInstance() {
            return new OrientationInterpolatorNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }

    }
}
