using System.IO;
using Graph3D.Vrml.Nodes;
using Graph3D.Vrml.Nodes.Geometry;
using Graph3D.Vrml.Parser;
using Graph3D.Vrml.Tokenizer;
using NUnit.Framework;

namespace Graph3D.Vrml.Test.Parser.Nodes.Geometry {
    [TestFixture]
    public class ConeNodeTest {

        [Test]
        public void ParseTest() {
            var parser = new VrmlParser(new Vrml97Tokenizer(new StringReader(@"
#VRML V2.0 utf8
Shape {
    geometry Cone {
        bottomRadius 10.0
        height 20.0
        side TRUE
        bottom FALSE
    }
}")));
            var scene = new VrmlScene();
            parser.Parse(scene);

            var cone = (scene.Root.Children[0] as ShapeNode).Geometry as ConeNode;
            Assert.That(cone.BottomRadius.Value, Is.EqualTo(10f));
            Assert.That(cone.Height.Value, Is.EqualTo(20f));
            Assert.That(cone.Side.Value, Is.EqualTo(true));
            Assert.That(cone.Bottom.Value, Is.EqualTo(false));

        }
    }
}