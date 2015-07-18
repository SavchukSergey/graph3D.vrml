using Graph3D.Vrml.Fields;

namespace Graph3D.Vrml.Nodes.LightSources {
    public abstract class LightSourceNode : Node {

        public LightSourceNode() {
            addExposedField("ambientIntensity", new SFFloat(0));
            addExposedField("intensity", new SFFloat(1));
            addExposedField("color", new SFColor(1, 1, 1));
            addExposedField("on", new SFBool(true));
        }


        public SFFloat ambientIntensity {
            get { return GetExposedField("ambientIntensity") as SFFloat; }
        }

        public SFFloat intensity {
            get { return GetExposedField("intensity") as SFFloat; }
        }

        public SFColor color {
            get { return GetExposedField("color") as SFColor; }
        }

        public SFBool on {
            get { return GetExposedField("on") as SFBool; }
        }

    }
}
