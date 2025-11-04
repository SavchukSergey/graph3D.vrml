using System.IO;
using Graph3D.Vrml.Parser;
using Graph3D.Vrml.Parser.Statements.Extern;
using Graph3D.Vrml.Tokenizer;
using NUnit.Framework;

namespace Graph3D.Vrml.Test.Parser.Statements.Extern {
    [TestFixture]
    public class ExternFieldStatementTest {

        [Test]
        public void ParseTest() {
            var context = new ParserContext(new Vrml97Tokenizer(new StringReader(@"
field SFInt32 test
")));
            var statement = ExternFieldStatement.Parse(context);
            Assert.That(statement.FieldType, Is.EqualTo("SFInt32"));
            Assert.That(statement.FieldId, Is.EqualTo("test"));
        }
    }
}
