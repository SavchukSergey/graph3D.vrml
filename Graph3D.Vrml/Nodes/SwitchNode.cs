using Graph3D.Vrml.Fields;

namespace Graph3D.Vrml.Nodes {
    /// <summary>
    /// Switch {
    /// exposedField    MFNode  choice      []
    /// exposedField    SFInt32 whichChoice -1
    /// }
    /// </summary>
    public class SwitchNode : Node {

        public SwitchNode() {
            AddExposedField("choice", new MFNode());
            AddExposedField("whichChoice", new SFInt32(-1));
        }

        public MFNode Choice {
            get { return GetExposedField("choice") as MFNode; }
        }

        public SFInt32 WhichChoice {
            get { return GetExposedField("whichChoice") as SFInt32; }
        }

        protected override BaseNode CreateInstance() {
            return new CoordinateNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }

    }
}
