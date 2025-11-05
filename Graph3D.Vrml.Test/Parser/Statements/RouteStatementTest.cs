using Graph3D.Vrml.Parser;
using Graph3D.Vrml.Parser.Statements;
using Graph3D.Vrml.Tokenizer;
using NUnit.Framework;

namespace Graph3D.Vrml.Test.Parser.Statements {
    [TestFixture]
    public class RouteStatementTest {

        [Test]
        public void ParseTest() {
            var context = new ParserContext(new Vrml97Tokenizer(@"
ROUTE nodeOut.eventOut TO nodeIn.eventIn
"));
            var statement = RouteStatement.Parse(context);
            AssertExt.AreEqual(new RouteStatement {
                NodeOut = "nodeOut",
                EventOut = "eventOut",
                NodeIn = "nodeIn",
                EventIn = "eventIn",

            }, statement);
        }
    }
}
