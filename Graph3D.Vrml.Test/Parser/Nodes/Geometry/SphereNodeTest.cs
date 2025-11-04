using System.IO;
using Graph3D.Vrml.Nodes;
using Graph3D.Vrml.Nodes.Geometry;
using Graph3D.Vrml.Parser;
using Graph3D.Vrml.Tokenizer;
using NUnit.Framework;

namespace Graph3D.Vrml.Test.Parser.Nodes.Geometry {
    [TestFixture]
    public class SphereNodeTest {

        [Test]
        public void ParseTest() {
            var parser = new VrmlParser(new Vrml97Tokenizer(new StringReader(@"
#VRML V2.0 utf8
Shape {
    geometry Sphere {
        radius 2
    }
}")));
            var scene = new VrmlScene();
            parser.Parse(scene);

            var sphere = (scene.Root.Children[0] as ShapeNode).Geometry as SphereNode;
            Assert.That(sphere.Radius.Value, Is.EqualTo(2f));

        }
    }
}