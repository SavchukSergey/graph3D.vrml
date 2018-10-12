using Graph3D.Vrml.Fields;

namespace Graph3D.Vrml.Nodes.Geometry {
    /// <summary>
    /// Sphere { 
    ///   field SFFloat radius  1    # (0,)
    /// }
    /// </summary>
    public class SphereNode : GeometryNode {

        public SphereNode() {
            AddField("radius", new SFFloat(1));
        }

        public SFFloat Radius {
            get { return GetField("radius") as SFFloat; }
        }

        protected override BaseNode CreateInstance() {
            return new SphereNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }

    }
}
