using Graph3D.Vrml.Fields;

namespace Graph3D.Vrml.Nodes.LightSources {
    public abstract class LightSourceNode : Node {

        public LightSourceNode() {
            AddExposedField("ambientIntensity", new SFFloat(0));
            AddExposedField("intensity", new SFFloat(1));
            AddExposedField("color", new SFColor(1, 1, 1));
            AddExposedField("on", new SFBool(true));
        }


        public SFFloat AmbientIntensity {
            get { return GetExposedField("ambientIntensity") as SFFloat; }
        }

        public SFFloat Intensity {
            get { return GetExposedField("intensity") as SFFloat; }
        }

        public SFColor Color {
            get { return GetExposedField("color") as SFColor; }
        }

        public SFBool On {
            get { return GetExposedField("on") as SFBool; }
        }

    }
}
