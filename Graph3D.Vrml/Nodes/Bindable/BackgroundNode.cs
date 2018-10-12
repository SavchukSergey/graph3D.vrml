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
            get { return GetExposedField("groundColor") as MFColor; }
        }

        public MFFloat GroundAngle {
            get { return GetExposedField("groundAngle") as MFFloat; }
        }

        public MFString BackUrl {
            get { return GetExposedField("backUrl") as MFString; }
        }

        public MFString BottomUrl {
            get { return GetExposedField("bottomUrl") as MFString; }
        }

        public MFString FrontUrl {
            get { return GetExposedField("frontUrl") as MFString; }
        }

        public MFString LeftUrl {
            get { return GetExposedField("leftUrl") as MFString; }
        }

        public MFString RightUrl {
            get { return GetExposedField("rightUrl") as MFString; }
        }

        public MFString TopUrl {
            get { return GetExposedField("topUrl") as MFString; }
        }

        public MFColor SkyColor {
            get { return GetExposedField("skyColor") as MFColor; }
        }

        public MFFloat SkyAngle {
            get { return GetExposedField("skyAngle") as MFFloat; }
        }

        protected override BaseNode CreateInstance() {
            return new BackgroundNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }

    }
}
