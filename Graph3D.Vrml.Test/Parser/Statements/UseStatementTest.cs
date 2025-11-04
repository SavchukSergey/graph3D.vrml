using System.IO;
using Graph3D.Vrml.Parser;
using Graph3D.Vrml.Parser.Statements;
using Graph3D.Vrml.Tokenizer;
using NUnit.Framework;

namespace Graph3D.Vrml.Test.Parser.Statements {
    [TestFixture]
    public class UseStatementTest {

        [Test]
        public void ParseTest() {
            var context = new ParserContext(new Vrml97Tokenizer(new StringReader(@"
USE qwe123
")));
            var statement = UseStatement.Parse(context);
            Assert.That(statement.NodeName, Is.EqualTo("qwe123"));
        }
    }
}
