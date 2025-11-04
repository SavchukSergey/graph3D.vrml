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
            AddExposedField("groundColor", new MFColor());
            AddExposedField("groundAngle", new MFFloat());
            AddExposedField("backUrl", new MFString());
            AddExposedField("bottomUrl", new MFString());
            AddExposedField("frontUrl", new MFString());
            AddExposedField("leftUrl", new MFString());
            AddExposedField("rightUrl", new MFString());
            AddExposedField("topUrl", new MFString());
            AddExposedField("skyAngle", new MFFloat());
            AddExposedField("skyColor", new MFColor());
        }

        public MFColor GroundColor {
            get { return GetExposedField<MFColor>("groundColor"); }
        }

        public MFFloat GroundAngle {
            get { return GetExposedField<MFFloat>("groundAngle"); }
        }

        public MFString BackUrl {
            get { return GetExposedField<MFString>("backUrl"); }
        }

        public MFString BottomUrl {
            get { return GetExposedField<MFString>("bottomUrl"); }
        }

        public MFString FrontUrl {
            get { return GetExposedField<MFString>("frontUrl"); }
        }

        public MFString LeftUrl {
            get { return GetExposedField<MFString>("leftUrl"); }
        }

        public MFString RightUrl {
            get { return GetExposedField<MFString>("rightUrl"); }
        }

        public MFString TopUrl {
            get { return GetExposedField<MFString>("topUrl"); }
        }

        public MFColor SkyColor {
            get { return GetExposedField<MFColor>("skyColor"); }
        }

        public MFFloat SkyAngle {
            get { return GetExposedField<MFFloat>("skyAngle"); }
        }

        protected override BaseNode CreateInstance() {
            return new BackgroundNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }

    }
}
