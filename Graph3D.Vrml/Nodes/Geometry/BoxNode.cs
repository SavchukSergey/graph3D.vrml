using Graph3D.Vrml.Fields;

namespace Graph3D.Vrml.Nodes.Geometry {
    /// <summary>
    /// Box { 
    ///   field    SFVec3f size  2 2 2        # (0, )
    /// }
    /// </summary>
    public class BoxNode : GeometryNode {

        public BoxNode() {
            AddField("size", new SFVec3f(2, 2, 2));
        }

        public SFVec3f Size => GetField("size") as SFVec3f;

        protected override BaseNode CreateInstance() {
            return new BoxNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }

    }
}
