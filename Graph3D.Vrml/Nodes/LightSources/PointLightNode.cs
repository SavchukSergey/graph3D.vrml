using Graph3D.Vrml.Fields;

namespace Graph3D.Vrml.Nodes.LightSources {
    /// <summary>
    /// PointLight { 
    ///   exposedField SFFloat ambientIntensity  0       # [0,1]
    ///   exposedField SFVec3f attenuation       1 0 0   # [0,)
    ///   exposedField SFColor color             1 1 1   # [0,1]
    ///   exposedField SFFloat intensity         1       # [0,1]
    ///   exposedField SFVec3f location          0 0 0   # (-,)
    ///   exposedField SFBool  on                TRUE 
    ///   exposedField SFFloat radius            100     # [0,)
    /// }
    /// </summary>
    public class PointLightNode : LightSourceNode {

        public PointLightNode() {
            addExposedField("attenuation", new SFVec3f(1, 0, 0));
            addExposedField("location", new SFVec3f(0, 0, 0));
            addExposedField("radius", new SFFloat(1));
        }
        
        public SFVec3f attenuation {
            get { return getExposedField("attenuation") as SFVec3f; }
        }

        public SFVec3f location {
            get { return getExposedField("location") as SFVec3f; }
        }

        public SFFloat radius {
            get { return getExposedField("radius") as SFFloat; }
        }

        protected override BaseNode createInstance() {
            return new PointLightNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }
    }
}
