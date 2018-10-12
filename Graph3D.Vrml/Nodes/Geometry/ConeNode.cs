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
            AddField("bottomRadius", new SFFloat(1));
            AddField("height", new SFFloat(2));
            AddField("side", new SFBool(true));
            AddField("bottom", new SFBool(true));
        }


        public SFFloat BottomRadius {
            get { return GetField("bottomRadius") as SFFloat; }
        }

        public SFFloat Height {
            get { return GetField("height") as SFFloat; }
        }

        public SFBool Side {
            get { return GetField("side") as SFBool; }
        }

        public SFBool Bottom {
            get { return GetField("bottom") as SFBool; }
        }

        protected override BaseNode CreateInstance() {
            return new ConeNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }

    }
}
