using System;
using Graph3D.Vrml.Fields;

namespace Graph3D.Vrml.Parser.Statements.Proto {
    public class ProtoFieldStatement {

        public string FieldType { get; set; }
        
        public string FieldId { get; set; }

        public Field Value { get; set; }

        //todo: remove second argument
        public static ProtoFieldStatement Parse(ParserContext context, Action<ParserContext> nodeStatementParser) {
            var keyword = context.ReadNextToken();
            if (keyword.Text != "field") {
                throw new InvalidVRMLSyntaxException("field expected");
            }

            var fieldType = context.ParseFieldType();
            var fieldId = context.ParseFieldId();

            var field = context.CreateField(fieldType);
            var fieldParser = new FieldParser(context, nodeStatementParser);
            field.AcceptVisitor(fieldParser);

            return new ProtoFieldStatement {
                FieldType = fieldType,
                FieldId = fieldId,
                Value = field
            };
        }
    }
}
