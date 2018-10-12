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
            AddField("bottom", Bottom);
            AddField("height", Height);
            AddField("radius", Radius);
            AddField("side", Side);
            AddField("top", Top);
        }

        public SFBool Bottom { get; } = new SFBool(true);

        public SFFloat Height { get; } = new SFFloat(2);

        public SFFloat Radius { get; } = new SFFloat(1);

        public SFBool Side { get; } = new SFBool(true);

        public SFBool Top { get; } = new SFBool(true);

        protected override BaseNode CreateInstance() {
            return new CylinderNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }

        public override BaseNode Clone() {
            return new CylinderNode {
                Bottom = {
                    Value = Bottom.Value
                },
                Height = {
                    Value = Height.Value
                },
                Radius = {
                    Value = Radius.Value
                },
                Side = {
                    Value = Side.Value
                },
                Top = {
                    Value = Top.Value
                }
            };
        }

    }
}
