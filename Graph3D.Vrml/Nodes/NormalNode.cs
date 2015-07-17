using Graph3D.Vrml.Fields;

namespace Graph3D.Vrml.Nodes {
    /// <summary>
    /// Normal { 
    ///   exposedField MFVec3f vector  []   # (-,)
    /// }
    /// </summary>
    public class NormalNode : Node {

        public NormalNode() {
            addExposedField("vector", new MFVec3f());
        }

        public MFVec3f vector {
            get { return getExposedField("vector") as MFVec3f; }
        }

        protected override BaseNode createInstance() {
            return new NormalNode();
        }

        public override void acceptVisitor(INodeVisitor visitor) {
            visitor.visit(this);
        }

    }

}
