using Graph3D.Vrml.Nodes;
using Graph3D.Vrml.Nodes.Geometry;
using Graph3D.Vrml.Parser;
using Graph3D.Vrml.Tokenizer;
using NUnit.Framework;

namespace Graph3D.Vrml.Test.Parser.Nodes.Geometry {
    [TestFixture]
    public class BoxNodeTest {

        [Test]
        public void ParseTest() {
            var parser = new VrmlParser(new Vrml97Tokenizer(@"
#VRML V2.0 utf8
Shape {
    geometry Box {
        size 4 5 6
    }
}"));
            var scene = new VrmlScene();
            parser.Parse(scene);

            AssertExt.AreEqual(new BoxNode {
                Size = { X = 4, Y = 5, Z = 6 }
            }, ((ShapeNode)scene.Root.Children[0]).Geometry);

        }
    }
}