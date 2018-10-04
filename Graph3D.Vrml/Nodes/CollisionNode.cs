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
            addExposedField("collide", new SFBool(true));
            addField("proxy", new SFNode());
            addEventOut("collideTime", new SFTime());
        }

        protected override BaseNode createInstance() {
            return new CollisionNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }

        public SFBool collide {
            get { return GetExposedField("collide") as SFBool; }
        }

        public SFNode proxy {
            get { return getField("proxy") as SFNode; }
        }

        public SFTime collideTime {
            get { return getEventOut("collideTime") as SFTime; }
        }

    }
}
