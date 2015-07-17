using Graph3D.Vrml.Fields;

namespace Graph3D.Vrml.Nodes.Bindable {
    /// <summary>
    /// Background { 
    ///   eventIn      SFBool   set_bind
    ///   exposedField MFFloat  groundAngle  []         # [0,/2]
    ///   exposedField MFColor  groundColor  []         # [0,1]
    ///   exposedField MFString backUrl      []
    ///   exposedField MFString bottomUrl    []
    ///   exposedField MFString frontUrl     []
    ///   exposedField MFString leftUrl      []
    ///   exposedField MFString rightUrl     []
    ///   exposedField MFString topUrl       []
    ///   exposedField MFFloat  skyAngle     []         # [0,]
    ///   exposedField MFColor  skyColor     0 0 0      # [0,1]
    ///   eventOut     SFBool   isBound
    /// }
    /// </summary>
    public class BackgroundNode : BindableNode {

        public BackgroundNode() {
            addExposedField("groundColor", new MFColor());
            addExposedField("groundAngle", new MFFloat());
            addExposedField("backUrl", new MFString());
            addExposedField("bottomUrl", new MFString());
            addExposedField("frontUrl", new MFString());
            addExposedField("leftUrl", new MFString());
            addExposedField("rightUrl", new MFString());
            addExposedField("topUrl", new MFString());
            addExposedField("skyAngle", new MFFloat());
            addExposedField("skyColor", new MFColor());
        }

        public MFColor groundColor {
            get { return getExposedField("groundColor") as MFColor; }
        }

        public MFFloat groundAngle {
            get { return getExposedField("groundAngle") as MFFloat; }
        }

        public MFString backUrl {
            get { return getExposedField("backUrl") as MFString; }
        }

        public MFString bottomUrl {
            get { return getExposedField("bottomUrl") as MFString; }
        }

        public MFString frontUrl {
            get { return getExposedField("frontUrl") as MFString; }
        }

        public MFString leftUrl {
            get { return getExposedField("leftUrl") as MFString; }
        }

        public MFString rightUrl {
            get { return getExposedField("rightUrl") as MFString; }
        }

        public MFString topUrl {
            get { return getExposedField("topUrl") as MFString; }
        }

        public MFColor skyColor {
            get { return getExposedField("skyColor") as MFColor; }
        }

        public MFFloat skyAngle {
            get { return getExposedField("skyAngle") as MFFloat; }
        }

        protected override BaseNode createInstance() {
            return new BackgroundNode();
        }

        public override void acceptVisitor(INodeVisitor visitor) {
            visitor.visit(this);
        }

    }
}
