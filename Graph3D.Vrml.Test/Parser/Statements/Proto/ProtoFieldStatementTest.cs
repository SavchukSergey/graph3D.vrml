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
            var context = new ParserContext(new Vrml97Tokenizer(@"
field SFInt32 test 2
"));
            var statement = ProtoFieldStatement.Parse(context, c => { });
            AssertExt.AreEqual(new ProtoFieldStatement {
                FieldId = "test",
                FieldType = FieldType.SFInt32,
                Value = new SFInt32(2)
            }, statement);
        }
    }
}
