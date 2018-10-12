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
    public class MaterialNodeTest {

        [Test]
        public void ParseTest() {
            var parser = new VrmlParser(new Vrml97Tokenizer(new StringReader(@"
#VRML V2.0 utf8
Shape {
    appearance Appearance {
        material Material {
            diffuseColor 0.05 0.03 0.01
            ambientIntensity 0
            specularColor 0.07 0.12 0.12
            shininess 0.06615
            transparency 0
        }
    }
}")));
            var scene = new VrmlScene();
            parser.Parse(scene);

            AssertExt.AreEqual(new ShapeNode {
                Appearance = new AppearanceNode {
                    Material = new MaterialNode {
                        DiffuseColor = new SFColor(0.05f, 0.03f, 0.01f),
                        AmbientIntensity = 0,
                        SpecularColor = new SFColor(0.07f, 0.12f, 0.12f),
                        Shininess = 0.06615f,
                        Transparency = 0,
                    }
                }
            }, scene.Root.Children[0]);

        }
    }
}