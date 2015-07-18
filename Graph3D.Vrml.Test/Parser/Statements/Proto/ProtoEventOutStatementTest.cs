using System.IO;
using Graph3D.Vrml.Parser;
using Graph3D.Vrml.Parser.Statements.Proto;
using Graph3D.Vrml.Tokenizer;
using NUnit.Framework;

namespace Graph3D.Vrml.Test.Parser.Statements.Proto {
    [TestFixture]
    public class ProtoEventOutStatementTest {

        [Test]
        public void ParseTest() {
            var context = new ParserContext(new Vrml97Tokenizer(new StringReader(@"
eventOut SFInt32 click
")));
            var statement = ProtoEventOutStatement.Parse(context);
            Assert.AreEqual("SFInt32", statement.FieldType);
            Assert.AreEqual("click", statement.EventId);
        }
    }
}
