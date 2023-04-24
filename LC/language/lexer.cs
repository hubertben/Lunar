

namespace _Lexer {

    public class Lexer {

        public enum Types {
            NUMBER,
            STRING,
            WHITESPACE,
            PLUS,
            MINUS,
            STAR,
            SLASH,
            COMMENT,
            UNKNOWN,
            LEFT_PAREN,
            RIGHT_PAREN,
            EOF,
            NUMBER_EXPR,
            BINARY_EXPR,
        }


        public class Token : SyntaxNode{
            public override Types type { get; }
            public string value { get; }
            public string text { get; }
            public int charPos { get; }
            
            public Token(Types type, string value = "", string text = "", int charPos = 0) {
                this.type = type;
                this.value = value;
                this.text = text;
                this.charPos = charPos;
            }

            public string __repr__(){
                return string.Format("Token({0}, {1}, {2}, {3})", this.type, this.value, this.text, this.charPos);
            }

            public override IEnumerable<SyntaxNode> GetChildren()
            {
                return Enumerable.Empty<SyntaxNode>();
            }

            public static bool operator ==(Token a, Token b) {
                return a.type == b.type && a.value == b.value && a.text == b.text;
            }

            public static bool operator !=(Token a, Token b) {
                return !(a == b);
            }

        }

        public abstract class SyntaxNode {
            public abstract Types type { get; }
            public abstract IEnumerable<SyntaxNode> GetChildren();
        }

        public abstract class ExpressionSyntaxNode : SyntaxNode {
            
        }
        
        public sealed class NumberExpressionSyntaxNode : ExpressionSyntaxNode {
            public override Types type => Types.NUMBER_EXPR;
            public Token token { get; }

            public NumberExpressionSyntaxNode(Token token) {
                this.token = token;
            }

            public override IEnumerable<SyntaxNode> GetChildren()
            {
                yield return this.token;
            }
        }

        public sealed class BinaryExpressionSyntaxNode : ExpressionSyntaxNode {
            public override Types type => Types.BINARY_EXPR;
            public ExpressionSyntaxNode left { get; }
            public Token operatorToken { get; }
            public ExpressionSyntaxNode right { get; }

            public BinaryExpressionSyntaxNode(ExpressionSyntaxNode left, Token operatorToken, ExpressionSyntaxNode right) {
                this.left = left;
                this.operatorToken = operatorToken;
                this.right = right;
            }

            public override IEnumerable<SyntaxNode> GetChildren()
            {
                yield return this.left;
                yield return this.operatorToken;
                yield return this.right;
            }
        }

        

        private string source;
        private int position;

        public Lexer(string source) {
            this.source = source;
        }

        public char Current {
            get {
                if (this.position >= this.source.Length) {
                    return '\0';
                }
                return this.source[this.position];
            }
        }

        public void Next(){
            this.position ++;
        } 

        
            
        public Token getNextToken() {

            if (this.position >= this.source.Length || this.Current == '\0') {
                return new Token(Types.EOF, "EOF", "EOF", this.position);
            }

            int tokenStart = this.position;

            if (char.IsDigit(this.Current)){
                while (char.IsDigit(this.Current)) {
                    this.Next();
                }
                string value = this.source.Substring(tokenStart, this.position - tokenStart);
                return new Token(Types.NUMBER, value, "NUMBER", tokenStart);
            }

            if (char.IsLetter(this.Current)) {
                while (char.IsLetter(this.Current)) {
                    this.Next();
                }
                string value = this.source.Substring(tokenStart, this.position - tokenStart);
                return new Token(Types.STRING, value, "STRING", tokenStart);
            }

            if (char.IsWhiteSpace(this.Current)) {
                while (char.IsWhiteSpace(this.Current)) {
                    this.Next();
                }
                string value = this.source.Substring(tokenStart, this.position - tokenStart);
                return new Token(Types.WHITESPACE, value, "WHITESPACE", tokenStart);
            }

            if (this.Current == '+') {
                this.Next();
                return new Token(Types.PLUS, "+", "PLUS", tokenStart);
            }

            if (this.Current == '-') {
                this.Next();
                return new Token(Types.MINUS, "-", "MINUS", tokenStart);
            }

            if (this.Current == '*') {
                this.Next();
                return new Token(Types.STAR, "*", "STAR", tokenStart);
            }

            if (this.Current == '/') {
                this.Next();
                return new Token(Types.SLASH, "/", "SLASH", tokenStart);
            }

            if (this.Current == '(') {
                this.Next();
                return new Token(Types.LEFT_PAREN, "(", "LEFT_PAREN", tokenStart);
            }

            if (this.Current == ')') {
                this.Next();
                return new Token(Types.RIGHT_PAREN, ")", "RIGHT_PAREN", tokenStart);
            }
            
            if (this.Current == '#') {
                while (this.Current != ' ' && this.Current != '\0') {
                    this.Next();
                }
                string value = this.source.Substring(tokenStart, this.position - tokenStart);
                return new Token(Types.COMMENT, value, "COMMENT", tokenStart);
            }

            // this.Next();
            return new Token(Types.UNKNOWN, this.Current.ToString(), "UNKNOWN", tokenStart);
            
        }

    }

}