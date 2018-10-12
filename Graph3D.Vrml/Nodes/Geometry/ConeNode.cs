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
            AddField("bottomRadius", BottomRadius);
            AddField("height", Height);
            AddField("side", Side);
            AddField("bottom", Bottom);
        }


        public SFFloat BottomRadius { get; } = new SFFloat(1);

        public SFFloat Height { get; } = new SFFloat(2);

        public SFBool Side { get; } = new SFBool(true);

        public SFBool Bottom { get; } = new SFBool(true);

        protected override BaseNode CreateInstance() {
            return new ConeNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }

        public override BaseNode Clone() {
            return new ConeNode {
                BottomRadius = {
                    Value = BottomRadius.Value
                },
                Height = {
                    Value = Height.Value
                },
                Side = {
                    Value = Side.Value
                },
                Bottom = {
                    Value = Bottom.Value
                }
            };
        }

    }
}
