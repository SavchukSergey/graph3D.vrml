using System.IO;
using Graph3D.Vrml.Fields;
using Graph3D.Vrml.Parser;
using Graph3D.Vrml.Parser.Statements;
using Graph3D.Vrml.Tokenizer;
using NUnit.Framework;

namespace Graph3D.Vrml.Test.Parser.Statements {
    [TestFixture]
    public class ExposedFieldStatementTest {

        [Test]
        public void ParseTest() {
            var context = new ParserContext(new Vrml97Tokenizer(new StringReader(@"
exposedField SFInt32 test 15
")));
            var statement = ExposedFieldStatement.Parse(context, c => { });
            Assert.That(statement.FieldType, Is.EqualTo("SFInt32"));
            Assert.That(statement.FieldId, Is.EqualTo("test"));
            Assert.That(statement.Value, Is.InstanceOf(typeof(SFInt32)));
            Assert.That(((SFInt32)statement.Value).Value, Is.EqualTo(15));
        }
    }
}
