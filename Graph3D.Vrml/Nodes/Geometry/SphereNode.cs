using Graph3D.Vrml.Fields;

namespace Graph3D.Vrml.Nodes.Geometry {
    /// <summary>
    /// Sphere { 
    ///   field SFFloat radius  1
    /// }
    /// </summary>
    public class SphereNode : GeometryNode {

        public SphereNode() {
            AddField("radius", Radius);
        }

        public SFFloat Radius { get; } = new SFFloat(1);

        protected override BaseNode CreateInstance() {
            return new SphereNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }

        public override BaseNode Clone() {
            return new SphereNode {
                Radius = {
                    Value = Radius.Value
                }
            };
        }

    }
}
