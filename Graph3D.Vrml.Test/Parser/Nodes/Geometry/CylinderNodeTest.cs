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
            var parser = new VrmlParser(new Vrml97Tokenizer(@"
#VRML V2.0 utf8
Shape {
    geometry Cylinder {
        bottom TRUE
        height 20.0
        radius 45.2
        side TRUE
        top FALSE
    }
}"));
            var scene = new VrmlScene();
            parser.Parse(scene);

            AssertExt.AreEqual(new CylinderNode {
                Bottom = { Value = true },
                Height = { Value = 20 },
                Radius = { Value = 45.2f },
                Side = { Value = true },
                Top = { Value = false }
            }, ((ShapeNode)scene.Root.Children[0]).Geometry);

        }
    }
}