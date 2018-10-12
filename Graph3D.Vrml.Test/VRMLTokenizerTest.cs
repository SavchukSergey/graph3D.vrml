using Graph3D.Vrml.Nodes;
using Graph3D.Vrml.Nodes.Grouping;
using Graph3D.Vrml.Parser;
using Graph3D.Vrml.Tokenizer;
using NUnit.Framework;

namespace Graph3D.Vrml.Test {
    [TestFixture]
    public class VRMLTokenizerTest {
        [Test]
        public void TokenizerTest() {
            using (var stream = GetType().Assembly.GetManifestResourceStream(GetType(), "Ant.WRL")) {
                var tokenizer = new Vrml97Tokenizer(stream);
                int count = 0;
                while (tokenizer.ReadNextToken().Type != VRML97TokenType.EOF) {
                    count++;
                }
                Assert.AreEqual(39343, count, "Check node count");
            }
        }

        /// <summary>
        /// D2 example from VRML 97 specification
        /// </summary>
        [Test]
        public void SimpleExampleTest() {
            var scene = LoadScene("D2.wrl");
            var children = scene.root.Children;
            Assert.AreEqual(1, children.length, "Check root children count");
            Assert.IsTrue(children[0] is TransformNode, "Check first child");
            children = ((children[0]) as TransformNode).Children;
            Assert.AreEqual(4, children.length, "Check children count");
        }

        /// <summary>
        /// D3 example from VRML 97 specification
        /// </summary>
        [Test]
        public void InstancingExampleTest() {
            var scene = LoadScene("D3.wrl");
        }

        /// <summary>
        /// D4 example from VRML 97 specification
        /// </summary>
        [Test]
        public void PrototypeExampleTest() {
            var scene = LoadScene("D4.wrl");
        }

        /// <summary>
        /// D4 example from VRML 97 specification
        /// </summary>
        [Test]
        public void RoseExampleTest() {
            var scene = LoadScene("rose.wrl");
        }

        private VrmlScene LoadScene(string name) {
            using (var stream = GetType().Assembly.GetManifestResourceStream(this.GetType(), name)) {
                var tokenizer = new Vrml97Tokenizer(stream);
                var parser = new VrmlParser(tokenizer);
                var scene = new VrmlScene();
                parser.Parse(scene);
                return scene;
            }
        }
    }
}
