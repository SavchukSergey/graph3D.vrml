namespace Graph3D.Vrml.Parser.Statements {
    public class RouteStatement {

        public string NodeOut { get; set; }

        public string EventOut { get; set; }

        public string NodeIn { get; set; }

        public string EventIn { get; set; }

        public static RouteStatement Parse(ParserContext context) {
            var keyword = context.ReadNextToken();
            if (keyword.Text != "ROUTE") {
                throw new InvalidVRMLSyntaxException("ROUTE expected");
            }

            var nodeOut = context.ParseNodeNameId();
            if (context.ReadNextToken().Text != ".") {
                throw new InvalidVRMLSyntaxException();
            }
            var eventOut = context.ParseEventOutId();
            if (context.ReadNextToken().Text != "TO") {
                throw new InvalidVRMLSyntaxException();
            }
            var nodeIn = context.ParseNodeNameId();
            if (context.ReadNextToken().Text != ".") {
                throw new InvalidVRMLSyntaxException();
            }
            var eventIn = context.ParseEventInId();

            return new RouteStatement {
                NodeOut = nodeOut,
                EventOut = eventOut,
                NodeIn = nodeIn,
                EventIn = eventIn
            };
        }
    }
}
