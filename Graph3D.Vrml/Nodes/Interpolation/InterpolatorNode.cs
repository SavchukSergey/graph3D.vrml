using Graph3D.Vrml.Fields;

namespace Graph3D.Vrml.Nodes.Interpolation {

    public abstract class InterpolatorNode<T> : InterpolatorNode where T : MField, new() {

        public InterpolatorNode() {
            AddExposedField("keyValue", new T());
        }

        public MFRotation KeyValue {
            get { return GetExposedField<MFRotation>("keyValue"); }
        }

    }

    public abstract class InterpolatorNode : Node {

        protected InterpolatorNode() {
            AddExposedField("key", new MFFloat());
        }

        public MFFloat Key {
            get { return GetExposedField<MFFloat>("key"); }
        }

    }
}
