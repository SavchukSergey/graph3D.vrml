using Graph3D.Vrml.Fields;

namespace Graph3D.Vrml.Nodes.Geometry {
    /// <summary>
    /// Extrusion { 
    ///   eventIn MFVec2f    set_crossSection
    ///   eventIn MFRotation set_orientation
    ///   eventIn MFVec2f    set_scale
    ///   eventIn MFVec3f    set_spine
    ///   field   SFBool     beginCap         TRUE
    ///   field   SFBool     ccw              TRUE
    ///   field   SFBool     convex           TRUE
    ///   field   SFFloat    creaseAngle      0                # [0,)
    ///   field   MFVec2f    crossSection     [ 1 1, 1 -1, -1 -1,
    ///                                        -1 1, 1  1 ]    # (-,)
    ///   field   SFBool     endCap           TRUE
    ///   field   MFRotation orientation      0 0 1 0          # [-1,1],(-,)
    ///   field   MFVec2f    scale            1 1              # (0,)
    ///   field   SFBool     solid            TRUE
    ///   field   MFVec3f    spine            [ 0 0 0, 0 1 0 ] # (-,)
    /// }
    /// </summary>
    public class ExtrusionNode : GeometryNode {

        public ExtrusionNode() {
            AddField("convex", new SFBool(true));
            AddField("creaseAngle", new SFFloat(0));
            AddField("crossSection", new MFVec2f(new SFVec2f(1, 1), new SFVec2f(1, -1) , new SFVec2f(-1, -1), new SFVec2f(-1, 1), new SFVec2f(1, 1)));
            AddField("endCap", new SFBool(true));
            AddField("scale", new MFVec2f(new SFVec2f(1, 1)));
            AddField("spine", new MFVec3f(new SFVec3f(0, 0, 0), new SFVec3f(0, 1, 0)));
        }

        public SFBool Convex {
            get { return GetField("convex") as SFBool; }
        }

        public SFFloat CreaseAngle {
            get { return GetField("creaseAngle") as SFFloat; }
        }

        public MFVec2f CrossSection {
            get { return GetField("crossSection") as MFVec2f; }
        }

        public SFBool EndCap {
            get { return GetField("endCap") as SFBool; }
        }

        public MFVec2f Scale {
            get { return GetField("scale") as MFVec2f; }
        }

        public MFVec3f Spine {
            get { return GetField("spine") as MFVec3f; }
        }

        protected override BaseNode CreateInstance() {
            return new ExtrusionNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }

    }
}
