using System.IO;
using Graph3D.Vrml.Fields;
using Graph3D.Vrml.Nodes;
using Graph3D.Vrml.Nodes.Geometry;
using Graph3D.Vrml.Parser;
using Graph3D.Vrml.Parser.Statements;
using Graph3D.Vrml.Tokenizer;
using NUnit.Framework;

namespace Graph3D.Vrml.Test.Parser.Statements {
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

            var cone = (scene.Root.Children[0] as ShapeNode).Geometry.Node as ConeNode;
            Assert.AreEqual(10f, cone.BottomRadius.Value);
            Assert.AreEqual(20f, cone.Height.Value);
            Assert.AreEqual(true, cone.Side.Value);
            Assert.AreEqual(false, cone.Bottom.Value);

        }
    }
}