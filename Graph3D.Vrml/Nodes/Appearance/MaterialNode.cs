using Graph3D.Vrml.Fields;

namespace Graph3D.Vrml.Nodes.Appearance {
    /// <summary>
    /// Material { 
    ///   exposedField SFFloat ambientIntensity  0.2         # [0,1]
    ///   exposedField SFColor diffuseColor      0.8 0.8 0.8 # [0,1]
    ///   exposedField SFColor emissiveColor     0 0 0       # [0,1]
    ///   exposedField SFFloat shininess         0.2         # [0,1]
    ///   exposedField SFColor specularColor     0 0 0       # [0,1]
    ///   exposedField SFFloat transparency      0           # [0,1]
    /// }
    /// </summary>
    public class MaterialNode : Node {

        private readonly SFFloat _ambientIntensityNode = new(0.2f);
        private SFColor _diffuseColorNode = new(0.8f, 0.8f, 0.8f);
        private SFColor _emissiveColorNode = new(0f, 0f, 0f);
        private readonly SFFloat _shininessNode = new(0.2f);
        private SFColor _specularColorNode = new(0f, 0f, 0f);
        private readonly SFFloat _transparencyNode = new(0f);

        public MaterialNode() {
            AddExposedField("ambientIntensity", _ambientIntensityNode);
            AddExposedField("diffuseColor", _diffuseColorNode);
            AddExposedField("emissiveColor", _emissiveColorNode);
            AddExposedField("shininess", _shininessNode);
            AddExposedField("specularColor", _specularColorNode);
            AddExposedField("transparency", _transparencyNode);
        }

        public float AmbientIntensity {
            get {
                return _ambientIntensityNode.Value;
            }
            set {
                if (_ambientIntensityNode.Value != value) {
                    _ambientIntensityNode.Value = value;
                    var handler = AmbientIntensityChanged;
                    if (handler != null) {
                        handler(this);
                    }
                }
            }
        }

        public SFColor DiffuseColor {
            get {
                return _diffuseColorNode;
            }
            set {
                if (_diffuseColorNode != value) {
                    _diffuseColorNode = value;
                    var handler = DiffuseColorChanged;
                    if (handler != null) {
                        handler(this);
                    }
                }
            }
        }

        public SFColor EmissiveColor {
            get {
                return _emissiveColorNode;
            }
            set {
                if (_emissiveColorNode != value) {
                    _emissiveColorNode = value;
                    var handler = EmissiveColorChanged;
                    if (handler != null) {
                        handler(this);
                    }
                }
            }
        }

        public float Shininess {
            get {
                return _shininessNode.Value;
            }
            set {
                if (_shininessNode.Value != value) {
                    _shininessNode.Value = value;
                    var handler = ShininessChanged;
                    if (handler != null) {
                        handler(this);
                    }
                }
            }
        }

        public SFColor SpecularColor {
            get {
                return _specularColorNode;
            }
            set {
                if (_specularColorNode != value) {
                    _specularColorNode = value;
                    var handler = SpecularColorChanged;
                    if (handler != null) {
                        handler(this);
                    }
                }
            }
        }

        public float Transparency {
            get {
                return _transparencyNode.Value;
            }
            set {
                if (_transparencyNode.Value != value) {
                    _transparencyNode.Value = value;
                    var handler = TransparencyChanged;
                    if (handler != null) {
                        handler(this);
                    }
                }
            }
        }

        public event VrmlEventHandler AmbientIntensityChanged;
        public event VrmlEventHandler DiffuseColorChanged;
        public event VrmlEventHandler EmissiveColorChanged;
        public event VrmlEventHandler ShininessChanged;
        public event VrmlEventHandler SpecularColorChanged;
        public event VrmlEventHandler TransparencyChanged;

        protected override BaseNode CreateInstance() {
            return new MaterialNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }

        public override BaseNode Clone() {
            return new MaterialNode {
                AmbientIntensity = AmbientIntensity,
                DiffuseColor = DiffuseColor,
                EmissiveColor = EmissiveColor,
                Shininess = Shininess,
                SpecularColor = SpecularColor,
                Transparency = Transparency
            };
        }

    }
}
