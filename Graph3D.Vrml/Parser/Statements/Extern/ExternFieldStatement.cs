namespace Graph3D.Vrml.Parser.Statements.Extern {
    public class ExternFieldStatement {

        public string FieldType { get; set; }
        
        public string FieldId { get; set; }

        public static ExternFieldStatement Parse(ParserContext context) {
            var keyword = context.ReadNextToken();
            if (keyword.Text != "field") {
                throw new InvalidVRMLSyntaxException("field expected");
            }

            var fieldType = context.ParseFieldType();
            var fieldId = context.ParseFieldId();

            return new ExternFieldStatement {
                FieldType = fieldType,
                FieldId = fieldId,
            };
        }
    }
}
