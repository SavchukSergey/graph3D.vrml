using Graph3D.Vrml.Fields;
using Graph3D.Vrml.Nodes.Grouping;

namespace Graph3D.Vrml.Nodes {
    /// <summary>
    /// Group { 
    ///   eventIn      MFNode  addChildren
    ///   eventIn      MFNode  removeChildren
    ///   exposedField MFNode  children      []
    ///   field        SFVec3f bboxCenter    0 0 0     # (-,)
    ///   field        SFVec3f bboxSize      -1 -1 -1  # (0,) or -1,-1,-1
    ///   exposedField SFBool   collide TRUE
    ///   field SFNode   proxy NULL
    ///   eventOut SFTime   collideTime
    /// }
    /// </summary>
    public class CollisionNode : GroupingNode, IChildNode {

        public CollisionNode() {
            AddExposedField("collide", new SFBool(true));
            AddField("proxy", new SFNode());
            AddEventOut("collideTime", new SFTime());
        }

        protected override BaseNode CreateInstance() {
            return new CollisionNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }

        public SFBool Collide {
            get { return GetExposedField<SFBool>("collide"); }
        }

        public SFNode Proxy {
            get { return GetExposedField<SFNode>("proxy"); }
        }

        public SFTime CollideTime {
            get { return GetExposedField<SFTime>("collideTime"); }
        }

    }
}
