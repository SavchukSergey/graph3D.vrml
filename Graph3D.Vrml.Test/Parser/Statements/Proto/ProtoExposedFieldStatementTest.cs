using System.IO;
using Graph3D.Vrml.Fields;
using Graph3D.Vrml.Parser;
using Graph3D.Vrml.Parser.Statements.Proto;
using Graph3D.Vrml.Tokenizer;
using NUnit.Framework;

namespace Graph3D.Vrml.Test.Parser.Statements.Proto {
    [TestFixture]
    public class ProtoExposedFieldStatementTest {

        [Test]
        public void ParseTest() {
            var context = new ParserContext(new Vrml97Tokenizer(new StringReader(@"
exposedField SFInt32 test 2
")));
            var statement = ProtoExposedFieldStatement.Parse(context, c => { });
            Assert.AreEqual("SFInt32", statement.FieldType);
            Assert.AreEqual("test", statement.FieldId);
            Assert.AreEqual(2, ((SFInt32)statement.Value).value);
        }
    }
}
