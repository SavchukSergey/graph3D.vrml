using Graph3D.Vrml.Fields;

namespace Graph3D.Vrml.Nodes.LightSources {
    /// <summary>
    /// DirectionalLight { 
    ///   exposedField SFFloat ambientIntensity  0        # [0,1]
    ///   exposedField SFColor color             1 1 1    # [0,1]
    ///   exposedField SFVec3f direction         0 0 -1   # (-,)
    ///   exposedField SFFloat intensity         1        # [0,1]
    ///   exposedField SFBool  on                TRUE 
    /// }
    /// </summary>
    public class DirectionalLightNode : LightSourceNode {

        public DirectionalLightNode() {
            addExposedField("direction", new SFVec3f(0, 0, -1));
        }

        public SFVec3f direction {
            get { return getExposedField("direction") as SFVec3f ; }
        }

        protected override BaseNode createInstance() {
            return new DirectionalLightNode();
        }

        public override void acceptVisitor(INodeVisitor visitor) {
            visitor.visit(this);
        }

    }
}
