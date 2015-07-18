using System.IO;
using Graph3D.Vrml.Parser;
using Graph3D.Vrml.Parser.Statements;
using Graph3D.Vrml.Tokenizer;
using NUnit.Framework;

namespace Graph3D.Vrml.Test.Parser.Statements {
    [TestFixture]
    public class RouteStatementTest {

        [Test]
        public void ParseTest() {
            var context = new ParserContext(new Vrml97Tokenizer(new StringReader(@"
ROUTE nodeOut.eventOut TO nodeIn.eventIn
")));
            var statement = RouteStatement.Parse(context);
            Assert.AreEqual("nodeOut", statement.NodeOut);
            Assert.AreEqual("eventOut", statement.EventOut);
            Assert.AreEqual("nodeIn", statement.NodeIn);
            Assert.AreEqual("eventIn", statement.EventIn);
        }
    }
}
