using Graph3D.Vrml.Fields;

namespace Graph3D.Vrml.Nodes
{
    /// <summary>
    /// Switch {
    /// exposedField    MFNode  choice      []
    /// exposedField    SFInt32 whichChoice -1
    /// }
    /// </summary>
public class Switch : Node
    {

        public Switch()
        {
            addExposedField("choice", new MFNode());
            addExposedField("whichChoice", new SFInt32(-1));
        }

        public MFNode choice
        {
            get { return GetExposedField("choice") as MFNode; }
        }

        public SFInt32 whichChoice
        {
            get { return GetExposedField("whichChoice") as SFInt32; }
        }

        protected override BaseNode createInstance()
        {
            return new CoordinateNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor)
        {
            visitor.Visit(this);
        }

    }
}
