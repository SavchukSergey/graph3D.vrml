using Graph3D.Vrml.Fields;

namespace Graph3D.Vrml.Nodes.Sensors {
    public class TimeSensorNode : SensorNode {

        public TimeSensorNode() {
            AddExposedField("cycleInterval", new SFTime(1));
            AddExposedField("loop", new SFBool(false));
        }

        public SFTime CycleInterval {
            get { return GetExposedField<SFTime>("cycleInterval"); }
        }

        public SFBool Loop {
            get { return GetExposedField<SFBool>("loop"); }
        }

        protected override BaseNode CreateInstance() {
            return new TimeSensorNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }
    }
}
