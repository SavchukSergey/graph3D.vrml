using Graph3D.Vrml.Fields;

namespace Graph3D.Vrml.Nodes.Interpolation {

    public abstract class InterpolatorNode<T> : InterpolatorNode where T : MField, new() {

        public InterpolatorNode() {
            addExposedField("keyValue", new T());
        }

        public MFRotation keyValue {
            get { return GetExposedField("keyValue") as MFRotation; }
        }

    }

    public abstract class InterpolatorNode : Node {

        protected InterpolatorNode() {
            addExposedField("key", new MFFloat());
        }

        public MFFloat key {
            get { return GetExposedField("key") as MFFloat; }
        }

    }
}
