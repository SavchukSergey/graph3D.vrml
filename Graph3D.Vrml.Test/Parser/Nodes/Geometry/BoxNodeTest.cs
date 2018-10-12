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
    public class BoxNodeTest {

        [Test]
        public void ParseTest() {
            var parser = new VrmlParser(new Vrml97Tokenizer(new StringReader(@"
#VRML V2.0 utf8
Shape {
    geometry Box {
        size 4 5 6
    }
}")));
            var scene = new VrmlScene();
            parser.Parse(scene);

            var box = (scene.Root.Children[0] as ShapeNode).Geometry.Node as BoxNode;
            Assert.AreEqual(4f, box.Size.X);
            Assert.AreEqual(5f, box.Size.Y);
            Assert.AreEqual(6f, box.Size.Z);

        }
    }
}