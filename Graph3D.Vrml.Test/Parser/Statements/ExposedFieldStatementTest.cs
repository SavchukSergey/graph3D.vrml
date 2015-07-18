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
            Assert.AreEqual("SFInt32", statement.FieldType);
            Assert.AreEqual("test", statement.FieldId);
            Assert.IsAssignableFrom(typeof(SFInt32), statement.Value);
            Assert.AreEqual(15, ((SFInt32)statement.Value).value);
        }
    }
}
