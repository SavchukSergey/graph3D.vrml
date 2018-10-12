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
    public class AppearanceNodeTest {

        [Test]
        public void ParseTest() {
            var parser = new VrmlParser(new Vrml97Tokenizer(new StringReader(@"
#VRML V2.0 utf8
Shape {
    appearance Appearance {
        material Material {
            diffuseColor 0.1 0.05 0.03
        }
        texture NULL
        textureTransform TextureTransform {
        }
    }
}")));
            var scene = new VrmlScene();
            parser.Parse(scene);

            AssertExt.AreEqual(new ShapeNode {
                Appearance = new AppearanceNode {
                    Material = new MaterialNode {
                        DiffuseColor = new SFColor(0.1f, 0.05f, 0.03f)
                    },
                    TextureTransform = new TextureTransformNode()

                }
            }, scene.Root.Children[0]);

        }
    }
}