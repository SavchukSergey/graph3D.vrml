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
            addExposedField("headlight", new SFBool(true));
            addExposedField("type", new MFString("WALK", "ANY"));
        }

        public SFBool headlight {
            get { return getExposedField("headlight") as SFBool; }
        }

        public MFString type {
            get { return getExposedField("type") as MFString; }
        }

        protected override BaseNode createInstance() {
            return new NavigationInfoNode();
        }

        public override void acceptVisitor(INodeVisitor visitor) {
            visitor.visit(this);
        }

    }
}
