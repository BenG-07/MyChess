namespace MyChess.Model
{
    public class Knight : ChessPiece
    {
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}