using System.IO;
using Graph3D.Vrml.Nodes;
using Graph3D.Vrml.Nodes.Geometry;
using Graph3D.Vrml.Parser;
using Graph3D.Vrml.Tokenizer;
using NUnit.Framework;

namespace Graph3D.Vrml.Test.Parser.Nodes.Geometry {
    [TestFixture]
    public class CylinderNodeTest {

        [Test]
        public void ParseTest() {
            var parser = new VrmlParser(new Vrml97Tokenizer(new StringReader(@"
#VRML V2.0 utf8
Shape {
    geometry Cylinder {
        bottom TRUE
        height 20.0
        radius 45.2
        side TRUE
        top FALSE
    }
}")));
            var scene = new VrmlScene();
            parser.Parse(scene);

            var cylinder = (scene.Root.Children[0] as ShapeNode).Geometry as CylinderNode;
            Assert.That(cylinder.Bottom.Value, Is.EqualTo(true));
            Assert.That(cylinder.Height.Value, Is.EqualTo(20f));
            Assert.That(cylinder.Radius.Value, Is.EqualTo(45.2f));
            Assert.That(cylinder.Side.Value, Is.EqualTo(true));
            Assert.That(cylinder.Top.Value, Is.EqualTo(false));
        }
    }
}