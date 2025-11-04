using System.IO;
using Graph3D.Vrml.Nodes;
using Graph3D.Vrml.Parser;
using Graph3D.Vrml.Tokenizer;
using NUnit.Framework;

namespace Graph3D.Vrml.Test.Parser.Nodes {
    [TestFixture]
    public class ShapeNodeTest {

        [Test]
        public void ParseTest() {
            var parser = new VrmlParser(new Vrml97Tokenizer(new StringReader(@"
#VRML V2.0 utf8
Shape {
    geometry Sphere {
        radius 2
    }
    appearance Appearance {
        material NULL
        texture NULL
        textureTransform NULL
    }
}")));
            var scene = new VrmlScene();
            parser.Parse(scene);

            var shape = scene.Root.Children[0] as ShapeNode;
            Assert.That(shape.Geometry, Is.Not.Null);
            Assert.That(shape.Appearance, Is.Not.Null);
        }
    }
}