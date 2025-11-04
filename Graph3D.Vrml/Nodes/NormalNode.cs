using Graph3D.Vrml.Fields;

namespace Graph3D.Vrml.Nodes {
    /// <summary>
    /// Normal { 
    ///   exposedField MFVec3f vector  []   # (-,)
    /// }
    /// </summary>
    public class NormalNode : Node {

        public NormalNode() {
            AddExposedField("vector", new MFVec3f());
        }

        public MFVec3f Vector {
            get { return GetExposedField<MFVec3f>("vector"); }
        }

        protected override BaseNode CreateInstance() {
            return new NormalNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }

    }

}
