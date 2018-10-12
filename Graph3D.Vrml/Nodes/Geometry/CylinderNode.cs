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
            AddField("bottom", new SFBool(true));
            AddField("height", new SFFloat(2));
            AddField("radius", new SFFloat(1));
            AddField("side", new SFBool(true));
            AddField("top", new SFBool(true));
        }


        public SFBool Bottom {
            get { return GetField("bottom") as SFBool; }
        }
        
        public SFFloat Height {
            get { return GetField("height") as SFFloat; }
        }

        public SFFloat Radius {
            get { return GetField("radius") as SFFloat; }
        }

        public SFBool Side {
            get { return GetField("side") as SFBool; }
        }

        public SFBool Top {
            get { return GetField("top") as SFBool; }
        }

        protected override BaseNode CreateInstance() {
            return new CylinderNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }

    }
}
