using System;
using System.Diagnostics;
using System.IO;
using Graph3D.Vrml.Nodes.Grouping;
using Graph3D.Vrml.Parser;
using Graph3D.Vrml.Tokenizer;
using NUnit.Framework;

namespace Graph3D.Vrml.Test {
    [TestFixture]
    public class VRMLTokenizerTest {
        [Test]
        public void TokenizerTest() {
            using var stream = GetType().Assembly.GetManifestResourceStream(GetType(), "Ant.WRL")!;
            using var reader = new StreamReader(stream);
            var content = reader.ReadToEnd();
            var tokenizer = new Vrml97Tokenizer(content);
            int count = 0;
            while (tokenizer.ReadNextToken().Type != VRML97TokenType.EOF) {
                count++;
            }
            Assert.That(count, Is.EqualTo(39343), "Check node count");
        }

        [Test]
        public void TokenizerBenchmarkTest() {
            using var stream = GetType().Assembly.GetManifestResourceStream(GetType(), "Ant.WRL")!;
            using var reader = new StreamReader(stream);
            var content = reader.ReadToEnd();

            var stopwatch = new Stopwatch();
            var memStart = GC.GetAllocatedBytesForCurrentThread();
            stopwatch.Start();

            var count = 100;
            for (var i = 0; i < count; i++) {
                var tokenizer = new Vrml97Tokenizer(content);
                while (tokenizer.ReadNextToken().Type != VRML97TokenType.EOF) {
                }
            }

            var memEnd = GC.GetAllocatedBytesForCurrentThread();

            var rps = count / stopwatch.Elapsed.TotalSeconds;
            var timeUs = stopwatch.Elapsed.TotalMicroseconds / count;
            var mpd = (memEnd - memStart) / count;
            Console.WriteLine($"Parses per second:  {rps}");
            Console.WriteLine($"Parses time:        {Math.Round(timeUs)}us");
            Console.WriteLine($"Heap per parse:     {mpd} bytes");
        }

        /// <summary>
        /// D2 example from VRML 97 specification
        /// </summary>
        [Test]
        public void SimpleExampleTest() {
            var scene = LoadScene("D2.wrl");
            var children = scene.Root.Children;
            Assert.That(children.Length, Is.EqualTo(1), "Check root children count");
            Assert.That(children[0] is TransformNode, Is.True, "Check first child");
            children = ((TransformNode)(children[0])).Children;
            Assert.That(children.Length, Is.EqualTo(4), "Check children count");
        }

        /// <summary>
        /// D3 example from VRML 97 specification
        /// </summary>
        [Test]
        public void InstancingExampleTest() {
            var scene = LoadScene("D3.wrl");
        }

        /// <summary>
        /// D4 example from VRML 97 specification
        /// </summary>
        [Test]
        public void PrototypeExampleTest() {
            var scene = LoadScene("D4.wrl");
        }

        /// <summary>
        /// D4 example from VRML 97 specification
        /// </summary>
        [Test]
        public void RoseExampleTest() {
            var scene = LoadScene("rose.wrl");
        }

        private VrmlScene LoadScene(string name) {
            using var stream = GetType().Assembly.GetManifestResourceStream(this.GetType(), name)!;
            var tokenizer = new Vrml97Tokenizer(stream);
            var parser = new VrmlParser(tokenizer);
            var scene = new VrmlScene();
            parser.Parse(scene);
            return scene;
        }
    }
}
