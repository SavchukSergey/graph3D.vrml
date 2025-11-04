using Graph3D.Vrml.Fields;

namespace Graph3D.Vrml.Nodes.Bindable {
    /// <summary>
    /// Viewpoint { 
    ///   eventIn      SFBool     set_bind
    ///   exposedField SFFloat    fieldOfView    0.785398  # (0,)
    ///   exposedField SFBool     jump           TRUE
    ///   exposedField SFRotation orientation    0 0 1 0   # [-1,1],(-,)
    ///   exposedField SFVec3f    position       0 0 10    # (-,)
    ///   field        SFString   description    ""
    ///   eventOut     SFTime     bindTime
    ///   eventOut     SFBool     isBound
    /// }
    /// </summary>
    public class ViewpointNode : BindableNode, IChildNode {

        public ViewpointNode() {
            AddExposedField("fieldOfView", new SFFloat(0.785398f));
            AddExposedField("orientation", new SFRotation(0, 0, 1, 0));
            AddExposedField("position", new SFVec3f(0, 0, 10));
            AddField("description", new SFString());
        }

        public SFVec3f Position {
            get { return GetExposedField<SFVec3f>("position"); }
        }

        public SFFloat FieldOfView {
            get { return GetExposedField<SFFloat>("fieldOfView"); }
        }

        public SFRotation Orientation {
            get { return GetExposedField<SFRotation>("orientation"); }
        }

        public SFString Description {
            get { return GetExposedField<SFString>("description"); }
        }

        protected override BaseNode CreateInstance() {
            return new ViewpointNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }

    }
}
