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
            addExposedField("fieldOfView", new SFFloat(0.785398f));
            addExposedField("orientation", new SFRotation(0, 0, 1, 0));
            addExposedField("position", new SFVec3f(0, 0, 10));
            addField("description", new SFString());
        }

        public SFVec3f position {
            get { return getExposedField("position") as SFVec3f; }
        }

        public SFFloat fieldOfView {
            get { return getExposedField("fieldOfView") as SFFloat; }
        }

        public SFRotation orientation {
            get { return getExposedField("orientation") as SFRotation; }
        }

        public SFString description {
            get { return getExposedField("description") as SFString; }
        }

        protected override BaseNode createInstance() {
            return new ViewpointNode();
        }

        public override void acceptVisitor(INodeVisitor visitor) {
            visitor.visit(this);
        }

    }
}
