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
            AddExposedField("attenuation", new SFVec3f(1, 0, 0));
            AddExposedField("location", new SFVec3f(0, 0, 0));
            AddExposedField("radius", new SFFloat(1));
        }
        
        public SFVec3f Attenuation {
            get { return GetExposedField<SFVec3f>("attenuation"); }
        }

        public SFVec3f Location {
            get { return GetExposedField<SFVec3f>("location"); }
        }

        public SFFloat Radius {
            get { return GetExposedField<SFFloat>("radius"); }
        }

        protected override BaseNode CreateInstance() {
            return new PointLightNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }
    }
}
