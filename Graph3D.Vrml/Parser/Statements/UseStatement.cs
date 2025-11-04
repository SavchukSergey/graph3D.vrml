namespace Graph3D.Vrml.Parser.Statements {
    public class UseStatement {

        public string NodeName { get; set; }

        public static UseStatement Parse(ParserContext context) {
            context.RequireNextToken("USE");

            var nodeName = context.ParseNodeNameId();

            return new UseStatement {
                NodeName = nodeName
            };
        }
    }
}
