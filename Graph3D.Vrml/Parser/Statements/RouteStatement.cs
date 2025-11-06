namespace Graph3D.Vrml.Parser.Statements {
    public class RouteStatement {

        public required string NodeOut { get; init; }

        public required string EventOut { get; init; }

        public required string NodeIn { get; init; }

        public required string EventIn { get; init; }

        public static RouteStatement Parse(ParserContext context) {
            context.ConsumeKeyword("ROUTE");

            var nodeOut = context.ParseNodeNameId();
            context.RequireNextToken('.');
            var eventOut = context.ParseEventOutId();
            context.RequireNextToken("TO");
            var nodeIn = context.ParseNodeNameId();
            context.RequireNextToken('.');
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
