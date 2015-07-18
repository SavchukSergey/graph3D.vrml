using System.IO;
using Graph3D.Vrml.Parser;
using Graph3D.Vrml.Parser.Statements.Extern;
using Graph3D.Vrml.Tokenizer;
using NUnit.Framework;

namespace Graph3D.Vrml.Test.Parser.Statements.Extern {
    [TestFixture]
    public class ExternExposedFieldStatementTest {

        [Test]
        public void ParseTest() {
            var context = new ParserContext(new Vrml97Tokenizer(new StringReader(@"
exposedField SFInt32 test
")));
            var statement = ExternExposedFieldStatement.Parse(context);
            Assert.AreEqual("SFInt32", statement.FieldType);
            Assert.AreEqual("test", statement.FieldId);
        }
    }
}
