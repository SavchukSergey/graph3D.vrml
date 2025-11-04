using System.IO;
using Graph3D.Vrml.Fields;
using Graph3D.Vrml.Parser;
using Graph3D.Vrml.Parser.Statements.Proto;
using Graph3D.Vrml.Tokenizer;
using NUnit.Framework;

namespace Graph3D.Vrml.Test.Parser.Statements.Proto {
    [TestFixture]
    public class ProtoFieldStatementTest {

        [Test]
        public void ParseTest() {
            var context = new ParserContext(new Vrml97Tokenizer(new StringReader(@"
field SFInt32 test 2
")));
            var statement = ProtoFieldStatement.Parse(context, c => { });
            Assert.That(statement.FieldType, Is.EqualTo("SFInt32"));
            Assert.That(statement.FieldId, Is.EqualTo("test"));
            Assert.That(((SFInt32)statement.Value).Value, Is.EqualTo(2));
        }
    }
}
