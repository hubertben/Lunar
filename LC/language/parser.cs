
using _Lexer;
using _Functions;

namespace _Parser {

    public class Parser {

        public Lexer.Token[] tokens;
        public int position;

        public Parser(string text){
            
            var _tokens = new List<Lexer.Token>();

            var lexer = new Lexer(text);

            while (true) {
                var token = lexer.getNextToken();
                
                if (token.type != Lexer.Types.WHITESPACE
                 && token.type != Lexer.Types.UNKNOWN 
                 && token.type != Lexer.Types.EOF) 
                {
                    _tokens.Add(token);
                }
                
                if (token.type == Lexer.Types.EOF) {
                    break;
                }
            }

            this.tokens = _tokens.ToArray();

            for (int i = 0; i < this.tokens.Length; i++){
                Console.WriteLine(this.tokens[i].__repr__());
            }
        }

        public static void printAST(Lexer.SyntaxNode node, string indent = "", bool last = true){ // 59:43

            if (indent.Length > 0){
                Console.Write(indent);
                if (last){
                    Console.Write("└── ");
                } else {
                    Console.Write("├── ");
                }
            }
            Console.Write(node.type);

            if (node is Lexer.Token t && t.value != null){
                Console.Write(" ");
                Console.Write(t.value);
            }

            Console.WriteLine();
            indent += last ? "    " : "│   ";

            var lastChild = node.GetChildren().LastOrDefault();
            foreach (var child in node.GetChildren()){
                printAST(child, indent, child == lastChild);
            }
        }

        public Lexer.Token look(int offset){
            int index = this.position + offset;
            if (index >= this.tokens.Length){
                return new Lexer.Token(Lexer.Types.EOF, "EOF", "EOF", this.position);
            }
            return this.tokens[index];
        }

        public Lexer.Token Current => this.look(0);

        public Lexer.Token Next(){
            this.position ++;
            return this.Current;
        }
        public bool isBinOp(Lexer.Token t){
            return t.type == Lexer.Types.PLUS || t.type == Lexer.Types.MINUS || t.type == Lexer.Types.STAR || t.type == Lexer.Types.SLASH;
        }

        private Lexer.Token match(Lexer.Types type){
            if (this.Current.type == type){
                return this.Next();
            }
            
            return new Lexer.Token(type, "null", "null", this.position);
        }

        private Lexer.ExpressionSyntaxNode parsePrimary(){
            var token = this.match(Lexer.Types.NUMBER);
            return new Lexer.NumberExpressionSyntaxNode(token);
        }



        public Lexer.ExpressionSyntaxNode parseExpression(){
            var left = this.parsePrimary();

            while (this.isBinOp(this.Current)){
                var op = this.Next();
                var right = this.parsePrimary();
                left = new Lexer.BinaryExpressionSyntaxNode(left, op, right);
            }

            return left;
        }

    }

}