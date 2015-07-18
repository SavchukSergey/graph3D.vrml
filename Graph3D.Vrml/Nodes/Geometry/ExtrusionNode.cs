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
            addField("convex", new SFBool(true));
            addField("creaseAngle", new SFFloat(0));
            addField("crossSection", new MFVec2f(new SFVec2f(1, 1), new SFVec2f(1, -1) , new SFVec2f(-1, -1), new SFVec2f(-1, 1), new SFVec2f(1, 1)));
            addField("endCap", new SFBool(true));
            addField("scale", new MFVec2f(new SFVec2f(1, 1)));
            addField("spine", new MFVec3f(new SFVec3f(0, 0, 0), new SFVec3f(0, 1, 0)));
        }

        public SFBool convex {
            get { return getField("convex") as SFBool; }
        }

        public SFFloat creaseAngle {
            get { return getField("creaseAngle") as SFFloat; }
        }

        public MFVec2f crossSection {
            get { return getField("crossSection") as MFVec2f; }
        }

        public SFBool endCap {
            get { return getField("endCap") as SFBool; }
        }

        public MFVec2f scale {
            get { return getField("scale") as MFVec2f; }
        }

        public MFVec3f spine {
            get { return getField("spine") as MFVec3f; }
        }

        protected override BaseNode createInstance() {
            return new ExtrusionNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }

    }
}
