using Graph3D.Vrml.Fields;

namespace Graph3D.Vrml.Nodes.Geometry {

    /// <summary>
    /// Cone { 
    ///   field SFFloat   bottomRadius 1        # (0,infinity)
    ///   field SFFloat   height       2        # (0,infinity)
    ///   field SFBool    side TRUE
    ///   field SFBool    bottom TRUE
    /// }
    /// </summary>
    public class ConeNode : GeometryNode {

        public ConeNode() {
            addField("bottomRadius", new SFFloat(1));
            addField("height", new SFFloat(2));
            addField("side", new SFBool(true));
            addField("bottom", new SFBool(true));
        }


        public SFFloat bottomRadius {
            get { return getField("bottomRadius") as SFFloat; }
        }

        public SFFloat height {
            get { return getField("height") as SFFloat; }
        }

        public SFBool side {
            get { return getField("side") as SFBool; }
        }

        public SFBool bottom {
            get { return getField("bottom") as SFBool; }
        }

        protected override BaseNode createInstance() {
            return new ConeNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }

    }
}
