namespace Graph3D.Vrml.Parser.Statements {
    public class RouteStatement {

        public string NodeOut { get; set; }

        public string EventOut { get; set; }

        public string NodeIn { get; set; }

        public string EventIn { get; set; }

        public static RouteStatement Parse(ParserContext context) {
            context.RequireNextToken("ROUTE");

            var nodeOut = context.ParseNodeNameId();
            context.RequireNextToken(".");
            var eventOut = context.ParseEventOutId();
            context.RequireNextToken("TO");
            var nodeIn = context.ParseNodeNameId();
            context.RequireNextToken(".");
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
