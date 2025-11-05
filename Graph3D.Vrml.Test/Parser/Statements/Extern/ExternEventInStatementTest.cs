using System.IO;
using Graph3D.Vrml.Fields;
using Graph3D.Vrml.Parser;
using Graph3D.Vrml.Parser.Statements.Extern;
using Graph3D.Vrml.Tokenizer;
using NUnit.Framework;

namespace Graph3D.Vrml.Test.Parser.Statements.Extern {
    [TestFixture]
    public class ExternEventInStatementTest {

        [Test]
        public void ParseTest() {
            var context = new ParserContext(new Vrml97Tokenizer(@"
eventIn SFInt32 click
"));
            var statement = ExternEventInStatement.Parse(context);

            AssertExt.AreEqual(new ExternEventInStatement {
                FieldType = FieldType.SFInt32,
                EventId = "click",
            }, statement);
        }
    }
}
