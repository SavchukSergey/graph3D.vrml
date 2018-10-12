using Graph3D.Vrml.Fields;

namespace Graph3D.Vrml.Nodes.Geometry {
    /// <summary>
    /// Box { 
    ///   field    SFVec3f size  2 2 2        # (0, )
    /// }
    /// </summary>
    public class BoxNode : GeometryNode {

        public BoxNode() {
            AddField("size", Size);
        }

        public SFVec3f Size { get; } = new SFVec3f(2, 2, 2);

        protected override BaseNode CreateInstance() {
            return new BoxNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }

        public override BaseNode Clone() {
            return new BoxNode {
                Size = {
                    X = Size.X,
                    Y = Size.Y,
                    Z = Size.Z
                }
            };
        }

    }
}
