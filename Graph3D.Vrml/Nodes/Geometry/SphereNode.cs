using Graph3D.Vrml.Fields;

namespace Graph3D.Vrml.Nodes.Geometry {
    /// <summary>
    /// Sphere { 
    ///   field SFFloat radius  1    # (0,)
    /// }
    /// </summary>
    public class SphereNode : GeometryNode {

        public SphereNode() {
            addField("radius", new SFFloat(1));
        }

        public SFFloat radius {
            get { return getField("radius") as SFFloat; }
        }

        protected override BaseNode createInstance() {
            return new SphereNode();
        }

        public override void acceptVisitor(INodeVisitor visitor) {
            visitor.visit(this);
        }

    }
}
