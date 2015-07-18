using Graph3D.Vrml.Fields;

namespace Graph3D.Vrml.Nodes.Sensors {
    public class TimeSensorNode : SensorNode {

        public TimeSensorNode() {
            addExposedField("cycleInterval", new SFTime(1));
            addExposedField("loop", new SFBool(false));
        }

        public SFTime cycleInterval {
            get { return getExposedField("cycleInterval") as SFTime; }
        }

        public SFBool loop {
            get { return getExposedField("loop") as SFBool; }
        }

        protected override BaseNode createInstance() {
            return new TimeSensorNode();
        }

        public override void AcceptVisitor(INodeVisitor visitor) {
            visitor.Visit(this);
        }
    }
}
