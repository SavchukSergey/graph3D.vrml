using System.IO;
using Graph3D.Vrml.Fields;
using Graph3D.Vrml.Nodes;
using Graph3D.Vrml.Parser;
using Graph3D.Vrml.Tokenizer;

namespace Graph3D.Vrml {
    //TODO: Read first vrml line when parse whole vrml
    public class Browser {

        public string getName() {
            return string.Empty;
        }

        public string getVersion() {
            return string.Empty;
        }

        public float getCurrentSpeed() {
            return 0.0f;
        }

        public float getCurrentFrameRate() {
            return 0.0f;
        }

        public string getWorldURL() {
            return string.Empty;
        }

        public void replaceWorld(BaseNode[] nodes) {
        }

        public BaseNode[] createVrmlFromString(string vrmlSyntax) {
            Vrml97Tokenizer tokenizer = new Vrml97Tokenizer(new StringReader(vrmlSyntax));
            VrmlParser parser = new VrmlParser(tokenizer);
            MFNode node = new MFNode();
            parser.Parse(node);
            return null;
        }

        public void createVrmlFromURL(string[] url, BaseNode node, string _event) {
        }

        public void addRoute(BaseNode fromNode, string fromEventOut, BaseNode toNode, string toEventIn) {
        }

        public void deleteRoute(BaseNode fromNode, string fromEventOut, BaseNode toNode, string toEventIn) {
        }

        public void loadURL(string[] url, string[] parameter) {
        }

        public void setDescription(string description) {
        }

    }
}
