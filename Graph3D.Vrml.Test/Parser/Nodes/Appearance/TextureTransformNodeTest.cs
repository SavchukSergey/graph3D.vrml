using System.IO;
using Graph3D.Vrml.Fields;
using Graph3D.Vrml.Nodes;
using Graph3D.Vrml.Nodes.Appearance;
using Graph3D.Vrml.Nodes.Geometry;
using Graph3D.Vrml.Parser;
using Graph3D.Vrml.Tokenizer;
using NUnit.Framework;

namespace Graph3D.Vrml.Test.Parser.Nodes.Appearance {
    [TestFixture]
    public class TextureTransformNodeTest {

        [Test]
        public void ParseTest() {
            var parser = new VrmlParser(new Vrml97Tokenizer(new StringReader(@"
#VRML V2.0 utf8
Shape {
    appearance Appearance {
        textureTransform TextureTransform {
        }
    }
}")));
            var scene = new VrmlScene();
            parser.Parse(scene);

            AssertExt.AreEqual(new ShapeNode {
                Appearance = new AppearanceNode {
                    TextureTransform = new TextureTransformNode {
                    }
                }
            }, scene.Root.Children[0]);

        }
    }
}