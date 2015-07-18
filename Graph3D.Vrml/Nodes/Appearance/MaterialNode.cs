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
            addExposedField("ambientIntensity", new SFFloat(0.2f));
            addExposedField("diffuseColor", new SFColor(0.8f, 0.8f, 0.8f));
            addExposedField("emissiveColor", new SFColor(0, 0, 0));
            addExposedField("shininess", new SFFloat(0.2f));
            addExposedField("specularColor", new SFColor(0, 0, 0));
            addExposedField("transparency", new SFFloat(0));
        }

        public SFFloat ambientIntensity {
            get { return getExposedField("ambientIntensity") as SFFloat;}
        }

        public SFColor diffuseColor {
            get { return getExposedField("diffuseColor") as SFColor; }
        }

        public SFColor emissiveColor {
            get { return getExposedField("emissiveColor") as SFColor; }
        }

        public SFFloat shininess {
            get { return getExposedField("shininess") as SFFloat; }
        }

        public SFColor specularColor {
            get { return getExposedField("specularColor") as SFColor; }
        }

        public SFFloat transparency {
            get { return getExposedField("transparency") as SFFloat; }
        }

        protected override BaseNode createInstance() {
            return new MaterialNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }

    }
}
