using Graph3D.Vrml.Fields;
using Graph3D.Vrml.Nodes.Appearance;
using Graph3D.Vrml.Nodes.Geometry;

namespace Graph3D.Vrml.Nodes {
    /// <summary>
    /// Shape {
    ///   exposedField SFNode appearance NULL
    ///   exposedField SFNode geometry   NULL
    /// }
    /// </summary>
    public class ShapeNode : Node, IChildNode {

        private readonly SFNode _appearanceNode = new();
        private readonly SFNode _geometryNode = new();

        public ShapeNode() {
            AddExposedField("appearance", _appearanceNode);
            AddExposedField("geometry", _geometryNode);
        }

        public AppearanceNode Appearance {
            get {
                return _appearanceNode.Node as AppearanceNode;
            }
            set {
                if (_appearanceNode.Node != value) {
                    _appearanceNode.Node = value;
                    var handler = AppearanceChanged;
                    if (handler != null) {
                        handler(this);
                    }
                }
            }
        }

        public GeometryNode Geometry {
            get {
                return _geometryNode.Node as GeometryNode;
            }
            set {
                if (_geometryNode.Node != value) {
                    _geometryNode.Node = value;
                    var handler = GeometryChanged;
                    if (handler != null) {
                        handler(this);
                    }
                }
            }
        }

        public event VrmlEventHandler AppearanceChanged;
        public event VrmlEventHandler GeometryChanged;

        protected override BaseNode CreateInstance() {
            return new ShapeNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }

        public override BaseNode Clone() {
            return new ShapeNode {
                Appearance = Appearance?.Clone() as AppearanceNode,
                Geometry = Geometry?.Clone() as GeometryNode
            };
        }

    }
}
