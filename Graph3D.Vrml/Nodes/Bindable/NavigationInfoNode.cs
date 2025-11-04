using Graph3D.Vrml.Fields;

namespace Graph3D.Vrml.Nodes.Bindable {
    /// <summary>
    /// NavigationInfo { 
    ///   eventIn      SFBool   set_bind
    ///   exposedField MFFloat  avatarSize      [0.25, 1.6, 0.75] # [0,)
    ///   exposedField SFBool   headlight       TRUE
    ///   exposedField SFFloat  speed           1.0               # [0,)
    ///   exposedField MFString type            ["WALK", "ANY"]
    ///   exposedField SFFloat  visibilityLimit 0.0               # [0,)
    ///   eventOut     SFBool   isBound
    /// }
    /// </summary>
    public class NavigationInfoNode : BindableNode, IChildNode {

        public NavigationInfoNode() {
            AddExposedField("headlight", new SFBool(true));
            AddExposedField("type", new MFString("WALK", "ANY"));
        }

        public SFBool Headlight {
            get { return GetExposedField<SFBool>("headlight"); }
        }

        public MFString Type {
            get { return GetExposedField<MFString>("type"); }
        }

        protected override BaseNode CreateInstance() {
            return new NavigationInfoNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }

    }
}
