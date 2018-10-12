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

        public MaterialNode() {
            AddExposedField("ambientIntensity", new SFFloat(0.2f));
            AddExposedField("diffuseColor", new SFColor(0.8f, 0.8f, 0.8f));
            AddExposedField("emissiveColor", new SFColor(0, 0, 0));
            AddExposedField("shininess", new SFFloat(0.2f));
            AddExposedField("specularColor", new SFColor(0, 0, 0));
            AddExposedField("transparency", new SFFloat(0));
        }

        public SFFloat AmbientIntensity {
            get { return GetExposedField("ambientIntensity") as SFFloat;}
        }

        public SFColor DiffuseColor {
            get { return GetExposedField("diffuseColor") as SFColor; }
        }

        public SFColor EmissiveColor {
            get { return GetExposedField("emissiveColor") as SFColor; }
        }

        public SFFloat Shininess {
            get { return GetExposedField("shininess") as SFFloat; }
        }

        public SFColor SpecularColor {
            get { return GetExposedField("specularColor") as SFColor; }
        }

        public SFFloat Transparency {
            get { return GetExposedField("transparency") as SFFloat; }
        }

        protected override BaseNode CreateInstance() {
            return new MaterialNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }

    }
}
