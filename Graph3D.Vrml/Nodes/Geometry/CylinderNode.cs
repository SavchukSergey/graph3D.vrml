using Graph3D.Vrml.Fields;

namespace Graph3D.Vrml.Nodes.Geometry {
    
    /// <summary>
    /// Cylinder { 
    ///   field    SFBool    bottom  TRUE
    ///   field    SFFloat   height  2         # (0,)
    ///   field    SFFloat   radius  1         # (0,)
    ///   field    SFBool    side    TRUE
    ///   field    SFBool    top     TRUE
    /// }
    /// </summary>
    public class CylinderNode : GeometryNode {

        public CylinderNode() {
            addField("bottom", new SFBool(true));
            addField("height", new SFFloat(2));
            addField("radius", new SFFloat(1));
            addField("side", new SFBool(true));
            addField("top", new SFBool(true));
        }


        public SFBool bottom {
            get { return getField("bottom") as SFBool; }
        }
        
        public SFFloat height {
            get { return getField("height") as SFFloat; }
        }

        public SFFloat radius {
            get { return getField("radius") as SFFloat; }
        }

        public SFBool side {
            get { return getField("side") as SFBool; }
        }

        public SFBool top {
            get { return getField("top") as SFBool; }
        }

        protected override BaseNode createInstance() {
            return new CylinderNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }

    }
}
