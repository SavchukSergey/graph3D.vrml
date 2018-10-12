using Graph3D.Vrml.Fields;
using Graph3D.Vrml.Nodes.Appearance.Texture;

namespace Graph3D.Vrml.Nodes.Appearance {
    /// <summary>
    /// Appearance { 
    ///   exposedField SFNode material          NULL
    ///   exposedField SFNode texture           NULL
    ///   exposedField SFNode textureTransform  NULL
    /// }
    /// </summary>
    public class AppearanceNode : Node {

        private readonly SFNode _materialNode = new SFNode();
        private readonly SFNode _textureNode = new SFNode();
        private readonly SFNode _textureTransformNode = new SFNode();

        public AppearanceNode() {
            AddExposedField("material", _materialNode);
            AddExposedField("texture", _textureNode);
            AddExposedField("textureTransform", _textureTransformNode);
        }
        public MaterialNode Material {
            get {
                return _materialNode.Node as MaterialNode;
            }
            set {
                if (_materialNode.Node != value) {
                    _materialNode.Node = value;
                    var handler = MaterialChanged;
                    if (handler != null) {
                        handler(this);
                    }
                }
            }
        }
        
        public TextureNode Texture {
            get {
                return _textureNode.Node as TextureNode;
            }
            set {
                if (_textureNode.Node != value) {
                    _textureNode.Node = value;
                    var handler = TextureChanged;
                    if (handler != null) {
                        handler(this);
                    }
                }
            }
        }
        
        public TextureTransformNode TextureTransform {
            get {
                return _textureTransformNode.Node as TextureTransformNode;
            }
            set {
                if (_textureTransformNode.Node != value) {
                    _textureTransformNode.Node = value;
                    var handler = TextureTransformChanged;
                    if (handler != null) {
                        handler(this);
                    }
                }
            }
        }

        public event VrmlEventHandler MaterialChanged;
        public event VrmlEventHandler TextureChanged;
        public event VrmlEventHandler TextureTransformChanged;

        protected override BaseNode CreateInstance() {
            return new AppearanceNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }
        
        public override BaseNode Clone() {
            return new AppearanceNode {
                Material = Material?.Clone() as MaterialNode,
                Texture = Texture?.Clone() as TextureNode,
                TextureTransform = TextureTransform?.Clone() as TextureTransformNode
            };
        }

    }
}
