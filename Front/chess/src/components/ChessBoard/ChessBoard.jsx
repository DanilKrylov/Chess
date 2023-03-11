import React, {useState, useEffect} from 'react';
import Cage from '../UI/Cages/Cage/Cage';
import classes from './ChessBoard.module.css'
import Piece from '../Piece/Piece';

const ChessBoard = ({pieces, fromColor, cageWidth, canMove, onMove}) => {
  const [targetFigure, setTargetFigure] = useState(undefined)
  let position = {};

  useEffect(() => {
    position.posY = document.getElementsByClassName(classes.chessBoard)[0].getBoundingClientRect().top
    position.posX = document.getElementsByClassName(classes.chessBoard)[0].getBoundingClientRect().left
  })
  
  function mouseMove(event){
    if(targetFigure){
      targetFigure.setViewPos({
        posX:(event.pageX - position.posX) / cageWidth + 0.5,
        posY: 8.5 - (event.pageY - position.posY)  / cageWidth
      })
    }
  }

  function renderPiece(pieceInfo) {
    return <Piece
      key={pieceInfo.pieceIdentifier}
      pieceInfo={pieceInfo} 
      setTargetFigure={setTargetFigure} 
      canMove={canMove} 
      onMove={onMove}
    />;
  }

  const squares = [];
  for (let i = 0; i < 64; i++) {
    squares.push(<Cage key={i} number={i}/>);
  }

  return (
    <div className={classes.chessBoard}
      onMouseMove={mouseMove}
    >
      {squares}
      {pieces.map(c => renderPiece(c))}
    </div>
  );
};

export default ChessBoard;